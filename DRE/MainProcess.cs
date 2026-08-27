using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRE
{
    public delegate void delMainProcessDisposeEvent();

    public partial class MainProcess:IDisposable
    {
        // field
        #region field

        public Parameter MyParameter = new Parameter();

        public bool bGraphRefreshStop = false;

        public List<XYZDataDto> XYZData = new List<XYZDataDto>();

        #endregion

        // event
        #region event

        public delMainProcessDisposeEvent MainProcessDisposeEventList;

        #endregion


        // destructor
        #region destructor

        ~MainProcess()
        {
            Dispose(false);
        }

        #endregion

        // IDispose
        #region IDispose

        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
                return;

            MainProcessDisposeEventList();

            

            this.disposed = true;
        }

        #endregion
    }

    public class XYZDataDto
    {
        public double[] X_Value = null;
        public double[] Y_Value = null;
        public double[] Z_Value = null;
        public string Title = "";

        public XYZDataDto() { }
        public XYZDataDto(double[] x_values, double[] y_values, double[] z_values, string title)
        {
            this.Title = title;

            if (x_values == null) this.X_Value = null; else { this.X_Value = new double[x_values.Length]; Array.Copy(x_values, this.X_Value, this.X_Value.Length); }
            if (y_values == null) this.Y_Value = null; else { this.Y_Value = new double[y_values.Length]; Array.Copy(y_values, this.Y_Value, this.Y_Value.Length); }
            if (z_values == null) this.Z_Value = null; else { this.Z_Value = new double[z_values.Length]; Array.Copy(z_values, this.Z_Value, this.Z_Value.Length); }
        }

        public void Copy(XYZDataDto data)
        {
            if (data.X_Value == null) this.X_Value = null; else{ this.X_Value = new double[data.X_Value.Length]; Array.Copy(data.X_Value, this.X_Value, this.X_Value.Length); }
            if (data.Y_Value == null) this.Y_Value = null; else { this.Y_Value = new double[data.Y_Value.Length]; Array.Copy(data.Y_Value, this.Y_Value, this.Y_Value.Length); }
            if (data.Z_Value == null) this.Z_Value = null; else { this.Z_Value = new double[data.Z_Value.Length]; Array.Copy(data.Z_Value, this.Z_Value, this.Z_Value.Length); }

            this.Title = data.Title;
        }
        
    }
}
