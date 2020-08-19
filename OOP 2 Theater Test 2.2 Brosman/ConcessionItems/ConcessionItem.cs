namespace ConcessionItems
{
    /// <summary>
    /// The class that represents a concession item.
    /// </summary>
    public abstract class ConcessionItem
    {
        /// <summary>
        /// The level of the concession item.
        /// </summary>
        private double level;

        /// <summary>
        /// Gets or sets the level of the concession item.
        /// </summary>
        protected double Level
        {
            get
            {
                return this.level;
            }

            set
            {
                this.level = value;
            }
        }

        /// <summary>
        /// Consumes the concession item.
        /// </summary>
        public abstract void Consume();
    }
}