using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand//transferred
{
    public class Store
    {
        //Member variables
        double PriceLemons;
        double PriceCups;
        double PriceIce;
        double PriceSugar;
        //Constructor
        public Store()
        {
            PriceLemons = .10;
            PriceCups = .01;
            PriceIce = .005;
            PriceSugar = .25;
        }
        //Member Variables
        public Player PlayerShopping(Player shopper)
        {
            int Again = 0;
            while (Again == 0)
            {
                List<string> Selections = new List<string> { "Lemons", "Sugar", "Cups", "Ice", "Return to Player Menu" };
                Action<List<string>, int, Player> SelectedMenu;
                SelectedMenu = UI.StoreMenu;
                UI.ShowStore(PriceLemons, PriceSugar, PriceCups, PriceIce);//Store Options Displayer
                int UserChoice = UI.UserController(Selections, SelectedMenu, shopper);//User selects what to buy
                if (UserChoice != 4)
                {
                    UI.ClearConsoleLine();
                    Console.WriteLine("How many would you like to purchase? (Input quantity then hit the ENTER key.)");
                    int Quantity = UI.PromptQuantity();//User inputs quantity of item to buy
                    double Total = RunTotal(UserChoice, Quantity);
                    if (shopper.GetBank() >= Total)//Transaction is attempted
                    {
                        shopper.StockItems(Total, UserChoice, Quantity);
                        Console.WriteLine("Transaction Completed!!!");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient Funds!!! Transaction Cancelled....");
                    }
                    Console.WriteLine("Press any key to continue.....");
                    Console.ReadKey();
                    Selections = new List<string> { "Yes", "No" };
                    string Message = ("\nWould you like to make another Purchase?\n\n");
                    Action<List<string>, int, string> AgainMenu;//User prompted whether or not they would like to make another transaction
                    AgainMenu = UI.AgainMenu;
                    Again = UI.UserController2(Selections, AgainMenu, Message);
                }
                else
                {
                    Again = 1;
                }
            }
            return shopper;
        }
        public double RunTotal(int ItemNum, int Quantity)
        {
            double Total = 0.0;
            if (Quantity > 0)
            {
                switch (ItemNum)
                {
                    case 0:
                        Total = Quantity * PriceLemons;
                        break;
                    case 1:
                        Total = Quantity * PriceSugar;
                        break;
                    case 2:
                        Total = Quantity * PriceCups;
                        break;
                    case 3:
                        Total = Quantity * PriceIce;
                        break;
                    default:
                        break;
                }
            }
            return Total;
        }
        public double GetPriceLemons()
        {
            return PriceLemons;
        }
        public double GetPriceSugar()
        {
            return PriceSugar;
        }
        public double GetPriceCups()
        {
            return PriceCups;
        }
        public double GetPriceIce()
        {
            return PriceIce;
        }


    }
}