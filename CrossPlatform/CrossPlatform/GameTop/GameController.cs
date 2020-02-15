using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatform.GameTop.Interfaces;

namespace CrossPlatform.GameTop
{
    class GameController
    {
        private IScreen previousScreen;
        private IScreen currentScreen;
        private Dictionary <ScreenState,IScreen> screens;
        private Renderer renderer;

        public void init(Renderer renderer)
        {
            this.renderer = renderer;
            screens = new Dictionary<ScreenState, IScreen>();

            screens.Add(ScreenState.MainScreenState, new MainScreen(this.renderer));
            screens[ScreenState.MainScreenState].init();

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
