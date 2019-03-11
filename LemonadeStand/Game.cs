using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        //Member Variables
        Player Player1;
        Player Player2;
        Store Shop;
        List<List<string>> Menus;
        List<Day> Week;
        List<List<double>> MoodGenerator;
        Random Rand;
        int NumberOfDays;
        double Profit1;
        double Profit2;
        int CustomersPerDay;
        int DayNumber;
        //Constructor
        public Game()
        {
            DayNumber = 0;
            CustomersPerDay = 100;
            NumberOfDays = 7;
            Player1 = new Player("Player 1");
            Player2 = new Player("Player 2");
            Shop = new Store();
            LoadMenuLists();
            Rand = new Random();
            MoodGenerator = LoadRandomDoubles();
            GetWeatherData.Retrieve();
            Week = LoadDays(GetWeatherData.GetForecast());
        }
        //Member Methods

        private List<Day> LoadDays(decimal[,] WeatherForWeek)
        {
            List<Day> Days = new List<Day>();
            for (int x = 0; x < NumberOfDays; x++)
            {
                Days.Add(new Day(MoodGenerator[x], WeatherForWeek[x,0], WeatherForWeek[x,1]));
            }
            return Days;
        }
        private List<List<double>> LoadRandomDoubles()
        {
            List<List<double>> CustomerMoods = new List<List<double>>();
            List<double> MoodBucket = new List<double>();
            for (int x = 0; x < NumberOfDays; x++)
            {
                for (int i = 0; i < (CustomersPerDay); i++)
                {
                    MoodBucket.Add(Rand.NextDouble());
                }
                CustomerMoods.Add(MoodBucket);
                MoodBucket = new List<double>();
            }
            return CustomerMoods;
        }
        public void StartGame()
        {
            UI.Welcome();
            int Player1SalesCount;
            int Player2SalesCount;
            while (DayNumber < NumberOfDays)
            {
                Profit1 = Player1.GetBank();
                Profit2 = Player2.GetBank();
                CallUserMenu(Player1);
                Profit1 -= Player1.GetBank();
                Profit1 *= -1;
                Player1SalesCount = Week[DayNumber].GetSalesCount();
                CallUserMenu(Player2);
                Profit2 -= Player2.GetBank();
                Profit2 *= -1;
                Player2SalesCount = Week[DayNumber].GetSalesCount();
                double TotalProfit1 = Player1.GetBank() - 20.00;
                double TotalProfit2 = Player2.GetBank() - 20.00;
                Console.Clear();
                Console.WriteLine("Player 1: ");
                UI.ShowDayResults(Player1SalesCount, Profit1, TotalProfit1, Player1);
                Console.WriteLine("Player 2: ");
                UI.ShowDayResults(Player2SalesCount, Profit2, TotalProfit2, Player2);
                DayNumber++;
                Console.ReadKey();
            }
            Console.Clear();
            UI.ShowEndGame(Player1);
            UI.ShowEndGame(Player2);
            if(Player1.GetBank() > Player2.GetBank())
            {
                Console.WriteLine($"{Player1.Name} WINS!!!");
            }else if (Player1.GetBank() < Player2.GetBank())
            {
                Console.WriteLine($"{Player2.Name} WINS!!!");
            }
            else
            {
                Console.WriteLine($"IT WAS A TIE!!!");
            }
            Console.ReadKey();
        }
        private Player CallUserMenu(Player CurrentPlayer)
        {
            int MenuNumber = 0;
            while (MenuNumber != 4)
            {
                List<string> Selections = Menus[0];
                Action<List<string>, int, Player> SelectedMenu;
                SelectedMenu = UI.PlayerMenu;
                MenuNumber = UI.UserController(Selections, SelectedMenu, CurrentPlayer);
                if (MenuNumber == 0)
                {
                    CurrentPlayer = CallCupStatMenu(CurrentPlayer);
                }
                else if (MenuNumber == 1)
                {
                    CurrentPlayer = CallStoreMenu(CurrentPlayer);
                }
                else if (MenuNumber == 2)
                {
                    CallForecast();
                }
                else if (MenuNumber == 3)
                {
                    CallInventory(CurrentPlayer);
                }
                else
                {
                    CurrentPlayer = RunDay(CurrentPlayer);
                }
            }
            return CurrentPlayer;
        }
        private void CallForecast()
        {
            UI.DisplayForecast(Week, DayNumber);
        }
        private Player CallCupStatMenu(Player CurrentPlayer)
        {
            int Again = 0;
            while (Again == 0)
            {
                List<string> Selections = Menus[1];
                Action<List<string>, int, Player> SelectedMenu;
                SelectedMenu = UI.CupStatMenu;
                int UserChoice = UI.UserController(Selections, SelectedMenu, CurrentPlayer);
                if (UserChoice != 4)
                {
                    UI.ClearConsoleLine();
                    Console.WriteLine("What would you like to change it to? (Input quantity then hit the ENTER key.)");
                    int Quantity = UI.PromptQuantity();
                    CurrentPlayer = ChangePlayerCupStats(UserChoice, Quantity, CurrentPlayer);
                    Console.WriteLine("Cup Stats have been updated!!!");
                    Selections = Menus[4];
                    string Message = ("\nWould you like to make another change?\n\n");
                    Action<List<string>, int, string> AgainMenu;
                    AgainMenu = UI.AgainMenu;
                    Again = UI.UserController2(Selections, AgainMenu, Message);
                }
                else
                {
                    Again = 1;
                }
            }
            return CurrentPlayer;
        }
        private Player ChangePlayerCupStats(int Item, int Quantity, Player CurrentPlayer)
        {
            switch (Item)
            {
                case 0:
                    CurrentPlayer.ChangeLemonsPP(Quantity);
                    break;
                case 1:
                    CurrentPlayer.ChangeSugarPP(Quantity);
                    break;
                case 2:
                    CurrentPlayer.ChangeIcePC(Quantity);
                    break;
                case 3:
                    CurrentPlayer.ChangePricePC(Quantity);
                    break;
                default:
                    break;
            }
            return CurrentPlayer;
        }
        private Player CallStoreMenu(Player CurrentPlayer)
        {
            CurrentPlayer = Shop.PlayerShopping(CurrentPlayer);
            return CurrentPlayer;
        }
        private void CallInventory(Player CurrentPlayer)
        {
            UI.DisplayInventoryMenu(CurrentPlayer);
        }
        private void LoadMenuLists()
        {
            Menus = new List<List<string>>();
            Menus.Add(new List<string> { "Change Cup Stats", "Visit Store/Buy Ingredients", "Check Weather Forcast", "View My Inventory", "Run Day" });
            Menus.Add(new List<string> { "Lemons", "Sugar", "Ice", "Price", "Return to Player Menu" });
            Menus.Add(new List<string> { "Lemons", "Sugar", "Cups", "Ice", "Return to Player Menu" });
            Menus.Add(new List<string> { "Return to Player Menu" });
            Menus.Add(new List<string> { "Yes", "No" });
        }
        private Player RunDay(Player CurrentPlayer)
        {
            CurrentPlayer = Week[DayNumber].RunDay(CurrentPlayer);
            CurrentPlayer.EndDay();
            return CurrentPlayer;
        }
    }
}
