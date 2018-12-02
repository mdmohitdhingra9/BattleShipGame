using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGround.src.common
{
    public static class BattleShipHelper
    {
        public static bool IsNumber(string input)
        {
            return int.TryParse(input, out int i);
        }

        public static int GetNumber(string input)
        {
            int result = -1;
            int.TryParse(input, out result);
            return result;
        }

        public static bool IsCharacter(string input)
        {
            return input.Length == 1;
        }

        public static char GetCharacter(string input)
        {
            return char.Parse(input);
        }
    }
}
