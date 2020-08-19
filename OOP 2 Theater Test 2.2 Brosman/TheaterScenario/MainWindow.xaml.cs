using System;
using System.Windows;
using ConcessionItems;
using MoneyCollectors;
using Stands;
using TheaterEngine;

namespace TheaterScenario
{
    /// <summary>
    /// Contains interaction logic for MainWindow.xaml.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Event handlers may begin with lower-case letters.")]
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The Marcus Theater.
        /// </summary>
        private Theater marcusTheater;

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The event that initially loads the window.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            // Create a new theater.
            this.marcusTheater = Theater.NewTheater();

            // Loads the list boxes.
            this.PopulateMovieListBox();
            this.PopulateGuestListBox();
        }

        /// <summary>
        /// Populates the movie list box.
        /// </summary>
        private void PopulateMovieListBox()
        {
            movieListBox.ItemsSource = null;
            movieListBox.ItemsSource = this.marcusTheater.Movies;
        }

        /// <summary>
        /// Populates the guest list box.
        /// </summary>
        private void PopulateGuestListBox()
        {
            guestListBox.ItemsSource = null;
            guestListBox.ItemsSource = this.marcusTheater.Guests;
        }

        /// <summary>
        /// The event that initially loads the movie list box.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void movieListBox_Loaded(object sender, RoutedEventArgs e)
        {            
        }

        /// <summary>
        /// The event that initially loads the guest list box.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void guestListBox_Loaded(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// Add a movie to the list box.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void addMovieButton_Click(object sender, RoutedEventArgs e)
        {
                Movie movie = (Movie)this.movieListBox.SelectedItem;
                movie = new Movie(false, MovieRating.Pg, 90, string.Empty);

                MovieWindow movieWindow = new MovieWindow(movie);

                movieWindow.ShowDialog();

                if (movieWindow.DialogResult == true)
                {
                    this.marcusTheater.AddMovie(movie);
                    this.PopulateMovieListBox();
                }
        }

        /// <summary>
        /// Add a guest to the list box.
        /// </summary>
        /// <param name="sender">The object that initiated the event.</param>
        /// <param name="e">The event arguments for the event.</param>
        private void addGuestButton_Click(object sender, RoutedEventArgs e)
        {
            Guest guest = (Guest)this.guestListBox.SelectedItem;
            guest = new Guest(21, string.Empty, SodaFlavor.Dolt, new Wallet(WalletColor.Black, 20.00m));

            GuestWindow guestWindow = new GuestWindow(guest);

            guestWindow.ShowDialog();

            if (guestWindow.DialogResult == true)
            {
                guest.BuyConcessions(new PopcornStand(8.00m, new MoneyCollector(50.00m)), new SodaCupStand(6.00m, new MoneyCollector(50.00m)), new SodaStand());
                this.marcusTheater.AddGuest(guest);
                this.PopulateGuestListBox();
            }
        }
    }
}