using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGround.src
{
    public class Player : IEquatable<Player>
    {
        private BattleArea battleArea;
        private string playerName;
        private string[] targets;

        public Player(string playerName, BattleArea battleArea)
        {
            this.playerName = playerName;
            this.battleArea = battleArea;
        }

        public Missile Traget(char x, int y)
        {
            return battleArea.Target(x, y - 1);
        }

        public Missile Attack(Player targetPlayer, char x, int y)
        {
            return targetPlayer.Traget(x, y);
        }

        public void SetShipinBattleArea(ShipType shipType, char x, int y, int width, int height)
        {
            battleArea.SetShip(shipType, x, y - 1, width, height);
        }

        public void SetTargets(string[] targets)
        {
            this.targets = targets;
        }

        public string GetTarget()
        {
            if (this.targets == null || !this.targets.Any())
                return null;

            var target = this.targets[0];
            this.targets = this.targets.Skip(1).ToArray();
            return target;
        }

        public bool HasTargets()
        {
            return this.targets?.Length > 0;
        }

        public int GetTargetsCount()
        {
            if (this.targets != null && targets.Any())
            {
                return this.targets.Length;
            }

            return 0;
        }

        public string GetName()
        {
            return this.playerName;
        }

        public bool Equals(Player other)
        {
            if (other == null)
                return false;

            return object.ReferenceEquals(this.playerName, other.playerName);
        }

        public int ShipsCount()
        {
            return battleArea.GetShipCount();
        }
    }

}
