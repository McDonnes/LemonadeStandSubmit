using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand//Transferred
{
    public class Player
    {
        //Member Variables
        double Bank;
        public string Name;
        public Inventory Pantry;
        int SugarPerPitcher;
        int LemonsPerPitcher;
        int IcePerCup;
        int Pitcher;
        double PricePerCup;
        //Constructor
        public Player(string name)
        {
            Bank = 20.00;
            Pantry = new Inventory();
            SugarPerPitcher = 4;
            LemonsPerPitcher = 4;
            IcePerCup = 4;
            Pitcher = 0;
            PricePerCup = .25;
            Name = name;
        }
        //Member Methods
        public int GetIcePC()
        {
            return IcePerCup;
        }
        public int GetLemonsPP()
        {
            return LemonsPerPitcher;
        }
        public int GetSugarPP()
        {
            return SugarPerPitcher;
        }
        public double GetPricePC()
        {
            int Val = (int)(PricePerCup * 100);
            return Val;
        }
        public double GetCost()
        {
            return PricePerCup;
        }
        public void ChangeIcePC(int Ice)
        {
            IcePerCup = Ice;
        }
        public void ChangeLemonsPP(int Lemons)
        {
            LemonsPerPitcher = Lemons;
        }
        public void ChangeSugarPP(int Sugar)
        {
            SugarPerPitcher = Sugar;
        }
        public void ChangePricePC(int Price)
        {
            double Val = (((double)Price) / 100);
            PricePerCup = Val;
        }
        public bool StockItems(double Cost, int Item, int Quantity)
        {
            if (Cost > Bank)
            {
                return false;
            }
            else
            {
                Bank -= Cost;
                Pantry.Restock(Item, Quantity);
                return true;
            }
        }
        public void EndDay()
        {
            Pantry.IceMelted();
            Pitcher = 0;
        }
        public double GetBank()
        {
            return Bank;
        }
        private void MakePitcher()
        {
            Pantry.TakeItems(1, LemonsPerPitcher); ;
            Pantry.TakeItems(2, SugarPerPitcher); ;
            Pitcher += 10;
        }
        public bool GetCup()
        {
            if (Pantry.Cups > 0 & Pitcher > 0 & Pantry.Ice >= IcePerCup)
            {
                Pantry.TakeItems(3, 1);
                Pantry.TakeItems(4, IcePerCup);
                Pitcher--;
                Bank += PricePerCup;
                return true;
            }
            else
            {
                if (LemonsPerPitcher <= Pantry.Lemons & SugarPerPitcher <= Pantry.Sugar & Pantry.Cups > 0 & Pantry.Ice >= IcePerCup)
                {
                    MakePitcher();
                    return GetCup();
                }
                else
                {
                    return false;
                }
            }
        }
        public string GetProfit()
        {
            double Profit = (20.0 - Bank) * -1;
            string Val = String.Format(" {0:C} ", Profit);
            return Val;
        }
        public double ProfitNum()
        {
            double Profit = (20.0 - Bank) * -1;
            return Profit;
        }
        public void UpdateCupRequirements(int Ice)
        {
            IcePerCup = Ice;
        }
        public void PutMoneyInBank(double Deposit)
        {
            Bank += Deposit;
        }
    }
}