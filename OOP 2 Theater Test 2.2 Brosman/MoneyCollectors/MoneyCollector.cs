namespace MoneyCollectors
{
    /// <summary>
    /// The class that represents something that collects money.
    /// </summary>
    public class MoneyCollector : IMoneyCollector
    {
        /// <summary>
        /// The money collector's  money balance.
        /// </summary>
        private decimal moneyBalance;

        /// <summary>
        /// Initializes a new instance of the MoneyCollector class.
        /// </summary>
        /// <param name="initialMoneyBalance">The money collector's initial money balance.</param>
        public MoneyCollector(decimal initialMoneyBalance)
        {
            this.moneyBalance = initialMoneyBalance;
        }

        /// <summary>
        /// Gets the money collector's money balance.
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                return this.moneyBalance;
            }
        }

        /// <summary>
        /// Adds the specified amount of money.
        /// </summary>
        /// <param name="amountToAdd">The amount to add.</param>
        public void AddMoney(decimal amountToAdd)
        {
            // Add the money to the money balance
            this.moneyBalance += amountToAdd;
        }

        /// <summary>
        /// Removes the specified amount of money.
        /// </summary>
        /// <param name="amountToRemove">The amount to remove.</param>
        /// <returns>The amount removed.</returns>
        public decimal RemoveMoney(decimal amountToRemove)
        {
            // Define and initialize a result variable.
            decimal result = 0m;

            // If there is enough money in the wallet...
            if (this.moneyBalance >= amountToRemove)
            {
                // Return the requested amount.
                result = amountToRemove;
            }
            else
            {
                // Return all that is left.
                result = this.moneyBalance;
            }

            // Subtract the amount of money returned from the wallet.
            this.moneyBalance -= result;

            // Return result.
            return result;
        }
    }
}