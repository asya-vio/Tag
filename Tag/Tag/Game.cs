using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    class Game
    {
        private readonly int counter;
        private readonly int boardSize;
        public int[,] GameBoard;
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
                }
                if (val > counter - 1)
                {
                    throw new ArgumentException("Передано cлишком большое значение фишки");
                }
            }

            if (Math.Sqrt(value.Length) % 1 != 0)
            {
                throw new ArgumentException("Количество ячеек не соответствует квадратной игре");
            }


            this.boardSize = (int)Math.Sqrt(counter);

            this.GameBoard = new int[boardSize, boardSize];
            for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                    GameBoard[i, j] = -1;

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

                    GameBoard[i, j] = value[count];
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
                return GameBoard[I, J];
            }
        }

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

            Point[] pArr = new Point[4];
            if (I < boardSize - 1) pArr[0] = new Point(I + 1, J);
            else pArr[0] = new Point(I, J);
            if (J < boardSize - 1) pArr[1] = new Point(I, J + 1);
            else pArr[1] = new Point(I, J);
            if (I > 0) pArr[2] = new Point(I - 1, J);
            else pArr[2] = new Point(I, J);
            if (J > 0) pArr[3] = new Point(I, J - 1);
            else pArr[3] = new Point(I, J);

            for (int i = 0; i < pArr.Length; i++)
            {
                if (GameBoard[pArr[i].I, pArr[i].J] == 0)
                {
                    GameBoard[pArr[i].I, pArr[i].J] = value;
                    GameBoard[I, J] = 0;

                    ValueLocation[0].I = I;
                    ValueLocation[0].J = J;

                    ValueLocation[value].I = pArr[i].I;
                    ValueLocation[value].J = pArr[i].J;

                    return;
                }
            }

            throw new ArgumentException("Эту ячейку сдвинуть нельзя");
        }
        public bool IsEnd()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (GameBoard[i, j] != i * boardSize + (j + 1) && (i != boardSize - 1 || j != boardSize - 1))

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
                    if (GameBoard[i, j] / 10 > 0) Console.Write("{0} ", GameBoard[i, j]);
                    else Console.Write("{0}  ", GameBoard[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
