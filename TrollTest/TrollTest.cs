using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Troll;

namespace TrollTest
{
    [TestClass]
    public class TrollTest
    {
        private InternetTroll _troll;

        [TestInitialize]
        public void BornTheTroll()
        {
            _troll = new InternetTroll();
        }      
   
        [TestMethod]
        public void Troll_CannotEeFedWithNegativeAmmount()
        {
            _troll.Feed(1);
            _troll.Feed(-1);
            Assert.IsTrue(_troll.IsAlive, "Troll cannot be fed with negative ammount");
        }

        [TestMethod]
        public void Troll_WithoutFed_IsNotAlive()
        {
            Assert.IsFalse(_troll.IsAlive,
                "Troll is not alive without feeding");
        }

        [TestMethod]
        public void Troll_FedTwoTimes_IsAlive()
        {
            _troll.Feed(2);
            Assert.IsTrue(_troll.IsAlive, "Troll is alive after feeding twice");
        }

        [TestMethod]
        public void Troll_FedOnce_IsAlive()
        {
            _troll.FeedOnce();
            Assert.IsTrue(_troll.IsAlive, "Troll is alive after feeding once");
        }

        [TestMethod]
        public void Troll_FedOnceAfterOneIgnore_IsNotAlive()
        {
            _troll.FeedOnce();
            _troll.Ignore();
            Assert.IsFalse(_troll.IsAlive, "Troll is not alive after feeding and ignoring once");
        }

        [TestMethod]
        public void Troll_FedOnceBeforeAndAfterOneIgnore_IsAlive()
        {
            _troll.FeedOnce();
            _troll.Ignore();
            _troll.FeedOnce();
            Assert.IsTrue(_troll.IsAlive, "Troll is alive when fed, ignored and fed");
        }

        [TestMethod]
        public void Troll_IngoredBeforeAndAfterOneFed_IsNotAlive()
        {
            _troll.Ignore();
            _troll.FeedOnce();
            _troll.Ignore();
            Assert.IsFalse(_troll.IsAlive, "Troll is not alive when ingored, fed and ignored");
        }

        [TestMethod]
        public void Troll_Fed100TimesAfter100Ignores_IsNotAlive()
        {
            var n = 100;
            _troll.Feed(n);

            for (int i = 0; i < n; i++)
            {
                _troll.Ignore();    
            }

            Assert.IsFalse(_troll.IsAlive, "Troll is alive after feeding and ignoring twice");
        }

        [TestMethod]
        public void Troll_FedManyTimesAfterDie_IsNotAlive()
        {
            _troll.Feed(5);
            _troll.DieTroll();
            Assert.IsFalse(_troll.IsAlive, "Troll is alive after feeding and dieing");
        }


        /// <summary>
        /// Bug in a box ;-)
        /// </summary>
        [TestMethod]
        public void Troll_JustExactToKill_SucceedsOnSameValues()
        {
            _troll.FeedOnce();
            Assert.IsTrue(_troll.IsItJustExactToKillTroll(1), 
                "Troll should be able to be killed using same ammount of power as having health");
        }
    }
}
