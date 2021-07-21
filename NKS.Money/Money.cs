using System.Collections.Generic;

namespace NKS.Money
{
    public class Money : IMoney
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public void SetAmount(decimal amount)
        {
            Amount = amount;
        }
    }
}

