namespace MoneyCollectors
{
    /// <summary>
    /// The interface that defines a contract for all things that collect money.
    /// </summary>
    public interface IMoneyCollector
    {
        /// <summary>
        /// Gets the money collector's money balance.
        /// </summary>
        decimal MoneyBalance
        {
            get;
        }

        /// <summary>
        /// Adds the specified amount of money.
        /// </summary>
        /// <param name="amountToAdd">The amount to add.</param>
        void AddMoney(decimal amountToAdd);

        /// <summary>
        /// Removes the specified amount of money.
        /// </summary>
        /// <param name="amountToRemove">The amount to remove.</param>
        /// <returns>The amount removed.</returns>
        decimal RemoveMoney(decimal amountToRemove);
    }
}