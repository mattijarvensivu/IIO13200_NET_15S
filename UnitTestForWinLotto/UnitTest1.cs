using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestForWinLotto
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetWeek()
        {

            //viittaus oikeaan luokkaan ja metodiin
            JAMK.IT.WinLotto.Lotto lotto = new JAMK.IT.WinLotto.Lotto();
            //kutsutaan testattavaa metodia
            string vk = lotto.GetWeekUnfinished();
            Assert.AreEqual("41/2015", vk);
        }

        [TestMethod]
        public void TestGetWeek2()
        {

            //viittaus oikeaan luokkaan ja metodiin
            JAMK.IT.WinLotto.Lotto lotto = new JAMK.IT.WinLotto.Lotto();
            //kutsutaan testattavaa metodia
            string vk = lotto.GetWeekFixed();
            Assert.AreEqual("41/2015", vk);
        }


    }
}
