using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatform.GameTop.Interfaces;
using CrossPlatform.GameTop.Screens;

namespace CrossPlatform.GameTop
{
    class ScreenController
    {
        private ScreenState previousScreen;
        private ScreenState currentScreen;
        private Dictionary <ScreenState,Screen> screens;
        private Renderer renderer;

        public void init(Renderer renderer, Microsoft.Xna.Framework.Rectangle screenSize)
        {
            this.renderer = renderer;
            screens = new Dictionary<ScreenState, Screen>();
            //main screen
            screens.Add(ScreenState.MainScreenState, new MainScreen(this,this.renderer));
            screens[ScreenState.MainScreenState].init(screenSize);
            //map screen
            screens.Add(ScreenState.MapScreenState, new MapScreen(this,this.renderer));
            screens[ScreenState.MapScreenState].init(screenSize);
            //army screen
            screens.Add(ScreenState.ArmyScreenState, new ArmyScreen(this,this.renderer));
            screens[ScreenState.ArmyScreenState].init(screenSize);
            //battle screen
            screens.Add(ScreenState.BattleScreenState, new Screen(this,this.renderer));
            screens[ScreenState.BattleScreenState].init(screenSize);
            //setting screen
            screens.Add(ScreenState.SettingScreenState, new SettingScreen(this,this.renderer));
            screens[ScreenState.SettingScreenState].init(screenSize);

            currentScreen = ScreenState.MainScreenState;
        }

        public void goToScreen(ScreenState screenState)
        {
            previousScreen = currentScreen;
            currentScreen = screenState;
        }

        public void goToPreviousScreen()
        {
            goToScreen(previousScreen);
        }

        public void update()
        {
            screens[currentScreen].update();
        }
        public void renderAll()
        {
            screens[currentScreen].render();
        }


    }

    public enum ScreenState {
        MainScreenState,
        SettingScreenState,
        MapScreenState,
        ArmyScreenState,
        BattleScreenState,
    }

}
