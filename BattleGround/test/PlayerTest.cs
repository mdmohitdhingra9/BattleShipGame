using BattleGround.src;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGround.test
{
    [TestFixture]
    public class PlayerTest
    {
        private BattleArea battleArea;
        private Player player;
        private Player player2;

        public PlayerTest()
        {
            battleArea = new BattleArea(5, 'E');
            battleArea.SetShip(ShipType.Q, 'B', 2, 2, 3);
            battleArea.SetShip(ShipType.Q, 'A', 1, 2, 3);
            battleArea.SetShip(ShipType.P, 'D', 3, 2, 4);
            battleArea.SetShip(ShipType.P, 'E', 2, 2, 3);
            player = new Player("Player-1", battleArea);

            var battleArea2 = new BattleArea(5, 'E');
            battleArea2.SetShip(ShipType.P, 'D', 3, 2, 4);
            battleArea2.SetShip(ShipType.Q, 'A', 1, 2, 3);
            player2 = new Player("Player-2", battleArea2);
        }

        [Test]
        public void AttackHitTest()
        {
            var result=player.Attack(player2, 'A', 2);
            Assert.AreEqual(Missile.Hit, result);
        }

        [Test]
        public void AttackMissTest()
        {
            var result = player.Attack(player2, 'A', 1);
            Assert.AreEqual(Missile.Miss, result);
        }

        [Test]
        public void AttackWithNoMissileTest()
        {
            player2 = new Player("Player", new BattleArea(2, 'B'));
            var result = player.Attack(player2, 'A', 3);
            Assert.AreEqual(Missile.NoMissile, result);
        }
    }
}
