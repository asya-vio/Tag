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

    }
}
