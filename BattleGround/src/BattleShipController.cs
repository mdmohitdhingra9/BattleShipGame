using BattleGround.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleGround.src.common;

namespace BattleGround.src
{
    public class BattleShipController
    {
        private IPlayerController playerController;


        public BattleShipController(IPlayerController playerController)
        {
            this.playerController = playerController;
        }

        public Tuple<char, int> GetBattleAreaCoordinates(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new Exception(ErrorMessage.BattleAreaMessage);

            var arr = input.Split(' ');

            if (arr != null &&
                (arr.Length > 2
                || arr.Length < 2
                || !BattleShipHelper.IsNumber(arr[0])
                || !BattleShipHelper.IsCharacter(arr[1])))
            {
                throw new Exception(ErrorMessage.BattleAreaMessage);
            }

            return new Tuple<char, int>(BattleShipHelper.GetCharacter(arr[1]), BattleShipHelper.GetNumber(arr[0]));
        }

        public int GetNumberofPlayers(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new Exception(ErrorMessage.NumberofPlayerMessage);

            if (!BattleShipHelper.IsNumber(input))
                throw new Exception(ErrorMessage.NumberofPlayerMessage);

            int number = BattleShipHelper.GetNumber(input);
            if (number != 2)
                throw new Exception(ErrorMessage.NumberofPlayerMessage);

            return number;
        }

        public Tuple<ShipType, int, int, string> GetShipType(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new Exception(ErrorMessage.ShipTypeMessage);

            var arr = input.Split(' ');
            if (arr != null && (arr.Length < 5 || !BattleShipHelper.IsCharacter(arr[0]) || !BattleShipHelper.IsNumber(arr[1]) || !BattleShipHelper.IsNumber(arr[2])))
                throw new Exception(ErrorMessage.ShipTypeMessage);

            var shipType = (ShipType)BattleShipHelper.GetCharacter(arr[0]);
            var numberOfShips = BattleShipHelper.GetNumber(arr[1]);
            var numberOfShips1 = BattleShipHelper.GetNumber(arr[2]);
            var shipAreas = string.Join(" ", arr.Skip(3));
            return new Tuple<ShipType, int, int, string>(shipType, numberOfShips, numberOfShips1, shipAreas);
        }

        public void SetTargets(string input)
        {
            this.playerController.SetTargets(input);
        }

        public void Play()
        {
            this.playerController.Play();
        }
    }
}
