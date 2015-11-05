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
         VendingMachine vendingMachine;
         private static string InsertCoinMessage = "INSERT COIN";

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
            vendingMachine.InsertCoin(.05f);
            string result = vendingMachine.Display();

            Assert.AreEqual("0.05", result);
        }

        [Test]
        public void WhenAPennyIsInsertedDisplayDisplaysInvalidCoin()
        {
            vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(.01f);
            string result = vendingMachine.Display();
            float returnAmount = vendingMachine.CoinReturn();

            Assert.AreEqual(InsertCoinMessage, result);
            Assert.AreEqual(returnAmount, 0.01f);
        }

        [Test]
        public void InsertPennyAndNickekDisplayShouldFiveCentsAndReturnDisplayOneCent()
        {
            vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(.01f);
            vendingMachine.InsertCoin(.05f);
            string result = vendingMachine.Display();
            float returnAmount = vendingMachine.CoinReturn();

            Assert.AreEqual("0.05", result);
            Assert.AreEqual(returnAmount, 0.01f);
        }

        [Test]
        public void NoCoinsWereInsertedDisplayTheProductPrice()
        {
            vendingMachine = new VendingMachine();
            vendingMachine.ColaButton();
            
            string result = vendingMachine.Display();

            Assert.AreEqual("1", result);
        }

        [Test]
        public void InsertAQuarterSelectColaCheckDisplayTwiceDisplayShouldReady25Cents()
        {
            vendingMachine = new VendingMachine();
            vendingMachine.InsertCoin(.25f);
            vendingMachine.ColaButton();
            string result1 = vendingMachine.Display();
            string result2 = vendingMachine.Display();

            Assert.AreEqual("0.25",result2);
        }
    }
}
