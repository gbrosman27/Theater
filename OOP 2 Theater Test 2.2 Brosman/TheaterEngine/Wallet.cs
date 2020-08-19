using System;
using MoneyCollectors;

namespace TheaterEngine
{
    /// <summary>
    /// The class that represents a wallet.
    /// </summary>
    public class Wallet
    {
        /// <summary>
        /// The wallet's color.
        /// </summary>
        private WalletColor color;

        /// <summary>
        /// The wallet's money collector.
        /// </summary>
        private IMoneyCollector moneyPocket;

        /// <summary>
        /// Initializes a new instance of the Wallet class.
        /// </summary>
        /// <param name="color">The wallet's color.</param>
        /// <param name="moneyBalance">The wallet's money balance.</param>
        public Wallet(WalletColor color, decimal moneyBalance)
        {
            this.color = color;
            this.moneyPocket = new MoneyCollector(moneyBalance);
        }

        /// <summary>
        /// Gets or sets the wallet's color.
        /// </summary>
        public WalletColor Color
        {
            get
            {
                return this.color;
            }

            set
            {
                this.color = value;
            }
        }

        /// <summary>
        /// Gets the wallet's money pocket's money balance.
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                return this.moneyPocket.MoneyBalance;
            }
        }

        /// <summary>
        /// Adds the specified amount of money.
        /// </summary>
        /// <param name="amountToAdd">The amount to add.</param>
        public void AddMoney(decimal amountToAdd)
        {
            // Add the money to the money pocket
            this.moneyPocket.AddMoney(amountToAdd);
        }

        /// <summary>
        /// Removes the specified amount of money.
        /// </summary>
        /// <param name="amountToRemove">The amount to remove.</param>
        /// <returns>The amount removed.</returns>
        public decimal RemoveMoney(decimal amountToRemove)
        {
            decimal result;

            if (this.MoneyBalance >= 5.00m)
            {
                // Remove the money from the money pocket
                result = this.moneyPocket.RemoveMoney(amountToRemove);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Not enough money in the wallet to remove amount.");
            }

            // Return result
            return result;
        }
    }
}