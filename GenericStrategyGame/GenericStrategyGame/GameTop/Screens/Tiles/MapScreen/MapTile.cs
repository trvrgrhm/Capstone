﻿using GenericStrategyGame.GameTop.LevelInfo;
using GenericStrategyGame.GameTop.UI;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStrategyGame.GameTop.Tiles
{
    class MapTile
    {
        PlayerInfo PlayerInfo { get; set; }
        CityMap Map { get; set; }
        public City SelectedCity { get {return selectedCity; } set  {selectedCity = value; newCitySelected = true; } }
        private City selectedCity;
        public bool newCitySelected;


        Rectangle Rect { get; set; }
        List<CityButton> CityButtons { get; set; }

        public MapTile(Screen screen, Renderer renderer, Rectangle rect, PlayerInfo playerInfo)
        {
            PlayerInfo = playerInfo;
            Map = PlayerInfo.SelectedMap;
            Rect = rect;
            CityButtons = new List<CityButton>();
            foreach (City city in Map.Cities)
            {
                Rectangle cityRect = new Rectangle(new Point(rect.Location.X + (int)((1.0 * city.MapLocation.X / Map.MapRect.Width) * rect.Width),rect.Location.Y + (int)((1.0*city.MapLocation.Y / Map.MapRect.Height) * rect.Height)), new Point(Rect.Width / 10, Rect.Width / 10));
                Button button = new Button(screen, renderer, cityRect, city.CityName);
                button.setClick(() => { SelectedCity = city; return true; });
                CityButton cityButton = new CityButton(city, button);
                CityButtons.Add(cityButton);
            }

        }
    }

    class CityButton
    {
        public City city;
        public Button button;
        public CityButton(City city,Button button)
        {
            this.city = city;
            this.button = button;

        }

    }
}
