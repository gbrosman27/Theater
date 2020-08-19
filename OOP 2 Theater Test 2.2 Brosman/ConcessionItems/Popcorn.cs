namespace ConcessionItems
{
    /// <summary>
    /// The class that represents popcorn.
    /// </summary>
    public class Popcorn : ConcessionItem
    {
        /// <summary>
        /// An indicator of whether or not the popcorn is buttered.
        /// </summary>
        private bool isButtered;

        /// <summary>
        /// The amount of salt on the popcorn.
        /// </summary>
        private int saltLevel;

        /// <summary>
        /// Initializes a new instance of the Popcorn class.
        /// </summary>
        public Popcorn()
            : base()
        {
            this.Level = 100;
        }

        /// <summary>
        /// Gets a value indicating whether or not the popcorn is buttered.
        /// </summary>
        public bool IsButtered
        {
            get
            {
                return this.isButtered;
            }
        }

        /// <summary>
        /// Gets a value indicating whether or not the popcorn is salted.
        /// </summary>
        public bool IsSalted
        {
            get
            {
                if (this.saltLevel > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets the amount of salt on the popcorn.
        /// </summary>
        public int SaltLevel
        {
            get
            {
                return this.saltLevel;
            }
        }

        /// <summary>
        /// Adds butter to the popcorn.
        /// </summary>
        public void AddButter()
        {
            // Set is buttered flag to true
            this.isButtered = true;
        }

        /// <summary>
        /// Adds salt to the popcorn.
        /// </summary>
        public void AddSalt()
        {
            // Increase salt level
            this.saltLevel += 1;
        }

        /// <summary>
        /// Consumes the popcorn.
        /// </summary>
        public override void Consume()
        {
            // Reduce level of popcorn.
            this.Level -= 10;
        }
    }
}