using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleGround.src
{
    public class BattleArea
    {
        private Ship[,] board;
        private static Dictionary<char, int> boardRows = GetBoardRows();
        private int shipCount;

        public BattleArea(int column, char row)
        {
            row = Char.ToUpper(row);
            int r = boardRows[row];
            if (column > 9)
            {
                throw new Exception("Battle ground width is high. It should be equal to or less than 9.");
            }
            if (!boardRows.Keys.Contains(row))
            {
                throw new Exception($"Input {row} for creating battle area is incorrect. Please use input between A-Z");
            }

            this.board = new Ship[r, column];
            this.shipCount = 0;
        }

        public void SetShip(ShipType shipType, char x, int y, int width, int height)
        {
            this.ValidateBoardRow(x);
            this.ValidateBoardColumn(y);

            int maxBoardWidth = board.GetLength(0);
            int maxBoardHeight = board.GetLength(1);
            int row = boardRows[char.ToUpper(x)] - 1;

            int forwardWidth = 0, backwardWidth = 0, forwardHeight = 0, backwardHeight = 0;
            for (int k = 0; k < height; k++)
            {
                int newRow = 0;
                if (row + k < maxBoardHeight)
                {
                    newRow = row + forwardHeight;
                    forwardHeight++; backwardHeight = 1;
                }
                else
                {
                    newRow = row - backwardHeight;
                    backwardHeight++;
                }

                forwardWidth = 0; backwardWidth = 0;
                for (int i = 0; i < width; i++)
                {
                    if (y + i < maxBoardWidth)
                    {
                        if (board[newRow, y + forwardWidth] == null)
                        {
                            board[newRow, y + forwardWidth] = new Ship(shipType);
                            this.shipCount++;
                            forwardWidth++;
                            backwardWidth = 1;
                        }
                    }
                    else
                    {
                        if (board[newRow, y - backwardWidth] == null)
                        {
                            board[newRow, y - backwardWidth] = new Ship(shipType);
                            backwardWidth++;
                            this.shipCount++;
                        }
                    }
                }
            }
        }

        public int GetShipCount()
        {
            return shipCount;
        }

        public Missile Target(char x, int y)
        {
            this.ValidateBoardRow(x);
            this.ValidateBoardColumn(y);

            if (this.shipCount <= 0)
            {
                return Missile.NoMissile;
            }

            int row = boardRows[char.ToUpper(x)] - 1;
            var ship = board[row, y];
            if (ship != null && !ship.IsDestoryed())
            {
                ship.Target();
                board[row, y] = !ship.IsDestoryed() ? ship : null;

                this.shipCount = board[row, y] == null ? this.shipCount - 1 : this.shipCount;
                return Missile.Hit;
            }

            return Missile.Miss;
        }

        private void ValidateBoardRow(char x)
        {
            int row = boardRows[char.ToUpper(x)] - 1;
            if (board.GetLength(0) < row)
            {
                throw new Exception($"The input row {x} is outside the battle area.");
            }
        }

        private void ValidateBoardColumn(int y)
        {
            if (board.GetLength(1) < y)
            {
                throw new Exception($"The input column {y} is outside the battle area.");
            }
        }

        private static Dictionary<char, int> GetBoardRows()
        {
            return new Dictionary<char, int>()
            {
                {'A',1},{'B',2},{'C',3},{'D',4},{'E',5},{'F',6},{'G',7},{'H',8},{'I',9},{'J',10},{'K',11},{'L',12},{'M',13},{'N',14},{'O',15},{'P',16},{'Q',17},{'R',18},{'S',19},{'T',20},{'U',21},{'V',22},{'W',23},{'X',24},{'Y',25},{'Z',26},
            };
        }
    }
}
