using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    class Game
    {
        public readonly int Counter;
        public List<List<int>> GameBoard;
        public Game(int count)
        {
            Counter = count;
            List<List<int>> GameBoard = new List<List<int>>();

            for (int i = 0; i < Counter; i++)
                for (int j = 0; j < Counter; j++)
                    GameBoard[i].Add(0);
        }

        public int Indexer(int x, int y)
        {
            if (x >= Counter || y >= Counter || x < 0 || y < 0)
            {
                {
                    throw new ArgumentException();
                }
            }
            else return GameBoard[x][y];
        }

        public void Shift(int value)
        {
            int x = 0, y = 0;
            for (int i = 0; i < Counter; i++)
            {
                bool flag = true;
                for (int j = 0; j < Counter; j++)
                    if (GameBoard[i][j] == value)
                    {
                        x = i; y = j;
                        flag = false;
                        break;
                    }
                if (!flag) break;
            }
            if (x < Counter - 1 && y < Counter - 1)
            {
                if (GameBoard[x + 1][y] == 0)
                {
                    GameBoard[x + 1][y] = value;
                    GameBoard[x][y] = 0;
                    return;
                }
                else if (GameBoard[x][y + 1] == 0)
                {
                    GameBoard[x][y + 1] = value;
                    GameBoard[x][y] = 0;
                    return;
                }
                else if (GameBoard[x + 1][y + 1] == 0)
                {
                    GameBoard[x + 1][y + 1] = value;
                    GameBoard[x][y] = 0;
                    return;
                }
            }

            else if (x > 0 && y > 0)
            {
                if (GameBoard[x - 1][y] == 0)
                {
                    GameBoard[x - 1][y] = value;
                    GameBoard[x][y] = 0;
                    return;
                }
                else if (GameBoard[x][y - 1] == 0)
                {
                    GameBoard[x][y - 1] = value;
                    GameBoard[x][y] = 0;
                    return;
                }
                else if (GameBoard[x - 1][y - 1] == 0)
                {
                    GameBoard[x - 1][y - 1] = value;
                    GameBoard[x][y] = 0;
                    return;
                }
            }
            else if (x > 0 && y < Counter -1)
            {
                if (GameBoard[x - 1][y + 1] == 0)
                {
                    GameBoard[x - 1][y + 1] = value;
                    GameBoard[x][y] = 0;
                    return;
                }
            }
            else if (x < Counter - 1 && y > 0)
            {
                if (GameBoard[x + 1][y - 1] == 0)
                {
                    GameBoard[x + 1][y - 1] = value;
                    GameBoard[x][y] = 0;
                    return;
                }
            }
            else
            {
                throw new ArgumentException();
            }
        }

    }
}
