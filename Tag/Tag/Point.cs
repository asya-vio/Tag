using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    public class Point
    {
        public int I,J;
        public Point(int x, int y)
        {
            this.I = x;
            this.J = y;
        }
        public Point()
        {
            this.I = -1;
            this.J = -1;          
        }
    }
}
