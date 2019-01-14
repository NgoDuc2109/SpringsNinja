using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constant
{
    public static class Tag
    {
        public const string PLAYER = "Player";
        public const string PLATFORM = "Platform";
        public const string BACKGROUND = "BackGround";
        public const string SCORE = "Score";
        public const string MAINCAMERA = "MainCamera";
        public const string COMBO = "Combo";
    }
    public static class SceneName
    {
        public const string STARTSCENE = "StartScene";
        public const string MAINSCENE = "MainScene";
        public const string OCEAN = "Ocean";
        public const string VOLCANO = "Volcano";
        public const string WINTER = "Winter";
        public const string DESERT = "Desert";
    }

    public static class ScoreInfo
    {
        public const string BESTSCORE = "BestScore";
        public const string TOTALCOINS = "TotalCoins";
    }

    public static class PlayerInfo
    {
        public static string CURRENTPLAYER = "CurrentPlayer";
        public static string[] LISTPLAYER = new string[9] {"Player1","Player2", "Player3", "Player4", "Player5", "Player6", "Player7", "Player8", "Player9" } ;
    }

    public static class AudioInfo
    {
        public static string ISAUDIO = "IsAudio";
    }
}


