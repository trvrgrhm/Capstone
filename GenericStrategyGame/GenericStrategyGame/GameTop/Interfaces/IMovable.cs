using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStrategyGame.GameTop.Interfaces
{
    interface IMovable
    {
        int DX { get; set; }
        int DY { get; set; }
        int X { get; set; }
        int Y { get; set; }

        void move();
        void destroy();
    }
}
