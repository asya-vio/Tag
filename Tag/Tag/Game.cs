using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    class Game
    {
        public readonly int Counter; //кол-во ячеек
        public readonly int BoardSize;
        public List<List<int>> GameBoard;
        public int[][] ValueLocation; 
        public Game(params int[] value)
        {
            int counter = 0;
            foreach (int val in value)
                counter++;

            if (Math.Sqrt(counter) % 1 != 0)
            {
                throw new ArgumentException();
            }

            this.Counter = counter;
            this.BoardSize = (int)Math.Sqrt(counter);

            List<List<int>> GameBoard = new List<List<int>>();
            for (int i = 0; i < BoardSize; i++)
                for (int j = 0; j < BoardSize; j++)
                    GameBoard[i].Add(-1);

            int [][] ValueLocation = new int[Counter][];
            for (int i = 0; i < Counter; i++)
            {
                ValueLocation[i] = new int[2];
                ValueLocation[i][0] = -1;
                ValueLocation[i][1] = -1;
            }


            counter = 0;
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (value[counter] > Counter - 1)
                    {
                        throw new IndexOutOfRangeException(); //недопустимое значение ячейки
                    }

                    if (ValueLocation[value[counter]][0] != -1 && ValueLocation[value[counter]][1] != -1)
                    {
                        throw new ArgumentException(); //повторяющееся значение ячейки
                    }

                    GameBoard[i][j] = value[counter];
                    ValueLocation[value[counter]][0] = i;
                    ValueLocation[value[counter]][1] = j;
                    counter++;
                }
            }                   
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
