using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGround.src.common
{
    public static class ErrorMessage
    {
        public const string BattleAreaMessage = "Input is incorrect. Please pass in the given format {5 E}";
        public const string NumberofPlayerMessage = "Input is incorrect. Please pass in the given format 2";
        public const string ShipTypeMessage = "Input is incorrect. Please pass in the given format [Q 1 1 A1 B2] or [P 2 1 D4 C3]";
        public const string TargetMessage = "Input is incorrect. Please pass in the given format [A1 B2 B2 B3]";
    }
}
