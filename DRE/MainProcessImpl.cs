using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRE
{
    public partial class MainProcess
    {
        // constructor
        #region constructor

        public MainProcess()
        {
            // Parameter
            MyParameter.Load();

            MyInitialFunctionList();
            ConstuctorForU2405();
            ConstuctorForVK701();
        }

        #endregion

        // Initial Function
        #region Initial Function

        private void MyInitialFunctionList()
        {

            // add event for Dispose Function
            MainProcessDisposeEventList += DisposeFunction_Polling;
            MainProcessDisposeEventList += DisposeFunction_U2405;
            MainProcessDisposeEventList += DisposeFunction_Main;
            MainProcessDisposeEventList += DisposeFunction_VK701;
            
        }

        #endregion

        // Main Dispose Function
        #region Main Dispose Function

        private void DisposeFunction_Main()
        {
            // Parameter
            MyParameter.Dispose();

        }

        #endregion
    }
}
