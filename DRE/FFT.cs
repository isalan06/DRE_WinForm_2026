using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DSPLib;
using System.Numerics;

namespace DRE
{
    public partial class MainProcess
    {
        Complex[] cpxResult = null;
        public double[][] magResult = new double[][] { new double[1024], new double[1024], new double[1024], new double[1024] };
        public double[][] amplitudeResult = new double[][] { new double[1024], new double[1024], new double[1024], new double[1024] };
        public double[][] magLogResult = new double[][] { new double[1024], new double[1024], new double[1024], new double[1024] };
        public double[][] phaseRadians = new double[][] { new double[1024], new double[1024], new double[1024], new double[1024] };
        public double[][] phaseDegrees = new double[][] { new double[1024], new double[1024], new double[1024], new double[1024] };

        public double[][] fSpan = new double[][] { new double[1024], new double[1024], new double[1024], new double[1024] };
        public double[][] mag = new double[][] { new double[1024], new double[1024], new double[1024], new double[1024] };
        public double[][] magLog = new double[][] { new double[1024], new double[1024], new double[1024], new double[1024] };

        Complex[][] cpxMutliResult = null;

        public void FFT()
        {
            for (int i = 0; i < 4; i++)
            {

                DSPLib.FFT fft = new DSPLib.FFT();
                //DSPLib.DFT fft = new DSPLib.DFT();

                fft.Initialize((uint)VoltageValue[i].Length, dwZeroPadding);
                //fft.Initialize((uint)VoltageValue[i].Length);

                cpxResult = fft.Execute(VoltageValue[i]);

                magResult[i] = DSP.ConvertComplex.ToMagnitude(cpxResult);
                amplitudeResult[i] = new double[magResult[i].Length];

                for (int bin = 0; bin < magResult[i].Length; bin++)
                {
                    bool isDc = bin == 0;
                    bool isNyquist = bin == magResult[i].Length - 1;

                    amplitudeResult[i][bin] = isDc || isNyquist
                        ? magResult[i][bin]
                        : magResult[i][bin] * Math.Sqrt(2.0);
                }

                magLogResult[i] = DSP.ConvertMagnitude.ToMagnitudeDBV(magResult[i]);

                phaseRadians[i] = DSP.ConvertComplex.ToPhaseRadians(cpxResult);
                phaseDegrees[i] = DSP.ConvertComplex.ToPhaseDegrees(cpxResult);

                // Calculate the frequency span
                fSpan[i] = fft.FrequencySpan(MyParameter.CaptureSetting.SamplingRate);

                // Convert and Plot Log Magnitude
                //mag[i] = DSP.ConvertComplex.ToMagnitude(cpxResult);
                //magLog[i] = DSP.ConvertMagnitude.ToMagnitudeDBV(mag[i]);
            }

        }

        
    }
}
