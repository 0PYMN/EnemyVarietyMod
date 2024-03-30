using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.InputSystem.XR;

namespace PYMN6
{
    public static class Vie
    {
        public static void Prepare()
        {
            Shore.Add("ZoneDB_01");
            Shore.Add("ZoneDB_Hard_01");
            Orpheum.Add("ZoneDB_02");
            Orpheum.Add("ZoneDB_Hard_02");
            Garden.Add("ZoneDB_Hard_03");
        }
        public static class Shore
        {
            public static void Add(string zone)
            {
                Easy(zone);
                Medium(zone);
                Hard(zone);
                Debug.Log(ColorLog.Cyan + "added more shore" + ColorLog.End + zone);
            }
            public static void Easy(string zone)
            {
                int min = ConfigB.Check("FarShoreEasyMin");
                int max = ConfigB.Check("FarShoreEasyMax");
                if (min <= 0 && max <= 0) return;

                CardTypeInfo cardTypeInfo = new CardTypeInfo();
                cardTypeInfo._cardInfo = new CardInfo()
                {
                    cardType = CardType.EnemyEasy,
                    pilePosition = PilePositionType.First
                };
                cardTypeInfo._minimumAmount = Math.Max(0, min);
                cardTypeInfo._maximumAmount = Math.Max(0, max);
                ZoneBGDataBaseSO zoneDb = LoadedAssetsHandler.GetZoneDB(zone) as ZoneBGDataBaseSO;
                List<CardTypeInfo> cardTypeInfoList = new List<CardTypeInfo>(zoneDb._deckInfo._possibleCards) { cardTypeInfo };
                zoneDb._deckInfo._possibleCards = cardTypeInfoList.ToArray();
            }
            public static void Medium(string zone)
            {
                int min = ConfigB.Check("FarShoreMedMin");
                int max = ConfigB.Check("FarShoreMedMax");
                if (min <= 0 && max <= 0) return;

                CardTypeInfo cardTypeInfo = new CardTypeInfo();
                cardTypeInfo._cardInfo = new CardInfo()
                {
                    cardType = CardType.EnemyMedium,
                    pilePosition = PilePositionType.Middle
                };
                cardTypeInfo._minimumAmount = Math.Max(0, min);
                cardTypeInfo._maximumAmount = Math.Max(0, max);
                ZoneBGDataBaseSO zoneDb = LoadedAssetsHandler.GetZoneDB(zone) as ZoneBGDataBaseSO;
                List<CardTypeInfo> cardTypeInfoList = new List<CardTypeInfo>(zoneDb._deckInfo._possibleCards) { cardTypeInfo };
                zoneDb._deckInfo._possibleCards = cardTypeInfoList.ToArray();
            }
            public static void Hard(string zone)
            {
                int min = ConfigB.Check("FarShoreHardMin");
                int max = ConfigB.Check("FarShoreHardMax");
                if (min <= 0 && max <= 0) return;

                CardTypeInfo cardTypeInfo = new CardTypeInfo();
                cardTypeInfo._cardInfo = new CardInfo()
                {
                    cardType = CardType.EnemyHard,
                    pilePosition = PilePositionType.Last
                };
                cardTypeInfo._minimumAmount = Math.Max(0, min);
                cardTypeInfo._maximumAmount = Math.Max(0, max);
                ZoneBGDataBaseSO zoneDb = LoadedAssetsHandler.GetZoneDB(zone) as ZoneBGDataBaseSO;
                List<CardTypeInfo> cardTypeInfoList = new List<CardTypeInfo>(zoneDb._deckInfo._possibleCards) { cardTypeInfo };
                zoneDb._deckInfo._possibleCards = cardTypeInfoList.ToArray();
            }
        }
        public static class Orpheum
        {
            public static void Add(string zone)
            {
                Easy(zone);
                Medium(zone);
                Hard(zone);
                Debug.Log(ColorLog.Cyan + "added more orpheum " + ColorLog.End + zone);
            }
            public static void Easy(string zone)
            {
                int min = ConfigB.Check("OrpheumEasyMin");
                int max = ConfigB.Check("OrpheumEasyMax");
                if (min <= 0 && max <= 0) return;

                CardTypeInfo cardTypeInfo = new CardTypeInfo();
                cardTypeInfo._cardInfo = new CardInfo()
                {
                    cardType = CardType.EnemyEasy,
                    pilePosition = PilePositionType.First
                };
                cardTypeInfo._minimumAmount = Math.Max(0, min);
                cardTypeInfo._maximumAmount = Math.Max(0, max);
                ZoneBGDataBaseSO zoneDb = LoadedAssetsHandler.GetZoneDB(zone) as ZoneBGDataBaseSO;
                List<CardTypeInfo> cardTypeInfoList = new List<CardTypeInfo>(zoneDb._deckInfo._possibleCards) { cardTypeInfo };
                zoneDb._deckInfo._possibleCards = cardTypeInfoList.ToArray();
            }
            public static void Medium(string zone)
            {
                int min = ConfigB.Check("OrpheumMedMin");
                int max = ConfigB.Check("OrpheumMedMax");
                if (min <= 0 && max <= 0) return;

                CardTypeInfo cardTypeInfo = new CardTypeInfo();
                cardTypeInfo._cardInfo = new CardInfo()
                {
                    cardType = CardType.EnemyMedium,
                    pilePosition = PilePositionType.Middle
                };
                cardTypeInfo._minimumAmount = Math.Max(0, min);
                cardTypeInfo._maximumAmount = Math.Max(0, max);
                ZoneBGDataBaseSO zoneDb = LoadedAssetsHandler.GetZoneDB(zone) as ZoneBGDataBaseSO;
                List<CardTypeInfo> cardTypeInfoList = new List<CardTypeInfo>(zoneDb._deckInfo._possibleCards) { cardTypeInfo };
                zoneDb._deckInfo._possibleCards = cardTypeInfoList.ToArray();
            }
            public static void Hard(string zone)
            {
                int min = ConfigB.Check("OrpheumHardMin");
                int max = ConfigB.Check("OrpheumHardMax");
                if (min <= 0 && max <= 0) return;

                CardTypeInfo cardTypeInfo = new CardTypeInfo();
                cardTypeInfo._cardInfo = new CardInfo()
                {
                    cardType = CardType.EnemyHard,
                    pilePosition = PilePositionType.Last
                };
                cardTypeInfo._minimumAmount = Math.Max(0, min);
                cardTypeInfo._maximumAmount = Math.Max(0, max);
                ZoneBGDataBaseSO zoneDb = LoadedAssetsHandler.GetZoneDB(zone) as ZoneBGDataBaseSO;
                List<CardTypeInfo> cardTypeInfoList = new List<CardTypeInfo>(zoneDb._deckInfo._possibleCards) { cardTypeInfo };
                zoneDb._deckInfo._possibleCards = cardTypeInfoList.ToArray();
            }
        }
        public static class Garden
        {
            public static void Add(string zone)
            {
                Easy(zone);
                Medium(zone);
                Hard(zone);
                Debug.Log(ColorLog.Cyan + "added more garden " + ColorLog.End + zone);
            }
            public static void Easy(string zone)
            {
                int min = ConfigB.Check("GardenEasyMin");
                int max = ConfigB.Check("GardenEasyMax");
                if (min <= 0 && max <= 0) return;

                CardTypeInfo cardTypeInfo = new CardTypeInfo();
                cardTypeInfo._cardInfo = new CardInfo()
                {
                    cardType = CardType.EnemyEasy,
                    pilePosition = PilePositionType.First
                };
                cardTypeInfo._minimumAmount = Math.Max(0, min);
                cardTypeInfo._maximumAmount = Math.Max(0, max);
                ZoneBGDataBaseSO zoneDb = LoadedAssetsHandler.GetZoneDB(zone) as ZoneBGDataBaseSO;
                List<CardTypeInfo> cardTypeInfoList = new List<CardTypeInfo>(zoneDb._deckInfo._possibleCards) { cardTypeInfo };
                zoneDb._deckInfo._possibleCards = cardTypeInfoList.ToArray();
            }
            public static void Medium(string zone)
            {
                int min = ConfigB.Check("GardenMedMin");
                int max = ConfigB.Check("GardenMedMax");
                if (min <= 0 && max <= 0) return;

                CardTypeInfo cardTypeInfo = new CardTypeInfo();
                cardTypeInfo._cardInfo = new CardInfo()
                {
                    cardType = CardType.EnemyMedium,
                    pilePosition = PilePositionType.Middle
                };
                cardTypeInfo._minimumAmount = Math.Max(0, min);
                cardTypeInfo._maximumAmount = Math.Max(0, max);
                ZoneBGDataBaseSO zoneDb = LoadedAssetsHandler.GetZoneDB(zone) as ZoneBGDataBaseSO;
                List<CardTypeInfo> cardTypeInfoList = new List<CardTypeInfo>(zoneDb._deckInfo._possibleCards) { cardTypeInfo };
                zoneDb._deckInfo._possibleCards = cardTypeInfoList.ToArray();
            }
            public static void Hard(string zone)
            {
                int min = ConfigB.Check("GardenHardMin");
                int max = ConfigB.Check("GardenHardMax");
                if (min <= 0 && max <= 0) return;

                CardTypeInfo cardTypeInfo = new CardTypeInfo();
                cardTypeInfo._cardInfo = new CardInfo()
                {
                    cardType = CardType.EnemyHard,
                    pilePosition = PilePositionType.Last
                };
                cardTypeInfo._minimumAmount = Math.Max(0, min);
                cardTypeInfo._maximumAmount = Math.Max(0, max);
                ZoneBGDataBaseSO zoneDb = LoadedAssetsHandler.GetZoneDB(zone) as ZoneBGDataBaseSO;
                List<CardTypeInfo> cardTypeInfoList = new List<CardTypeInfo>(zoneDb._deckInfo._possibleCards) { cardTypeInfo };
                zoneDb._deckInfo._possibleCards = cardTypeInfoList.ToArray();
            }
        }
    }
    public static class Yay
    {
        public static void Setup()
        {
            if (ConfigA.Check("OptionC"))
            {
                (LoadedAssetsHandler.GetZoneDB("ZoneDB_01") as ZoneBGDataBaseSO)._deckInfo._pileNumber++;
                (LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_01") as ZoneBGDataBaseSO)._deckInfo._pileNumber++;
                (LoadedAssetsHandler.GetZoneDB("ZoneDB_02") as ZoneBGDataBaseSO)._deckInfo._pileNumber++;
                (LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_02") as ZoneBGDataBaseSO)._deckInfo._pileNumber++;
                (LoadedAssetsHandler.GetZoneDB("ZoneDB_03") as ZoneBGDataBaseSO)._deckInfo._pileNumber++;
                (LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_03") as ZoneBGDataBaseSO)._deckInfo._pileNumber++;
                Debug.Log(ColorLog.Cyan + "added additional pile all zones" + ColorLog.End);
            }
        }
    }
}
