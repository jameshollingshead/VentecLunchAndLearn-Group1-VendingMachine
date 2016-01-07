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
        private int chipsQuantity = 0;
        private bool isChipsButton = false;
        private bool iscolasButton =false;
        private bool dispensing = false;
        private int colaQuantity = 0;
        private int candyQuantity = 0;
        private bool isCandyButton = false;
        private int amountofchangeinmachine = 0;

        public VendingMachine(int numChips = 10,int numcola =10, int numCandy=10, int Amountofchangeinmachine = 100)
        {
            chipsQuantity = numChips;
            colaQuantity = numcola;
            candyQuantity = numCandy;
            amountofchangeinmachine = Amountofchangeinmachine;
        }

        public string Display()
        {
            numberOfDisplayChecks++;

            if (isChipsButton && chipsQuantity == 0)
            {
                isChipsButton = false;
                return "SOLD OUT";
            }
            if (iscolasButton && colaQuantity == 0 && dispensing == false)
            {
                iscolasButton = false;
                return "SOLD OUT";
            }

            if (isCandyButton && candyQuantity == 0)
            {
                isCandyButton = false;
                return "SOLD OUT";
            }
            if (amountofchangeinmachine == 0)
            {
                return "EXACT CHANGE ONLY";
            }

            if ((numberOfDisplayChecks == 1) && (productPrice > balance))
            {
                return productPrice.ToString(CultureInfo.InvariantCulture);
            }
            else if (productPrice != 0 && balance >= productPrice)
            {
                balance = 0;
                dispensing = false;
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
            iscolasButton = true;
            productPrice = 100;

            if (colaQuantity > 0)
            {
                UpdateAmountofChange();
                colaQuantity = colaQuantity - 1;
                dispensing = true;
            }
        }

        public void ChipsButton()
        {
            isChipsButton = true;
            productPrice = 50;
            UpdateAmountofChange();
        }

        public void CandyButton()
        {
            isCandyButton = true;
            productPrice = 65;
            UpdateAmountofChange();
        }

        public void CoinReturnButton()
        {
            change = balance;
        }

        private void UpdateAmountofChange()
        {
            amountofchangeinmachine += balance;
        }
    }
}
