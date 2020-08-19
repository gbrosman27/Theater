using System;
using System.Windows;
using System.Windows.Controls;
using TheaterEngine;

namespace TheaterScenario
{
    /// <summary>
    /// Interaction logic for MovieWindow.xaml.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Event handlers may begin with lower-case letters.")]
    public partial class MovieWindow : Window
    {
        /// <summary>
        /// A movie at the theater.
        /// </summary>
        private Movie movie;

        /// <summary>
        /// Initializes a new instance of the MovieWindow class.
        /// </summary>
        /// <param name="movie">The movie created.</param>
        public MovieWindow(Movie movie)
        {
            // Sets the movie field via parameter.
            this.movie = movie;

            this.InitializeComponent();
        }

        /// <summary>
        /// Loads the movie window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void movieWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Set up the text boxes to take input.
            this.titleTextBox.Text = this.movie.Title.ToString();
            this.runtimeTextBox.Text = this.movie.Runtime.ToString();

            // Populate the rating combo box.
            this.ratingComboBox.ItemsSource = Enum.GetValues(typeof(MovieRating));
        }

        /// <summary>
        /// Actions for the movie title text box in the movie window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void titleTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                this.movie.Title = titleTextBox.Text;
                this.okButton.IsEnabled = true;                
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("The movie title must be atleast one character, and no more than 100 characters.");
                this.okButton.IsEnabled = false;
            }
            catch (FormatException)
            {
                MessageBox.Show("A value must be entered.");
                this.okButton.IsEnabled = false;
            }
        }

        /// <summary>
        /// Actions for the runtime text box in the movie window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void runtimeTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                this.movie.Runtime = int.Parse(runtimeTextBox.Text);
                this.okButton.IsEnabled = true;               
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("The movie runtime must be between one and 210 minutes.");
                this.okButton.IsEnabled = false;
            }
            catch (FormatException)
            {
                MessageBox.Show("A value must be entered.");
                this.okButton.IsEnabled = false;
            }
        }

        /// <summary>
        /// Actions for the movie window combo box in the movie window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void ratingComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MovieRating movieRating = (MovieRating)this.ratingComboBox.SelectedItem;
        }

        /// <summary>
        /// Changes the movie is3D property to true.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void is3dCheckBox_Checked(object sender, RoutedEventArgs e)
        {
                this.movie.Is3d = true;
        }

        /// <summary>
        /// Changes the movie is3D property to false.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void is3dCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.movie.Is3d = false;
        }

        /// <summary>
        /// Actions for the OK button in the movie window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
                this.DialogResult = true;
        }
    }
}
