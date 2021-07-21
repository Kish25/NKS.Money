/*
 *  easyJet Interview Assessment
 *  ============================
 *
 *  Money - Candidate Instructions
 *  ------------------------------
 *
 *  Provide a working solution containing implementations of the following interfaces,
 *  with tests demonstrating their correctness.
 *  Use whatever tools and .NET versions you have available.
 */

    
using System.Collections.Generic;

namespace NKS.Money
{
    /// <summary>
    /// Some fun things to do with money.
    /// </summary>
    public interface IMoneyCalculator
    {
        /// <summary>
        /// Find the largest amount of money.
        /// </summary>
        /// <returns>
        ///     The <see cref="IMoney"/> instance having the largest amount.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// All monies are not in the same currency.</exception>
        /// <example>{GBP10, GBP20, GBP50} => {GBP50}</example>
        /// <example>{GBP10, GBP20, EUR50} => exception</example>
        IMoney Max(IEnumerable<IMoney> monies);

        /// <summary>
        /// Return one <see cref="IMoney"/> per currency with the sum of all monies of the same currency.
        /// </summary>
        /// <example>{GBP10, GBP20, GBP50} => {GBP80}</example>
        /// <example>{GBP10, GBP20, EUR50} => {GBP30, EUR50}</example>
        /// <example>{GBP10, USD20, EUR50} => {GBP10, USD20, EUR50}</example>
        IEnumerable<IMoney> SumPerCurrency(IEnumerable<IMoney> monies);
    }
}

