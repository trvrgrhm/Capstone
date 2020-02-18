using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatform.GameTop.Interfaces;
using CrossPlatform.GameTop.Screens;

namespace CrossPlatform.GameTop
{
    class GameController
    {
        private Screen previousScreen;
        private Screen currentScreen;
        private Dictionary <ScreenState,Screen> screens;
        private Renderer renderer;

        public void init(Renderer renderer)
        {
            this.renderer = renderer;
            screens = new Dictionary<ScreenState, Screen>();
            //main screen
            screens.Add(ScreenState.MainScreenState, new MainScreen(this,this.renderer));
            screens[ScreenState.MainScreenState].init();
            //map screen
            screens.Add(ScreenState.MapScreenState, new MapScreen(this,this.renderer));
            screens[ScreenState.MapScreenState].init();
            //army screen
            screens.Add(ScreenState.ArmyScreenState, new ArmyScreen(this,this.renderer));
            screens[ScreenState.ArmyScreenState].init();
            //battle screen
            screens.Add(ScreenState.BattleScreenState, new Screen(this,this.renderer));
            screens[ScreenState.BattleScreenState].init();
            //setting screen
            screens.Add(ScreenState.SettingScreenState, new Screen(this,this.renderer));
            screens[ScreenState.SettingScreenState].init();

            currentScreen = screens[ScreenState.MainScreenState];
        }

        public void goToScreen(ScreenState screenState)
        {
            previousScreen = currentScreen;
            currentScreen = screens[screenState];
        }

        public void update()
        {
            currentScreen.update();
        }
        public void renderAll()
        {
            currentScreen.render();
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
