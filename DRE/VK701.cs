using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRE
{
    public partial class MainProcess
    {
        #region attribute

        public bool IsVK701Connected = false;

        private int deviceNoForVK701 = 0;

        public bool bVK701RegisterFlag = false;
        public bool VK701Used = false;

        public bool IsRegisterForVK701 { get { return bVK701RegisterFlag; } }

        #endregion

        #region constructor

        private void ConstuctorForVK701()
        {

            //InitialVK701();
        }

        #endregion

        #region Dispose

        private void DisposeFunction_VK701()
        {
            int err = 0;
            err = USBVK701.Device_Close(deviceNoForVK701);
            if (err < 0)
            {
                ErrorString = "VK701_Device_Close!!Error Code:" + err.ToString();
            }

        }

        #endregion

        #region VK701 Function

        public void InitialVK701()
        {
            int err = 0;
            int loopTimes = 0;
            int curDeviceNum = 0;
            int curHandle = 0;                          // The handle of the current device
            int vkType = 0;                             // Device DAQ type
            int NumofADCChannel = 4;                    // Number of ADC channels
            string serialNumStr;                        // Serial number string
            double[] revResult = new double[800000];    // max samplingFrequency points x (4 adc channels + 4 IO channels)
            byte[] serialNum = new byte[128];           // Used to store serial number
            int[] paraInitialize = new int[20];         // Parameter array for initializing functions
            bool testcaptureFunctionFlag = false;

            int totalPointNum = 0;                      // sample counter
            int samplingFrequency = 100000;             // sample frequency

            int getPoints = 0;
            int recvLen = 0;

            try
            {
                try
                {
                    err = USBVK701.Device_Open();
                }
                catch (Exception ex)
                {
                    ErrorString = "VK701 Error: " + ex.ToString();
                }


                if (err < 0)
                {
                    ErrorString = "VK701_Device_Open!!Error Code:" + err.ToString();
                }
                else
                {
                    IsVK701Connected = true;
                    bool bFound = false;
                    err = -1;
                    while (err < 0)
                    {
                        loopTimes++;
                        if (loopTimes > 500)// Approximately 10 seconds
                        {
                            break;
                        }
                        err = USBVK701.Device_Get_ConnectedClientNumbers(ref curDeviceNum);
                        Thread.Sleep(1);
                    }

                    if (err < 0)
                    {
                        ErrorString = "VK701_Device_Get_ConnectedClientNumbers!! Error Code: " + err.ToString();
                    }
                    else
                    {
                        bFound = true;
                        //bRegisterFlag = true;
                        bVK701RegisterFlag = true;
                        VK701Used = true;
                    }

                    if (bFound)
                    {
                        // Get the Handle and Serial number of the current DAQ
                        for (int i = 0; i < 128; i++)
                        {
                            serialNum[i] = 0;
                        }
                        err = USBVK701.Device_Get_ConnectedClientHandle(deviceNoForVK701, ref curHandle, ref vkType, serialNum);
                        if (err < 0)
                        {
                            ErrorString = "VK701_Device_Get_ConnectedClientHandle!! Error Code: " + err.ToString();
                        }
                        else
                        {
                            for (int i = 14; i < 128; i++)// Zero invalid characters
                            {
                                serialNum[i] = 0;
                            }
                            serialNumStr = Encoding.ASCII.GetString(serialNum);

                            //ErrorString = $"DAQ Type: {vkType} (VK701/701H+ is 0, VK702 is 1); DAQ Handle: {String.Format("{0:00}", curHandle)}";

                            // Switching Sample Mode
                            err = USBVK701.VK70xUMC_Set_SampleMode(deviceNoForVK701, 0);
                            if (err < 0)
                            {
                                ErrorString = "VK701_VK70xUMC_Set_SampleMode!! Error Code: " + err.ToString();
                            }
                            else
                            {
                                //testcaptureFunctionFlag = true;
                                err = USBVK701.VK70xUMC_Set_AdditionalFeature(deviceNoForVK701, 31, 0, 0);
                                if (err < 0)
                                {
                                    ErrorString = "VK70xUMC_Set_AdditionalFeature!! Error Code: " + err.ToString();
                                }
                                else
                                {

                                }
                            }
                        }
                    }

                    if (testcaptureFunctionFlag)
                    {
                        // Initialize parameters
                        paraInitialize[0] = 0x22;
                        paraInitialize[1] = samplingFrequency;
                        for (int i = 2; i < 20; i++)
                            paraInitialize[i] = 0; 
                        err = USBVK701.VK70xUMC_InitializeAll(deviceNoForVK701, paraInitialize, 20);
                        if (err < 0)
                        {
                            ErrorString = "VK701_VK70xUMC_InitializeAll!! Error Code: " + err.ToString();
                        }
                        else
                        {
                            // Set blocking read data
                            err = USBVK701.VK70xUMC_Set_BlockingMethodtoReadADCResult(1, 1000);
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
                                    while (err >= 0)
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
                                                if (i % (100 * NumofADCChannel) == 0)// Print only 1% because the printing speed cannot keep up with the speed of DAQ transmission.
                                                {
                                                    for (int j = 0; j < NumofADCChannel; j++)
                                                        System.Diagnostics.Debug.WriteLine(String.Format("CH{0:0} = {1:F8}V,\t", j + 1, revResult[i + j]));
                                                    System.Diagnostics.Debug.WriteLine("");
                                                }
                                            }
                                            System.Diagnostics.Debug.WriteLine(String.Format("The total number of points is [{0:00}], and the number of points obtained this time is [{1:00}]", totalPointNum, recvLen));
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                ErrorString = "VK701_Device_Open!!Exception:" + ex.ToString();
            }
        }
        private bool SetChannelConfigForVK701()
        {
            int[] paraInitialize = new int[20];         // Parameter array for initializing functions

            int samplingFrequency = (int)MyParameter.CaptureSetting.SamplingRate;        // sample frequency

            bool result = false;
            int err = 0;

            // Initialize parameters
            paraInitialize[0] = 0x22;
            paraInitialize[1] = samplingFrequency;
            for (int i = 2; i < 20; i++)
                paraInitialize[i] = 0;
            err = USBVK701.VK70xUMC_InitializeAll(deviceNoForVK701, paraInitialize, 20);
            if (err < 0)
            {
                ErrorString = "VK701_VK70xUMC_InitializeAll!! Error Code: " + err.ToString();
            }
            else
            {
                result = true;
            }

            return result;
        }
        private bool SetChannelConfigWithCaptureNumberForVK701()
        {
            int[] paraInitialize = new int[20];         // Parameter array for initializing functions

            int samplingFrequency = (int)MyParameter.CaptureSetting.SamplingRate;        // sample frequency

            bool result = false;
            int err = 0;

            // Initialize parameters
            paraInitialize[0] = 0x22;
            paraInitialize[1] = samplingFrequency;
            paraInitialize[2] = MyParameter.CaptureSetting.DataNumber;
            for (int i = 3; i < 20; i++)
                paraInitialize[i] = 0;
            err = USBVK701.VK70xUMC_InitializeAll(deviceNoForVK701, paraInitialize, 20);
            if (err < 0)
            {
                ErrorString = "VK701_VK70xUMC_InitializeAll!! Error Code: " + err.ToString();
            }
            else
            {
                result = true;
            }

            return result;
        }

        #endregion

    }
}
