using System;
using System.Windows;
using System.Windows.Controls;
using ConcessionItems;
using TheaterEngine;

namespace TheaterScenario
{
    /// <summary>
    /// Interaction logic for GuestWindow.xaml.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Event handlers may begin with lower-case letters.")]
    public partial class GuestWindow : Window
    {
        /// <summary>
        /// The theater's guest.
        /// </summary>
        private Guest guest;

        /// <summary>
        /// Initializes a new instance of the GuestWindow class.
        /// </summary>
        /// <param name="guest">The intended guest.</param>
        public GuestWindow(Guest guest)
        {
            this.guest = guest;

            this.InitializeComponent();
        }

        /// <summary>
        /// Loads the guest window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void guestWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Ready the text boxes for input.
            this.ageTextBox.Text = this.guest.Age.ToString();
            this.desiredMovieTitleTextBox.Text = this.guest.DesiredMovieTitle.ToString();

            // Populate the combo boxes.
            this.preferredSodaFlavorComboBox.ItemsSource = Enum.GetValues(typeof(SodaFlavor));
            this.walletColorComboBox.ItemsSource = Enum.GetValues(typeof(WalletColor));

            // Set the money label to the guest's wallet money balance.
            this.moneyLabel.Content = this.guest.Wallet.MoneyBalance;
        }

        /// <summary>
        /// Actions for the age text box in the guest window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void ageTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                this.guest.Age = int.Parse(ageTextBox.Text);
                this.okButton.IsEnabled = true;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("The guest's age must be between zero and 120");
                this.okButton.IsEnabled = false;
            }
            catch (FormatException)
            {
                MessageBox.Show("A value must be entered.");
                this.okButton.IsEnabled = false;
            }
        }

        /// <summary>
        /// Actions for the desired movie title text box in the guest window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void desiredMovieTitleTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                this.guest.DesiredMovieTitle = this.desiredMovieTitleTextBox.Text;
                this.okButton.IsEnabled = true;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("The length of the desired movie title must be at least one character and no more than 100 characters.");
                this.okButton.IsEnabled = false;
            }
        }

        /// <summary>
        /// Adds 5 dollars to the guest's wallet.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void add5MoneyButton_Click(object sender, RoutedEventArgs e)
        {
            this.guest.Wallet.AddMoney(5.00m);
            this.moneyLabel.Content = this.guest.Wallet.MoneyBalance.ToString("C");
        }

        /// <summary>
        /// Subtracts 5 dollars from the guest's wallet.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void subtract5MoneyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.guest.Wallet.RemoveMoney(5.00m);
                this.moneyLabel.Content = this.guest.Wallet.MoneyBalance.ToString("C");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Not enough money in the wallet to remove amount.");
            }
        }

        /// <summary>
        /// Actions for the soda flavor combo box in the guest window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void preferredSodaFlavorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SodaFlavor sodaFlavor = (SodaFlavor)this.preferredSodaFlavorComboBox.SelectedItem;
        }

        /// <summary>
        /// Actions for the wallet color combo box in the guest window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void walletColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WalletColor walletColor = (WalletColor)this.walletColorComboBox.SelectedItem;
        }

        /// <summary>
        /// Actions for the ok button in the guest window.
        /// </summary>
        /// <param name="sender">System data.</param>
        /// <param name="e">Associated event data.</param>
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}