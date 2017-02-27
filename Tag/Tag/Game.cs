using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    class Game
    {
        readonly int counter; //кол-во ячеек
        readonly int boardSize;
        public List<List<int>> GameBoard;
        public Point[] ValueLocation;
        //I - строка, J - столбец
        public Game(params int[] value)
        {
            this.counter = value.Length;
            foreach (int val in value)
            {
                if (val < 0)
                {                       
                    throw new ArgumentException("Передано недопустимое значение фишки - отрицательное число"); 
                    break;
                }
                if (val > counter -1)
                {
                    throw new ArgumentException("Передано cлишком большое значение фишки"); 
                    break;
                }
            }

            if (Math.Sqrt(value.Length) % 1 != 0)
            {
                throw new ArgumentException("Количество ячеек не соответствует квадратной игре"); 
            }


            this.boardSize = (int)Math.Sqrt(counter);

            this.GameBoard = new List<List<int>>();
            for (int i = 0; i < boardSize; i++)
            {
                GameBoard.Add(new List<int>());
            }
                
            for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                    GameBoard[i].Add(-1);

            this.ValueLocation = new Point[counter];

            for (int i = 0; i < counter; i++)
                ValueLocation[i] = new Point();

            int count = 0;
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {

                    if (ValueLocation[value[count]].I != -1 && ValueLocation[value[count]].J != -1)
                    {
                        throw new ArgumentException("Недопустимо повторение значений");
                    }

                    GameBoard[i][j] = value[count];
                    ValueLocation[value[count]].I = i; 
                    ValueLocation[value[count]].J = j; 
                    count++;
                }
            }
        }

        public int this[int I, int J] 
        {
            get
            {
                return GameBoard[I][J];
            }
        }
        //public int Indexer(int I, int J)
        //{
        //    if (I >= boardSize || J >= boardSize || I < 0 || J < 0)
        //    {
        //        {
        //            throw new ArgumentException("Переданы неверные координаты");
        //        }
        //    }
        //    else return GameBoard[I][J];
        //}

        public Point GetLocation(int value)
        {
            if (value > counter - 1 || value < 0)
            {
                throw new ArgumentException("Передано неверное значение ячейки");
            }
            else
            {
                return new Point(ValueLocation[value].I, ValueLocation[value].J);
            }
        }

        public void Shift(int value)
        {
            int I = GetLocation(value).I;
            int J = GetLocation(value).J;

            if (I < boardSize - 1)
            {
                if (GameBoard[I + 1][J] == 0)
                {
                    GameBoard[I + 1][J] = value;
                    GameBoard[I][J] = 0;

                    ValueLocation[0].I = I;
                    ValueLocation[0].J = J;

                    ValueLocation[value].I = I + 1;
                    return;
                }
            }
            if (J < boardSize - 1)
            {
                if (GameBoard[I][J + 1] == 0)
                {
                    GameBoard[I][J + 1] = value;
                    GameBoard[I][J] = 0;

                    ValueLocation[0].I = I;
                    ValueLocation[0].J = J;

                    ValueLocation[value].J = J + 1;
                    return;
                }
            }

            if (I > 0)
            {
                if (GameBoard[I - 1][J] == 0)
                {
                    GameBoard[I - 1][J] = value;
                    GameBoard[I][J] = 0;

                    ValueLocation[0].I = I;
                    ValueLocation[0].J = J;

                    ValueLocation[value].I = I - 1;
                    return;
                }
            }

            if (J > 0)
            {
                if (GameBoard[I][J - 1] == 0)
                {
                    GameBoard[I][J - 1] = value;
                    GameBoard[I][J] = 0;

                    ValueLocation[0].I = I;
                    ValueLocation[0].J = J;

                    ValueLocation[value].J = J - 1;
                    return;
                }
            }

            throw new ArgumentException("Эту ячейку сдвинуть нельзя");
        }

        public void Shift1(int value)
        {

        }

        public bool IsEnd()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (GameBoard[i][j] != i * boardSize + (j + 1) && i != boardSize - 1 && j != boardSize - 1
                        || GameBoard[boardSize - 1][boardSize - 1] != 0)
                        return false;
                }
            }
            return true;
        }

        public void PrintBoard()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (GameBoard[i][j] / 10 > 0) Console.Write("{0} ", GameBoard[i][j]);
                    else Console.Write("{0}  ", GameBoard[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
