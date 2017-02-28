using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    public class Game2 : Game
    {
        private readonly int counter;
        private readonly int boardSize;
        private static Random rng = new Random();
        public Game2(params int[] value)
        {
            // if (Math.Sqrt(counter) % 1 != 0)
            // {
            //     throw new ArgumentException("Количество фишек не дает квадратного поля"); 
            // }

            // this.counter = counter;
            // this.boardSize = (int)Math.Sqrt(counter);
            // this.GameBoard = new List<List<int>>();

            // for (int i = 0; i < boardSize; i++)
            //     GameBoard.Add(new List<int>());

            // for (int i = 0; i < boardSize; i++)
            //     for (int j = 0; j < boardSize; j++)
            //         GameBoard[i].Add(i * boardSize + (j + 1));
            // GameBoard[boardSize - 1][boardSize - 1] = 0;

            // this.ValueLocation = new Point[counter];
            // for (int i = 0; i < counter; i++)
            //     ValueLocation[i] = new Point();

            //Shuffle(GameBoard);
        }

       //private static void Shuffle<GameBoard>(this IList<GameBoard> board)
       // {
       //     int n = board.Count;
       //     while (n > 1)
       //     {
       //         n--;
       //         int k = rng.Next(n + 1);
       //         GameBoard value = board[k];
       //         board[k] = board[n];
       //         board[n] = value;
       //     }
       // }

    }
}
