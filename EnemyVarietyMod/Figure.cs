using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace PYMN6
{
    public static class ConfigA
    {
        public const string FolderName = "EnemyVariety";
        public const string FileName = "ConfigA";
        public const bool Default = false;

        public static void TryWriteConfig() => WriteConfig(SaveName);


        public static Dictionary<string, bool> SaveConfigNames;

        public static void WriteConfig(string location)
        {
            StreamWriter text = File.CreateText(location);
            XmlDocument xmlDocument = new XmlDocument();
            string xml = "<config";
            foreach (string key in SaveConfigNames.Keys)
            {
                xml += " ";
                xml += key;
                xml += "='";
                xml += SaveConfigNames[key].ToString().ToLower();
                xml += "'\n";
            }
            xml += "> </config>";
            xmlDocument.LoadXml(xml);
            xmlDocument.Save((TextWriter)text);
            text.Close();
        }

        public static bool Check(string name)
        {
            if (!File.Exists(SaveName)) return false;
            if (SaveConfigNames == null)
            {
                SaveConfigNames = new Dictionary<string, bool>();
            }
            string l = SaveName;
            bool add = Default;
            FileStream inStream = File.Open(SaveName, FileMode.Open);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load((Stream)inStream);
            if (xmlDocument.GetElementsByTagName("config").Count > 0)
            {

                if (xmlDocument.GetElementsByTagName("config")[0].Attributes[name] != null)
                {
                    add = bool.Parse(xmlDocument.GetElementsByTagName("config")[0].Attributes[name].Value);

                }
                if (!SaveConfigNames.Keys.Contains(name))
                    SaveConfigNames.Add(name, add);
                else
                    SaveConfigNames[name] = add;
            }
            inStream.Close();
            return add;
        }

        public static void Set(string name, bool value)
        {
            if (!File.Exists(SavePath + FileName + ".config")) return;
            if (Check(name) != value)
            {
                SaveConfigNames[name] = value;
                WriteConfig(SaveName);
            }
        }

        static string pathPlus
        {
            get
            {
                return BepInEx.Paths.BepInExRootPath + "\\Plugins\\";
            }
        }
        public static string SavePath
        {
            get
            {
                if (!Directory.Exists(pathPlus + FolderName + "\\"))
                {
                    Directory.CreateDirectory(pathPlus + FolderName + "\\");
                }
                return pathPlus + FolderName + "\\";
            }
        }
        public static string SaveName
        {
            get
            {
                
                return SavePath + FileName + ".config";
            }
        }
    }
    public static class ConfigB
    {
        public const string FolderName = "EnemyVariety";
        public const string FileName = "ConfigB";
        public const int Default = 0;

        public static void TryWriteConfig() => WriteConfig(SaveName);


        public static Dictionary<string, int> SaveConfigNames;

        public static void WriteConfig(string location)
        {
            StreamWriter text = File.CreateText(location);
            XmlDocument xmlDocument = new XmlDocument();
            string xml = "<config";
            foreach (string key in SaveConfigNames.Keys)
            {
                xml += " ";
                xml += key;
                xml += "='";
                xml += SaveConfigNames[key].ToString().ToLower();
                xml += "'\n";
            }
            xml += "> </config>";
            xmlDocument.LoadXml(xml);
            xmlDocument.Save((TextWriter)text);
            text.Close();
        }

        public static int Check(string name)
        {
            if (!File.Exists(SavePath + FileName + ".config")) return 0;
            if (SaveConfigNames == null)
            {
                SaveConfigNames = new Dictionary<string, int>();
            }
            string l = SaveName;
            int add = Default;
            FileStream inStream = File.Open(SaveName, FileMode.Open);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load((Stream)inStream);
            if (xmlDocument.GetElementsByTagName("config").Count > 0)
            {

                if (xmlDocument.GetElementsByTagName("config")[0].Attributes[name] != null)
                {
                    add = int.Parse(xmlDocument.GetElementsByTagName("config")[0].Attributes[name].Value);

                }
                if (!SaveConfigNames.Keys.Contains(name))
                    SaveConfigNames.Add(name, add);
                else
                    SaveConfigNames[name] = add;
            }
            inStream.Close();
            return add;
        }

        public static void Set(string name, int value)
        {
            if (!File.Exists(SavePath + FileName + ".config")) return;
            if (Check(name) != value)
            {
                SaveConfigNames[name] = value;
                WriteConfig(SaveName);
            }
        }

        static string pathPlus
        {
            get
            {
                return BepInEx.Paths.BepInExRootPath + "\\Plugins\\";
            }
        }
        public static string SavePath
        {
            get
            {
                if (!Directory.Exists(pathPlus + FolderName + "\\"))
                {
                    Directory.CreateDirectory(pathPlus + FolderName + "\\");
                }
                return pathPlus + FolderName + "\\";
            }
        }
        public static string SaveName
        {
            get
            {
                
                return SavePath + FileName + ".config";
            }
        }
    }
    public static class ConfigC
    {
        public const string FolderName = "EnemyVariety";
        public const string FileName = "ConfigC";
        public const string Default = "disabled";

        public static void TryWriteConfig() => WriteConfig(SaveName);
        public static void LoadAllValues()
        {
            if (SaveConfigNames == null) SaveConfigNames = new Dictionary<string, string>();
            if (!File.Exists(SavePath + FileName + ".config")) return;
            FileStream inStream = File.Open(SaveName, FileMode.Open);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load((Stream)inStream);
            if (xmlDocument.GetElementsByTagName("config").Count > 0)
            {
                foreach (XmlAttribute node in xmlDocument.GetElementsByTagName("config")[0].Attributes)
                {
                    string val = node.Value;
                    string name = node.Name;
                    if (val != null & name.Length > 0)
                    {
                        if (SaveConfigNames.Keys.Contains(name))
                        {
                            SaveConfigNames[name] = val;
                        }
                        else
                        {
                            SaveConfigNames.Add(name, val);
                        }
                    }
                }
            }
            inStream.Close();
        }

        public static Dictionary<string, string> SaveConfigNames;

        public static void WriteConfig(string location)
        {
            StreamWriter text = File.CreateText(location);
            XmlDocument xmlDocument = new XmlDocument();
            string xml = "<config";
            foreach (string key in SaveConfigNames.Keys)
            {
                xml += " ";
                xml += key;
                xml += "='";
                xml += SaveConfigNames[key].ToString().ToLower();
                xml += "'\n";
            }
            xml += "> </config>";
            xmlDocument.LoadXml(xml);
            xmlDocument.Save((TextWriter)text);
            text.Close();
        }

        public static bool Check(string name)
        {
            if (!File.Exists(SavePath + FileName + ".config")) return false;
            return Get(name) == Default;
        }
        public static string Get(string name)
        {
            if (!File.Exists(SavePath + FileName + ".config")) return "";
            if (SaveConfigNames == null)
            {
                SaveConfigNames = new Dictionary<string, string>();
            }
            string l = SaveName;
            string add = Default;
            FileStream inStream = File.Open(SaveName, FileMode.Open);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load((Stream)inStream);
            if (xmlDocument.GetElementsByTagName("config").Count > 0)
            {

                if (xmlDocument.GetElementsByTagName("config")[0].Attributes[name] != null)
                {
                    add = xmlDocument.GetElementsByTagName("config")[0].Attributes[name].Value;

                }
                if (!SaveConfigNames.Keys.Contains(name))
                    SaveConfigNames.Add(name, add);
                else
                    SaveConfigNames[name] = add;
            }
            inStream.Close();
            return add;
        }
        public static void Set(string name, string value)
        {
            if (!File.Exists(SavePath + FileName + ".config")) return;
            if (Get(name) != value)
            {
                SaveConfigNames[name] = value;
                WriteConfig(SaveName);
            }
        }

        static string pathPlus
        {
            get
            {
                return BepInEx.Paths.BepInExRootPath + "\\Plugins\\";
            }
        }
        public static string SavePath
        {
            get
            {
                if (!Directory.Exists(pathPlus + FolderName + "\\"))
                {
                    Directory.CreateDirectory(pathPlus + FolderName + "\\");
                }
                return pathPlus + FolderName + "\\";
            }
        }
        public static string SaveName
        {
            get
            {
                
                return SavePath + FileName + ".config";
            }
        }
    }
    public static class TextGen
    {
        public const string FolderName = "EnemyVariety";
        public static bool ResetDefault() => !File.Exists(SavePath + "Reset.txt");
        public static void ReadMe()
        {
            if (true)
            {
                File.WriteAllText(SavePath + "README.txt", "INSTRUCTIONS\n\n" +
                    "ConfigA:\n" +
                    "OptionA: Enables encounter variety boost. When the game loads an encounter into the run, if an encounter of the same type has already been loaded in it'll pick again. Only retries up to 3 however.\n" +
                    "OptionB: Enables enemy variety boost. When the game loads an encounter into the run, if an enemy in the encounter has already been loaded into the run it'll pick again. Onlly retries up to 3 times however.\n" +
                    "OptionC: Enables a fourth portal lane.\n\n" +
                    "ConfigB:\n" +
                    "FarShoreEasyMin: the minimum number of extra Easy encounters added to the Far Shore.\n" +
                    "FarShoreEasyMax: the maximum number of extra Easy encounters added to the Far Shore.\n" +
                    "FarShoreMedMin: the minimum number of extra Medium encounters added to the Far Shore.\n" +
                    "FarShoreMedMax: the maximum number of extra Medium encounters added to the Far Shore.\n" +
                    "FarShoreHardMin: the minimum number of extra Hard encounters added to the Far Shore.\n" +
                    "FarShoreHardMax: the maximum number of extra Hard encounters added to the Far Shore.\n" +
                    "OrpheumEasyMin: the minimum number of extra Easy encounters added to the Orpheum.\n" +
                    "OrpheumEasyMax: the maximum number of extra Easy encounters added to the Orpheum.\n" +
                    "OrpheumMedMin: the minimum number of extra Medium encounters added to the Orpheum.\n" +
                    "OrpheumMedMax: the maximum number of extra Medium encounters added to the Orpheum.\n" +
                    "OrpheumHardMin: the minimum number of extra Hard encounters added to the Orpheum.\n" +
                    "OrpheumHardMax: the maximum number of extra Hard encounters added to the Orpheum.\n" +
                    "GardenEasyMin: the minimum number of extra Easy encounters added to the Garden.\n" +
                    "GardenEasyMax: the maximum number of extra Easy encounters added to the Garden.\n" +
                    "GardenMedMin: the minimum number of extra Medium encounters added to the Garden.\n" +
                    "GardenMedMax: the maximum number of extra Medium encounters added to the Garden.\n" +
                    "GardenHardMin: the minimum number of extra Hard encounters added to the Garden.\n" +
                    "GardenHardMax: the maximum number of extra Hard encounters added to the Garden.\n\n" +
                    "ConfigC:\n" +
                    "You may manually add or remove values in ConfigC. Writing them such as the given examples will attempt to prevent the game from loading encounters with that specific enemy.\n" +
                    "It cannot guarantee to disable the enemy, as it will only re-pick encounters 1000 times before giving up.\n" +
                    "Additionally, while it can disable encounters from starting with an enemy, it cannot prevent other enemies from spawning that enemy from sources such as Decay or Bronzo/Sepulchre.\n" +
                    "Also note that you need the precies enemy ID (such as Maniskins being called ManicMan_EN in the games code");
                Debug.Log("reset read me");
            }
        }
        public static void Reset()
        {
            if (!File.Exists(SavePath + "Reset.txt"))
            {
                File.WriteAllText(SavePath + "Reset.txt", "Deleting this text file will attempt to re-generate all config files as listed by default on the itch page for this mod.");
                Debug.Log(ColorLog.Cyan + "created Reset.txt" + ColorLog.End);
            }
        }
        static string pathPlus
        {
            get
            {
                return BepInEx.Paths.BepInExRootPath + "\\Plugins\\";
            }
        }
        public static string SavePath
        {
            get
            {
                if (!Directory.Exists(pathPlus + FolderName + "\\"))
                {
                    Directory.CreateDirectory(pathPlus + FolderName + "\\");
                }
                return pathPlus + FolderName + "\\";
            }
        }
    }
}
