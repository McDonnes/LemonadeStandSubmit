using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LemonadeStand
{
    public class Inventory
    {
        //Member Variables
        public int Lemons;
        public int Cups;
        public int Sugar;
        public int Ice;
        //Constructor
        public Inventory()
        {
            Lemons = 0;
            Cups = 0;
            Sugar = 0;
            Ice = 0;
        }
        //Member Methods
        public bool TakeItems(int itemType, int itemAmount)
        {
            if (itemAmount > 0)
            {
                switch (itemType)
                {
                    case 1:
                        if (Lemons >= itemAmount)
                        {
                            Lemons -= itemAmount;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    case 2:
                        if (Sugar >= itemAmount)
                        {
                            Sugar -= itemAmount;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    case 3:
                        if (Cups >= itemAmount)
                        {
                            Cups -= itemAmount;
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    case 4:
                        if (Ice >= itemAmount)
                        {
                            Ice -= itemAmount;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    default:
                        return false;
                }
            }
            else
            {
                return false;
            }
        }
        public void Restock(int item, int quantity)
        {
            if (quantity > 0)
            {
                switch (item)
                {
                    case 0:
                        Lemons += quantity;
                        break;
                    case 1:
                        Sugar += quantity;
                        break;
                    case 2:
                        Cups += quantity;
                        break;
                    case 3:
                        Ice += quantity;
                        break;
                }
            }
        }
        public void IceMelted()
        {
            Ice = 0;
        }
        public int GetLemons()
        {
            return Lemons;
        }
        public int GetSugar()
        {
            return Sugar;
        }
        public int GetCups()
        {
            return Cups;
        }
        public int GetIce()
        {
            return Ice;
        }
    }
}