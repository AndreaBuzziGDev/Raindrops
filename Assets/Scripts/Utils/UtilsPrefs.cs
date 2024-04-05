using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilsPrefs
{
    public static class Options
    {
        public static void SetVolumeMusic(float value)
        {
            //TODO: EVENTUALLY IMPLEMENT THIS

        }

        public static void SetVolumeEffects(float value)
        {
            //TODO: EVENTUALLY IMPLEMENT THIS

        }

    }

    public static class GameSettings
    {
        //ENUMS
        public enum DIFFICULTY
        {
            EASY = 0,
            NORMAL = 1,
            HARD = 2
        }



        //FUNCTIONALITIES
        //DIFFICULTY SETTINGS

        //GAME SPEED
        public static void SetGameSpeed(DIFFICULTY value) => PlayerPrefs.SetInt(SaveController.gameSpeed, (int) value);

        public static int GetGameSpeed() => PlayerPrefs.HasKey(SaveController.gameSpeed) ? PlayerPrefs.GetInt(SaveController.gameSpeed) : (int) DIFFICULTY.EASY;
        
        //GRADUAL GAME DIFFICULTY INCREMENT
        //UNUSED...
        public static void SetDifficultyIncrement(DIFFICULTY value)
        {

        }

    }
}
