﻿
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStrategyGame.GameTop.Interfaces
{
    interface IRenderable
    {
        Screen Screen { get; set; }
        Renderer Renderer { get; set; }
        Rectangle Rect { get; set; }

        void render();
        void destroy();
    }
}
