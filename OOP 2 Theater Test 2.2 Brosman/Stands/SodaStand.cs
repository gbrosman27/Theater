using ConcessionItems;

namespace Stands
{
    /// <summary>
    /// The class that represents a soda stand.
    /// </summary>
    public class SodaStand : Stand
    {
        /// <summary>
        /// Initializes a new instance of the SodaStand class.
        /// </summary>
        public SodaStand()
            : base("Soda")
        {
        }

        /// <summary>
        /// Fills a cup of soda.
        /// </summary>
        /// <param name="sodaCup">The cup to fill.</param>
        /// <param name="flavor">The soda flavor with which to fill the cup.</param>
        public void FillSodaCup(SodaCup sodaCup, SodaFlavor flavor)
        {
            // Fill the soda cup
            sodaCup.Fill(flavor);
        }
    }
}