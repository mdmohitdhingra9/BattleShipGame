using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BattleGround.src;

namespace BattleGround.src
{
    class MainBattleGround
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n------------ Start Battle Ship Game ---------------\n\n");
            IPlayerController playerController = new PlayerController();

            BattleShipController controller = new BattleShipController(playerController);

            // 5 E
            var battleArea = Console.ReadLine();
            var battleAreaCoordinates = controller.GetBattleAreaCoordinates(battleArea);

            // 2
            var players = Console.ReadLine();
            var numberofPlayers = controller.GetNumberofPlayers(players);

            playerController.CreatePlayers(numberofPlayers, battleAreaCoordinates.Item1, battleAreaCoordinates.Item2);

            // Q 1 1 A1 B2
            var shipTypeQInput = Console.ReadLine();
            var shipTypeQ = controller.GetShipType(shipTypeQInput);
            playerController.CreateandAssignShips(shipTypeQ.Item1, shipTypeQ.Item2, shipTypeQ.Item3, shipTypeQ.Item4);
            // P 2 1 D4 C3
            var shipTypePInput = Console.ReadLine();
            var shipTypeP = controller.GetShipType(shipTypePInput);
            playerController.CreateandAssignShips(shipTypeP.Item1, shipTypeP.Item2, shipTypeP.Item3, shipTypeP.Item4);

            // A1 B2 B2 B3
            var player_one_targets = Console.ReadLine();
            controller.SetTargets(player_one_targets);

            var player_two_targets = Console.ReadLine();
            controller.SetTargets(player_two_targets);

            Console.WriteLine("\n\n-------------- Initializing Battle Ground --------------\n\n");
            controller.Play();
            Console.Read();
        }
    }
}
