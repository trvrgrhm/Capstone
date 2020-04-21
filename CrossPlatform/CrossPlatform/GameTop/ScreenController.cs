using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossPlatform.GameTop.Interfaces;
using CrossPlatform.GameTop.Screens;
using CrossPlatform.GameTop.Storage;
using Microsoft.Xna.Framework;

namespace CrossPlatform.GameTop
{
    class ScreenController
    {
        private ScreenState previousScreen;
        private ScreenState currentScreen;
        private Dictionary <ScreenState,Screen> screens;
        private Rectangle ScreenSize { get; set; }
        //potentially get rid of things that screencontroller doesn't need...
        private Renderer renderer;
        private SoundController soundController;

        public PlayerInfo playerInfo { get; set; }
        public StorageManager storageManager { get; set; }

        public void init(Renderer renderer, PlayerInfo playerInfo,StorageManager storageManager, SoundController soundController,Rectangle screenSize)
        {
            //will eventually get this from save data
            this.playerInfo = playerInfo;
            this.storageManager = storageManager;

            ScreenSize = screenSize;

            this.renderer = renderer;
            this.soundController = soundController;

            screens = new Dictionary<ScreenState, Screen>();
            //main screen
            screens.Add(ScreenState.MainScreenState, new MainScreen(this,this.renderer, this.soundController, this.playerInfo));
            //map screen
            screens.Add(ScreenState.MapScreenState, new MapScreen(this, this.renderer, this.soundController, this.playerInfo));
            //army screen
            screens.Add(ScreenState.ArmyScreenState, new ArmyScreen(this, this.renderer, this.soundController, this.playerInfo));
            //battle screen
            screens.Add(ScreenState.BattleScreenState, new BattleScreen(this, this.renderer, this.soundController, this.playerInfo));
            //setting screen
            screens.Add(ScreenState.SettingScreenState, new SettingScreen(this, this.renderer, this.soundController, this.playerInfo,this.storageManager));


            goToScreen(ScreenState.MainScreenState);
        }

        public void goToScreen(ScreenState screenState)
        {
            previousScreen = currentScreen;
            screens[screenState].init(ScreenSize);
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
