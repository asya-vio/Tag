using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tag
{
    class Point
    {
        public int I {get; set;}
        public int J {get; set;}
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
