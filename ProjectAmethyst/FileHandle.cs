using System;
using System.IO;
using System.Collections.Generic;

namespace ProjectAmethyst
{
    public static class FileHandle
    {
        private static String _LOCATION = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\ProjectAmethyst\\";
        private static String _FILENAME = "settings.cfg";

        private static LinkedList<Setting> settings;

        public static void addSetting()
        {

        }

        public static void readSettings()
        {
            String line;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(_LOCATION + _FILENAME);

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the line to console window
                    Console.WriteLine(line);
                    
                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
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
                }
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        public static void writeSettings()
        {
            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter(_LOCATION + _FILENAME);

                //Write a line of text
                sw.WriteLine("Hello World!!");

                //Write a second line of text
                sw.WriteLine("From the StreamWriter class");

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                if (!System.IO.Directory.Exists(_LOCATION))
                {
                    Console.WriteLine("Directory did not exist! creating now...");
                    System.IO.Directory.CreateDirectory(_LOCATION);
                    Console.WriteLine("Created Directory at: " + _LOCATION);
                }
            }
            finally
            {
                Console.WriteLine("Completed Successfully. Location: " + _LOCATION + _FILENAME);
            }
        }
    }
}
