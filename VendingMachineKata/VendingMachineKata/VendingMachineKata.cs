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
        float balance = 0;
        private float productPrice = 0;
        private int numberOfDisplayChecks = 0;
        private float change = 0;
        public string Display()
        {
            numberOfDisplayChecks++; 

            if ((numberOfDisplayChecks == 1) && (productPrice > balance))
            {
                return productPrice.ToString(CultureInfo.InvariantCulture);
            }
            else
            {
                return (balance.Equals(0.0f)) ? "INSERT COIN" : balance.ToString(CultureInfo.InvariantCulture);  
            }            
        }

        public void InsertCoin(float coin)
        {
            if (coin.Equals(.01f))
                change = coin;
            else
            {
                balance += coin;
            }
            
        }

        public float CoinReturn()
        {
            return change;
        }

        public void ColaButton()
        {
            productPrice = 1.00f;
        }
    }
}
