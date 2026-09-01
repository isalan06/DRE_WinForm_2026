using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DRE
{
    public partial class MainProcess
    {
        // field
        #region field

        CallbackDelegate m_delegate;


        public bool bGetCaptureOneTimeData = false;
        public bool bGetCaptureOneTimeData2 = false;

        public bool IsUseSetRPM = false;
        public double SetRPM = 100.0;

        public bool bCaptureOneTimeFinished = false;
        public bool bCaptureOneTimeFinished2 = false;
        public bool bCaptureOneTimeFinished3 = false;
        public bool bCaptureOneTimeFinished4 = false;

        #endregion

        // constructor
        private void CaptureOneTime_Constructor()
        {
        }

        // dispose event
        #region dispose event

        private void DisposeFunction_CaptureOneTime()
        {
            short err;
            uint AccessCnt;

            //StopAutoCalRPM();

            if (Module_Num != USBDASK.INVALID_CARD_ID)
                err = USBDASK.UD_AI_AsyncClear(Module_Num, out AccessCnt);


        }

        #endregion

        // function
        #region function

        public bool CaptureOneTime_Start()
        {
            bool result = false;

            LoadedRPM = -1.0;

            if (!IsExecutingProcedure) // 確認是否執行流程中，確認在未執行流程狀態下可以進行一次擷取流程啟動
            {
                if (bRegisterFlag) // 確認是否有讀取到U2405設備，請參考 function: InitialU2405()
                {
                    bCaptureOneTimeFinished = false; bCaptureOneTimeFinished2 = false; bCaptureOneTimeFinished3 = false; bCaptureOneTimeFinished4 = false;
                    //  設定流程執行狀態為啟動狀態
                    IsExecutingProcedure = true;
                    ExecutingProgramName = "CaptureOneTime";

                    // 重新設定 資料存取陣列
                    CheckNumberForU2405((uint)MyParameter.CaptureSetting.DataNumber);
                    // 設定AI訊號進入類型
                    SetRangeForU2405();

                    // 設定擷取頻率及訊號類型
                    UseFrameRate = MyParameter.CaptureSetting.SamplingRate;
                    RangeIndex = MyParameter.ScopeSetting.RangeIndex;

                    // 初始化 Keyphasor 暫存區
                    keyphasorBuffer.Clear();
                    keyphasorBuffer_End.Clear();

                    // 設定資料擷取 Call Back function - Callback_CaptureOneTime 為收到U2405一次資料後要處理的函式
                    m_delegate = new CallbackDelegate(Callback_CaptureOneTime);

                    // 開啟執行緒執行一次資料擷取流程(DoCaptureOneTimeProcedure)
                    new Thread(new ThreadStart(DoCaptureOneTimeProcedure)).Start();
                }

                else if (bVK701RegisterFlag)
                {
                    bCaptureOneTimeFinished = false; bCaptureOneTimeFinished2 = false; bCaptureOneTimeFinished3 = false; bCaptureOneTimeFinished4 = false;
                    //  設定流程執行狀態為啟動狀態
                    IsExecutingProcedure = true;
                    ExecutingProgramName = "CaptureOneTime";

                    // 重新設定 資料存取陣列
                    CheckNumberForU2405((uint)MyParameter.CaptureSetting.DataNumber);
                    //// 設定AI訊號進入類型
                    //SetChannelConfigWithCaptureNumberForVK701();

                    // 設定擷取頻率及訊號類型
                    UseFrameRate = MyParameter.CaptureSetting.SamplingRate;
                    RangeIndex = MyParameter.ScopeSetting.RangeIndex;

                    // 初始化 Keyphasor 暫存區
                    keyphasorBuffer.Clear();
                    keyphasorBuffer_End.Clear();

                    // 開啟執行緒執行一次資料擷取流程(DoCaptureOneTimeProcedure)
                    new Thread(new ThreadStart(DoCaptureOneTimeProcedure_VK701)).Start();
                }
            }

            return result;
        }

        public bool CaptureOneTime_Sim_Start(bool isUseSetRPM = false, double setRPM = 100.0)
        {
            bool result = false;

            LoadedRPM = -1.0;

            if (!IsExecutingProcedure)
            {
                bCaptureOneTimeFinished = false; bCaptureOneTimeFinished2 = false; bCaptureOneTimeFinished3 = false; bCaptureOneTimeFinished4 = false;
                IsExecutingProcedure = true;
                ExecutingProgramName = "CaptureOneTime_Sim";

                CheckNumberForU2405((uint)MyParameter.CaptureSetting.DataNumber);

                UseFrameRate = MyParameter.CaptureSetting.SamplingRate;
                RangeIndex = MyParameter.ScopeSetting.RangeIndex;

                keyphasorBuffer.Clear();
                keyphasorBuffer_End.Clear();

                IsUseSetRPM = isUseSetRPM;
                SetRPM = setRPM;

                new Thread(new ThreadStart(DoCaptureOneTimeSimProcedure)).Start();
            }

            return result;
        }

        public bool CaptureOneTime_Stop()
        {
            bool result = false;

            

            if (IsExecutingProcedure)
            {
                if (ExecutingProgramName == "CaptureOneTime")
                {
                    IsExecutingProcedure = false;
                    ExecutingProgramName = "";

                    short err;
                    uint dwAccessCnt;

                    err = USBDASK.UD_AI_AsyncClear(Module_Num, out dwAccessCnt);
                    if (err != USBDASK.NoError)
                    {
                        ErrorString = "UD_AI_AsyncClear error = :" + err.ToString();
                    }

                    result = true;
                }

                if (ExecutingProgramName == "CaptureOneTime_Sim")
                {
                    IsExecutingProcedure = false;
                    ExecutingProgramName = "";

                    result = true;
                }
            }

            bCaptureOneTimeFinished = true; bCaptureOneTimeFinished2 = true; bCaptureOneTimeFinished3 = true; bCaptureOneTimeFinished4 = true;

            return result;
        }

        private void DoCaptureOneTimeProcedure()
        {
            short err;
            ErrorString = "";

            if (bRegisterFlag)
            {
                // Configure AI Channel
                if (!SetChannelConfigForU2405())
                    return;

                // Configure trigger source
                err = USBDASK.UD_AI_2405_Trig_Config(Module_Num, USBDASK.P2405_AI_CONVSRC_INT, USBDASK.P2405_AI_TRGMOD_POST, USBDASK.P2405_AI_TRGSRC_SOFT, 0, 0, 0, 0);
                if (err != USBDASK.NoError)
                {
                    ErrorString = "UD_AI_2405_Trig_Config error = :" + err.ToString();
                    return;
                }

                // Disable double-buffer
                err = USBDASK.UD_AI_AsyncDblBufferMode(Module_Num, false);
                if (err != USBDASK.NoError)
                {
                    ErrorString = "UD_AI_AsyncDblBufferMode error = :" + err.ToString();
                    return;
                }

                // set callback function for handling message received from U2405
                err = USBDASK.UD_AI_EventCallBack_x64(Module_Num, 1, USBDASK.AIEnd, m_delegate);
                if (err < 0)
                {
                    ErrorString = "UD_AI_EventCallBack error = :" + err.ToString();
                    return;
                }

                //err = USBDASK.UD_AI_ContReadChannel(Module_Num, 0, GainArray[0], AiBuf2, dwDataNum, dframerate, USBDASK.ASYNCH_OP);
                // start to capture message from U2405
                err = USBDASK.UD_AI_ContReadMultiChannels(Module_Num, 4, new ushort[] { 0, 1, 2, 3 }, GainArray, AiBuf, dwDataNum * 4, UseFrameRate, USBDASK.ASYNCH_OP);
                if (err != USBDASK.NoError)
                {
                    ErrorString = "UD_AI_ContReadMultiChannels error = :" + err.ToString();
                    return;
                }


            }
        }

        private void DoCaptureOneTimeProcedure_VK701()
        {
            int err;
            ErrorString = "";

            int SAMPLENUMLEN = MyParameter.CaptureSetting.DataNumber;
            //double[] SaveADCBuffer = new double[SAMPLENUMLEN * 4];


            if (bVK701RegisterFlag)
            {
                // Configure AI Channel
                if (!SetChannelConfigWithCaptureNumberForVK701())
                    return;

                // Set blocking read data
                err = USBVK701.VK70xUMC_Set_BlockingMethodtoReadADCResult(1, 2000);
                if (err < 0)
                {
                    ErrorString = "VK70xUMC_Set_BlockingMethodtoReadADCResult error = :" + err.ToString();
                    return;
                }

                // Start N-point sampling
                err = USBVK701.VK70xUMC_StartSampling_NPoints(deviceNoForVK701, SAMPLENUMLEN);
                if (err < 0)
                {
                    ErrorString = "VK70xUMC_StartSampling_NPoints error = :" + err.ToString();
                    return;
                }

                // Read sampling data from 4 channels.
                int recvLen = USBVK701.VK70xUMC_GetFourChannel(deviceNoForVK701, AiValue2, SAMPLENUMLEN);
                if (recvLen > 0)
                {
                    for (int i = 0; i < SAMPLENUMLEN; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            VoltageValue[j][i] = AiValue2[i * 4 + j];
                        }
                    }
                }
                else
                {
                    ErrorString = "VK70xUMC_GetFourChannel error = :" + recvLen.ToString();
                    return;
                }

                // 使用第四軸為 KeyPhasor 檢測軸 (parameter=3)
                CheckKeyPhasor(3);

                // 將所得數據進行FFT轉換
                FFT();

                // 設定已擷取資料旗標
                bGetCaptureOneTimeData = true;

                // 流程執行狀態回復
                IsExecutingProcedure = false;
                ExecutingProgramName = "";

                CaptureOneTime_Stop();

            }
        }

        private void Callback_CaptureOneTime()
        {
            short err;
            uint dwAccessCnt;

            // get data
            err = USBDASK.UD_AI_AsyncClear(Module_Num, out dwAccessCnt); // 資料收集完成後進行命令清除
            if (err != USBDASK.NoError) // 功能失敗狀態
            {
                ErrorString = "UD_AI_AsyncClear error = :" + err.ToString();
            }
            else 
            {
                // 資料轉換 - AiBuf為U2405讀取資料存放暫存區; AiValue是由AiValue轉換過來; VoltageValue將AiBuf轉換成伏特值(目前只使用0~10V / -10V~10V)
                for (int i = 0; i < dwDataNum; i++)
                {
                    int[] I32Temp = new int[4];
                    uint[] U32Temp = new uint[4];

                    for (int j = 0; j < 4; j++)
                    {
                        U32Temp[j] = (AiBuf[j + i * 4]);

                        if (RangeIndex == 0) // -10V~10V
                        {
                            if ((U32Temp[j] & 0x800000) != 0x00000000) // 確認為負數
                                U32Temp[j] = (U32Temp[j] | 0xFF000000);
                        }

                        I32Temp[j] = (int)U32Temp[j];

                        AiValue[i + dwDataNum * j] = I32Temp[j];
                        VoltageValue[j][i] = (double)I32Temp[j] / 838860.8;
                    }
                }

                //AiValue2_Mat = new MWNumericArray(AiValue2);
                //new MWNumericArray();

                //FFT_CaptureOneTime();

                // 使用第四軸為 KeyPhasor 檢測軸 (parameter=3)
                CheckKeyPhasor(3);

                // 將所得數據進行FFT轉換
                FFT();

                // 設定已擷取資料旗標
                bGetCaptureOneTimeData = true;

                // 流程執行狀態回復
                IsExecutingProcedure = false;
                ExecutingProgramName = "";
            }

        }

        private void DoCaptureOneTimeSimProcedure()
        {
            int index = 0;

            int number = MyParameter.CaptureSetting.DataNumber;
            int RPMPoint = GetPointFromRPM(SetRPM);
            int UpPoint = RPMPoint / 10;

            for (int i=0;i<number;i++)
            {
                double v1 = 0.0, v2 = 0.0, v3 = 0.0;
                CreateSimulatedData(ref v1, ref v2, ref v3, index);

                int trigger = (i + 1) % 100;
                double triggerValue = (trigger <= 10) ? 5.0 : 0.0;

                if (IsUseSetRPM)
                {
                    trigger = (i + 1) % RPMPoint;
                    triggerValue = (trigger <= UpPoint) ? 5.0 : 0.0;
                }

                double[] dBufferVoltage = new double[] { v1, v2, v3, triggerValue };

                for (int j = 0; j < dBufferVoltage.Length; j++)
                    VoltageValue[j][i] = dBufferVoltage[j];

                if (++index >= 360) index = 0;
            }

            CheckKeyPhasor(3);

            FFT();

            CaptureOneTime_Stop();
        }

        public double Deg2Rad(double degree)
        {
            double result = (degree * (Math.PI)) / 180.0;

            return result;
        }
        public double Deg2Rad(int degree)
        {
            double result = ((double)degree * (Math.PI)) / 180.0;

            return result;
        }

        #endregion
    }
}
