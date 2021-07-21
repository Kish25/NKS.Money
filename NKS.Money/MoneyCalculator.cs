using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;
using NKS.Money;
using NKS.Money.Exceptions;

namespace NKS.Money
{
    public class MoneyCalculator : IMoneyCalculator
    {
        public IMoney Max(IEnumerable<IMoney> monies)
        {
            ValidateParameters(monies);

            if (GetCurrencyCount(monies) > 1 )
                throw new MixCurrencyException("All monies are not in the same currency.");

            var items = monies
                .GroupBy(amount => amount.Amount);

            if (items.Count() < 2)
                throw new SameValueException("List contains same amount for currency.");


            var money = monies
                .OrderByDescending(m => m.Amount)
                .FirstOrDefault();
               
            return money;
        }

        public IEnumerable<IMoney> SumPerCurrency(IEnumerable<IMoney> monies)
        {
            ValidateParameters(monies);

            
            return monies
                .GroupBy(currency => currency.Currency)
                .Select(ms => new Money()
                    {
                    Currency=ms.Key,
                    Amount = ms.Sum(s=>s.Amount)
                    }
                ).ToList();
        }

        private static int GetCurrencyCount(IEnumerable<IMoney> monies)
        {
            return monies
                .GroupBy(g => g.Currency)
                .Count();
        }

        private static void ValidateParameters(IEnumerable<IMoney> monies)
        {
            if (monies == null)
                throw new ArgumentNullException("Parameter value is missing.");

            if (monies.Count() == 0)
                throw new MissingItemsException("Needs at least single currency and value.");
        }
    }
}


