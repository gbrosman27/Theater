using System;
using ConcessionItems;
using MoneyCollectors;

namespace Stands
{
    /// <summary>
    /// The class that represents a soda cup stand.
    /// </summary>
    public class SodaCupStand : MoneyCollectingStand
    {
        /// <summary>
        /// Initializes a new instance of the SodaCupStand class.
        /// </summary>
        /// <param name="itemPrice">The price of an item.</param>
        /// <param name="moneyBox">The soda cup stand's money collector.</param>
        public SodaCupStand(decimal itemPrice, IMoneyCollector moneyBox)
            : base(itemPrice, "Soda cup", moneyBox)
        {
        }

        /// <summary>
        /// Buys a cup of soda.
        /// </summary>
        /// <param name="payment">The amount paid for the soda.</param>
        /// <returns>A cup of soda.</returns>
        public SodaCup BuySodaCup(decimal payment)
        {
            // Define result variable
            SodaCup result = null;

            if (payment >= this.ItemPrice)
            {
                this.AddMoney(payment);
                result = new SodaCup();
            }
            else
            {
                throw new Exception("Not enough money to buy a soda cup.");
            }

            // Return result
            return result;
        }
    }
}