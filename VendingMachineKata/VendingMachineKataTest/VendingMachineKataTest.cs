using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit;
using VendingMachineKata;

namespace VendingMachineKataTest
{
    [TestFixture]
    public class TestClass
    {
        private VendingMachine vendingMachine;
        private static string InsertCoinMessage = "INSERT COIN";

        private enum Coin
        {
            Penny = 1,
            Nickel = 5,
            Dime = 10,
            Quarter = 25
        };

        private int penny = (int)Coin.Penny;
        private int nickel = (int)Coin.Nickel;
        private int dime = (int)Coin.Dime;
        private int quarter = (int)Coin.Quarter;

        [SetUp]
        public void TestSetup()
        {

        }

        [Test]
        public void WhenThereAreNoCoinsInsertedInsertCoinIsDisplayed()
        {
            vendingMachine = new VendingMachine();
            string result = vendingMachine.Display();

            Assert.AreEqual(InsertCoinMessage, result);
        }

        [Test]
        public void WhenANickleIsInsertedDisplayDisplaysFiveCents()
        {
            vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(nickel);
            string result = vendingMachine.Display();

            Assert.AreEqual("5", result);
        }

        [Test]
        public void WhenAPennyIsInsertedDisplayDisplaysInvalidCoin()
        {
            vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(penny);
            string result = vendingMachine.Display();
            int returnAmount = vendingMachine.CoinReturn();

            Assert.AreEqual(InsertCoinMessage, result);
            Assert.AreEqual(returnAmount, 1);
        }

        [Test]
        public void InsertPennyAndNickekDisplayShouldFiveCentsAndReturnDisplayOneCent()
        {
            vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(penny);
            vendingMachine.InsertCoin(nickel);
            string result = vendingMachine.Display();
            int returnAmount = vendingMachine.CoinReturn();

            Assert.AreEqual("5", result);
            Assert.AreEqual(returnAmount, 1);
        }

        [Test]
        public void NoCoinsWereInsertedDisplayTheProductPrice()
        {
            vendingMachine = new VendingMachine();
            vendingMachine.ColaButton();

            string result = vendingMachine.Display();

            Assert.AreEqual("100", result);
        }

        [Test]
        public void InsertAQuarterSelectColaCheckDisplayTwiceDisplayShouldReady25Cents()
        {
            vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(quarter);
            vendingMachine.ColaButton();
            string result1 = vendingMachine.Display();
            string result2 = vendingMachine.Display();

            Assert.AreEqual("25", result2);
        }

        [Test]
        public void InsertOneDollarSelectColaDisplayShouldDesplayThankYou()
        {
            vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(quarter);
            vendingMachine.InsertCoin(quarter);
            vendingMachine.InsertCoin(quarter);
            vendingMachine.InsertCoin(quarter);
            vendingMachine.ColaButton();
            string result = vendingMachine.Display();

            Assert.AreEqual("THANK YOU", result);
        }

        [Test]
        public void InsertOneDollarSelectColaDisplayTwiceShouldDesplayInsertCoin()
        {
            vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(quarter);
            vendingMachine.InsertCoin(quarter);
            vendingMachine.InsertCoin(quarter);
            vendingMachine.InsertCoin(quarter);
            vendingMachine.ColaButton();
            string result = vendingMachine.Display();
            result = vendingMachine.Display();

            Assert.AreEqual("INSERT COIN", result);
        }

        [Test]
        public void SelectChipsButtonDisplayFiftyCents()
        {
            vendingMachine = new VendingMachine();

            vendingMachine.ChipsButton();
            string result = vendingMachine.Display();

            Assert.AreEqual(("50"), result);
        }

        [Test]
        public void InsertAQuarterSelectChipsCheckDisplayTwiceDisplayShouldReady25Cents()
        {
            vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(quarter);
            vendingMachine.ChipsButton();
            string result1 = vendingMachine.Display();
            string result2 = vendingMachine.Display();

            Assert.AreEqual("25", result2);
        }

        [Test]
        public void SelectCandyButtonDisplaySixtyFiveCents()
        {
            vendingMachine = new VendingMachine();
            vendingMachine.CandyButton();
            string result = vendingMachine.Display();

            Assert.AreEqual(("65"), result);
        }

        [Test]
        public void InsertOneDollarTwentyFiveSelectColaCoinReturnShouldContain25Cents()
        {
            vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(quarter);
            vendingMachine.InsertCoin(quarter);
            vendingMachine.InsertCoin(quarter);
            vendingMachine.InsertCoin(quarter);
            vendingMachine.InsertCoin(quarter);
            vendingMachine.ColaButton();
            int result = vendingMachine.CoinReturn();

            Assert.AreEqual(25, result);
        }

        [Test]
        public void InsertTwoPenniesCheckCoinReturn()
        {
            vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(penny);
            vendingMachine.InsertCoin(penny);
            int result = vendingMachine.CoinReturn();

            Assert.AreEqual(2, result);
        }

        [Test]
        public void InsertCoinsPushReturnCoins()
        {
            vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(quarter);
            vendingMachine.CoinReturnButton();
            int result = vendingMachine.CoinReturn();

            Assert.AreEqual(result, 25);
        }

        [Test]
        public void InsertFiftyCentsCoinsPushReturnCoins()
        {
            vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(quarter);
            vendingMachine.InsertCoin(quarter);
            vendingMachine.CoinReturnButton();
            int result = vendingMachine.CoinReturn();

            Assert.AreEqual(result, 50);
        }

        [Test]
        public void IfChipsAreSoldOutSoldOutIsDisplayed()
        {
            //Assume that item count is 0 for Chips
            vendingMachine = new VendingMachine(0);
            vendingMachine.ChipsButton();
            string expectedResult = "SOLD OUT";

            var result = vendingMachine.Display();
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void IfColaIsSoldOutSoldOutIsDisplayed()
        {
            //Assume that item count is 0 for cola
            vendingMachine = new VendingMachine(0,0);
            vendingMachine.ColaButton();
            string expectedResult = "SOLD OUT";

            var result = vendingMachine.Display();
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void IfCandyIsSoldOutSoldOutIsDisplayed()
        {
            //Assume that item count is 0 for candy
            vendingMachine = new VendingMachine(0, 0, 0);
            vendingMachine.CandyButton();
            string expectedResult = "SOLD OUT";

            var result = vendingMachine.Display();
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void IfItemSoldOutDisplayCheckedTwiceAndMoneyInMachineDisplayAmountInserted()
        {
            //Assume that item count is 0 for candy
            vendingMachine = new VendingMachine(0, 0, 0);
            vendingMachine.InsertCoin(quarter);
            vendingMachine.CandyButton();
            string expectedResult = "25";

            var result = vendingMachine.Display();
            result = vendingMachine.Display();
            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void IfMachineHasNoChangeExactChangeIsDisplayed()
        {
            vendingMachine = new VendingMachine(0, 0, 0, 0);
            string expectedResult = "EXACT CHANGE ONLY";
            string result = vendingMachine.Display();

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void IfMachineHasNoChangeBuyItemWithExactChangeDisplayInsertCoins()
        {
            vendingMachine = new VendingMachine(1, 1, 1, 0);
            string expectedResult = "INSERT COINS";
            vendingMachine.InsertCoin(quarter);
            vendingMachine.InsertCoin(quarter);
            vendingMachine.InsertCoin(quarter);
            vendingMachine.InsertCoin(quarter);
            vendingMachine.ColaButton();

            string result = vendingMachine.Display();

            Assert.AreEqual(expectedResult, result);
        }
    }
}
