using CrossPlatform.GameTop.LevelInfo;
using CrossPlatform.GameTop.UI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatform.GameTop.Tiles
{
    class CityInfoTile
    {
        public City SelectedCity { get { return selectedCity; } set{ selectedCity = value;updateCityInfo(); } }
        private City selectedCity;
        Rectangle Rect { get; set; }
        RenderableElement background;
        TextElement cityStats;

        public CityInfoTile(Screen screen, Renderer renderer, Rectangle rect)
        {
            Rect = rect;
            background = new RenderableElement(screen, renderer, Rect);
            cityStats = new TextElement(screen, renderer, Rect, "City Information");
        }

        void updateCityInfo()
        {
            if(SelectedCity == null)
            {
                cityStats.Text = "No City Selected";
            }
            else
            {
                cityStats.Text = "Owned by: " + SelectedCity.GetCityOwner(); ;
            }
        }

    }
}
