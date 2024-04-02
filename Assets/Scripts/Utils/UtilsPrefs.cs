using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilsPrefs
{
    public static class Options
    {
        public static void SetVolume(float value)
        {
            //TODO: EVENTUALLY IMPLEMENT THIS

        }

    }

    public static class GameSettings
    {
        public enum DIFFICULTY
        {
            EASY,
            NORMAL,
            HARD
        }

        public readonly static Dictionary<GameSettings.DIFFICULTY, int> DifficultyMapping = new Dictionary<GameSettings.DIFFICULTY, int>
        {
            {DIFFICULTY.EASY, 1},
            {DIFFICULTY.NORMAL, 2},
            {DIFFICULTY.HARD, 3},
        };
        
        //DIFFICULTY SETTINGS

        //GAME SPEED
        public static void SetGameSpeed(DIFFICULTY value) => PlayerPrefs.SetInt(SaveController.gameSpeed, DifficultyMapping[value]);

        public static int GetGameSpeed() => PlayerPrefs.HasKey(SaveController.gameSpeed) ? PlayerPrefs.GetInt(SaveController.gameSpeed) : 1;
        
        //GRADUAL GAME DIFFICULTY INCREMENT
        //UNUSED...
        public static void SetDifficultyIncrement(DIFFICULTY value)
        {

        }

    }
}
