using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKS.Money.Exceptions
{
    public class MissingItemsException:Exception
    {
        public MissingItemsException(string message) : base(message)
        {
                
        }
    }
}
