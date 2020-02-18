using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.Interfaces
{
    interface IHoverable
    {
        void onHover();
        void updateHover(Point mousePosition);
    }
}
