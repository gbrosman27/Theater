namespace Stands
{
    /// <summary>
    /// The class that represents a stand.
    /// </summary>
    public abstract class Stand
    {
        /// <summary>
        /// The number of items sold.
        /// </summary>
        private int itemCountSold;

        /// <summary>
        /// The type of the item.
        /// </summary>
        private string itemType;

        /// <summary>
        /// Initializes a new instance of the Stand class.
        /// </summary>
        /// <param name="itemType">The type of the item.</param>
        public Stand(string itemType)
        {
            this.itemType = itemType;
        }

        /// <summary>
        /// Gets the number of items sold.
        /// </summary>
        public int ItemCountSold
        {
            get
            {
                return this.itemCountSold;
            }
        }

        /// <summary>
        /// Gets the type of item.
        /// </summary>
        public string ItemType
        {
            get
            {
                return this.itemType;
            }
        }
    }
}