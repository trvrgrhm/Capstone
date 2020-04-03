using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.Interfaces
{
    interface IScrollable
    {
        void onScrollDown();
        void onScrollUp();
        void updateScroll(int scrollValue);
        void destroy();
    }
}
