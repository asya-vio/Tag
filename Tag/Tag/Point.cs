using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    class Point
    {
        public int I,J;
        public Point(int X, int Y)
        {
            this.I = X;
            this.J = Y;
        }
        public Point()
        {
            this.I = -1;
            this.J = -1;          
        }
    }
}
