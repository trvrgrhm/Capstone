﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStrategyGame.GameTop.Interfaces
{
    interface IClickable
    {
        void setOnClick(Func<bool> function);
        void onClick();
        void updateClick(Point mouseLocation, bool leftClick, bool dragStarted);
        void destroy();
    }
}
