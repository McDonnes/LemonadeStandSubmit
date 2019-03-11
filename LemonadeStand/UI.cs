using System;
using System.Collections.Generic;

namespace LemonadeStand//transferred
{
    public static class UI
    {
        private static string StdBreak = ("--------------------------------------------------------------------------------------------------");
        public static void Welcome()
        {
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            Console.WriteLine("\n                                           Welcome to Lemonade Stand!\n");
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            Console.WriteLine("You have 7 days to mix different ingredients, regulate your prices, and maximize your profits!\n" +
                              "\nUse the user keypad to make selections:\n\n" +
                              "      W - Up        S - Down      A - Left        D - Right        F - Select\n");
            RainBowBreak(StdBreak);
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }
        private static void RainBowBreak(string Breaker)
        {
            List<ConsoleColor> Color = new List<ConsoleColor> { ConsoleColor.Blue, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Magenta };
            char[] BreakUpBreaker = Breaker.ToCharArray();
            int Count = 0;
            for (int x = 0; x < BreakUpBreaker.Length; x++)
            {
                if (Count == 5)
                {
                    Count = 0;
                }
                if (BreakUpBreaker[x] == '-')
                {
                    Console.ForegroundColor = Color[Count];
                    Console.Write(BreakUpBreaker[x]);
                    Count++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(BreakUpBreaker[x]);
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void CrossHair(string Selection)
        {
            char[] BreakUpBreaker = Selection.ToCharArray();
            int Count = 0;
            for (int x = 0; x < BreakUpBreaker.Length; x++)
            {
                if (Count == 5)
                {
                    Count = 0;
                }
                if (BreakUpBreaker[x] == '<' || BreakUpBreaker[x] == '>')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(BreakUpBreaker[x]);
                    Count++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(BreakUpBreaker[x]);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void PlayerMenu(List<string> Selections, int Selector, Player Player1)
        {
            string CrossHair = ("<" + Selections[Selector] + ">");
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            Console.WriteLine($"\n                                           {Player1.Name}'s Menu\n");
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            for (int x = 0; x < Selections.Count; x++)
            {
                if (x == Selector)
                {
                    Console.Write("                    ");
                    UI.CrossHair(CrossHair);
                }
                else
                {
                    Console.Write("                     " + Selections[x]);
                }
                if (x % 2 == 1)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            RainBowBreak(StdBreak);
        }
        public static int UserController(List<string> selections, Action<List<string>, int, Player> MenuSelection, Player Player1)
        {
            bool Flag = true;
            int Val = 0;
            while (Flag)
            {
                Console.Clear();
                MenuSelection(selections, Val, Player1);
                string move = (Console.ReadKey().KeyChar + "").ToUpper();
                switch (move)
                {
                    case "W":
                        Val += -2;
                        break;
                    case "S":
                        Val += 2;
                        break;
                    case "A":
                        Val -= 1;
                        break;
                    case "D":
                        Val += 1;
                        break;
                    case "F":
                        Flag = false;
                        break;
                }
                if (Val >= selections.Count)
                {
                    Val = selections.Count - 1;
                }
                else if (Val < 0)
                {
                    Val = 0;
                }
            }
            return Val;
        }
        public static int UserController2(List<string> Selections, Action<List<string>, int, string> MenuSelection, string Message)
        {
            bool Flag = true;
            int Val = 0;
            while (Flag)
            {
                Console.Clear();
                MenuSelection(Selections, Val, Message);
                string Move = (Console.ReadKey().KeyChar + "").ToUpper();
                switch (Move)
                {
                    case "W":
                        Val += -2;
                        break;
                    case "S":
                        Val += 2;
                        break;
                    case "A":
                        Val -= 1;
                        break;
                    case "D":
                        Val += 1;
                        break;
                    case "F":
                        Flag = false;
                        break;
                }
                if (Val >= Selections.Count)
                {
                    Val = Selections.Count - 1;
                }
                else if (Val < 0)
                {
                    Val = 0;
                }
            }
            return Val;
        }
        public static void CupStatMenu(List<string> Selections, int Selector, Player Player1)
        {
            string CrossHair = ("<" + Selections[Selector] + ">");
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            Console.WriteLine("\n                                        Cup Stat Menu\n");
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            Console.WriteLine("\nCurrent Cup Stats: \n");
            DisplayCurrentCupStats(Player1);
            Console.WriteLine();
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            Console.WriteLine("\nWhat would you like to change?\n\n");
            for (int x = 0; x < Selections.Count; x++)
            {
                if (x == Selector)
                {
                    Console.Write("         ");
                    UI.CrossHair(CrossHair);
                }
                else
                {
                    Console.Write("         " + Selections[x]);
                }
            }
            Console.WriteLine();
            RainBowBreak(StdBreak);
        }
        public static void DisplayCurrentCupStats(Player Player1)
        {
            Console.WriteLine($"Lemons per Pitcher: {Player1.GetLemonsPP()}");
            Console.WriteLine($"Cups of Sugar per Pitcher: {Player1.GetSugarPP()}");
            Console.WriteLine($"Ice Cubes per Cup: {Player1.GetIcePC()}");
            Console.WriteLine($"Price per Cup: {Player1.GetPricePC()} cents");
        }
        public static int PromptQuantity()
        {
            string Input;
            int Quantity = -1;
            while (Quantity == -1)
            {
                Input = Console.ReadLine();
                Quantity = ValidateInteger(Input);

            }
            return Quantity;
        }
        private static int ValidateInteger(string Input)
        {
            int Num;
            if (int.TryParse(Input, out Num))
            {
                return Num;
            }
            else
            {
                Console.WriteLine("Please enter a valid quantity!");
                return -1;
            }
        }
        public static void AgainMenu(List<string> Selections, int Selector, string Message)
        {
            string CrossHair = ("<" + Selections[Selector] + ">");
            Console.WriteLine("                    " + Message);
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            for (int x = 0; x < Selections.Count; x++)
            {
                if (x == Selector)
                {
                    Console.Write("         ");
                    UI.CrossHair(CrossHair);
                }
                else
                {
                    Console.Write("         " + Selections[x]);
                }
            }
            Console.WriteLine();
            RainBowBreak(StdBreak);
        }
        public static void ClearConsoleLine()
        {
            int CurrentConsoleLine = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, CurrentConsoleLine);
        }
        public static void StoreMenu(List<string> Selections, int Selector, Player Player1)
        {
            string Crosshair = ("<" + Selections[Selector] + ">");
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            Console.WriteLine("\n                                            Store Menu\n");
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            Console.WriteLine("Current Bank: {0:C}", Player1.GetBank());
            Console.WriteLine("\nCurrent Inventory: \n");
            DisplayCurrentInventory(Player1);
            Console.WriteLine();
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            Console.WriteLine("\nWhat would you like to purchase?\n\n");
            for (int x = 0; x < Selections.Count; x++)
            {
                if (x == Selector)
                {
                    Console.Write("         ");
                    UI.CrossHair(Crosshair);
                }
                else
                {
                    Console.Write("         " + Selections[x]);
                }
            }
            Console.WriteLine();
            RainBowBreak(StdBreak);
        }
        public static void DisplayCurrentInventory(Player Player1)
        {
            Console.WriteLine($"Lemons: {Player1.Pantry.GetLemons()}");
            Console.WriteLine($"Cups of Sugar: {Player1.Pantry.GetSugar()}");
            Console.WriteLine($"Ice Cubes: {Player1.Pantry.GetIce()}");
            Console.WriteLine($"Cups: {Player1.Pantry.GetCups()}");
        }
        public static void DisplayInventoryMenu(Player Player1)
        {
            Console.Clear();
            RainBowBreak(StdBreak);
            Console.WriteLine("Current Bank: {0:C}", Player1.GetBank());
            Console.WriteLine("\nCurrent Inventory: \n");
            DisplayCurrentInventory(Player1);
            Console.WriteLine();
            RainBowBreak(StdBreak);
            Console.WriteLine("Press any key to return to the main menu....");
            Console.ReadKey();
        }
        public static void ShowStore(double LemonsPrice, double SugarPrice, double CupsPrice, double IcePrice)
        {
            Console.WriteLine("\nStore Prices:\n");
            Console.WriteLine($"Lemons: ${LemonsPrice} per Lemon");
            Console.WriteLine($"Sugar: ${SugarPrice} per Cup");
            Console.WriteLine($"Cups: ${CupsPrice} per Cup");
            Console.WriteLine($"Ice: ${IcePrice} per Cube");
        }
        public static void DisplayForecast(List<Day> Week, int DayNum)
        {
            Console.Clear();
            RainBowBreak(StdBreak);
            RainBowBreak("--------------------Your 7 Day Forecast!--------------------");
            Console.WriteLine("Day:           1      2      3       4       5      6      7\n");
            Console.WriteLine($"Temperature:  {Week[0].GetTemperature()}     {Week[1].GetTemperature()}      {Week[2].GetTemperature()}       {Week[3].GetTemperature()}     {Week[4].GetTemperature()}      {Week[5].GetTemperature()}     {Week[6].GetTemperature()}");
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            if(Week[DayNum].GetPrecipitation() == false)
            {
                Console.WriteLine($"    Today has a high of {Week[DayNum].GetTemperature()} degrees with clear skies!");
            }else
            {
                Console.WriteLine($"    Today has a high of {Week[DayNum].GetTemperature()} degrees with rain!");
            }
            RainBowBreak(StdBreak);

            Console.WriteLine("Press any key to continue to the Player Menu......");
            Console.ReadKey();
        }
        public static void ShowDayResults(int SalesCount, double TodaysProfit, double TotalProfit, Player CurrentPlayer)
        {
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            Console.WriteLine($"      {CurrentPlayer.Name} sold {SalesCount} cups of lemonade today!");
            if (TodaysProfit >= 0)
            {
                Console.WriteLine("                Todays Profit Made: {0:C}", TodaysProfit);
            }
            else
            {
                Console.WriteLine("                Todays Profit Made: -{0:C}", TodaysProfit);
            }
            if (TodaysProfit >= 0)
            {
                Console.WriteLine("                Total Profit Made: {0:C}", TotalProfit);
            }
            else
            {
                Console.WriteLine("                Total Profit Made: -{0:C}", TotalProfit);
            }
            
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
        }
        public static void ShowEndGame(Player CurrentPlayer)
        {
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            if (CurrentPlayer.ProfitNum() >= 0)
            {
                Console.WriteLine($"{CurrentPlayer.Name}'s total profits were...$" + CurrentPlayer.GetProfit());
                Console.WriteLine("Nice work!");
            }
            else
            {
                Console.WriteLine($"{CurrentPlayer.Name}'s total profits were...- $" + CurrentPlayer.GetProfit());
                Console.WriteLine("Try better next time!");
            }
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
            RainBowBreak(StdBreak);
        }
    }
}
