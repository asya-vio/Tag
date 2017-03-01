using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tag
{
    class Game
    {
        private readonly int counter;
        public readonly int boardSize;
        public int[,] GameBoard;
        public Point[] ValueLocation;
        //I - строка, J - столбец
        public Game(params int[] value)
        {
            if (Math.Sqrt(value.Length) % 1 != 0)
            {
                throw new ArgumentException("Количество ячеек не соответствует квадратной игре");
            }

            this.counter = value.Length;
            int count = 0;
            for(int i = 0; i < counter - 1; i++)
            {
                for (int j = 0; j < counter - 1; j++)
                {
                    if (value[j] == i)
                    {
                        count++;
                        break;
                    }
                }
            }
            if (count != counter - 1) 
            {
              throw new ArgumentException("Введены некорректные данные");
            }

            this.boardSize = (int)Math.Sqrt(counter);

            this.GameBoard = new int[boardSize, boardSize];

            this.ValueLocation = new Point[counter];

            count = 0;
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    this[i, j] = value[count];
                    ValueLocation[value[count]] = new Point(i, j);
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
            set
            {
                GameBoard[I, J] = value;
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
        private void Swap(int val1, int val2 = 0)
        {
            int I0 = GetLocation(0).I;
            int J0 = GetLocation(0).J;

            int I = GetLocation(val1).I;
            int J = GetLocation(val1).J;

            this[I, J] = 0;
            this[I0, J0] = val1;
            ValueLocation[0].I = I;
            ValueLocation[0].J = J;

            ValueLocation[val1].I = I0;
            ValueLocation[val1].J = J0;
        }
        public void Shift(int value)
        {
            int I = GetLocation(value).I;
            int J = GetLocation(value).J;

            int I0 = GetLocation(0).I;
            int J0 = GetLocation(0).J;


            if (I == I0 && (J - J0 == 1 || J0 - J == 1) || J == J0 && (I - I0 == 1 || I0 - I == 1))
                Swap(value, 0);

            else 
            throw new ArgumentException("Эту ячейку сдвинуть нельзя");
        }
        public static Game ReadCSV(string filePath)
        {
            List<int[]> masList = new List<int[]>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var strMas = line.Split(';');
                    int[] intMas = new int[strMas.Length];
                    for (int i = 0; i < strMas.Length; i++)
                    {
                        intMas[i] = int.Parse(strMas[i]);
                    }
                    masList.Add(intMas);
                }
            }
            int[] gameArr = new int[masList.Count * masList.Count];
            int cnt = 0;
            for (int i = 0; i < masList.Count; i++)
            {
                for (int j = 0; j < masList.Count; j++)
                {
                    gameArr[cnt] = masList[i][j];
                    cnt++;
                }
            }

            return new Game(gameArr);

        }
        public bool IsEnd()
        {
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    if (this[i, j] != i * boardSize + (j + 1) && (i != boardSize - 1 || j != boardSize - 1))

                        return false;
                }
            }
            return true;
        }

    }
}
