using BattleGround.src.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGround.src
{
    public interface IPlayerController
    {
        void CreatePlayers(int numberofPlayer, char row, int column);
        void CreateandAssignShips(ShipType shipType, int width, int height, string coordinates);
        void SetTargets(string targets);
        void Play();

        List<Player> GetPlayers { get; }
    }

    public class PlayerController : IPlayerController
    {
        private List<Player> players;
        private int maxTargets;
        public void CreatePlayers(int numberofPlayer, char row, int column)
        {
            if (players == null)
                players = new List<Player>();

            string playerName = "Player-";
            for (int i = 0; i < numberofPlayer; i++)
            {
                players.Add(new Player(playerName + (i + 1), new BattleArea(column, row)));
            }
        }

        public List<Player> GetPlayers { get { return players; } }

        public void CreateandAssignShips(ShipType shipType, int width, int height, string coordinates)
        {
            var shipsCoordinates = coordinates.Split(' ');
            // Excpecting that we will have only 2 playser in player list

            for (int i = 0; i < shipsCoordinates.Length; i++)
            {
                var coordinate = shipsCoordinates[i];
                // validate coordinate length should be 2
                if (coordinate == null || (coordinate != null && coordinate.Length != 2))
                {
                    throw new Exception(ErrorMessage.ShipTypeMessage);
                }

                char row = BattleShipHelper.GetCharacter(coordinate[0].ToString());
                int column = BattleShipHelper.GetNumber(coordinate[1].ToString());

                if (i % 2 == 0)
                    players?[0].SetShipinBattleArea(shipType, row, column, width, height);
                else
                    players?[1].SetShipinBattleArea(shipType, row, column, width, height);
            }
        }

        public void SetTargets(string targets)
        {
            if (string.IsNullOrEmpty(targets))
                throw new Exception(ErrorMessage.TargetMessage);

            var arr = targets.Split(' ');
            if (arr == null || !arr.Any())
                throw new Exception(ErrorMessage.TargetMessage);

            if (!players[0].HasTargets())
            {
                players[0].SetTargets(arr);
            }
            else if (!players[1].HasTargets())
            {
                players[1].SetTargets(arr);
            }
        }

        public void Play()
        {
            // Expecting only 2 players
            if (players != null && players.Any() && players.Count == 2)
            {

                var playerOne = players[0];
                var playerTwo = players[1];

                int player_one_targetCount = playerOne.GetTargetsCount();
                int player_two_targetCount = playerTwo.GetTargetsCount();

                var playerTurn = playerOne;
                var targetPlayer = playerTwo;
                for (int i = 0; i < player_one_targetCount + player_two_targetCount; i++)
                {
                    var target = playerTurn.GetTarget();
                    if (target == null)
                    {
                        Console.WriteLine($"{playerTurn.GetName()} has no more missiles left to launch");
                        var playersResult = this.GetCurrentandTargetPlayer(playerTurn, targetPlayer, playerOne, playerTwo);
                        playerTurn = playersResult.Item1;
                        targetPlayer = playersResult.Item2;
                        continue;
                    }

                    // validate target
                    char row = target[0];
                    int column = BattleShipHelper.GetNumber(target[1].ToString());
                    var response = playerTurn.Attack(targetPlayer, row, column);

                    if (response == Missile.NoMissile)
                    {
                        Console.WriteLine($"{playerTurn.GetName()} has no more missiles left to launch");
                    }
                    else if (response == Missile.Hit)
                    {
                        Console.WriteLine($"{playerTurn.GetName()} fires a missile with target {target} which got hit");
                        continue;
                    }
                    else if (response == Missile.Miss)
                    {
                        Console.WriteLine($"{playerTurn.GetName()} fires a missile with target {target} which got miss");
                    }

                    // compare 2 player objects
                    var players = this.GetCurrentandTargetPlayer(playerTurn, targetPlayer, playerOne, playerTwo);
                    playerTurn = players.Item1;
                    targetPlayer = players.Item2;
                }

                int player_one_shipsCount = playerOne.ShipsCount();
                int player_two_shipsCount = playerTwo.ShipsCount();

                DisplayResult(player_one_shipsCount, player_two_shipsCount, playerOne.GetName(), playerTwo.GetName());
            }
        }

        private Tuple<Player, Player> GetCurrentandTargetPlayer(Player currentPlayer, Player targetPlayer, Player playerOne, Player playerTwo)
        {
            if (currentPlayer.Equals(playerOne))
            {
                return new Tuple<Player, Player>(playerTwo, playerOne);
            }

            return new Tuple<Player, Player>(playerOne, playerTwo);
        }

        private void DisplayResult(int playerOneShipsCount, int playertwoShipsCount, string playerOneName, string playerTwoName)
        {
            if (playerOneShipsCount > playertwoShipsCount)
            {
                Console.WriteLine($"{playerOneName} won the battle");
                return;
            }
            Console.WriteLine($"{playerTwoName} won the battle");
        }
    }
}
