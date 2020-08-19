using MoneyCollectors;

namespace Stands
{
    /// <summary>
    /// The class that represents a money collecting stand.
    /// </summary>
    public class MoneyCollectingStand : Stand, IMoneyCollector
    {
        /// <summary>
        /// The price of an item.
        /// </summary>
        private decimal itemPrice;

        /// <summary>
        /// The stand's money collector.
        /// </summary>
        private IMoneyCollector moneyBox;

        /// <summary>
        /// Initializes a new instance of the MoneyCollectingStand class.
        /// </summary>
        /// <param name="itemPrice">The price of an item.</param>
        /// <param name="itemType">The type of an item.</param>
        /// <param name="moneyBox">The money collecting stand's money box.</param>
        public MoneyCollectingStand(decimal itemPrice, string itemType, IMoneyCollector moneyBox)
            : base(itemType)
        {
            this.itemPrice = itemPrice;
            this.moneyBox = moneyBox;
        }

        /// <summary>
        /// Gets the money collecting stand's item price.
        /// </summary>
        public decimal ItemPrice
        {
            get
            {
                return this.itemPrice;
            }
        }

        /// <summary>
        /// Gets the money collecting stand's money balance.
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                return this.moneyBox.MoneyBalance;
            }
        }

        /// <summary>
        /// Adds the specified amount of money.
        /// </summary>
        /// <param name="amountToAdd">The amount to add.</param>
        public void AddMoney(decimal amountToAdd)
        {
            // Add the money to the money box
            this.moneyBox.AddMoney(amountToAdd);
        }

        /// <summary>
        /// Removes the specified amount of money.
        /// </summary>
        /// <param name="amountToRemove">The amount to remove.</param>
        /// <returns>The amount removed.</returns>
        public decimal RemoveMoney(decimal amountToRemove)
        {
            // Remove the amount from the money box
            decimal result = this.moneyBox.RemoveMoney(amountToRemove);

            // Return result
            return result;
        }
    }
}