using System;
using System.Collections.Generic;
using ConcessionItems;
using Stands;

namespace TheaterEngine
{
    /// <summary>
    /// The class that represents a guest.
    /// </summary>
    public class Guest
    {
        /// <summary>
        /// The guest's age.
        /// </summary>
        private int age;

        /// <summary>
        /// The guest's list of purchased concession items.
        /// </summary>
        private List<ConcessionItem> concessionItems;

        /// <summary>
        /// The title of the movie the guest wants to see.
        /// </summary>
        private string desiredMovieTitle;

        /// <summary>
        /// The guest's list of movies seen.
        /// </summary>
        private List<Movie> moviesSeen;

        /// <summary>
        /// The guest's preferred soda flavor.
        /// </summary>
        private SodaFlavor preferredSodaFlavor;

        /// <summary>
        /// The guest's wallet.
        /// </summary>
        private Wallet wallet;

        /// <summary>
        /// Initializes a new instance of the Guest class.
        /// </summary>
        /// <param name="age">The guest's age.</param>
        /// <param name="desiredMovieTitle">The title of the movie the guest wants to see.</param>
        /// <param name="preferredSodaFlavor">The guest's preferred soda flavor.</param>
        /// <param name="wallet">The guest's wallet.</param>
        public Guest(int age, string desiredMovieTitle, SodaFlavor preferredSodaFlavor, Wallet wallet)
        {
            this.age = age;
            this.concessionItems = new List<ConcessionItem>();
            this.desiredMovieTitle = desiredMovieTitle;
            this.moviesSeen = new List<Movie>();
            this.preferredSodaFlavor = preferredSodaFlavor;
            this.wallet = wallet;
        }

        /// <summary>
        /// Gets or sets the guest's age.
        /// </summary>
        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value >= 0 && value <= 120)
                {
                    this.age = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Age", "The age must be between 0 and 120.");
                }
            }
        }

        /// <summary>
        /// Gets or sets the title of the movie the guest wants to see.
        /// </summary>
        public string DesiredMovieTitle
        {
            get
            {
                return this.desiredMovieTitle;
            }

            set
            {
                if (value.Length >= 1 && value.Length <= 100)
                {
                    this.desiredMovieTitle = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Movie Title Length", "The movie title length must be between 1 and 100 characters.");
                }
            }
        }

        /// <summary>
        /// Gets the guest's wallet's money balance.
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                return this.wallet.MoneyBalance;
            }
        }

        /// <summary>
        /// Gets or sets the guest's preferred soda flavor.
        /// </summary>
        public SodaFlavor PreferredSodaFlavor
        {
            get
            {
                return this.preferredSodaFlavor;
            }

            set
            {
                this.preferredSodaFlavor = value;
            }
        }

        /// <summary>
        /// Gets the guest's wallet.
        /// </summary>
        public Wallet Wallet
        {
            get
            {
                return this.wallet;
            }
        }

        /// <summary>
        /// Adds a movie to the guest's list of movies seen.
        /// </summary>
        /// <param name="movie">The movie to add.</param>
        public void AddMovieSeen(Movie movie)
        {
            this.moviesSeen.Add(movie);
        }

        /// <summary>
        /// Buys concessions.
        /// </summary>
        /// <param name="popcornStand">The stand from which to purchase popcorn.</param>
        /// <param name="sodaCupStand">The stand from which to purchase a soda cup.</param>
        /// <param name="sodaStand">The stand from which to fill a soda cup.</param>
        public void BuyConcessions(PopcornStand popcornStand, SodaCupStand sodaCupStand, SodaStand sodaStand)
        {
            // Buy popcorn
            Popcorn popcorn = this.BuyPopcorn(popcornStand);

            popcorn.AddButter();
            popcorn.AddSalt();
            popcorn.AddSalt();
            this.concessionItems.Add(popcorn);

            // Buy soda
            SodaCup sodaCup = this.BuySoda(sodaCupStand, sodaStand);
            this.concessionItems.Add(sodaCup);

            foreach (ConcessionItem ci in this.concessionItems)
            {
                ci.Consume();
            }
        }

        /// <summary>
        /// Creates a string representation of a guest.
        /// </summary>
        /// <returns>The specified string.</returns>
        public override string ToString()
        {
            return $"Wants to see: {this.DesiredMovieTitle} (Age: {this.Age})";
        }

        /// <summary>
        /// Buys a bag of popcorn.
        /// </summary>
        /// <param name="popcornStand">The stand from which to purchase the popcorn.</param>
        /// <returns>The bag of popcorn.</returns>
        private Popcorn BuyPopcorn(PopcornStand popcornStand)
        {
            // Define result variable.
            Popcorn result = null;

            // Get the price.
            decimal popcornPrice = popcornStand.ItemPrice;

            decimal popcornPayment = this.wallet.RemoveMoney(popcornPrice);

            result = popcornStand.BuyPopcorn(popcornPayment);

            // Return result
            return result;
        }

        /// <summary>
        /// Buys a cup of soda.
        /// </summary>
        /// <param name="sodaCupStand">The stand from which to purchase the cup.</param>
        /// <param name="sodaStand">The stand from which to purchase the soda.</param>
        /// <returns>The cup of soda.</returns>
        private SodaCup BuySoda(SodaCupStand sodaCupStand, SodaStand sodaStand)
        {
            // Define result variable
            SodaCup result = null;

            // Get the price.
            decimal sodaCupPrice = sodaCupStand.ItemPrice;

            decimal sodaCupPayment = this.wallet.RemoveMoney(sodaCupPrice);

            result = sodaCupStand.BuySodaCup(sodaCupPayment);

            this.FillSoda(result, sodaStand);

            // Return result
            return result;
        }

        /// <summary>
        /// Fills a soda cup.
        /// </summary>
        /// <param name="sodaCup">The cup to fill.</param>
        /// <param name="sodaStand">The stand from which to fill the cup.</param>
        private void FillSoda(SodaCup sodaCup, SodaStand sodaStand)
        {
            // Fill the soda cup
            sodaStand.FillSodaCup(sodaCup, this.preferredSodaFlavor);
        }
    }
}