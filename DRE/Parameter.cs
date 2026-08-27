using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace DRE
{
    public class Parameter : IDisposable
    {
        [DllImport("kernel32", CharSet = CharSet.Auto)]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool WritePrivateProfileString(string section, string key, string def, string filePath);

        #region field

        public ChannelSettingType[] ChannelSetting = new ChannelSettingType[]
            { new ChannelSettingType(), new ChannelSettingType(), new ChannelSettingType(), new ChannelSettingType() };
        public int ChannelSettingIndex = 0;
        public ChannelSettingType SelectedChannelSetting { get { return ChannelSetting[ChannelSettingIndex]; }  set { ChannelSetting[ChannelSettingIndex].Copy(value); } }
        public CaptureSettingType CaptureSetting = new CaptureSettingType();
        public ScopeSettingType ScopeSetting = new ScopeSettingType();

       


        #endregion

        #region constructor

        public Parameter()
        {
            Load();
        }

        #endregion

        #region destructor

        ~Parameter()
        {
            Dispose(false);
        }

        #endregion

        #region IDisposable

        bool _disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                // ToDo:
                Save();
            }

            // ToDo: Release component and set null to it

            _disposed = true;
        }

        #endregion

        #region function

        public void Load()
        {
            if (File.Exists("Parameter.ini"))
            {
                StringBuilder retVal = new StringBuilder(255);
                string Default = "0";
                int Size = 255;
                int strref = 0;

                string runningPath = System.Environment.CurrentDirectory;
                string iniFilePath = Path.Combine(runningPath, "Parameter.ini");

                string keyString = "";

                // Channel Setting
                for (int i = 0; i < ChannelSetting.Length; i++)
                {
                    keyString = "ChannelSetting_" + (i + 1).ToString();
                    strref = GetPrivateProfileString(keyString, "IEPE", Default, retVal, Size, iniFilePath);
                    ChannelSetting[i].IEPE = Convert.ToInt32(retVal.ToString());
                    strref = GetPrivateProfileString(keyString, "InputType", Default, retVal, Size, iniFilePath);
                    ChannelSetting[i].InputType = Convert.ToInt32(retVal.ToString());
                    strref = GetPrivateProfileString(keyString, "CouplingType", Default, retVal, Size, iniFilePath);
                    ChannelSetting[i].CouplingType = Convert.ToInt32(retVal.ToString());
                    strref = GetPrivateProfileString(keyString, "DisplaySpecification", Default, retVal, Size, iniFilePath);
                    ChannelSetting[i].DisplaySpecification = Convert.ToInt32(retVal.ToString());
                    strref = GetPrivateProfileString(keyString, "DisplayType", Default, retVal, Size, iniFilePath);
                    ChannelSetting[i].DisplayType = Convert.ToInt32(retVal.ToString());
                }

                // Capture Setting
                keyString = "CaptureSetting";
                strref = GetPrivateProfileString(keyString, "ProgramName", Default, retVal, Size, iniFilePath);
                CaptureSetting.ProgramName = retVal.ToString();
                strref = GetPrivateProfileString(keyString, "SamplingRateIndex", Default, retVal, Size, iniFilePath);
                CaptureSetting.SamplingRateIndex = Convert.ToInt32(retVal.ToString());
                strref = GetPrivateProfileString(keyString, "DataNumber", Default, retVal, Size, iniFilePath);
                CaptureSetting.DataNumber = Convert.ToInt32(retVal.ToString());
                strref = GetPrivateProfileString(keyString, "RPMTriggerIndex", Default, retVal, Size, iniFilePath);
                CaptureSetting.RPMTriggerIndex = Convert.ToInt32(retVal.ToString());
                strref = GetPrivateProfileString(keyString, "KeyPhysorIndex", Default, retVal, Size, iniFilePath);
                CaptureSetting.KeyPhysorIndex = Convert.ToInt32(retVal.ToString());

                // Scope Setting
                keyString = "ScopeSetting";
                strref = GetPrivateProfileString(keyString, "RangeIndex", Default, retVal, Size, iniFilePath);
                ScopeSetting.RangeIndex = Convert.ToInt32(retVal.ToString());
                strref = GetPrivateProfileString(keyString, "TimeRange", Default, retVal, Size, iniFilePath);
                ScopeSetting.TimeRange = Convert.ToInt32(retVal.ToString());
                strref = GetPrivateProfileString(keyString, "Layout", Default, retVal, Size, iniFilePath);
                ScopeSetting.Layout = Convert.ToInt32(retVal.ToString());

                /*
                string keyString = "Main";
                strref = GetPrivateProfileString(keyString, "MachineID", Default, retVal, Size, iniFilePath);
                MachineID = retVal.ToString();
                strref = GetPrivateProfileString(keyString, "SaveSnapShotFolderPath", Default, retVal, Size, iniFilePath);
                SaveSnapShotFolderPath = retVal.ToString();
                try { if (!Directory.Exists(SaveSnapShotFolderPath)) { Directory.CreateDirectory(SaveSnapShotFolderPath); } } catch { }
                strref = GetPrivateProfileString(keyString, "DefaultCameraIndex", Default, retVal, Size, iniFilePath);
                DefaultCameraIndex = Convert.ToInt32(retVal.ToString());
                strref = GetPrivateProfileString(keyString, "TestingPersonInfoFolderPath", Default, retVal, Size, iniFilePath);
                TestingPersonInfoFolderPath = retVal.ToString();
                try { if (!Directory.Exists(TestingPersonInfoFolderPath)) { Directory.CreateDirectory(TestingPersonInfoFolderPath); } } catch (Exception) { }
                strref = GetPrivateProfileString(keyString, "TestingPersonPictureFolderPath", Default, retVal, Size, iniFilePath);
                TestingPersonPictureFolderPath = retVal.ToString();
                try { if (!Directory.Exists(TestingPersonPictureFolderPath)) { Directory.CreateDirectory(TestingPersonPictureFolderPath); } } catch (Exception ex) { }
                strref = GetPrivateProfileString(keyString, "TestingIDCardPictureFolderPath", Default, retVal, Size, iniFilePath);
                TestingIDCardPictureFolderPath = retVal.ToString();
                try { if (!Directory.Exists(TestingIDCardPictureFolderPath)) { Directory.CreateDirectory(TestingIDCardPictureFolderPath); } } catch (Exception ex) { }
                strref = GetPrivateProfileString(keyString, "TestingVideoFolderPath", Default, retVal, Size, iniFilePath);
                TestingVideoFolderPath = retVal.ToString();
                try { if (!Directory.Exists(TestingVideoFolderPath)) { Directory.CreateDirectory(TestingVideoFolderPath); } } catch (Exception ex) { }
                */
            }

        }

        public void Save()
        {
            if (File.Exists("Parameter.ini"))
            {
                StringBuilder retVal = new StringBuilder(255);
                string Default = "0";
                int Size = 255;
                int strref = 0;

                string runningPath = System.Environment.CurrentDirectory;
                string iniFilePath = Path.Combine(runningPath, "Parameter.ini");

                string keyString = "";

                // Channel Setting
                for (int i = 0; i < ChannelSetting.Length; i++)
                {
                    keyString = "ChannelSetting_" + (i + 1).ToString();
                    WritePrivateProfileString(keyString, "IEPE", ChannelSetting[i].IEPE.ToString(), iniFilePath);
                    WritePrivateProfileString(keyString, "InputType", ChannelSetting[i].InputType.ToString(), iniFilePath);
                    WritePrivateProfileString(keyString, "CouplingType", ChannelSetting[i].CouplingType.ToString(), iniFilePath);
                    WritePrivateProfileString(keyString, "DisplaySpecification", ChannelSetting[i].DisplaySpecification.ToString(), iniFilePath);
                    WritePrivateProfileString(keyString, "DisplaySpecificationName", ChannelSetting[i].DisplaySpecificationName, iniFilePath);
                    WritePrivateProfileString(keyString, "DisplayType", ChannelSetting[i].DisplayType.ToString(), iniFilePath);
                    
                }

                // Capture Setting
                keyString = "CaptureSetting";
                WritePrivateProfileString(keyString, "ProgramName", CaptureSetting.ProgramName, iniFilePath);
                WritePrivateProfileString(keyString, "SamplingRateIndex", CaptureSetting.SamplingRateIndex.ToString(), iniFilePath);
                WritePrivateProfileString(keyString, "DataNumber", CaptureSetting.DataNumber.ToString(), iniFilePath);
                WritePrivateProfileString(keyString, "RPMTriggerIndex", CaptureSetting.RPMTriggerIndex.ToString(), iniFilePath);
                WritePrivateProfileString(keyString, "KeyPhysorIndex", CaptureSetting.KeyPhysorIndex.ToString(), iniFilePath);

                // Scope Setting
                keyString = "ScopeSetting";
                WritePrivateProfileString(keyString, "RangeIndex", ScopeSetting.RangeIndex.ToString(), iniFilePath);
                WritePrivateProfileString(keyString, "TimeRange", ScopeSetting.TimeRange.ToString(), iniFilePath);
                WritePrivateProfileString(keyString, "Layout", ScopeSetting.Layout.ToString(), iniFilePath);

                /*
                string keyString = "Main";
                WritePrivateProfileString(keyString, "MachineID", MachineID, iniFilePath);
                WritePrivateProfileString(keyString, "SaveSnapShotFolderPath", SaveSnapShotFolderPath, iniFilePath);
                try { if (!Directory.Exists(SaveSnapShotFolderPath)) { Directory.CreateDirectory(SaveSnapShotFolderPath); } } catch { }
                WritePrivateProfileString(keyString, "DefaultCameraIndex", DefaultCameraIndex.ToString(), iniFilePath);
                WritePrivateProfileString(keyString, "TestingPersonInfoFolderPath", TestingPersonInfoFolderPath, iniFilePath);
                try { if (!Directory.Exists(TestingPersonInfoFolderPath)) { Directory.CreateDirectory(TestingPersonInfoFolderPath); } } catch { }
                WritePrivateProfileString(keyString, "TestingPersonPictureFolderPath", TestingPersonPictureFolderPath, iniFilePath);
                try { if (!Directory.Exists(TestingPersonPictureFolderPath)) { Directory.CreateDirectory(TestingPersonPictureFolderPath); } } catch { }
                WritePrivateProfileString(keyString, "TestingIDCardPictureFolderPath", TestingIDCardPictureFolderPath, iniFilePath);
                try { if (!Directory.Exists(TestingIDCardPictureFolderPath)) { Directory.CreateDirectory(TestingIDCardPictureFolderPath); } } catch { }
                WritePrivateProfileString(keyString, "TestingVideoFolderPath", TestingVideoFolderPath, iniFilePath);
                try { if (!Directory.Exists(TestingVideoFolderPath)) { Directory.CreateDirectory(TestingVideoFolderPath); } } catch { }
                */
            }
        }

        #endregion

    }
}