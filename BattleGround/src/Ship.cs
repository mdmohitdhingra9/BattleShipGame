using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGround.src
{
    public class Ship
    {
        private int life = 0;
        private ShipType shipType;

        public Ship(ShipType shipType)
        {
            this.shipType = shipType;
            life = shipType == ShipType.P ? 1 : 2;
        }

        public void Target()
        {
            if (this.life > 0)
                this.life--;
        }

        public bool IsDestoryed()
        {
            return life == 0;
        }
    }
}
