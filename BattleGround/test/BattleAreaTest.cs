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
    public class BattleAreaTest
    {
        private BattleArea battleArea;

        public BattleAreaTest()
        {
            battleArea = new BattleArea(5, 'E');
            battleArea.SetShip(ShipType.Q, 'B', 2, 2, 3);
            battleArea.SetShip(ShipType.Q, 'A', 1, 2, 3);
            battleArea.SetShip(ShipType.P, 'D', 3, 2, 4);
            battleArea.SetShip(ShipType.P, 'E', 2, 2, 3);
        }

        [Test]
        public void HitTargetTest()
        {
            var result = battleArea.Target('A', 1);
            Assert.AreEqual(Missile.Hit, result);
        }

        [Test]
        public void MissTargetTest()
        {
            var result = battleArea.Target('C', 4);
            Assert.AreEqual(Missile.Miss, result);
        }

        [Test]
        public void NoMissileTargetTest()
        {
            var battleArea1 = new BattleArea(2, 'B');

            var result = battleArea1.Target('A', 1);
            Assert.AreEqual(Missile.NoMissile, result);
        }
    }
}
