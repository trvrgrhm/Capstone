using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.Interfaces
{
    interface IMovable
    {
        int DX { get; set; }
        int DY { get; set; }

        void move();
    }
}
