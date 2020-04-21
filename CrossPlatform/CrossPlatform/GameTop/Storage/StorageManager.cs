using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;
using System.IO;

namespace CrossPlatform.GameTop.Storage
{
    class StorageManager
    {
        //StorageDevice Device { get; set; }
        XmlSerializer Serializer { get; set; }
        WrapperManager wrapperManager { get; set; }
        PlayerInfo Info { get; set; }

        public StorageManager(PlayerInfo info)
        {
            Info = info;
            Serializer = new XmlSerializer(typeof(SaveGame));
            wrapperManager = new WrapperManager();
        }

        public void SaveGame()
        {
            try
            {
                //create save game
                SaveGame save = new SaveGame();

                //generate and add wrappers
                save.army = wrapperManager.generateWrapperFromArmy(Info.PlayerArmy);
                save.map = wrapperManager.generateWrapperFromMap(Info.SelectedMap);

                //save game
                IsolatedStorageFile isoFile;
                isoFile = IsolatedStorageFile.GetUserStoreForDomain();
                IsolatedStorageFileStream isoStream = null;

                //potentially allow multiple saves in the future...
                if (isoFile.FileExists("PlayerData"))
                {
                    isoFile.DeleteFile("PlayerData");
                }
                using(isoStream = isoFile.CreateFile("PlayerData"))
                {
                    // Set the position to the begining of the file.
                    isoStream.Seek(0, SeekOrigin.Begin);
                    // Serialize the new data object.
                    Serializer.Serialize(isoStream, save);
                    // Set the length of the file.
                    isoStream.SetLength(isoStream.Position);
                }
                isoFile.Close();
                isoStream.Dispose();
            }
            catch(Exception e)
            {
                Console.WriteLine("error with saving game... " + e.ToString());
            }

        }

        public void LoadGame()
        {
            try
            {
                IsolatedStorageFile isoFile;
                isoFile = IsolatedStorageFile.GetUserStoreForDomain();
                IsolatedStorageFileStream isoStream = null;


                using(isoStream = isoFile.OpenFile("PlayerData", FileMode.Open, FileAccess.ReadWrite))
                {
                    SaveGame save = (SaveGame)Serializer.Deserialize(isoStream);
                    ArmyInfo.Army tempArmy = wrapperManager.generateArmyFromWrapper(save.army);
                    LevelInfo.CityMap tempMap = wrapperManager.generateMapFromWrapper(save.map);
                    if (tempArmy.units.Count > 0)
                    {
                        Info.PlayerArmy = tempArmy;
                        Info.SelectedMap = tempMap;
                    }

                }
                isoFile.Close();
                isoStream.Dispose();

            }
            catch (Exception e)
            {
                Console.WriteLine("error with loading game... " + e.ToString());
            }
        }
        public void ResetGame()
        {
            Info.resetGame();
            //SaveGame();
            //LoadGame();
        }
    }


    [Serializable]
    public struct SaveGame
    {
        public ArmyWrapper army;
        public MapWrapper map;
    }

    
}
