using UnitTestLibrary;

namespace TheaterTest13
{
    /// <summary>
    /// Test cases.
    /// </summary>
    public class TheaterTestBase : TestBase
    {
        /// <summary>
        /// Initializes a new instance of the TheaterTestBase class.
        /// </summary>
        public TheaterTestBase()
        {
            this.RegisterTypes(
                "ConcessionItems.ConcessionItem",
                "ConcessionItems.Popcorn",
                "ConcessionItems.SodaCup",
                "MoneyCollectors.IMoneyCollector",
                "MoneyCollectors.MoneyCollector",
                "Stands.MoneyCollectingStand",
                "Stands.PopcornStand",
                "Stands.SodaCupStand",
                "Stands.SodaStand",
                "Stands.Stand",
                "TheaterEngine.Guest",
                "TheaterEngine.Movie",
                "TheaterEngine.ScreeningRoom",
                "TheaterEngine.Theater",
                "TheaterEngine.Wallet",
                "TheaterScenario.MainWindow"
                );
        }

        /// <summary>
        /// Creates an instance of the MainWindow and creates and configures the theater.
        /// </summary>
        /// <returns>An instance of the MainWindow class.</returns>
        protected object CreateWindow()
        {
            object mainWindow = this.CreateObject("MainWindow");

            return mainWindow;
        }
    }
}