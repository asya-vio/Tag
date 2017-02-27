using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    class Game2 : Game
    {
        private readonly int counter;
        private readonly int boardSize;
        public Game2(int counter)
        {
            if (Math.Sqrt(counter) % 1 != 0)
            {
                throw new ArgumentException("Количество фишек не дает квадратного поля"); 
            }

            this.counter = counter;
            this.boardSize = (int)Math.Sqrt(counter);
            this.GameBoard = new List<List<int>>();

            for (int i = 0; i < boardSize; i++)
                GameBoard.Add(new List<int>());

            for (int i = 0; i < boardSize; i++)
                for (int j = 0; j < boardSize; j++)
                    GameBoard[i].Add(-1);


            this.ValueLocation = new Point[counter];

            for (int i = 0; i < counter; i++)
                ValueLocation[i] = new Point();

            for (int i = 0; i < counter - 1; i++)
            {

            }

        }

    }
}
