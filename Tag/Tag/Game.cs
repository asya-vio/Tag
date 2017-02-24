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
        private readonly int boardSize;
        public List<List<int>> GameBoard;
        public int[][] ValueLocation;
        //I - строка, J - столбец
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
            this.boardSize = (int)Math.Sqrt(Counter);

            this.GameBoard = new List<List<int>>();
            for (int i = 0; i < boardSize; i++)
                GameBoard.Add(new List<int>());

            for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                    GameBoard[i].Add(-1);

            this.ValueLocation = new int[Counter][];

            for (int i = 0; i < Counter; i++)
            {
                ValueLocation[i] = new int[2];
                ValueLocation[i][0] = -1;
                ValueLocation[i][1] = -1;
            }

            counter = 0;
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (value[counter] > Counter - 1 || value[counter] < 0)
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

        public int Indexer(int I, int J)
        {
            if (I >= boardSize || J >= boardSize || I < 0 || J < 0)
            {
                {
                    throw new ArgumentException();
                }
            }
            else return GameBoard[I][J];
        }

        public void GetLocation(int value, out int I, out int J)
        {
            if (value > Counter - 1 || value < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                I = ValueLocation[value][0];
                J = ValueLocation[value][1];
            }
        }

        public void Shift(int value)
        {
            int I, J;
            GetLocation(value, out I, out J);

            try
            {
                if (I < boardSize - 1)
                {
                    if (GameBoard[I + 1][J] == 0)
                    {
                        GameBoard[I + 1][J] = value;
                        GameBoard[I][J] = 0;

                        ValueLocation[0][0] = I;
                        ValueLocation[0][1] = J;

                        ValueLocation[value][0] = I + 1;
                        return;
                    }
                }
                if (J < boardSize - 1)
                {
                    if (GameBoard[I][J + 1] == 0)
                    {
                        GameBoard[I][J + 1] = value;
                        GameBoard[I][J] = 0;

                        ValueLocation[0][0] = I;
                        ValueLocation[0][1] = J;

                        ValueLocation[value][1] = J + 1;
                        return;
                    }
                }

                if (I > 0)
                {
                    if (GameBoard[I - 1][J] == 0)
                    {
                        GameBoard[I - 1][J] = value;
                        GameBoard[I][J] = 0;

                        ValueLocation[0][0] = I;
                        ValueLocation[0][1] = J;

                        ValueLocation[value][0] = I - 1;
                        return;
                    }
                }

                if (J > 0)
                {
                    if (GameBoard[I][J - 1] == 0)
                    {
                        GameBoard[I][J - 1] = value;
                        GameBoard[I][J] = 0;

                        ValueLocation[0][0] = I;
                        ValueLocation[0][1] = J;

                        ValueLocation[value][1] = J - 1;
                        return;
                    }
                }

                throw new ArgumentException();
                
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Shift is impossible\n");
            }
        }
        public void PrintBoard()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    Console.Write("{0}  ", GameBoard[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
