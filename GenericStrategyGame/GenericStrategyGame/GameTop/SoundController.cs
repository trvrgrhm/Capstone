using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericStrategyGame.GameTop
{
    class SoundController
    {
        Dictionary<string, Song> songList;
        Dictionary<string, SoundEffect> soundEffects;
        ContentManager Content { get; set; }
        public void init(ContentManager content)
        {
            Content = content;
            songList = new Dictionary<string, Song>();
            soundEffects = new Dictionary<string, SoundEffect>();
        }
        public void loadContent()
        {
            SoundEffect clickSound = Content.Load<SoundEffect>("Sounds/MenuSelectionClick");

            Song mainSong = Content.Load<Song>("Sounds/MagicalTheme");
            Song battleSong = Content.Load<Song>("Sounds/HeroicDemise");

            soundEffects.Add("clickSound", clickSound);
            songList.Add("MagicalTheme", mainSong);
            songList.Add("HeroicDemise", battleSong);
        }
        public void playSong(string songName)
        {
            MediaPlayer.Play(songList[songName]);
            MediaPlayer.IsRepeating = true;
        }
        public void playSound(string soundName)
        {
            soundEffects[soundName].Play();
        }
        public void unloadContent()
        {
            foreach (SoundEffect sound in soundEffects.Values)
            {
                sound.Dispose();
            }
            foreach (Song song in songList.Values)
            {
                song.Dispose();
            }
        }
    }
}
