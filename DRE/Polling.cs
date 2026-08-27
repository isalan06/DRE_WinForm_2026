using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace DRE
{
    public partial class MainProcess
    {
        public double[] dTestVoltage = new double[] { 0.0, 0.0, 0.0, 0.0 };
        public uint[] uiEdgeCounter = new uint[] { 0, 0 };
        public long[] lCaptureDataIntervalTime = new long[] { 0, 0 };

        private long[] captureIntervalTime_ms = new long[] { 0, 0 };
        private uint[] totalEdgeCounter = new uint[] { 0, 0 };
        public long lSetCaptureToAnalysisTime = 1000;
        public uint[] uiTotalEdgeCounter = new uint[] { 0, 0 };
        public long[] lTotalCaptureIntervalTime = new long[] { 0, 0 };

        // dispose event
        #region dispose event

        private void DisposeFunction_Polling()
        {

        }

        #endregion

        // function
        #region function

        public bool Polling_Start()
        {
            bool result = false;

            if (!IsExecutingProcedure)
            {
                if (U2405Used)
                {
                    if (SetChannelConfigForU2405())
                    {
                        SetRangeForU2405();

                        IsExecutingProcedure = true;
                        ExecutingProgramName = "Polling";

                        ErrorString = "";

                        CheckNumberForU2405(200);

                        UseFrameRate = MyParameter.CaptureSetting.SamplingRate;

                        new Thread(new ThreadStart(DoPollingProcedure)).Start();
                    }
                }

                if (VK701Used)
                {
                    if (SetChannelConfigForVK701())
                    {
                        IsExecutingProcedure = true;
                        ExecutingProgramName = "Polling";

                        ErrorString = "";

                        CheckNumberForU2405(200);

                        UseFrameRate = MyParameter.CaptureSetting.SamplingRate;

                        new Thread(new ThreadStart(DoPollingProcedure)).Start();
                    }
                }
            }

            return result;
        }
        public bool Polling_Sim_Start()
        {
            bool result = false;

            if (!IsExecutingProcedure)
            {

                IsExecutingProcedure = true;
                ExecutingProgramName = "Polling_Sim";

                ErrorString = "";

                CheckNumberForU2405(200);

                UseFrameRate = MyParameter.CaptureSetting.SamplingRate;

                new Thread(new ThreadStart(DoPollingSimProcedure)).Start();
            }

            return result;
        }

        public bool Polling_Stop()
        {
            bool result = false;

            if (IsExecutingProcedure)
            {
                if (ExecutingProgramName == "Polling")
                {
                    IsExecutingProcedure = false;
                    ExecutingProgramName = "";
                    result = true;
                }

                if (ExecutingProgramName == "Polling_Sim")
                {
                    IsExecutingProcedure = false;
                    ExecutingProgramName = "";
                    result = true;
                }

            }

            return result;
        }

        private void DoPollingProcedure()
        {
            Stopwatch[] sw = new Stopwatch[] { new Stopwatch(), new Stopwatch() };
            sw[0].Start();
            sw[1].Start();


            while (IsExecutingProcedure)
            {
                if (U2405Used)
                {
                    short err;
                    err = USBDASK.UD_AI_ReadMultiChannels(Module_Num, wSelectedChans, ChanArray, GainArray, AiBuf);
                    if (err != USBDASK.NoError)
                    {
                        ErrorString = "UD_AI_ReadMultiChannels error = :" + err.ToString();
                        IsExecutingProcedure = false;
                        ExecutingProgramName = "";
                    }
                    else
                    {
                        for (int Cur_Channel = 0; Cur_Channel < wSelectedChans; Cur_Channel++)
                        {
                            TransferVoltageValueFromU2405(ref dTestVoltage[Cur_Channel], ref AiValue[Cur_Channel], AiBuf[Cur_Channel], MyParameter.ScopeSetting.RangeIndex);

                            RightOneShiftVoltageValue(Cur_Channel, dTestVoltage[Cur_Channel]);
                        }

                        FFT();

                        Thread.Sleep(10);
                    }

                    // To Do : Just Test
                    for (ushort i = 0; i < uiEdgeCounter.Length; i++)
                    {

                        err = USBDASK.UD_CTR_ReadEdgeCounter(Module_Num, i, out uiEdgeCounter[i]);
                        if (err != USBDASK.NoError)
                        {
                            ErrorString = $"UD_CTR_ReadEdgeCounter {i} error = : {err.ToString()}";
                        }
                        else
                        {
                            lCaptureDataIntervalTime[i] = sw[i].ElapsedMilliseconds;
                            sw[i].Restart();

                            CaptureCounterByTime(i);
                        }
                    }
                }

                if (VK701Used)
                {
                    int err = 0;
                    int samplingFrequency = (int)MyParameter.CaptureSetting.SamplingRate;
                    int getPoints = 0;
                    int recvLen = 0;
                    int totalPointNum = 0;                      // sample counter
                    int NumofADCChannel = 4;                    // Number of ADC channels
                    double[] revResult = new double[800000];    // max samplingFrequency points x (4 adc channels + 4 IO channels)

                    // Set blocking read data
                    err = USBVK701.VK70xUMC_Set_BlockingMethodtoReadADCResult(1, 1024);
                    if (err < 0)
                    {
                        ErrorString = "VK701_VK70xUMC_Set_BlockingMethodtoReadADCResult!! Error Code: " + err.ToString();
                    }
                    else
                    {
                        // Start continuous sampling
                        err = USBVK701.VK70xUMC_StartSampling(deviceNoForVK701);
                        if (err < 0)
                        {
                            ErrorString = "VK701_VK70xUMC_StartSampling!! Error Code: " + err.ToString();
                        }
                        else
                        {
                            getPoints = (samplingFrequency > 10) ? samplingFrequency / 10 : 1;
                            while ((err >= 0) && IsExecutingProcedure)
                            {
                                // Read sampling data from 4 channels.
                                recvLen = USBVK701.VK70xUMC_GetFourChannel(deviceNoForVK701, revResult, getPoints);
                                if (recvLen > 0)
                                {
                                    // Count the number of points obtained each time
                                    totalPointNum = totalPointNum + recvLen;

                                    // Print the numerical values of some points
                                    for (int i = 0; i < recvLen * NumofADCChannel; i += NumofADCChannel)
                                    {
                                        if (i % (1024 * NumofADCChannel) == 0)// Print only 1% because the printing speed cannot keep up with the speed of DAQ transmission.
                                        {
                                            for (int j = 0; j < NumofADCChannel; j++)
                                            {
                                                System.Diagnostics.Debug.WriteLine(String.Format("CH{0:0} = {1:F8}V,\t", j + 1, revResult[i + j]));
                                                RightOneShiftVoltageValue(j, revResult[i + j]);
                                            }

                                            
                                            System.Diagnostics.Debug.WriteLine("");
                                        }
                                    }

                                    FFT();
                                    Thread.Sleep(10);
                                }

                                // To Do: Just Test
                                int tcCounter = 0;
                                int err2 = USBVK701.VK70xUMC_Get_Counter(deviceNoForVK701, ref tcCounter);
                                if (err2 < 0)
                                {
                                    ErrorString = "VK70xUMC_Get_Counter!! Error Code: " + err2.ToString();
                                }
                                else
                                {
                                    uiEdgeCounter[0] = (uint)tcCounter;

                                    System.Diagnostics.Debug.WriteLine($"Counter: {uiEdgeCounter[0]}");

                                    lCaptureDataIntervalTime[0] = sw[0].ElapsedMilliseconds;
                                    sw[0].Restart();

                                    CaptureCounterByTime(0);
                                }
                            }
                        }
                    }

                    
                }
            }

            sw[0].Stop();
            sw[1].Stop();

        }

        private void DoPollingSimProcedure()
        {
            int index = 0;

            Random r = new Random();
            Stopwatch[] sw = new Stopwatch[] { new Stopwatch(), new Stopwatch() };
            sw[0].Start();
            sw[1].Start();

            while (IsExecutingProcedure)
            {
                double v1 = 0.0, v2 = 0.0, v3 = 0.0, v4 = 0.0;
                //CreateSimulatedData(ref v1, ref v2, index);
                CreateSimulatedData(ref v1, ref v2, ref v3, ref v4, index);

                double[] dBufferVoltage = new double[] { v1, v2, v3, v4 };
                for (int i = 0; i < dBufferVoltage.Length; i++)
                {
                    dTestVoltage[i] = dBufferVoltage[i];
                    RightOneShiftVoltageValue(i, dBufferVoltage[i]);
                }

                for (int i = 0; i < uiEdgeCounter.Length; i++)
                {
                    lCaptureDataIntervalTime[i] = sw[i].ElapsedMilliseconds;
                    sw[i].Restart();

                    uiEdgeCounter[i] = (uint)r.Next(300, 2000);

                    CaptureCounterByTime(i);
                }

                if (++index >= 360) index = 0;

                FFT();

                Thread.Sleep(10);
            }

            sw[0].Stop();
            sw[1].Stop();
        }

        private void CaptureCounterByTime(int index)
        {
            captureIntervalTime_ms[index] += lCaptureDataIntervalTime[index];
            totalEdgeCounter[index] += uiEdgeCounter[index];

            if (captureIntervalTime_ms[index] >= lSetCaptureToAnalysisTime)
            {
                uiTotalEdgeCounter[index] = totalEdgeCounter[index];
                lTotalCaptureIntervalTime[index] = captureIntervalTime_ms[index];
                totalEdgeCounter[index] = 0;
                captureIntervalTime_ms[index] = 0;

            }
        }

        #endregion
    }
}
