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


        [SetUp]
        public void TestSetup()
        {
            vendingMachine = new VendingMachine();
        }

    }
}
