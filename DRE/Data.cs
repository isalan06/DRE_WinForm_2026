using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Globalization;

namespace DRE
{
    public partial class MainProcess
    {
        // field
        #region field

        public Color[] CurveColor = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Orange, Color.Lime, Color.Brown, Color.Purple, Color.DarkRed, Color.DarkSeaGreen, Color.SkyBlue };

        public double UseFrameRate = 10000.0;
        public double MSPerPoint
        {
            get
            {
                double result = 1.0;

                result = 1000.0 / UseFrameRate;

                return result;
            }
        }
        public int RangeIndex = 0;

        private string[] filenamepath = null;
        public string[] MultiFileNamePaths
        {
            get { return filenamepath; }
            set
            {
                if (value == null) filenamepath = null;
                else if (value.Length == 0) filenamepath = null;
                else
                {
                    filenamepath = new string[value.Length];
                    Array.Copy(value, filenamepath, filenamepath.Length);
                }

            }
        }
        public string[] MultiFileNames
        {
            get
            {
                string[] result = null;

                if (filenamepath != null)
                {
                    result = new string[filenamepath.Length];
                    for (int i = 0; i < result.Length; i++)
                    {
                        result[i] = Path.GetFileNameWithoutExtension(filenamepath[i]);
                    }
                }

                return result;
            }
        }

        public int DataNumberZero
        {
            get
            {
                int result = 0;

                int startValue = 2;

                while (startValue < DataNumber)
                {
                    startValue *= 2;
                }

                result = startValue;

                return result;
            }
        }

        #endregion

        #region function

        public void SaveDataWithInfo(string filenamepath)
        {
            if (VoltageValue == null) return;
            if (VoltageValue.Length <= 0) return;

            using (FileStream fs = new FileStream(filenamepath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    string title = "@Title=Voltage Data With Information";
                    sw.WriteLine(title);
                    string rpm = "@ProgramName=" + this.MyParameter.CaptureSetting.ProgramName;
                    sw.WriteLine(rpm);
                    double savedRPM = IsSetSimRPM ? SetSimRPM : -1.0;
                    sw.WriteLine("@RPM=" + savedRPM.ToString("R", CultureInfo.InvariantCulture));
                    string framerate = "@Framerate=" + this.MyParameter.CaptureSetting.SamplingRateIndex.ToString();
                    sw.WriteLine(framerate);
                    string rangeindex = "@RangeIndex=" + this.MyParameter.ScopeSetting.RangeIndex.ToString();
                    sw.WriteLine(rangeindex);
                    string readcount = "@Count=" + this.MyParameter.CaptureSetting.DataNumber.ToString();
                    sw.WriteLine(readcount);
                    for (int i = 0; i < 4; i++)
                    {
                        string specificationindex = "@SpecificationIndex" + (i + 1).ToString() + "=" + this.MyParameter.ChannelSetting[i].DisplaySpecification.ToString();
                        sw.WriteLine(specificationindex);
                        string specificationname = "@SpecificationName" + (i + 1).ToString() + "=" + this.MyParameter.ChannelSetting[i].DisplaySpecificationName;
                        sw.WriteLine(specificationname);
                        string typeindex = "@TypeIndex" + (i + 1).ToString() + "=" + this.MyParameter.ChannelSetting[i].DisplayType.ToString();
                        sw.WriteLine(typeindex);
                    }
                    string datatitle = "@Data:";
                    sw.WriteLine(datatitle);

                    for (int i = 0; i < VoltageValue.Length; i++) 
                    {
                        for (int j = 0; j < this.MyParameter.CaptureSetting.DataNumber; j++)
                        {
                            sw.WriteLine(VoltageValue[i][j].ToString("F8"));
                        }
                        
                    }

                    string keyphasornumber = "@KeyPhasorNumber=" + this.KeyPhasorList.Length.ToString();
                    sw.WriteLine(keyphasornumber);
                    string keyphasordatatitle = "@KeyPhasorData:";
                    sw.WriteLine(keyphasordatatitle);

                    int[] keyphasordatalist = this.KeyPhasorList;
                    for (int i = 0; i < keyphasordatalist.Length; i++)
                    {
                        sw.WriteLine(keyphasordatalist[i].ToString());
                    }

                    string keyphasorendnumber = "@KeyPhasorEndNumber=" + this.KeyPhasorEndList.Length.ToString();
                    sw.WriteLine(keyphasorendnumber);
                    string keyphasorenddatatitle = "@KeyPhasorEndData:";
                    sw.WriteLine(keyphasorenddatatitle);

                    int[] keyphasorenddatalist = this.KeyPhasorEndList;
                    for (int i = 0; i < keyphasorenddatalist.Length; i++)
                    {
                        sw.WriteLine(keyphasorenddatalist[i].ToString());
                    }

                    sw.Flush();
                }

                fs.Close();
            }
        }

        public void LoadDataWithInfo(string filenamepath)
        {
            List<string> data = new List<string>();
            List<string> data2 = new List<string>();
            List<string> data3 = new List<string>();
            double loadedRPM = -1.0;

            using (FileStream fs = new FileStream(filenamepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string lineString = "";
                    bool bStart = false;
                    bool bStart2 = false;
                    bool bStart3 = false;
                    int dataNumber = 0;
                    int datacount = 0;
                    int keyphasorNumber = 0;
                    int keyphasorEndNumber = 0;
                    int kpdatacount = 0;
                    int kpenddatacount = 0;
                    while ((lineString = sr.ReadLine()) != null)
                    {
                        if (!bStart && !bStart2 && !bStart3)
                        {
                            if (lineString[0] == '@')
                            {
                                string[] dataarray = lineString.Split(new string[] { "@", "=" }, StringSplitOptions.RemoveEmptyEntries);
                                if (dataarray.Length >= 2)
                                {
                                    string data_title = dataarray[0];
                                    string data_value = dataarray[1];

                                    switch (data_title)
                                    {
                                        default: break;

                                        case "Title": break;

                                        case "ProgramName": try { this.MyParameter.CaptureSetting.ProgramName = data_value; } catch { this.MyParameter.CaptureSetting.ProgramName = "NA"; } break;

                                        case "RPM":
                                            double parsedRPM;
                                            if (double.TryParse(data_value, NumberStyles.Float, CultureInfo.InvariantCulture, out parsedRPM) && parsedRPM >= 0.0)
                                                loadedRPM = parsedRPM;
                                            break;

                                        case "Framerate": try { this.MyParameter.CaptureSetting.SamplingRateIndex = Convert.ToInt32(data_value); } catch { this.MyParameter.CaptureSetting.SamplingRateIndex = 1; } finally { UseFrameRate = this.MyParameter.CaptureSetting.SamplingRate; } break;

                                        case "RangeIndex": try { this.MyParameter.ScopeSetting.RangeIndex = Convert.ToInt32(data_value); } catch { this.MyParameter.ScopeSetting.RangeIndex = 0; } finally { RangeIndex = this.MyParameter.ScopeSetting.RangeIndex; } break;

                                        case "Count": try { this.MyParameter.CaptureSetting.DataNumber = Convert.ToInt32(data_value); dataNumber = this.MyParameter.CaptureSetting.DataNumber * 4; } catch { this.MyParameter.CaptureSetting.DataNumber = 1024; dataNumber = 4096; } break;

                                        case "SpecificationIndex1": try { this.MyParameter.ChannelSetting[0].DisplaySpecification = Convert.ToInt32(data_value); } catch { this.MyParameter.ChannelSetting[0].DisplaySpecification = 0; } break;
                                        case "TypeIndex1": try { this.MyParameter.ChannelSetting[0].DisplayType = Convert.ToInt32(data_value); } catch { this.MyParameter.ChannelSetting[0].DisplayType = 0; } break;
                                        case "SpecificationIndex2": try { this.MyParameter.ChannelSetting[1].DisplaySpecification = Convert.ToInt32(data_value); } catch { this.MyParameter.ChannelSetting[1].DisplaySpecification = 0; } break;
                                        case "TypeIndex2": try { this.MyParameter.ChannelSetting[1].DisplayType = Convert.ToInt32(data_value); } catch { this.MyParameter.ChannelSetting[1].DisplayType = 0; } break;
                                        case "SpecificationIndex3": try { this.MyParameter.ChannelSetting[2].DisplaySpecification = Convert.ToInt32(data_value); } catch { this.MyParameter.ChannelSetting[2].DisplaySpecification = 0; } break;
                                        case "TypeIndex3": try { this.MyParameter.ChannelSetting[2].DisplayType = Convert.ToInt32(data_value); } catch { this.MyParameter.ChannelSetting[2].DisplayType = 0; } break;
                                        case "SpecificationIndex4": try { this.MyParameter.ChannelSetting[3].DisplaySpecification = Convert.ToInt32(data_value); } catch { this.MyParameter.ChannelSetting[3].DisplaySpecification = 0; } break;
                                        case "TypeIndex4": try { this.MyParameter.ChannelSetting[3].DisplayType = Convert.ToInt32(data_value); } catch { this.MyParameter.ChannelSetting[3].DisplayType = 0; } break;

                                        case "KeyPhasorNumber": try { keyphasorNumber = Convert.ToInt32(data_value); } catch { keyphasorNumber = 0; } break;
                                        case "KeyPhasorEndNumber": try { keyphasorEndNumber = Convert.ToInt32(data_value); } catch { keyphasorEndNumber = 0; } break;
                                    }
                                }
                                else if (dataarray[0] == "Data:")
                                    bStart = true;
                                else if (dataarray[0] == "KeyPhasorData:")
                                    bStart2 = true;
                                else if (dataarray[0] == "KeyPhasorEndData:")
                                    bStart3 = true;
                            }
                        }
                        else if (bStart)
                        {
                            data.Add(lineString);
                            if (++datacount >= dataNumber) bStart = false;
                        }
                        else if (bStart2)
                        {
                            data2.Add(lineString);
                            if (++kpdatacount >= keyphasorNumber) bStart2 = false;
                        }
                        else if (bStart3)
                        {
                            data3.Add(lineString);
                            if (++kpenddatacount >= keyphasorEndNumber) bStart3 = false;
                        }
                    }
                }

                fs.Close();
            }

            if (data.Count > 0)
            {
                this.ExecutingProgramName = "Load Data From File";
                //VoltageValue = new double[data.Count];
                int datacount = data.Count / 4;
                this.CheckNumberForU2405((uint)datacount);

                for (int j = 0; j < VoltageValue.Length; j++)
                {
                    for (int i = 0; i < datacount; i++)
                        VoltageValue[j][i] = Convert.ToDouble(data[i + j * datacount]);
                }

                int[] keyphasorbuffer = new int[data2.Count];
                int[] keyphasorendbuffer = null;
                if (data3.Count <= 0)
                    keyphasorendbuffer = new int[data2.Count];
                else
                {
                    keyphasorendbuffer = new int[data3.Count];
                    for(int i=0;i<keyphasorendbuffer.Length;i++)
                        keyphasorendbuffer[i] = Convert.ToInt32(data3[i]);
                }
                for (int i = 0; i < keyphasorbuffer.Length; i++)
                {
                    keyphasorbuffer[i] = Convert.ToInt32(data2[i]);
                    if ((data3.Count <= 0) && (i < keyphasorendbuffer.Length - 1))
                        keyphasorendbuffer[i] = Convert.ToInt32(data2[i + 1]);
                }
                
                this.KeyPhasorList = keyphasorbuffer;
                this.KeyPhasorEndList = keyphasorendbuffer;
                this.LoadedRPM = loadedRPM;

                FFT();
            }
        }

        #endregion

    }
}
