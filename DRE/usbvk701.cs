using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DRE
{
    public class USBVK701
    {
        public const string VK710_DLL_FILE_NAME = "VK70xUMC_DAQ2.dll";

        // Initialize connected collection card parameters
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_InitializeAll", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_InitializeAll(int mci, int[] para, int len);
        // [prototype]; int VK70xUMC_InitializeAll(int mci, int* para, int len);
        // [parameter]: int mci: DAQ serial number.                                     Default: [0] (Signal DAQ)
        //              int[] para: sampling parameters                                  
        //					para[0]: Sampling command									Range: [0x00]/[0x22]: Set parameters to start sampling
        //					para[1]: Sampling frequency									Range: [1]~[100000]: If the sampling accuracy is 24 bits, the maximum sampling rate is 50KSPS
        //					para[2]: Number of sampling points for N points				Range: [1]~[2^31]
        //					para[3]: Reference voltage									Range: [4000]: Indicating a reference voltage of 4.000V (VK701)
        //																					   [4096]: Indicating a reference voltage of 4.096V (VK701H+)
        //																					   [0]: If the current reference voltage of the acquisition card is unclear, this parameter is set to 0 by default
        //					para[4]: Voltage input range for CH1                        Range: [0]: +-10V, [1]: +-5V, [2]: +-2.5V, [3]: +-1V, [4]: +-500mV, [5]: +-100mV, [6]: +-20mV, [7]: +-1mV  
        //					para[5]: Voltage input range for CH2                        Range: [0]: +-10V, [1]: +-5V, [2]: +-2.5V, [3]: +-1V, [4]: +-500mV, [5]: +-100mV, [6]: +-20mV, [7]: +-1mV  
        //					para[6]: Voltage input range for CH3                        Range: [0]: +-10V, [1]: +-5V, [2]: +-2.5V, [3]: +-1V, [4]: +-500mV, [5]: +-100mV, [6]: +-20mV, [7]: +-1mV  
        //					para[7]: Voltage input range for CH4                        Range: [0]: +-10V, [1]: +-5V, [2]: +-2.5V, [3]: +-1V, [4]: +-500mV, [5]: +-100mV, [6]: +-20mV, [7]: +-1mV  
        //					para[8]~para[11]: Parameters are meaningless
        //					para[12]: IEPE switch for CH1								Range: [0]: ADC mode, [1]: IEPE mode
        //					para[13]: IEPE switch for CH2								Range: [0]: ADC mode, [1]: IEPE mode
        //					para[14]: IEPE switch for CH3								Range: [0]: ADC mode, [1]: IEPE mode
        //					para[15]: IEPE switch for CH4								Range: [0]: ADC mode, [1]: IEPE mode
        //					para[16]~para[19]: Parameters are meaningless
        // [parameter]: int len: Set parameter length									Range: >=[20]
        // [return value]: >= 0 : Set successfully 
        //                 -11  : Device not opened
        //                 -12  : DAQ not connected or not present
        //                 -13  : DAQ not connected or not present
        //                 other: Abnormal exit


        // Start continuous sampling
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_StartSampling", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_StartSampling(int mci);
        // [prototype]; int VK70xUMC_StartSampling(int mci);
        // [parameter]: int mci: DAQ serial number.                                     Default: [0] (Signal DAQ)
        // [return value]: >= 0 : Operation successful
        //                 -11  : Device not opened
        //                 -12  : No DAQ detected
        //                 -13  : DAQ not connected or not present
        //                 other: Abnormal exit


        // Start N-point sampling
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_StartSampling_NPoints", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_StartSampling_NPoints(int mci, int Npointsnums);
        // [prototype]; int VK70xUMC_StartSampling_NPoints(int mci, int Npointsnums);
        // [parameter]: int mci: DAQ serial number.                                     Default: [0] (Signal DAQ)
        //              int Npointsnums: Number of N-point samples.                     Range: [0]~[N]: Number of sampling points for N points
        // [return value]: >= 0 : Operation successful
        //                 -11  : Device not opened
        //                 -12  : No DAQ detected
        //                 -13  : DAQ not connected or not present
        //                 other: Abnormal exit


        // Stop sampling
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_StopSampling", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_StopSampling(int mci);
        // [prototype]; int VK70xUMC_StopSampling(int mci);
        // [parameter]: int mci: DAQ serial number.                                     Default: [0] (Signal DAQ)
        // [return value]: >= 0 : Operation successful
        //                 -11  : Device not opened
        //                 -12  : No DAQ detected
        //                 -13  : DAQ not connected or not present
        //                 other: Abnormal exit


        // Switching System Mode
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_Set_SampleMode", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_Set_SampleMode(int mci, int modeval);
        // [prototype]; int VK70xUMC_Set_SampleMode(int mci, int modeval);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        //              int modeval: Select System Mode.                                Range: [0x00]: Normal mode
        //                                                                                     [0x8080]: IO interrupt triggers ADC sampling mode
        //                                                                                     [0x8199]: Set IO4 as input clock as ADC sampling clock
        //                                                                                     Others: Reserve
        // [return value]: >= 0 : Set successfully 
        //                 -11  : Device not opened
        //                 -12  : DAQ not connected or not present
        //                 -13  : DAQ not connected or not present
        //                 other: Abnormal exit


        // Set up PWM/DAC/IO/counter/temperature channels
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_Set_AdditionalFeature", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_Set_AdditionalFeature(int mci, int funcNo, int para1, double para2);
        // [prototype]; int VK70xUMC_Set_AdditionalFeature(int mci, int funcNo, int para1, double para2);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        //              int funcNo: Function Parameter                                  Range: Name    Function Parameter    Parameter 1                Parameter 2
        //                                                                                     PWM     1                     The frequency of PWM1      The duty cycle of PWM1([0.1]%~[100.0]%)
        //                                                                                             2                     The frequency of PWM2      The duty cycle of PWM2([0.1]%~[100.0]%)
        //                                                                                     DAC     11                    Meaningless                Voltage value([0.0]V~[3.3]V)
        //                                                                                             12                    Meaningless                Voltage value([0.0]V~[3.3]V)
        //                                                                                     IO      20                    IO1~IO4                    Meaningless
        //                                                                                     IO      21                    IO1,[0]:Low,[1]:High,      Meaningless
        //                                                                                                                   [2]:Input,[0xFF]:Invalid     
        //                                                                                     IO      22                    IO2,[0]:Low,[1]:High,      Meaningless
        //                                                                                                                   [2]:Input,[0xFF]:Invalid     
        //                                                                                     IO      23                    IO3,[0]:Low,[1]:High,      Meaningless
        //                                                                                                                   [2]:Input,[0xFF]:Invalid     
        //                                                                                     IO      24                    IO4,[0]:Low,[1]:High,      Meaningless
        //                                                                                                                       [2]:Input,[0xFF]:Invalid     
        //                                                                                     COUNT   31                    [0]:Reset counter          Meaningless
        //                                                                                  FREQ VAL   32                    [100]: Counting period     Meaningless
        //                                                                                                                   [200]: Counting period
        //                                                                                                                   [500]: Counting period
        //                                                                                                                   [1000]: Counting period
        //                                                                                     TEMP    41                    [0]~[4], Set temperature   Meaningless
        //                                                                                                                   channel,[0] is the internal channel   
        //                                                                                     RESERVE other                 Meaningless                Meaningless
        //              int para1: Parameter 1
        //              double para2: Parameter 2
        // [return value]: >= 0 : Set successfully 
        //                 -11  : Device not opened
        //                 -12  : DAQ not connected or not present
        //                 -13  : DAQ not connected or not present
        //                 other: Abnormal exit


        // Get version information of DLL functions
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_GetVersionLot", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern char[] VK70xUMC_GetVersionLot();
        // [prototype]; char[] VK70xUMC_GetVersionLot();
        // [return value]: Get DLL version number (string)


        // Read single channel data
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_GetOneChannel", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_GetOneChannel(int mci, int CHNum, double[] adcbuffer, int rsamplenum);
        // [prototype]; int VK70xUMC_GetOneChannel(int mci, int CHNum, double[] adcbuffer, int rsamplenum);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        //              int CHNum: Channel select                                       Range: [0]~[3]: CH1~CH4
        //              double[] adcbuffer: Read the first address of the data          
        //              int rsamplenum: Number of sampling points to be read   
        // [return value]: > 0 : Actual reading of sampling points
        //                 = 0 : No data
        //                 other: Abnormal exit


        // Read 4-channel sampling data
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_GetFourChannel", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_GetFourChannel(int mci, double[] adcbuffer, int rsamplenum);
        // [prototype]; int VK70xUMC_GetFourChannel(int mci, double[] adcbuffer, int rsamplenum);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        //              double[] adcbuffer: Read the first address of the data          
        //              int rsamplenum: Number of sampling points to be read   
        // [return value]: > 0 : Actual reading of sampling points
        //                 = 0 : No data
        //                 other: Abnormal exit


        // Read single channel data with IO status
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_GetOneChannel_WithIOStatus", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_GetOneChannel_WithIOStatus(int mci, int CHNum, double[] adcbuffer, int rsamplenum, int ioenable);
        // [prototype]; int VK70xUMC_GetOneChannel_WithIOStatus(int mci, int CHNum, double[] adcbuffer, int rsamplenum, int ioenable);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        //              int CHNum: Channel select                                       Range: [0]~[3]: CH1~CH4
        //              double[] adcbuffer: Read the first address of the data          
        //              int rsamplenum: Number of sampling points to be read   
        //              int ioenable: Read IO status                                    Range: [0]: Do not read IO status
        //                                                                                     [1]: Read IO2 status
        //                                                                                     [2]: Read IO3 status
        //                                                                                     [3]: Read IO2 and IO3 status
        //                                                                                     other: Do not read IO status
        // [return value]: > 0 : Actual reading of sampling points
        //                 = 0 : No data
        //                 other: Abnormal exit
        // [note]: VK70xUMC_ Initialize(); It is necessary to ensure that the value of the refmode parameter in the Initialize function is 4.000 (VK701N must be done this way). 
        //         In addition, before reading the status, IO needs to be set to input mode



        // Read 4-channel sampling data with IO status
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_GetFourChannel_WithIOStatus", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_GetFourChannel_WithIOStatus(int mci, double[] adcbuffer, int rsamplenum, int ioenable);
        // [prototype]; int VK70xUMC_GetFourChannel_WithIOStatus(int mci, double[] adcbuffer, int rsamplenum, int ioenable);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        //              double[] adcbuffer: Read the first address of the data          
        //              int rsamplenum: Number of sampling points to be read   
        //              int ioenable: Read IO status                                    Range: [0]: Do not read IO status
        //                                                                                     [1]: Read IO2 status
        //                                                                                     [2]: Read IO3 status
        //                                                                                     [3]: Read IO2 and IO3 status
        //                                                                                     other: Do not read IO status
        // [return value]: > 0 : Actual reading of sampling points
        //                 = 0 : No data
        //                 other: Abnormal exit
        // [note]: VK70xUMC_ Initialize(); It is necessary to ensure that the value of the refmode parameter in the Initialize function is 4.000 (VK701N must be done this way). 
        //         In addition, before reading the status, IO needs to be set to input mode


        // Read IO2 and IO3 status
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_GetIOStatus", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_GetIOStatus(int mci, int[] iostatus);
        // [prototype]; int VK70xUMC_GetIOStatus(int mci, int[] iostatus);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        //              int[] iostatus: Read the first address of the IO status         Range: iostatus[0]: The status of IO1, [0]: low level, [1]: high level
        //                                                                                     iostatus[1]: The status of IO2, [0]: low level, [1]: high level
        //                                                                                     iostatus[2]: The status of IO3, [0]: low level, [1]: high level
        //                                                                                     iostatus[3]: The status of IO4, [0]: low level, [1]: high level
        // [return value]: = 0 : Read successful
        //                 = -1 : The working mode of the acquisition card does not support IO status return
        //                 = -2 : The acquisition card does not support IO status return
        //                 other: Abnormal exit
        // [note]: VK70xUMC_ Initialize(); It is necessary to ensure that the value of the refmode parameter in the Initialize function is 4.000 (VK701N must be done this way). 
        //         In addition, before reading the status, IO needs to be set to input mode


        // Read all IO state functions
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_Get_AllIOS", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_Get_AllIOS(int mci, int[] iobuffer);
        // [prototype]; int VK70xUMC_Get_AllIOS(int mci, int[] iobuffer, int timeout);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        //              int[] iobuffer: Read the first address of the IO status         Range: iobuffer[0]: The status of IO1, [0]: low level, [1]: high level
        //                                                                                     iobuffer[1]: The status of IO2, [0]: low level, [1]: high level
        //                                                                                     iobuffer[2]: The status of IO3, [0]: low level, [1]: high level
        //                                                                                     iobuffer[3]: The status of IO4, [0]: low level, [1]: high level
        // [return value]:  1   : Successfully read IO status
        //                  0   : Read failed, IO status still not updated, please delay 100ms before trying again
        //                 -11  : Device not opened
        //                 -12  : DAQ not connected or not present
        //                 -13  : DAQ not connected or not present
        //                 other: Abnormal exit


        // Read IO1 status
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_Get_IO1", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_Get_IO1(int mci, ref int iovalue);
        // [prototype]; int VK70xUMC_Get_IO1(int mci, ref int iovalue);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        //              ref int iovalue: Read IO status                                 Range: [0]: low level, [1]: high level
        // [return value]:  1   : Successfully read IO status
        //                  0   : Read failed, IO status still not updated, please delay 100ms before trying again
        //                 -11  : Device not opened
        //                 -12  : DAQ not connected or not present
        //                 -13  : DAQ not connected or not present
        //                 other: Abnormal exit


        // Read IO2 status
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_Get_IO2", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_Get_IO2(int mci, ref int iovalue);
        // [prototype]; int VK70xUMC_Get_IO2(int mci, ref int iovalue);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        //              ref int iovalue: Read IO status                                 Range: [0]: low level, [1]: high level
        // [return value]:  1   : Successfully read IO status
        //                  0   : Read failed, IO status still not updated, please delay 100ms before trying again
        //                 -11  : Device not opened
        //                 -12  : DAQ not connected or not present
        //                 -13  : DAQ not connected or not present
        //                 other: Abnormal exit


        // Read IO3 status
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_Get_IO3", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_Get_IO3(int mci, ref int iovalue);
        // [prototype]; int VK70xUMC_Get_IO3(int mci, ref int iovalue);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        //              ref int iovalue: Read IO status                                 Range: [0]: low level, [1]: high level
        // [return value]:  1   : Successfully read IO status
        //                  0   : Read failed, IO status still not updated, please delay 100ms before trying again
        //                 -11  : Device not opened
        //                 -12  : DAQ not connected or not present
        //                 -13  : DAQ not connected or not present
        //                 other: Abnormal exit


        // Read IO4 status
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_Get_IO4", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_Get_IO4(int mci, ref int iovalue);
        // [prototype]; int VK70xUMC_Get_IO4(int mci, ref int iovalue);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        //              ref int iovalue: Read IO status                                 Range: [0]: low level, [1]: high level
        // [return value]:  1   : Successfully read IO status
        //                  0   : Read failed, IO status still not updated, please delay 100ms before trying again
        //                 -11  : Device not opened
        //                 -12  : DAQ not connected or not present
        //                 -13  : DAQ not connected or not present
        //                 other: Abnormal exit


        // Read PWM parameters
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_Get_PWM", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_Get_PWM(int mci, double[] dutyval, int[] freqval);
        // [prototype]; int VK70xUMC_Get_PWM(int mci, double[] dutyval, int[] freqval);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        //              double[] dutyval: Read PWM duty cycle                           Range: dutyval[0] is PWM1, dutyval[1] is PWM2
        //              int[] freqval: Read PWM frequency                               Range: freqval[0] is PWM1, freqval[1] is PWM2
        // [return value]:  1   : Successfully read PWM status
        //                  0   : Read failed, PWM status still not updated, please delay 100ms before trying again
        //                 -11  : Device not opened
        //                 -12  : DAQ not connected or not present
        //                 -13  : DAQ not connected or not present
        //                 other: Abnormal exit


        // Read DAC parameters
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_Get_DAC", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_Get_DAC(int mci, ref double dacvalue);
        // [prototype]; int VK70xUMC_Get_DAC(int mci, ref double dacvalue);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        //              ref double dacvalue: Read DAC voltage value                     Range: [0]~[3.3]V
        // [return value]:  1   : Successfully read DAC status
        //                  0   : Read failed, DAC status still not updated, please delay 100ms before trying again
        //                 -11  : Device not opened
        //                 -12  : DAQ not connected or not present
        //                 -13  : DAQ not connected or not present
        //                 other: Abnormal exit


        // Read Counter parameters
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_Get_Counter", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_Get_Counter(int mci, ref int countervalue);
        // [prototype]; int VK70xUMC_Get_Counter(int mci, ref int countervalue);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        //              ref int countervalue: Read Counter value
        // [return value]:  1   : Successfully read CNT status
        //                  0   : Read failed, CNT status still not updated, please delay 100ms before trying again
        //                 -11  : Device not opened
        //                 -12  : DAQ not connected or not present
        //                 -13  : DAQ not connected or not present
        //                 other: Abnormal exit
        // [note]: Before using the current function, you need to first use the VK70xUMC_Set_AdditionalFeature() function to set IO4 to external interrupt mode.
        //         eg: VK70xUMC_Set_AdditionalFeature(0, 31, 0, 0);


        // Read Temperature parameters
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_Get_Temperature", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_Get_Temperature(int mci, ref double tempvalue);
        // [prototype]; int VK70xUMC_Get_Temperature(int mci, ref double tempvalue);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        //              ref double tempvalue: Read temperature value
        // [return value]:  1   : Successfully read TEMP status
        //                  0   : Read failed, TEMP status still not updated, please delay 100ms before trying again
        //                 -11  : Device not opened
        //                 -12  : DAQ not connected or not present
        //                 -13  : DAQ not connected or not present
        //                 other: Abnormal exit
        // [note]: Before using the current function, you need to first use the VK70xUMC_Set_AdditionalFeature() function to set parameter.
        //         eg: VK70xUMC_Set_AdditionalFeature(0, 4, 0, 0); // Select the internal channel temperature sensor of the acquisition card
        //         eg: VK70xUMC_Set_AdditionalFeature(0, 4, 1, 0); // Select IO1 as the temperature sensor channel
        //         eg: VK70xUMC_Set_AdditionalFeature(0, 4, 2, 0); // Select IO2 as the temperature sensor channel
        //         eg: VK70xUMC_Set_AdditionalFeature(0, 4, 3, 0); // Select IO3 as the temperature sensor channel
        //         eg: VK70xUMC_Set_AdditionalFeature(0, 4, 4, 0); // Select IO4 as the temperature sensor channel


        // Read frequency value parameters
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_Get_Freq", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_Get_Freq(int mci, ref int freqvalue);
        // [prototype]; int VK70xUMC_Get_Freq(int mci, ref int freqvalue);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        //              ref int freqvalue: Read frequency value
        // [return value]:  1   : Successfully read FreqVal status
        //                  0   : Read failed, FreqVal status still not updated, please delay 100ms before trying again
        //                 -11  : Device not opened
        //                 -12  : DAQ not connected or not present
        //                 -13  : DAQ not connected or not present
        //                 other: Abnormal exit
        // [note]: Before using the current function, you need to first use the VK70xUMC_Set_AdditionalFeature() function to set parameter.
        //         Set IO4 as the external interrupt counting mode, and the function call method is:
        //         eg: VK70xUMC_Set_AdditionalFeature(0, 32, 1000, 0);


        // Open Device
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "Device_Open", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Device_Open();
        // [prototype]; int Device_Open();
        // [return value]: >= 0 : Device successfully opened
        //                 1    : The Device is already open
        //                 -13  : The Device port is already occupied!
        //                 other: Abnormal exit


        // Close Device
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "Device_Close", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Device_Close(int mci);
        // [prototype]; int Device_Close(int mci);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        // [return value]: >= 0 : Set successfully 
        //                 other: Abnormal exit


        // Read the number of collection cards on the connected Device
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "Device_Get_ConnectedClientNumbers", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Device_Get_ConnectedClientNumbers(ref int cnum);
        // [prototype]; int Device_Get_ConnectedClientNumbers(ref int cnum);
        // [parameter]: ref int cnum: Used to store and read the number of DAQs on connected Devices
        // [return value]: >= 0 : Read successful
        //                 -11  : Device not opened
        //                 -12  : No DAQ connection to Device
        //                 other: Abnormal exit


        // Read the handle and IP address of the current collection card
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "Device_Get_ConnectedClientHandle", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Device_Get_ConnectedClientHandle(int mci, ref int ihadble, ref int vktype, Byte[] ipadr);
        // [prototype]; int Device_Get_ConnectedClientHandle(int mci, ref int ihadble, Byte[] ipAdr);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        //              ref int ihadble: Connection handle pointing to the current DAQ used for storing reads.
        //              ref int vktype: Used to store collection card types.            Range: [0]: VK701/VK701H+, [1]: VK702
        //              Byte[] ipAdr: The IP address used to store the currently active collection card for reading.
        //                            Require at least 16 bytes of space to be guaranteed.
        // [return value]: >= 0 : Read successful
        //                 -11  : Device not opened
        //                 -12  : The requested collection card index number is incorrect
        //                 -13  : The requested collection card is not connected or does not exist
        //                 other: Abnormal exit


        // Read the total number of bytes received by the current Device-side
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "Device_Get_RxTotoalBytes", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Device_Get_RxTotoalBytes(ref int totalbytesnum, int clrflag);
        // [prototype]; int Device_Get_RxTotoalBytes(ref int totalbytesnum, int clrflag);
        // [parameter]: ref int totalbytesnum: Used to store the total number of bytes received by the current Device for reading.
        //              int clrflag: Clear the receive byte count flag after reading is completed.          Range: [0]: accumulate, [1]: Zero after reading
        // [return value]: >= 0 : Read successful
        //                 other: Abnormal exit


        // Initialize trigger parameters
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_Set_SimulationTriggerMode", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_Set_SimulationTriggerMode(int mci, int status, int trigch, int trigedge, int rdnpoints, int rdnegnpoints, double trigval);
        // [prototype]; int VK70xUMC_Set_SimulationTriggerMode(int mci, int status, int trigch, int trigedge, int rdnpoints, int rdnegnpoints, double trigval);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        //              int status: N-point sampling trigger state                      Range: [0]: Stop triggering, [1]: Enable trigger ready, [other values]: Invalid / Restored to default [0]
        //              int trigch: Select trigger channel                              Range: [0]~[7]: CH1~CH8, Voltage triggered
        //                                                                                     [8]: IO1 level or edge trigger
        //                                                                                     [9]: IO2 level or edge trigger
        //                                                                                     [10]: IO3 level or edge trigger
        //                                                                                     [11]: IO4 level or edge trigger
        //                                                                                     [other values]: Invalid / Restored to default [0]
        //              int trigedge:                                                   Range: [0]: If triggered by IO, it is triggered by the rising edge. 
        //                                                                                          If triggered through analog channel, triggering above the set threshold.
        //                                                                                     [1]: If triggered by IO, it is triggered by the falling  edge. 
        //                                                                                          If triggered through analog channel, triggering below the set threshold.
        //                                                                                     [2]: If using IO trigger, it is a high-level trigger.
        //                                                                                          If triggered through analog channel, triggering above the set threshold.
        //                                                                                     [3]: If using IO trigger, it is a low-level trigger.
        //                                                                                          If triggered through analog channel, triggering below the set threshold.
        //                                                                                     [other values]: Invalid / Restored to default [0]
        //              int rdnpoints: Trigger the total number of N points.            Range: [1]~[2^31], Note: Including negative sampling points
        //              int rdnegnpoints: Number of negative samples triggered          Range: [1]~[2^31], Note: The value must be less than rdnpoints
        //              double trigval: Trigger voltage value                           Range: [-10.0]~[10.0], Note: If IO is triggered, this setting value is invalid
        // [return value]: >= 0 : Set successfully 
        //                 -3   : The requested collection card is not connected or does not exist
        //                 -4   : The current collection card is not working in this triggering mode
        //                 -5   : Trigger channel setting error
        //                 other: Abnormal exit
        // [note]: (1) Before using this function, the current acquisition card must be initialized with VK702NHMC_InitializeAll() and set to continuous sampling mode.


        // Get trigger data
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_Get_SelectChannelsFromSimulationTrigger", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_Get_SelectChannelsFromSimulationTrigger(int mci, int readdchnum, double[] adcbuffer, int rsamplenum);
        // [prototype]; int VK70xUMC_Get_SelectChannelsFromSimulationTrigger(int mci, int readdchnum, double[] adcbuffer, int rsamplenum);
        // [parameter]: int mci: DAQ serial number                                      Default: [0] (Signal DAQ)
        //              int readdchnum: N-point sampling trigger state                  Range: [1]: Indicates reading analog CH1 data
        //                                                                                     [2]: Indicates reading analog CH1 & CH2 data
        //                                                                                     [3]: Indicates reading analog CH1 & CH2 & CH3 data
        //                                                                                     [4]: Indicates reading analog CH1 & CH2 & CH3 & CH4 data
        //                                                                                     [5]: Indicates reading analog CH1 & CH2 & CH3 & CH4 & CH5 data
        //                                                                                     [6]: Indicates reading analog CH1 & CH2 & CH3 & CH4 & CH5 & CH6 data
        //                                                                                     [7]: Indicates reading analog CH1 & CH2 & CH3 & CH4 & CH5 & CH6 & CH7 data
        //                                                                                     [8]: Indicates reading analog CH1 & CH2 & CH3 & CH4 & CH5 & CH6 & CH7 & CH8 data
        //                                                                                     [9]: Indicates reading analog CH1 & CH2 & CH3 & CH4 & CH5 & CH6 & CH7 & CH8 & IO2 data
        //                                                                                     [10]: Indicates reading analog CH1 & CH2 & CH3 & CH4 & CH5 & CH6 & CH7 & CH8 & IO2 & IO3 data
        //              double[] adcbuffer: Read the first address of the data
        //              int rsamplenum:Prepare to read the number of sampling points.
        // [return value]: > 0 : Actual reading of sampling points
        //                 = 0 : No data
        //                 -2  : Timed out exit
        //                 other: Abnormal exit


        // Set reading method
        [DllImport(VK710_DLL_FILE_NAME, EntryPoint = "VK70xUMC_Set_BlockingMethodtoReadADCResult", ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int VK70xUMC_Set_BlockingMethodtoReadADCResult(int tmode, int timeout);
        // [prototype]; int VK70xUMC_Set_BlockingMethodtoReadADCResult(int tmode, int timeout);
        // [parameter]: int tmode: Reading method										Range: [0]: Non blocking read method, [1]: Blocking read method
        //              int timeout: Set timeout for blocking read.						Range: If non blocking read method, default [0]
        //																					   [1]~[10000]: 1ms~10s
        // [return value]: >= 0 : Set successfully 
        //                 other: Abnormal exit


    }
}