using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRE
{
    public partial class MainProcess
    {
        #region property

        public bool IsRegister { get { return bRegisterFlag; } }
        public int RegisterCardNumber
        {
            get
            {
                int result = 0;

                if (bU2405RegisterFlag) result++;
                if (bVK701RegisterFlag) result++;

                return result;
            }
        }

        #endregion

    }
}
