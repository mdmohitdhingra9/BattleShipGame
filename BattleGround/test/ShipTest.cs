using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGround.src;
using NUnit.Framework;

namespace BattleGround.test
{
    [TestFixture]
    public class ShipTest
    {
        [Test]
        public void IsShip_P_DestroyedTest()
        {
            var ship = new Ship(ShipType.P);
            ship.Target();
            Assert.IsTrue(ship.IsDestoryed());
        }

        [Test]
        public void IsShip_P_Not_DestroyedTest()
        {
            var ship = new Ship(ShipType.P);
            Assert.IsTrue(ship.IsDestoryed());
        }

        [Test]
        public void IsShip_Q_DestroyedTest()
        {
            var ship = new Ship(ShipType.Q);
            ship.Target();
            ship.Target();
            Assert.IsTrue(ship.IsDestoryed());
        }

        [Test]
        public void IsShip_Q_Not_DestroyedTest()
        {
            var ship = new Ship(ShipType.Q);
            ship.Target();
            Assert.IsFalse(ship.IsDestoryed());
        }
    }
}
