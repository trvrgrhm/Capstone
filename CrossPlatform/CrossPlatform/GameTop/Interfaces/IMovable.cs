using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.Interfaces
{
    interface IMovable
    {
        int dx { get; set; }
        int dy { get; set; }

        void move();
    }
}
