using System;
using ConcessionItems;
using MoneyCollectors;

namespace Stands
{
    /// <summary>
    /// The class that represents a popcorn stand.
    /// </summary>
    public class PopcornStand : MoneyCollectingStand
    {
        /// <summary>
        /// Initializes a new instance of the PopcornStand class.
        /// </summary>
        /// <param name="itemPrice">The price of an item.</param>
        /// <param name="moneyBox">The stand's money collector.</param>
        public PopcornStand(decimal itemPrice, IMoneyCollector moneyBox)
            : base(itemPrice, "Popcorn", moneyBox)
        {
        }

        /// <summary>
        /// Buys a bag of popcorn.
        /// </summary>
        /// <param name="payment">The amount paid for the popcorn.</param>
        /// <returns>A bag of popcorn.</returns>
        public Popcorn BuyPopcorn(decimal payment)
        {
            // Define result variable
            Popcorn result = null;

            if (payment == this.ItemPrice)
            {
                this.AddMoney(payment);
                result = new Popcorn();
            }
            else
            {
                throw new Exception("Not enough money to buy popcorn.");
            }
     
            // Return result
            return result;
        }
    }
}