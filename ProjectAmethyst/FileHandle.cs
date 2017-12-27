using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProjectAmethyst
{
    public static class FileHandle
    {
        private static String _LOCATION = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\ProjectAmethyst\\";
        private static String _FILENAME = "settings.amts";
        private static String _CHAMPFILE = "champgroups.amts";
        public static Settings _settings;

        public static Settings getDefaultSettings()
        {
            return (
                new Settings
                {
                    startWithWindows = false,
                    leagueVersion = "kappa",
                    appVersion = "pre-alpha"
                });
        }

        public static void readSettings()
        {
            checkDirectory();
            try
            {
                //Pass the file path and file name to the FileStream constructor
                FileStream fs = new FileStream(_LOCATION + _FILENAME, FileMode.Open);

                //Deserialize
                BinaryFormatter bf = new BinaryFormatter();

                _settings = (Settings)bf.Deserialize(fs);

                if(_settings == null)
                {
                    _settings = getDefaultSettings();
                }

                Console.WriteLine(
                    "Settings Found: \n" + 
                    "/t" + _settings.appVersion + "\n" +
                    "/t" + _settings.leagueVersion + "\n" +
                    "/t" + _settings.startWithWindows + "\n"
                    );

                //close the file
                fs.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when reading settings file\n" + e.Message + "\n" + e.StackTrace);
                _settings = getDefaultSettings();
            }
        }

        public static void writeSettings()
        {
            checkDirectory();
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                //Pass the filepath and filename to the StreamWriter Constructor
                FileStream fs = new FileStream(_LOCATION + _FILENAME, FileMode.Create);

                if (_settings == null)
                {
                    _settings = getDefaultSettings();
                }

                //Serialize settings to the stream output
                bf.Serialize(fs, _settings);

                //Close the file
                fs.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when writing settings file\n" + e.Message + "\n" + e.StackTrace);
            }
        }

        public static void readChamps()
        {
            checkChamps();
            try
            {
                //Pass the file path and file name to the FileStream constructor
                FileStream fs = new FileStream(_LOCATION + _CHAMPFILE, FileMode.Open);

                //Deserialize
                BinaryFormatter bf = new BinaryFormatter();

                ChampionGroup.groups = (List<ChampionGroup>)bf.Deserialize(fs);

                //close the file
                fs.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when reading championGroups file\n" + e.Message + "\n" + e.StackTrace);
            }
        }

        public static void writeChamps()
        {
            checkChamps();
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                //Pass the filepath and filename to the StreamWriter Constructor
                FileStream fs = new FileStream(_LOCATION + _CHAMPFILE, FileMode.Create);

                //Serialize settings to the stream output
                bf.Serialize(fs, ChampionGroup.groups);

                //Close the file
                fs.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error when writing championGroups file\n" + e.Message + "\n" + e.StackTrace);
            }
        }

        public static void checkDirectory()
        {
            if (!System.IO.Directory.Exists(_LOCATION))
            {
                Console.WriteLine("Directory did not exist! creating now...");
                System.IO.Directory.CreateDirectory(_LOCATION);
                Console.WriteLine("Created Directory at: " + _LOCATION);
            }
            if (!System.IO.File.Exists(_LOCATION + _FILENAME))
            {
                Console.WriteLine("File did not exist! creating now...");
                System.IO.File.Create(_LOCATION + _FILENAME);
                Console.WriteLine("Created File at: " + _LOCATION + _FILENAME);
                _settings = getDefaultSettings();
                writeSettings();
            }
        }
        public static void checkChamps()
        {
            if (!System.IO.Directory.Exists(_LOCATION))
            {
                Console.WriteLine("Directory did not exist! creating now...");
                System.IO.Directory.CreateDirectory(_LOCATION);
                Console.WriteLine("Created Directory at: " + _LOCATION);
            }
            if (!System.IO.File.Exists(_LOCATION + _CHAMPFILE))
            {
                Console.WriteLine("File did not exist! creating now...");
                System.IO.File.Create(_LOCATION + _CHAMPFILE);
                Console.WriteLine("Created File at: " + _LOCATION + _CHAMPFILE);
            }
        }
    }
}
