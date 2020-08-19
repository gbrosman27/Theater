using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestLibrary;

namespace TheaterTest13
{
    [TestClass]
    public class Theater13 : TheaterTestBase
    {

        // TODO: Add CheckCounts, Object values, check method values.

        [TestMethod]
        public void Theater13Step02CreateProjects()
        {
            // TheaterScenario
            this.CheckClass("MainWindow");

            // TheaterEngine
            this.CheckClass("Wallet");
            this.CheckClass("Guest");
            this.CheckClass("Movie");
            this.CheckClass("Theater");
            this.CheckClass("ScreeningRoom");

            // Stands
            this.CheckClass("Stand", Modifier.Abstract);
            this.CheckClass("SodaStand");
            this.CheckClass("SodaCupStand");
            this.CheckClass("PopcornStand");
            this.CheckClass("MoneyCollectingStand");

            // MoneyCollectors
            this.CheckInterface("IMoneyCollector");
            this.CheckClass("MoneyCollector");

            // ConcessionItems
            this.CheckClass("ConcessionItem", Modifier.Abstract);
            this.CheckClass("Popcorn");
            this.CheckClass("SodaCup");
        }

        [TestMethod]
        public void Theater13Step03ConcessionItems()
        {
            // Concession Item
            this.CheckField("Guest", "concessionItems", "List<Guest>", Visibility.Private);
            this.CheckField("ConcessionItem", "level", "double", Visibility.Private);
            this.CheckProperty("ConcessionItem", "Level", Visibility.Protected, Access.ReadWrite);
            this.CheckMethod("ConcessionItem", "Consume", Visibility.Public, Modifier.Abstract, true);
            this.CheckFieldCount("ConcessionItem", 1, Visibility.Private);
            this.CheckPropertyCount("ConcessionItem", 1, Visibility.Protected);
            this.CheckMethodCount("ConcessionItem", 1, Visibility.Public);

            // Popcorn
            this.CheckField("Popcorn", "isButtered", "bool", Visibility.Private);
            this.CheckField("Popcorn", "saltLevel", "int", Visibility.Private);
            this.CheckConstructor("Popcorn", Visibility.Public, true);
            this.CheckProperty("Popcorn", "IsButtered", "bool", Access.Readonly);
            this.CheckProperty("Popcorn", "IsSalted", "bool", Access.Readonly);
            this.CheckProperty("Popcorn", "SaltLevel", "int", Access.Readonly);
            this.CheckMethod("Popcorn", "AddButter", "void", Visibility.Public, true);
            this.CheckMethod("Popcorn", "AddSalt", "void", Visibility.Public, true);
            this.CheckMethod("Popcorn", "Consume", "void", Visibility.Public, Modifier.Override, true);
            this.CheckFieldCount("Popcorn", 2, Visibility.Private);
            this.CheckPropertyCount("Popcorn", 3);
            this.CheckMethodCount("Popcorn", 3, Visibility.Public);

            // SodaCup
            this.CheckField("SodaCup", "flavor", "string", Visibility.Private);
            this.CheckMethod("SodaCup", "Fill", "void", Visibility.Public, true, "flavor:string");
            this.CheckMethod("SodaCup", "Consume", "void", Visibility.Public, Modifier.Override, true);
            this.CheckFieldCount("SodaCup", 1, Visibility.Private);
            this.CheckMethodCount("SodaCup", 2, Visibility.Public);

            // Checking Popcorn property values.
            object popcorn = this.CreateObject("Popcorn");
            this.CheckValue(popcorn, "Level", 100.0);
            this.CheckValue(popcorn, "IsSalted", false);
            this.CheckValue(popcorn, "IsButtered", false);
            this.InvokeMethod(popcorn, "Consume");
            this.CheckValue(popcorn, "Level", 90.0);
            this.InvokeMethod(popcorn, "AddButter");
            this.CheckValue(popcorn, "IsButtered", true);
            this.InvokeMethod(popcorn, "AddSalt");
            this.CheckValue(popcorn, "IsSalted", true);
            this.CheckValue(popcorn, "saltLevel", 1);

            // Checking SodaCup property and method values
            object sodaCup = this.CreateObject("SodaCup");
            this.InvokeMethod(sodaCup, "Fill", "DrPepper");
            this.CheckValue(sodaCup, "Level", 100.0);
            this.InvokeMethod(sodaCup, "Consume");
            this.CheckValue(sodaCup, "Level", 90.0);
        }

        [TestMethod]
        public void Theater13Step04ConcessionStandClasses()
        {
            // Stand
            this.CheckField("Stand", "itemCountSold", "int", Visibility.Private);
            this.CheckField("Stand", "itemType", "string", Visibility.Private);
            this.CheckConstructor("Stand", Visibility.Public, true, "itemType:string");
            this.CheckProperty("Stand", "ItemCountSold", "int", Access.Readonly);
            this.CheckProperty("Stand", "ItemType", "string", Access.Readonly);

            // SodaStand
            this.CheckConstructor("SodaStand", Visibility.Public, true);
            this.CheckMethod("SodaStand", "FillSodaCup", "void", Visibility.Public, true, "sodaCup:SodaCup", "flavor:string");
            this.CheckIfSupports("SodaStand", "Stand");

            // SodaCupStand
            this.CheckConstructor("SodaCupStand", Visibility.Public, true, "itemPrice:decimal", "moneyBox:IMoneyCollector");
            this.CheckMethod("SodaCupStand", "BuySodaCup", "SodaCup", true, "payment:decimal");

            // MoneyCollectingStand
            this.CheckField("MoneyCollectingStand", "moneyBox", "IMoneyCollector", Visibility.Private);
            this.CheckField("MoneyCollectingStand", "itemPrice", "decimal", Visibility.Private);
            this.CheckConstructor("MoneyCollectingStand", Visibility.Public, true, "itemPrice:decimal", "itemType:string", "moneyBox:IMoneyCollector");
            this.CheckProperty("MoneyCollectingStand", "ItemPrice", "decimal", Access.Readonly);
            this.CheckProperty("MoneyCollectingStand", "MoneyBalance", "decimal", Access.Readonly);
            this.CheckMethod("MoneyCollectingStand", "AddMoney", "void", Visibility.Public, true, "amountToAdd:decimal");
            this.CheckMethod("MoneyCollectingStand", "RemoveMoney", "decimal", Visibility.Public, true, "amountToRemove:decimal");
            this.CheckIfSupports("MoneyCollectingStand", "Stand");

            // IMoneyCollector
            this.CheckProperty("IMoneyCollector", "MoneyBalance", "decimal", Access.Readonly);
            this.CheckMethod("IMoneyCollector", "AddMoney", "void", Visibility.Public, true, "amountToAdd:decimal");
            this.CheckMethod("IMoneyCollector", "RemoveMoney", "decimal", Visibility.Public, true, "amountToRemove:decimal");

            // SodaCupStand
            this.CheckConstructor("SodaCupStand", Visibility.Public, true, "itemPrice:decimal", "moneyBox:IMoneyCollector");
            this.CheckMethod("SodaCupStand", "BuySodaCup", "SodaCup", true, "payment:decimal");
            this.CheckIfSupports("SodaCupStand", "MoneyCollectingStand");

            // PopcornStand
            this.CheckConstructor("PopcornStand", Visibility.Public, true, "itemPrice:decimal", "moneyBox:IMoneyCollector");
            this.CheckIfSupports("PopcornStand", "MoneyCollectingStand");

            // MoneyCollector
            this.CheckField("MoneyCollector", "moneyBalance", "decimal");
            this.CheckConstructor("MoneyCollector", Visibility.Public, true, "initialMoneyBalance:decimal");
            this.CheckProperty("MoneyCollector", "MoneyBalance", "decimal", Access.Readonly);
            this.CheckMethod("MoneyCollector", "AddMoney", "void", Visibility.Public, true, "amountToAdd:decimal");
            this.CheckMethod("MoneyCollector", "RemoveMoney", "decimal", Visibility.Public, true, "amountToRemove:decimal");
            this.CheckIfSupports("MoneyCollector", "IMoneyCollector");

            // Theater 
            this.CheckField("Theater", "sodaCupStand", "SodaCupStand", Visibility.Private);
            this.CheckField("Theater", "sodaStand", "SodaStand", Visibility.Private);
            this.CheckField("Theater", "popcornStand", "PopcornStand", Visibility.Private);
            this.CheckProperty("Theater", "PopcornStand", "PopcornStand", Access.Readonly);
            this.CheckProperty("Theater", "SodaStand", "SodaStand", Access.Readonly);
            this.CheckProperty("Theater", "SodaCupStand", "SodaCupStand", Access.Readonly);

            // Check AddMoney RemoveMoney in money collecting stand.
            object moneyBox = this.CreateObject("MoneyCollector", 100.0m);
            object moneyCollectingStand = this.CreateObject("MoneyCollectingStand", 5.00m, "Popcorn", moneyBox);
            this.CheckValue(moneyCollectingStand, "MoneyBalance", 100.0m);
            this.InvokeMethod(moneyCollectingStand, "AddMoney", 50.0m);
            this.CheckValue(moneyCollectingStand, "MoneyBalance", 150.0m);
            this.InvokeMethod(moneyCollectingStand, "RemoveMoney", 25.0m);
            this.CheckValue(moneyCollectingStand, "MoneyBalance", 125.0m);
            this.InvokeMethod(moneyCollectingStand, "RemoveMoney", 150.0m);
            this.CheckValue(moneyCollectingStand, "MoneyBalance", 0.0m);
        }

        [TestMethod]
        public void Theater13Step05TheaterMovieClassees()
        {
            // Theater
            this.CheckField("Theater", "movies", "List<Movie>");
            this.CheckField("Theater", "guests", "List<Guest>");
            this.CheckConstructor("Theater", Visibility.Public, true, "name:string", "screeningRoom:ScreeningRoom", "moneyBoxInitialMoneyBalance:decimal", "popcornPrice:decimal", "sodaCupPrice:decimal");
            this.CheckProperty("Theater", "AverageMovieRuntime", "double", Access.Readonly);
            this.CheckProperty("Theater", "Movies", "IEnumerable<Movie>", Access.Readonly);
            this.CheckProperty("Theater", "Guests", "IEnumerable<Guest>", Access.Readonly);
            this.CheckProperty("Theater", "Name", "string", Access.Readonly);
            this.CheckProperty("Theater", "ScreeningRoom", "ScreeningRoom", Access.Readonly);
            this.CheckMethod("Theater", "AddGuest", "void", true, "guest:Guest");
            this.CheckMethod("Theater", "AddMovie", "void", true, "movie:Movie");

            // Movie
            this.CheckField("Movie", "is3d", "bool", Visibility.Private);
            this.CheckField("Movie", "rating", "string", Visibility.Private);
            this.CheckField("Movie", "runtime", "int", Visibility.Private);
            this.CheckField("Movie", "title", "string", Visibility.Private);
            this.CheckConstructor("Movie", Visibility.Public, true, "is3d:bool", "rating:string", "runtime:int", "title:string");
            this.CheckProperty("Movie", "Is3d", "bool", Access.ReadWrite);
            this.CheckProperty("Movie", "Rating", "string", Access.ReadWrite);
            this.CheckProperty("Movie", "Runtime", "int", Access.ReadWrite);
            this.CheckProperty("Movie", "Title", "string", Access.ReadWrite);
            this.CheckMethod("Movie", "ToString", "string", Modifier.Override, true);

            // Guest
            this.CheckField("Guest", "age", "int", Visibility.Private);
            this.CheckField("Guest", "desiredMovieTitle", "string", Visibility.Private);
            this.CheckField("Guest", "preferredSodaFlavor", "string", Visibility.Private);
            this.CheckField("Guest", "wallet", "Wallet", Visibility.Private);
            this.CheckConstructor("Guest", Visibility.Public, true, "age:int", "desiredMovieTitle:string", "preferredSodaFlavor:string", "wallet:Wallet");
            this.CheckProperty("Guest", "Age", "int", Access.ReadWrite);
            this.CheckProperty("Guest", "DesiredMovieTitle", "string", Access.ReadWrite);
            this.CheckProperty("Guest", "MoneyBalance", "decimal", Access.Readonly);
            this.CheckProperty("Guest", "PreferredSodaFlavor", "string", Access.ReadWrite);
            this.CheckProperty("Guest", "Wallet", "Wallet", Access.Readonly);
            this.CheckMethod("Guest", "AddMovieSeen", "void", Visibility.Public, true, "movie:Movie");
            this.CheckMethod("Guest", "BuyConcessions", "void", Visibility.Public, true, "popcornStand:PopcornStand", "sodaCupStand:SodaCupStand", "sodaStand:SodaStand");
            this.CheckMethod("Guest", "BuyPopcorn", "Popcorn", Visibility.Private, true, "popcornStand:PopcornStand");
            this.CheckMethod("Guest", "BuySoda", "SodaCup", Visibility.Private, true, "sodaCupStand:SodaCupStand", "sodaStand:SodaStand");
            this.CheckMethod("Guest", "FillSoda", "void", Visibility.Private, true, "sodaCup:SodaCup", "sodaStand:SodaStand");
            this.CheckMethod("Guest", "ToString", "string", Visibility.Public, Modifier.Override, true);

            // Wallet
            this.CheckField("Wallet", "moneyPocket", "IMoneyCollector", Visibility.Private);
            this.CheckField("Wallet", "color", "string", Visibility.Private);
            this.CheckConstructor("Wallet", Visibility.Public, true, "color:string", "moneyBalance:decimal");
            this.CheckProperty("Wallet", "Color", "string", Access.ReadWrite);
            this.CheckProperty("Wallet", "MoneyBalance", "decimal", Access.Readonly);
            this.CheckMethod("Wallet", "AddMoney", "void", Visibility.Public, true, "amountToAdd:decimal");
            this.CheckMethod("Wallet", "RemoveMoney", "decimal", Visibility.Public, true, "amountToRemove:decimal");

            // Check AverageRuntime
            object mainWindow = this.CreateObject("MainWindow");
            this.InvokeMethod(mainWindow, "window_Loaded", null, null);
            this.CheckValue(mainWindow, "marcusTheater.AverageMovieRuntime", 135.0);

            // The MoneyBalance property and AddMoney and RemoveMoney methods in the wallet 
            object wallet = this.CreateObject("Wallet", "Brown", 100.0m);
            this.CheckValue(wallet, "MoneyBalance", 100.0m);
            this.InvokeMethod(wallet, "AddMoney", 50.0m);
            this.CheckValue(wallet, "MoneyBalance", 150.0m);
            this.InvokeMethod(wallet, "RemoveMoney", 25.0m);
            this.CheckValue(wallet, "MoneyBalance", 125.0m);
            this.InvokeMethod(wallet, "RemoveMoney", 150.0m);
            this.CheckValue(wallet, "MoneyBalance", 0.0m);

            // Override ToString
            // ---- CAN'T CHECK specifics BECAUSE WE DIDN'T PROVIDE A FORMAT
            object guest = this.CreateObject("Guest", 25, "DrPepper", "Movie", wallet);
            object guestString = this.InvokeMethod(guest, "ToString");
            if (guestString == null)
            {
                this.AddFailureMessage("Guest's ToString method doesn't return a string value.");
            }

            object movie = this.CreateObject("Movie", true, "R", 100, "MovieTitle");
            object movieString = this.InvokeMethod(movie, "ToString");
            if(movieString == null)
            {
                this.AddFailureMessage("Movie's ToString method doesn't return a string value.");
            }
        }

        [TestMethod]
        public void Theater13Step06InitializeObjects()
        {
            // Checking that theater Constructor is correct.
            object screeningRoom = this.CreateObject("ScreeningRoom", true, 200);
            object theater = this.CreateObject("Theater", "TestTheater", screeningRoom, 500.0m, 5.0m, 5.0m);
            this.CheckValue(theater, "Name", "TestTheater");

            // Check that popcorn stand and sodacup stand share a money box.
            this.CheckValueM("Popcorn stand's money balance is hard-coded.", theater, "popcornStand.MoneyBalance", 500.0m);
            this.CheckValueM("Soda cup stand's money balance is hard-coded.", theater, "sodaCupStand.MoneyBalance", 500.0m);
            this.CheckValueM("Checking for hard-coded values", theater, "screeningRoom.Is3dCapable", true);

            // Check that marcus theater is initialized in window_Loaded has correct values based on object diagram.
            object mainWindow = this.CreateWindow();
            this.InvokeMethod(mainWindow, "window_Loaded", null, null);
            this.CheckValue(mainWindow, "marcusTheater.Name", "Marcus Theater");
            this.CheckValue(mainWindow, "marcusTheater.PopcornStand.MoneyBalance", 450.0m);
            this.CheckValue(mainWindow, "marcusTheater.PopcornStand.itemPrice", 5.0m);
            this.CheckValue(mainWindow, "marcusTheater.SodaCupStand.MoneyBalance", 450.0m);
            this.CheckValue(mainWindow, "marcusTheater.SodaCupStand.itemPrice", 4.0m);
            this.CheckValue(mainWindow, "marcusTheater.ScreeningRoom.Is3dCapable", true);
            this.CheckValue(mainWindow, "marcusTheater.ScreeningRoom.seatingCapacity", 78);
            this.CheckValueNotNull(mainWindow, "marcusTheater.Guests");
            this.CheckValueNotNull(mainWindow, "marcusTheater.Movies");
            //this.AddNotTestableMessage("Not able to check the movies and guests that were added to the theater because can't access lists.");

            // Check guest constructor.
            object wallet = this.CreateObject("Wallet", "Black", 25.00m);
            object guest = this.CreateObject("Guest", 25, "Moonlight", "Pepsi", wallet);
            this.CheckValue(guest, "Age", 25);
            this.CheckValue(guest, "DesiredMovieTitle", "Moonlight");
            this.CheckValue(guest, "PreferredSodaFlavor", "Pepsi");
            this.CheckValue(guest, "Wallet.MoneyBalance", 25.00m);
        }
    }
}
