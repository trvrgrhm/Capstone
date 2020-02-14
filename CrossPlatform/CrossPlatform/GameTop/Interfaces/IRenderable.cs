
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.Interfaces
{
    interface IRenderable
    {
        float X { get; set; }
        float Y { get; set; }

        void render();
    }
}
