using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineKata
{

    public class VendingMachine
    {
        int balance = 0;
        private int productPrice = 0;
        private int numberOfDisplayChecks = 0;
        private int change = 0;
        public string Display()
        {
            numberOfDisplayChecks++; 

            if ((numberOfDisplayChecks == 1) && (productPrice > balance))
            {
                return productPrice.ToString(CultureInfo.InvariantCulture);
            }
            else if (productPrice != 0 && balance >= productPrice)
            {
                balance = 0;
                return "THANK YOU";
            }
            else
            {
                return (balance.Equals(0)) ? "INSERT COIN" : balance.ToString(CultureInfo.InvariantCulture);  
            }            
        }

        public void InsertCoin(int coin)
        {
            if (coin.Equals(1))
                change += coin;
            else
            {
                balance += coin;
            }
            
        }

        public int CoinReturn()
        {
            if (productPrice != 0 && balance > productPrice)
                change = balance - productPrice;

            return change;
        }

        public void ColaButton()
        {
            productPrice = 100;
        }

        public void ChipsButton()
        {
            productPrice = 50;
        }

        public void CandyButton()
        {
            productPrice = 65;
        }

        public void CoinReturnButton()
        {
            change = balance;
        }
    }
}
