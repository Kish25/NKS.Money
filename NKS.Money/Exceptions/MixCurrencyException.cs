using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKS.Money.Exceptions
{
    public class MixCurrencyException : Exception
    {
        public MixCurrencyException(string message):base(message)
        {
            
        }
    }
}
