using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DRE
{

    public class ChannelSettingType
    {
        // 0: Disable IEPE; 1: Enable IEPE
        public int IEPE { get; set; }

        // 0: Differential; 1: PseudoDifferential
        public int InputType { get; set; }

        // 0: Coupling_AC; 1: Couping_NA
        public int CouplingType { get; set; }

        // Display Specification
        // 0: 1g/100 mV; 1: 1g/200mV; 2: 1g/300mV; 3: 1g/400mV; 4: 1g/500mV
        // 5: 1mil/100mv; 6: 1mil/200mV; 7: 1mil/300mV; 8: 1mil/400mV; 9: 1mil/500mV
        public int DisplaySpecification { get; set; }

        public string DisplaySpecificationName
        {
            get
            {
                string result = "Unknown";

                switch (DisplaySpecification)
                {
                    default: break;

                    case 0: result = "1g / 100mV"; break;
                    case 1: result = "1g / 200mV"; break;
                    case 2: result = "1g / 300mV"; break;
                    case 3: result = "1g / 400mV"; break;
                    case 4: result = "1g / 500mV"; break;

                    case 5: result = "1mil / 100mV"; break;
                    case 6: result = "1mil / 200mV"; break;
                    case 7: result = "1mil / 300mV"; break;
                    case 8: result = "1mil / 400mV"; break;
                    case 9: result = "1mil / 500mV"; break;
                }

                return result;
            }
        }

        // 1V transfer value by unit
        public double ChangedValue
        {
            get
            {
                double result = 1.0;

                double buffer = 1.0;

                switch (DisplaySpecification)
                {
                    default: break;

                    case 0: case 5: buffer = 0.1; break;
                    case 1: case 6: buffer = 0.2; break;
                    case 2: case 7: buffer = 0.3; break;
                    case 3: case 8: buffer = 0.4; break;
                    case 4: case 9: buffer = 0.5; break;
                }

                result = 1.0 / buffer;

                return result;
            }
        }

        public bool IsUnitGram
        {
            get
            {
                bool result = false;

                result = DisplaySpecification < 5;

                return result;
            }
        }

        // Display Type
        // 0: p-p; 1: 0-p; 2: rms (=original value * 0.707)
        public int DisplayType { get; set; }



        public ChannelSettingType()
        {
            IEPE = 0;
            InputType = 0;
            CouplingType = 1;
            DisplaySpecification = 0;
            DisplayType = 0;
        }
        public ChannelSettingType(ChannelSettingType data)
        { this.Copy(data); }
        public ChannelSettingType(int iepe, int inputtype, int couplingtype, int displayspecification, int displaytype)
        { this.IEPE = iepe; this.InputType = inputtype; this.CouplingType = couplingtype; this.DisplaySpecification = displayspecification; this.DisplayType = displaytype; }

        public void Copy(ChannelSettingType data)
        {
            this.IEPE = data.IEPE;
            this.InputType = data.InputType;
            this.CouplingType = data.CouplingType;
            this.DisplaySpecification = data.DisplaySpecification;
            this.DisplayType = data.DisplayType;
        }


    }

    public class CaptureSettingType
    {
        public string ProgramName { get; set; }
        public double SamplingRate
        {
            get
            {
                double result = 0.0;
                switch (SamplingRateIndex)
                {
                    case 0:
                        result = 1000.0;
                        break;

                    case 1:
                    default:
                        result = 10000.0;
                        break;

                    case 2:
                        result = 32000.0;
                        break;

                    case 3:
                        result = 64000.0;
                        break;

                    case 4:
                        result = 128000.0;
                        break;
                }
                return result;
            }
        }
        // Sampling Rate Index:
        // 0: 1kHz; 1: 10kHz; 2: 32kHz; 3: 64kHz; 4: 128kHz
        public int SamplingRateIndex { get; set; }
        public string[] SameplingRateList
        { get { return new string[] { "1 kHz", "10 kHz", "32 kHz", "64 kHz", "128 kHz" }; } }

        public int DataNumber { get; set; }
        public string[] DataNumberList
        { get { return new string[] { "1024", "2048", "5120", "10240" }; } }
        

        public bool EnableRPMTrigger { get { return (RPMTriggerIndex != 0); } }
        public int RPMTriggerIndex { get; set; }

        public bool EnableKeyPhysor { get { return (KeyPhysorIndex != 0); } }
        public int KeyPhysorIndex { get; set; }

        public CaptureSettingType()
        {
            SamplingRateIndex = 1;
            DataNumber = 1024;
        }
        public CaptureSettingType(string programname, int samplingateindex, int datanumber, bool rpmtrigger, bool keyphysor)
        {
            this.ProgramName = programname;
            this.SamplingRateIndex = samplingateindex;
            this.DataNumber = datanumber;
            this.RPMTriggerIndex = rpmtrigger ? 1 : 0;
            this.KeyPhysorIndex = keyphysor ? 1 : 0;
        }
        public CaptureSettingType(CaptureSettingType data)
        { this.Copy(data); }

        public void Copy(CaptureSettingType data)
        {
            this.ProgramName = data.ProgramName;
            this.SamplingRateIndex = data.SamplingRateIndex;
            this.DataNumber = data.DataNumber;
            this.RPMTriggerIndex = data.RPMTriggerIndex;
            this.KeyPhysorIndex = data.KeyPhysorIndex;
        }
        
    }

    public class ScopeSettingType
    {
        public int RangeIndex { get; set; }
        public string[] RangeList
        { get { return new string[] { "-10V~10V", "0V-10V" }; } }
        public int Layout { get; set; }

        public int TimeRange { get; set; }

        public ScopeSettingType()
        {
            TimeRange = 500;
            Layout = 1;
        }
        public ScopeSettingType(ScopeSettingType data)
        { this.Copy(data); }
        public ScopeSettingType(int rangeindex, int timerange, int layout)
        {
            this.RangeIndex = rangeindex;
            this.TimeRange = timerange;
            this.Layout = layout;
        }

        public void Copy(ScopeSettingType data)
        {
            this.RangeIndex = data.RangeIndex;
            this.TimeRange = data.TimeRange;
            this.Layout = data.Layout;
        }
    }
}