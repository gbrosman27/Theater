using System.Collections.Generic;
using ConcessionItems;
using MoneyCollectors;
using Stands;

namespace TheaterEngine
{
    /// <summary>
    /// The class which is used to represent a theater.
    /// </summary>
    public class Theater
    {
        /// <summary>
        /// The theater's list of guests.
        /// </summary>
        private List<Guest> guests;

        /// <summary>
        /// The theater's current list of movies.
        /// </summary>
        private List<Movie> movies;

        /// <summary>
        /// The name of the theater.
        /// </summary>
        private string name;

        /// <summary>
        /// The theater's popcorn stand.
        /// </summary>
        private PopcornStand popcornStand;

        /// <summary>
        /// The theater's screening room 1.
        /// </summary>
        private ScreeningRoom screeningRoom;

        /// <summary>
        /// The theater's soda cup stand.
        /// </summary>
        private SodaCupStand sodaCupStand;

        /// <summary>
        /// The theater's soda stand.
        /// </summary>
        private SodaStand sodaStand;

        /// <summary>
        /// Initializes a new instance of the Theater class.
        /// </summary>
        /// <param name="name">The theater's name.</param>
        /// <param name="screeningRoom">The theater's screening room.</param>
        /// <param name="moneyBoxInitialMoneyBalance">The initial money balance of the theater's money collector.</param>
        /// <param name="popcornPrice">The price of a bag of popcorn.</param>
        /// <param name="sodaCupPrice">The price of a cup of soda.</param>
        public Theater(string name, ScreeningRoom screeningRoom, decimal moneyBoxInitialMoneyBalance, decimal popcornPrice, decimal sodaCupPrice)
        {
            this.guests = new List<Guest>();
            this.movies = new List<Movie>();
            this.name = name;
            this.screeningRoom = screeningRoom;

            MoneyCollector moneyBox = new MoneyCollector(moneyBoxInitialMoneyBalance);
            this.popcornStand = new PopcornStand(popcornPrice, moneyBox);
            this.sodaCupStand = new SodaCupStand(sodaCupPrice, moneyBox);
            this.sodaStand = new SodaStand();
        }

        /// <summary>
        /// Gets the average runtime of all of the theater's movies.
        /// </summary>
        public double AverageMovieRuntime
        {
            get
            {
                // Define an accumulator variable.
                int totalRuntime = 0;

                // For each movie in the list
                foreach (Movie m in this.movies)
                {
                    // Add the movie's runtime to the accumulator variable
                    totalRuntime += m.Runtime;
                }

                // Find the average runtime and return it
                return totalRuntime / this.movies.Count;
            }
        }

        /// <summary>
        /// Gets the theater's guest collection.
        /// </summary>
        public IEnumerable<Guest> Guests
        {
            get
            {
                return this.guests;
            }
        }

        /// <summary>
        /// Gets the theater's movies collection.
        /// </summary>
        public IEnumerable<Movie> Movies
        {
            get
            {
                return this.movies;
            }
        }

        /// <summary>
        /// Gets the name of the theater.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets the theater's popcorn stand.
        /// </summary>
        public PopcornStand PopcornStand
        {
            get
            {
                return this.popcornStand;
            }
        }

        /// <summary>
        /// Gets screening room 1.
        /// </summary>
        public ScreeningRoom ScreeningRoom
        {
            get
            {
                return this.screeningRoom;
            }
        }

        /// <summary>
        /// Gets the theater's soda cup stand.
        /// </summary>
        public SodaCupStand SodaCupStand
        {
            get
            {
                return this.sodaCupStand;
            }
        }

        /// <summary>
        /// Gets the theater's soda stand.
        /// </summary>
        public SodaStand SodaStand
        {
            get
            {
                return this.sodaStand;
            }
        }

        /// <summary>
        /// The new theater.
        /// </summary>
        /// <returns>Returns the new theater.</returns>
        public static Theater NewTheater()
        {
            Theater theater;

            // Create the screening room.
            ScreeningRoom screeningRoom = new ScreeningRoom(true, 78);

            // Create Marcus Theater.
            theater = new Theater("Marcus Theater", screeningRoom, 450m, 5m, 4m);

            // Create and add the first guest.
            theater.AddGuest(new Guest(26, "The Godfather", SodaFlavor.PrDepper, new Wallet(WalletColor.Salmon, 12m)));

            // Create and add the second guest.
            theater.AddGuest(new Guest(34, "August Rush", SodaFlavor.Dolt, new Wallet(WalletColor.Brown, 15m)));

            // Create and add "The Godfather."
            theater.AddMovie(new Movie(false, MovieRating.R, 175, "The Godfather"));

            // Create and add "Despicable Me."
            theater.AddMovie(new Movie(true, MovieRating.Pg, 95, "Despicable Me"));

            return theater;
        }

        /// <summary>
        /// Adds a guest to the theater's list of guests.
        /// </summary>
        /// <param name="guest">The guest to add.</param>
        public void AddGuest(Guest guest)
        {
            this.guests.Add(guest);
        }

        /// <summary>
        /// Adds a movie to the theater's list of movies.
        /// </summary>
        /// <param name="movie">The movie to add.</param>
        public void AddMovie(Movie movie)
        {
            this.movies.Add(movie);
        }
    }
}