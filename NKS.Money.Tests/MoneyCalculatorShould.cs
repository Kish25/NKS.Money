using System;
using System.Collections.Generic;
using Xunit;
using NKS.Money;
using System.Collections;
using System.Linq;
using FluentAssertions;
using NKS.Money.Exceptions;
using Shouldly;

namespace NKS.Money.Tests
{
    public class MoneyCalculatorShould
    {
        private IMoneyCalculator _moneyCalculator;
        public MoneyCalculatorShould()
        {
            _moneyCalculator = new MoneyCalculator();

        }

        private IEnumerable<IMoney> GetTestData()
        {
            return new List<IMoney>()
            {
                new Money() { Currency = "GBP", Amount = 10.00M },
                new Money() { Currency = "EUR", Amount = 10.00M }
            };
        }

        //[Fact]
        //public void ThrowsNotImplementedException()
        //{
        //    _money = GetTestData();
            
        //    Assert.Throws<NotImplementedException>(() => _moneyCalculator.Max(_money));
        //}
        [Fact]
        public void ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _moneyCalculator.Max(null));
        }

        [Fact]
        public void ThrowsMissingCurrencyException()
        {
            var monies = MoniesWithDefaultValues();

            Assert.Throws<MissingItemsException>(() => _moneyCalculator.Max(monies));
        }

        [Fact]
        public void ThrowsMixCurrencyException()
        {
            var monies = MoniesWithCurrencyGBPAndEUR();

            Assert.Throws<MixCurrencyException>(() => _moneyCalculator.Max(monies));
        }

        [Fact]
        public void ReturnsMaxForGivenCurrency()
        {
            var monies = MoniesWithGbp();

            var money = _moneyCalculator.Max(monies);

            money.ShouldNotBeNull();

            money.Currency.ShouldBe("GBP");
            money.Amount.ShouldBe(50M);
        }

        [Fact]
        public void ThrowsSameValueException()
        {
            var monies = MoniesWithGbpSameAmount();

            Assert.Throws<SameValueException>(() => _moneyCalculator.Max(monies));
        }


        [Fact]
        public void ReturnsSumForSingleGBPCurrency()
        {
            var monies = MoniesWithGbp();

            var moneiesSum = _moneyCalculator.SumPerCurrency(monies);

            moneiesSum.ShouldNotBeNull();
            
            moneiesSum.ShouldContain(sc=>sc.Currency=="GBP");

            var moneyGBP = moneiesSum
                .FirstOrDefault(currency => currency.Currency == "GBP");

            moneyGBP.Amount.ShouldBe(110M);
        }

        [Fact]
        public void ReturnsSumForCurrencyGBPAndEUR()
        {
            var monies = MoniesWithCurrencyGBPAndEUR();

            var moneiesSum = _moneyCalculator.SumPerCurrency(monies);

            moneiesSum.ShouldNotBeNull();
            
            moneiesSum.ShouldContain(sc=>sc.Currency=="GBP");

            var moneyGbp = moneiesSum
                .FirstOrDefault(currency => currency.Currency == "GBP");

            moneyGbp.Amount.ShouldBe(60M);

            moneiesSum.ShouldContain(sc=>sc.Currency=="EUR");
            var moneyEur = moneiesSum
                .FirstOrDefault(currency => currency.Currency == "EUR");

            moneyEur.Amount.ShouldBe(175M);
        }

        public IEnumerable<IMoney> MoniesWithGbp()
        {
            return new List<IMoney>()
            {
                new Money(){Currency = "GBP",Amount = 10M},
                new Money(){Currency = "GBP",Amount = 20M},
                new Money(){Currency = "GBP",Amount = 30M},
                new Money(){Currency = "GBP",Amount = 50M}
            };

        }
        public IEnumerable<IMoney> MoniesWithGbpSameAmount()
        {
            return new List<IMoney>()
            {
                new Money(){Currency = "EUR",Amount = 10M},
                new Money(){Currency = "EUR",Amount = 10M},
            };
            
        }
        public IEnumerable<IMoney> MoniesWithEuro()
        {
            return new List<IMoney>()
            {
                new Money(){Currency = "EUR",Amount = 15M},
                new Money(){Currency = "EUR",Amount = 25M},
                new Money(){Currency = "EUR",Amount = 35M},
                new Money(){Currency = "EUR",Amount = 55M}
            };
            
        }
        public IEnumerable<IMoney> MoniesWithCurrencyGBPAndEUR()
        {
            return new List<IMoney>()
            {
                new Money(){Currency = "GBP",Amount = 10M},
                new Money(){Currency = "GBP",Amount = 20M},
                new Money(){Currency = "GBP",Amount = 30M},
                new Money(){Currency = "EUR",Amount = 25M},
                new Money(){Currency = "EUR",Amount = 50M},
                new Money(){Currency = "EUR",Amount = 100M}
            };
        }
        public IEnumerable<IMoney> MoniesWithDefaultValues()
        {
            return new List<Money>();
        }
    }
}
