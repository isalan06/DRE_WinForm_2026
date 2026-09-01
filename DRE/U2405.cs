using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRE
{
    public partial class MainProcess
    {
        #region field

        ushort wModuleNum;
        ushort wSelModuleID;
        ushort Module_Num;
        USBDAQ_DEVICE[] AvailModules = new USBDAQ_DEVICE[USBDASK.MAX_USB_DEVICE];
        ushort wSelectedChans = 4;
        uint[] AiBuf = new uint[4];
        ushort[] ChanArray = new ushort[] { 0, 1, 2, 3 };
        ushort[] GainArray = new ushort[4];
        bool bRegisterFlag = false;
        public bool bU2405RegisterFlag = false;
        public bool U2405Used = false;

        public string[] sSelBoardList = null;

        public int[] AiValue = new int[4];
        public double[] AiValue2 = new double[4];
        public string ErrorString = "";
        public bool IsExecutingProcedure = false;
        public string ExecutingProgramName = "Pooling";
        public bool IsU2405Connected = false;

        public bool IsRegisterForU2405 { get { return bRegisterFlag; } }

        public bool IsPoolingStatus { get { return (ExecutingProgramName == "Pooling"); } }
        public bool IsPoolingSimStatus { get { return (ExecutingProgramName == "Polling_Sim"); } }
        public bool IsCaptureOneTimeStatus { get { return (ExecutingProgramName == "CaptureOneTime"); } }
        public bool IsCaptureOneTimeSimStatus { get { return (ExecutingProgramName == "CaptureOneTime_Sim"); } }

        uint dwDataNum = 1024;
        public uint DataNumber { get { return dwDataNum; } }
        uint dwZeroPadding = 0;
        public double[][] VoltageValue = new double[][] { new double[1024], new double[1024], new double[1024], new double[1024] };

        private List<int> keyphasorBuffer = new List<int>();
        private List<int> keyphasorBuffer_End = new List<int>();
        public int[] KeyPhasorList
        {
            get
            {
                int[] result = new int[keyphasorBuffer.Count];

                result = keyphasorBuffer.ToArray();

                return result;
            }
            set
            {
                keyphasorBuffer.Clear();
                keyphasorBuffer.AddRange(value);
            }
        }
        public int[] KeyPhasorEndList
        {
            get
            {
                int[] result = new int[keyphasorBuffer_End.Count];

                result = keyphasorBuffer_End.ToArray();

                return result;
            }
            set
            {
                keyphasorBuffer_End.Clear();
                keyphasorBuffer_End.AddRange(value);
            }
        }

        public int[] KeyPhasorPoint
        {
            get
            {
                int[] result = null;

                if ((keyphasorBuffer.Count > 0))
                {
                    result = new int[keyphasorBuffer.Count];
                    result = keyphasorBuffer.ToArray();
                }

                return result;
            }
        }
        public int[] KeyPhasorEndPoint
        {
            get
            {
                int[] result = null;

                if ((keyphasorBuffer_End.Count > 0))
                {
                    result = new int[keyphasorBuffer_End.Count];
                    result = keyphasorBuffer_End.ToArray();
                }

                return result;
            }
        }
        public int[,] KeyPhasorFullPoint
        {
            get
            {
                int[,] result = null;

                if ((keyphasorBuffer.Count > 0) && (keyphasorBuffer_End.Count > 0) && (keyphasorBuffer.Count >= keyphasorBuffer_End.Count))
                {
                    result = new int[keyphasorBuffer_End.Count, 2];
                    for (int i = 0; i < keyphasorBuffer_End.Count; i++)
                    {
                        result[i, 0] = keyphasorBuffer[i];
                        result[i, 1] = keyphasorBuffer_End[i];
                    }

                }

                return result;
            }
        }

        public int CyclePointNumber
        {
            get
            {
                int result = 0;

                if ((keyphasorBuffer.Count > 1) && (keyphasorBuffer_End.Count > 1))
                {
                    result = keyphasorBuffer_End[1] - keyphasorBuffer[1];
                }

                return result;
            }
        }
        public double RPM
        {
            get
            {
                if (LoadedRPM >= 0.0)
                    return LoadedRPM;

                double result = 0.0;

                if (keyphasorBuffer.Count > 2)
                {
                    int points = keyphasorBuffer[2] - keyphasorBuffer[1];
                    double value = (double)points * MSPerPoint;
                    if (value != 0.0) result = 60.0 * 1000.0 / value;
                }
                else if (keyphasorBuffer.Count == 2)
                {
                    int points = keyphasorBuffer[1] - keyphasorBuffer[0];
                    double value = (double)points * MSPerPoint;
                    if (value != 0.0) result = 60.0 * 1000.0 / value;
                }

                return result;
            }
        }
        public double LoadedRPM { get; set; } = -1.0;
        public double SetSimRPM { get; set; }
        public bool IsSetSimRPM { get; set; }

        #endregion

        #region constructor

        private void ConstuctorForU2405()
        {
            Module_Num = USBDASK.INVALID_CARD_ID;

            //InitialU2405();
        }

        #endregion

        #region Dispose

        private void DisposeFunction_U2405()
        {
            short err;
            uint AccessCnt;

            //StopAutoCalRPM();

            IsExecutingProcedure = false;

            if (Module_Num != USBDASK.INVALID_CARD_ID)
                err = USBDASK.UD_AI_AsyncClear(Module_Num, out AccessCnt);

            if (Module_Num != USBDASK.INVALID_CARD_ID)
                USBDASK.UD_Release_Card(Module_Num);
        }

        #endregion

        #region Common Function

        /// <summary>
        /// 檢查U2405 Function所回應的回應碼
        /// </summary>
        /// <param name="err">U2405回應碼</param>
        /// <param name="functionName"></param>
        /// <returns>true:No Error; false: Error</returns>
        private bool CheckU2405Error(short err, string functionName)
        {
            bool result = false;

            if (err == USBDASK.NoError) result = true;
            else ErrorString = functionName + " error = :" + err.ToString();

            return result;
        }

        public void CreateSimulatedData(ref double v1, ref double v2, int index)
        {
            double degree = 0.2 * Math.PI * (double)index;
            double y = 10 * Math.Sin(degree);
            double y2 = 10 * Math.Cos(degree);

            v1 = y;
            v2 = y2;
        }

        public void CreateSimulatedData(ref double v1, ref double v2, ref double v3, ref double v4, int index)
        {
            double degree = 0.2 * Math.PI * (double)index;
            double y = 10 * Math.Sin(degree);
            double y2 = 10 * Math.Cos(degree);
            double y3 = 2 * Math.Tan(degree);
            double y4 = 10;

            if ((index >= 100) && (index < 150))
                y4 = 10;
            else
                y4 = 0;

            v1 = y;
            v2 = y2;
            v3 = y3;
            v4 = y4;
        }

        public void CreateSimulatedData(ref double v1, ref double v2, ref double v3, int index)
        {
            double degree = 0.2 * Math.PI * (double)index; //Math.PI * 1000.0 * (double)index / this.UseFrameRate;// 0.2 * Math.PI * (double)index;
            double y = 10 * Math.Sin(degree);
            double y2 = 10 * Math.Cos(degree);
            double y3 = Math.Sin(60.0 * 2.0 * Math.PI * (double)index / UseFrameRate) + 0.5 * Math.Sin(90.0 * 2.0 * Math.PI * (double)index / UseFrameRate);

            v1 = y;
            v2 = y2;
            v3 = y3;
        }

        public int GetPointFromRPM(double RPM)
        {
            int result = 100;

            double value = 60.0 * 1000.0 / RPM;
            result = (int)(value / MSPerPoint);

            return result;
        }

        #endregion

        #region U2405 Function

        public void InitialU2405()
        {
            short err = USBDASK.NoError;
            string strTemp = "";
            short iTemp;

            // scan the active USB DASK module
            try
            {
                err = USBDASK.UD_Device_Scan(out wModuleNum, AvailModules);
            }
            catch (Exception ex)
            {
                ErrorString = "U2405 Error: " + ex.ToString();
                return;
            }
            if (err != USBDASK.NoError)
            {
                ErrorString = "UD_Device_Scan!!Error Code:" + err.ToString();
            }
            else
            {
                IsU2405Connected = true;
                bool bFound = false;
                //ushort wCardID = 0;
                for (int index = 0; index < wModuleNum; index++)
                {
                    if (AvailModules[index].wModuleType == USBDASK.USB_2405) 
                    {
                        //讀取U2405卡片資料
                        strTemp = AvailModules[index].wCardID.ToString();
                        //wSelModuleID = AvailModules[index].wCardID;
                        short.TryParse(strTemp, out iTemp);
                        wSelModuleID = (ushort)iTemp;
                        if (bFound == false)
                        {
                            bFound = true;
                        }
                        break;
                    }
                }

                if (bFound)
                { 
                    // Register U2405 Card
                    iTemp = USBDASK.UD_Register_Card(USBDASK.USB_2405, wSelModuleID);
                    if (iTemp < 0)
                    {
                        ErrorString = "Register card Fail, Code:" + Module_Num.ToString();
                    }
                    else
                    {
                        Module_Num = (ushort)iTemp;

                        bRegisterFlag = true;
                        bU2405RegisterFlag = true;
                        U2405Used = true;

                        // Configure DI Channel
                        err = USBDASK.UD_DIO_2405_Config(Module_Num, USBDASK.P2405_COUNTER_INPUT, USBDASK.GPIO_IGNORE_CONFIG);
                        if (err != USBDASK.NoError)
                        {
                            ErrorString = "UD_DIO_2405_Config error = :" + err.ToString();
                            return;
                        }

                        // Reset DI Channel
                        err = USBDASK.UD_CTR_Control(Module_Num, 0, USBDASK.UD_CTR_Polarity_Positive | USBDASK.UD_CTR_Reset_Edge_Counter);
                        if (err != USBDASK.NoError)
                        {
                            ErrorString = "UD_CTR_Control error = :" + err.ToString();
                            return;
                        }

                    }
                }
                else
                {
                    ErrorString = "Cannot find U2405";
                }

            }
        }
        public bool SetChannelConfigForU2405()
        {
            bool result = false;
            short err = 0;

            // Configure AI Channel
            ushort[] chan1flag = new ushort[] { 0, 0, 0, 0};
            for (int i = 0; i < chan1flag.Length; i++)
            {
                if (MyParameter.ChannelSetting[i].IEPE == 1) chan1flag[i] |= USBDASK.P2405_AI_EnableIEPE; else chan1flag[i] |= USBDASK.P2405_AI_DisableIEPE;
                if (MyParameter.ChannelSetting[i].InputType == 1) chan1flag[i] |= USBDASK.P2405_AI_PseudoDifferential; else chan1flag[i] |= USBDASK.P2405_AI_Differential;
                if (MyParameter.ChannelSetting[i].CouplingType == 1) chan1flag[i] |= USBDASK.P2405_AI_Coupling_None; else chan1flag[i] |= USBDASK.P2405_AI_Coupling_AC;
            }

            err = USBDASK.UD_AI_2405_Chan_Config(Module_Num, chan1flag[0],
                                           chan1flag[1],
                                           chan1flag[2],
                                           chan1flag[3]);
            if (err != USBDASK.NoError)
            {
                ErrorString = "UD_AI_2405_Chan_Config error = :" + err.ToString();
            }
            else
                result = true;

            if (result) ErrorString = "";
            return result;
        }
        public bool SetRangeForU2405()
        {
            bool result = false;


            for (int i = 0; i < GainArray.Length; i++)
            {
                if (MyParameter.ScopeSetting.RangeIndex == 1)
                    GainArray[i] = USBDASK.AD_U_10_V; // 0V~10V
                else
                    GainArray[i] = USBDASK.AD_B_10_V; // -10V~10V
            }

            result = true;

            return result;
        }
        // number initialize
        public void CheckNumberForU2405(uint number)
        {
            int _count = 0;

            uint mask = 0x2;
            dwZeroPadding = 0;

            dwDataNum = number;

            // 重新設定資料存取陣列 - 同時4個Channel資料存取陣列 - AiBuf/AiValue/VoltageValue
            AiBuf = new uint[number * 4];
            AiValue = new int[number * 4];
            AiValue2 = new double[number * 4];
            VoltageValue = new double[4][];
            for (int i = 0; i < 4; i++)
                VoltageValue[i] = new double[number];

            // 補零計算 - 請參考參數 dwZeroPadding
            while (_count++ < 15)
            {
                if (number < mask) break;
                dwZeroPadding = mask - (number % mask);
                mask = mask << 1;

                if (number == mask) dwZeroPadding = 0;
            }
        }
        public void TransferVoltageValueFromU2405(ref double voltagedata, ref int aiValue, uint originalData, int rangeindex)
        {
            int I32Temp;
            uint U32Temp;

            U32Temp = originalData;

            if (rangeindex == 0)
            {
                if ((U32Temp & 0x800000) != 0x00000000)
                    U32Temp = (U32Temp | 0xFF000000);
            }

            I32Temp = (int)U32Temp;

            aiValue = I32Temp;

            voltagedata = (double)I32Temp / 838860.8;
        }
        public void RightOneShiftVoltageValue(int index, double addValue)
        {
            if (index < 0) return;
            if (index >= VoltageValue.Length) return;
            int ArrayNumber = VoltageValue[index].Length;
            double[] buffer = new double[ArrayNumber];
            Array.Copy(VoltageValue[index], 0,  buffer, 1, ArrayNumber - 1);
            buffer[0] = addValue;
            Array.Copy(buffer, VoltageValue[index], ArrayNumber);
        }

        // Check Key Phasor
        public void CheckKeyPhasor(int index)
        {
            if (index < 0) return;
            if (index > 3) return;

            double Max = -1000000.0, Min = 1000000.0;
            for (int i = 0; i < VoltageValue[index].Length; i++)
            {
                double value = VoltageValue[index][i];
                if (value > Max) Max = value;
                if (value < Min) Min = value;
            }
            double avg = (Max + Min) / 2.0;

            bool isEmpty = true;
            bool isCheckEnd = false;

            for (int i = 0; i < VoltageValue[index].Length; i++)
            {
                double value = VoltageValue[index][i];

                // old check function - up trigger is start point
                //if (isEmpty && (value > avg)) { isEmpty = false; keyphasorBuffer.Add(i); }
                //if (!isEmpty && (value < avg)) isEmpty = true;

                // new check function - down trigger is start point
                // up trigger is end point
                if (isEmpty && (value < avg)) { isEmpty = false; isCheckEnd = true; keyphasorBuffer.Add(i); }
                if (isCheckEnd && (value > avg)) { isCheckEnd = false; keyphasorBuffer_End.Add(i); }
                if (!isEmpty && !isCheckEnd) isEmpty = true;
            }

        }
        #endregion
    }
}
