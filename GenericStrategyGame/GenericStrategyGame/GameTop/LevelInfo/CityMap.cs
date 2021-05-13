using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStrategyGame.GameTop.LevelInfo
{
    class CityMap
    {
        public City SelectedCity { get; set; }
        public List<City> Cities { get; set; }
        public Rectangle MapRect { get; set; }
        public CityMap()
        {
            //TODO: fix how to add cites to map, I don't think I like this way...
            MapRect = new Rectangle(0, 0, 500, 500);
            Cities = new List<City>();
            City startCity = new City(this, new Point((int)(MapRect.Width * .25), (int)(MapRect.Height * .25)), "One City", "Enemy");
            City secondCity = new City(this, new Point((int)(MapRect.Width * .25), (int)(MapRect.Height * .75)), "Two City", "Enemy");
            City thirdCity = new City(this, new Point((int)(MapRect.Width * .75), (int)(MapRect.Height * .25)), "Three City", "Enemy");
            City fourthCity = new City(this, new Point((int)(MapRect.Width * .75), (int)(MapRect.Height * .5)), "Four City", "Enemy");
            City fifthCity = new City(this, new Point((int)(MapRect.Width * .1), (int)(MapRect.Height * .6)), "Five City", "Enemy");
            City sixthCity = new City(this, new Point((int)(MapRect.Width * .9), (int)(MapRect.Height * .9)), "Six City", "Enemy");
            City seventhCity = new City(this, new Point((int)(MapRect.Width * .5), (int)(MapRect.Height * .8)), "Seven City", "Enemy");
            City eighthCity = new City(this, new Point((int)(MapRect.Width * .6), (int)(MapRect.Height * .6)), "Eight City", "Enemy");
        }
    }
}
