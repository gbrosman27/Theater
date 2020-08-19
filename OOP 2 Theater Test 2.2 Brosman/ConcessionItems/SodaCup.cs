namespace ConcessionItems
{
    /// <summary>
    /// The class that represents a soda cup.
    /// </summary>
    public class SodaCup : ConcessionItem
    {
        /// <summary>
        /// The flavor of the soda in the cup.
        /// </summary>
        private SodaFlavor flavor;

        /// <summary>
        /// Fills the soda cup with the specified flavor of soda.
        /// </summary>
        /// <param name="flavor">The flavor of soda with which to fill the cup.</param>
        public void Fill(SodaFlavor flavor)
        {
            this.flavor = flavor;
            this.Level = 100;
        }

        /// <summary>
        /// Consumes the soda.
        /// </summary>
        public override void Consume()
        {
            // Reduce soda level
            this.Level -= 10;
        }
    }
}