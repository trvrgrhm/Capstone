using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.Interfaces
{
    interface IClickable
    {
        void setClick(Func<bool> function);
        void onClick();
        void updateClick(Point mouseLocation, bool leftClick);
    }
}
