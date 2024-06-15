using BepInEx;
using System;
using UnityEngine;
using System.Collections.Generic;

namespace PYMN6
{
    [BepInPlugin("000.EnemyVarietyMod", "Enemy Encounter Variety Mod", "2.0.0")]
    public class Class1 : BaseUnityPlugin
    {
        public bool SHUTUP = false;
        public void Awake()
        {
            Debug.Log("thanks");
            try
            {
                if (TextGen.ResetDefault())
                {
                    ResetDefault();
                    Debug.Log("config reset to defaults");
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("config check failed");
                //Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
            }
            try
            {
                Metanoia.Setup();
                Debug.Log("metanoia set");
            }
            catch
            {
                Debug.LogError("metanoia failed");
            }
            try
            {
                Yay.Setup();
                Debug.Log("yay set up");
            }
            catch (Exception ex)
            {
                Debug.LogError("yay failed");
                //Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
            }
            try
            {
                Vie.Prepare();
                Debug.Log("vie prepared");
            }
            catch
            {
                Debug.LogError("vie failed");
            }
            try
            {
                HooksGeneral.Setup();
                Debug.Log("hooks general est");
            }
            catch
            {
                Debug.LogError("hooksgeneral failed");
            }
            try
            {
                TextGen.Reset();
            }
            catch
            {
                Debug.Log("text gen reset file failed");
            }
            Logger.LogInfo("Enemy Variety Mod finished loading..");
        }
        public static void ResetDefault()
        {
            try
            {
                TextGen.ReadMe();
            }
            catch (Exception ex)
            {
                Debug.LogError("failed to reset read me.");
                //Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
            }
            try
            {
                if (ConfigA.SaveConfigNames == null) ConfigA.SaveConfigNames = new Dictionary<string, bool>();
                ConfigA.SaveConfigNames.Clear();
                ConfigA.SaveConfigNames.Add("OptionA", true);
                ConfigA.SaveConfigNames.Add("OptionB", true);
                ConfigA.SaveConfigNames.Add("OptionC", true);
                ConfigA.TryWriteConfig();
                Debug.Log("Reset config a");
            }
            catch (Exception ex)
            {
                Debug.LogError("failed to reset config a");
                //Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
            }
            try
            {
                if (ConfigB.SaveConfigNames == null) ConfigB.SaveConfigNames = new Dictionary<string, int>();
                ConfigB.SaveConfigNames.Clear();
                ConfigB.SaveConfigNames.Add("FarShoreEasyMin", 2);
                ConfigB.SaveConfigNames.Add("FarShoreEasyMax", 4);
                ConfigB.SaveConfigNames.Add("FarShoreMedMin", 4);
                ConfigB.SaveConfigNames.Add("FarShoreMedMax", 5);
                ConfigB.SaveConfigNames.Add("FarShoreHardMin", 2);
                ConfigB.SaveConfigNames.Add("FarShoreHardMax", 4);
                ConfigB.SaveConfigNames.Add("OrpheumEasyMin", 2);
                ConfigB.SaveConfigNames.Add("OrpheumEasyMax", 2);
                ConfigB.SaveConfigNames.Add("OrpheumMedMin", 3);
                ConfigB.SaveConfigNames.Add("OrpheumMedMax", 4);
                ConfigB.SaveConfigNames.Add("OrpheumHardMin", 2);
                ConfigB.SaveConfigNames.Add("OrpheumHardMax", 4);
                ConfigB.SaveConfigNames.Add("GardenEasyMin", 1);
                ConfigB.SaveConfigNames.Add("GardenEasyMax", 1);
                ConfigB.SaveConfigNames.Add("GardenMedMin", 1);
                ConfigB.SaveConfigNames.Add("GardenMedMax", 3);
                ConfigB.SaveConfigNames.Add("GardenHardMin", 1);
                ConfigB.SaveConfigNames.Add("GardenHardMax", 3);
                ConfigB.TryWriteConfig();
                Debug.Log("Reset config b");
            }
            catch (Exception ex)
            {
                Debug.LogError("failed to reset config b");
                //Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
            }
            try
            {
                if (ConfigC.SaveConfigNames == null) ConfigC.SaveConfigNames = new Dictionary<string, string>();
                ConfigC.SaveConfigNames.Clear();
                ConfigC.SaveConfigNames.Add("Wimbleton_EN", "disabled");
                ConfigC.SaveConfigNames.Add("SourDour_EN", "disabled");
                ConfigC.SaveConfigNames.Add("HappyDooWah_EN", "disabled");
                ConfigC.TryWriteConfig();
                Debug.Log("reset config c");
            }
            catch (Exception ex)
            {
                Debug.LogError("failed to reset config c");
                //Debug.LogError(ex.ToString() + ex.Message + ex.StackTrace);
            }
        }
    }
}
