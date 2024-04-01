using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace PYMN6
{
    public static class Metanoia
    {
        public static void GenerateEnemyCard(Action<ZoneBGDataBaseSO, CardInfo, EnemyEncounterSelectorSO> orig, ZoneBGDataBaseSO self, CardInfo info, EnemyEncounterSelectorSO encounterSelector)
        {
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    orig(self, info, encounterSelector);
                    return;
                }
                catch
                {
                    Debug.LogWarning("failed to generate enemy card (this is the ZoneBGDataBaseSO)" + (i + 1).ToString() + " times.");
                }
            }
            Debug.LogError("failed to generate enemy bundle 20 times; skipping.");
        }
        public static EnemyCombatBundle GetEnemyBundle(Func<EnemyEncounterSelectorSO, EnemyCombatBundle> orig, EnemyEncounterSelectorSO self)
        {
            EnemyCombatBundle ret = null;
            ret = orig(self);
            for (int i = 0; i < 4; i++)
            {
                for (int b = 0; b < 2;  b++)
                {
                    for (int d = 0; d < 1000; d++)
                    {
                        for (int h = 0; h < 1000; h++)
                        {
                            try
                            {
                                if (Seraphine.NullCheck(ret)) 
                                { 
                                    //Debug.Log("null pass");  
                                    break; 
                                }
                                ret = orig(self);
                                if (h == 500) Debug.LogError("null checked 500 times");
                                if (h == 900) Debug.LogError("null checked 900 times");
                            }
                            catch
                            {
                                Debug.LogError("somehow null check failed.");
                                ret = orig(self);
                            }
                        }
                        if (Seraphine.DisableCheck(ret)) 
                        { 
                            //Debug.Log("disable pass"); 
                            break; 
                        }
                        if (d == 500) Debug.LogWarning("disable checked 500 times");
                        if (d == 900) Debug.LogWarning("disable checked 900 times");
                        if (d >= 999 && !Seraphine.DisableCheck(ret, false)) Debug.LogWarning("disable check ignored");
                        else ret = orig(self);
                    }
                    if (!ConfigA.Check("OptionB"))
                    {
                        //Debug.Log(ColorLog.Cyan + "unit variety inactive" + ColorLog.End);
                        break;
                    }
                    else if (Seraphine.UnitCheck(ret))
                    {
                        //Debug.Log(ColorLog.Green + "unit pass" + ColorLog.End);
                        break;
                    }
                    if (b >= 1) Debug.LogWarning("unit check ignored.");
                    else ret = orig(self);
                }
                if (!ConfigA.Check("OptionA"))
                {
                    //Debug.Log(ColorLog.Cyan + "encouner variety inactive" + ColorLog.End);
                    break;
                }
                else if (Seraphine.SignCheck(ret))
                {
                    //Debug.Log(ColorLog.Green + "sign pass" + ColorLog.End);
                    break;
                }
                if (i >= 3) Debug.LogWarning("sign check ignored");
                else ret = orig(self);
            }
            if (ret == null) throw new Exception("enemy bundle failed (in EnemyEncounterSelectorSO.GetEnemyBundle). message hopefully will not be seen due to try catch.");
            if (!Seraphine.UsedGroups.Contains(ret._bundleSignType))
            {
                Debug.Log("new used sign type " + ret._bundleSignType.ToString());
                Seraphine.UsedGroups.Add(ret._bundleSignType);
            }
            else Debug.LogWarning("reusing sign type " + ret._bundleSignType);
            List<EnemySO> reuse = new List<EnemySO>();
            foreach (EnemyBundleData enemy in ret.Enemies)
            {
                if (Seraphine.UsedEnemies.Contains(enemy.enemy))
                {
                    if (!reuse.Contains(enemy.enemy))
                    {
                        reuse.Add(enemy.enemy);
                        Debug.LogWarning("reusing enemy " + enemy.enemy._enemyName);
                    }
                }
            }
            foreach (EnemyBundleData enemy in ret.Enemies)
            {
                if (!Seraphine.UsedEnemies.Contains(enemy.enemy))
                {
                    Seraphine.UsedEnemies.Add(enemy.enemy);
                    Debug.Log("new used enemy " + enemy.enemy._enemyName);
                }
            } 
            //Debug.Log("good");
            return ret;
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(ZoneBGDataBaseSO).GetMethod(nameof(ZoneBGDataBaseSO.GenerateEnemyCard), ~BindingFlags.Default), typeof(Metanoia).GetMethod(nameof(GenerateEnemyCard), ~BindingFlags.Default));
            IDetour hack = new Hook(typeof(EnemyEncounterSelectorSO).GetMethod(nameof(EnemyEncounterSelectorSO.GetEnemyBundle), ~BindingFlags.Default), typeof(Metanoia).GetMethod(nameof(GetEnemyBundle), ~BindingFlags.Default));
            Debug.Log("metanoie ");
        }
    }
    public static class Seraphine
    {
        public static List<SignType> UsedGroups;
        public static List<EnemySO> UsedEnemies;
        public static void Clear()
        {
            if (UsedGroups == null) UsedGroups = new List<SignType>();
            if (UsedEnemies == null) UsedEnemies = new List<EnemySO>();
            UsedGroups.Clear();
            UsedEnemies.Clear();
            Debug.Log(ColorLog.Cyan + "Variety: used cleared" + ColorLog.End);
        }
        public static List<EnemySO> DisabledEnemies;
        public static void Setup()
        {
            try
            {
                if (DisabledEnemies == null) DisabledEnemies = new List<EnemySO>();
                DisabledEnemies.Clear();
                ConfigC.LoadAllValues();
                foreach (string key in new List<string>(ConfigC.SaveConfigNames.Keys))
                {
                    if (ConfigC.Check(key) && EnemyExists(key))
                    {
                        DisabledEnemies.Add(LoadedAssetsHandler.GetEnemy(key));
                        Debug.Log(ColorLog.Magenta + "disabling enemy: " + key + ColorLog.End);
                    }
                }
                Debug.Log(ColorLog.Cyan + "Disabled: refreshed" + ColorLog.End);
            }
            catch
            {
                Debug.LogError("disabling enemies failed.");
            }
        }
        public static bool EnemyExists(string name)
        {
            if (!LoadedAssetsHandler.LoadedEnemies.Keys.Contains(name) && LoadedAssetsHandler.LoadEnemy(name) == null) { Debug.LogWarning("Enemy: " + name + " is null"); return false; }
            return LoadedAssetsHandler.GetEnemy(name) != null;
        }

        public static bool SignCheck(EnemyCombatBundle bundle, bool read = true)
        {
            if (UsedGroups == null) UsedGroups = new List<SignType>();
            if (UsedGroups.Contains(bundle._bundleSignType))
            {
                if (read) Debug.Log(ColorLog.Green + "Variety: skipping sign type " + ColorLog.End + bundle._bundleSignType.ToString());
                else Debug.LogWarning("Variety: cannot skip sign type " + bundle._bundleSignType.ToString());
                return false;
            }
            //UsedGroups.Add(bundle._bundleSignType);
            return true;
        }
        public static bool UnitCheck(EnemyCombatBundle bundle, bool read = true)
        {
            if (UsedEnemies == null) UsedEnemies = new List<EnemySO>();
            bool ret = true;
            List<EnemySO> cant = new List<EnemySO>();
            foreach (EnemyBundleData enemy in bundle.Enemies)
            {
                if (UsedEnemies.Contains(enemy.enemy))
                {
                    if (read) Debug.Log(ColorLog.Green + "Variety: skipping unit " + ColorLog.End + enemy.enemy._enemyName);
                    else Debug.LogWarning("Variety: cannot skip unit " + enemy.enemy._enemyName);
                    return false;
                }
            }
            //foreach (EnemyBundleData add in bundle.Enemies)
            //{
                //UsedEnemies.Add(add.enemy);
            //}
            return ret;
        }
        public static bool DisableCheck(EnemyCombatBundle bundle, bool read = true)
        {
            if (DisabledEnemies == null) DisabledEnemies = new List<EnemySO>();
            foreach (EnemyBundleData enemy in bundle.Enemies)
            {
                if (DisabledEnemies.Contains(enemy.enemy))
                {
                    if (read) Debug.Log(ColorLog.Magenta + "Disable: skipping unit " + ColorLog.End + enemy.enemy._enemyName);
                    else Debug.LogWarning("Diable: cannot skip unit " + enemy.enemy._enemyName);
                    return false;
                }
            }
            return true;
        }
        public static bool NullCheck(EnemyCombatBundle bundle)
        {
            try
            {
                if (bundle.Enemies == null) return false;
                foreach (EnemyBundleData enemy in bundle.Enemies)
                {
                    if (enemy.enemy == null)
                    {
                        Debug.LogError("enemycombatbundle has null enemy");
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                Debug.LogError("enemycombatbundle has unspecified error");
                return false;
            }
        }
    }
}
