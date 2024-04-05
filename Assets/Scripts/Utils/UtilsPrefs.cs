using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilsPrefs
{
    public static class Options
    {
        //NB: IMPLEMENT DEBOUNCE FOR THESE
        public static void SetVolumeMusic(float value) => PlayerPrefs.SetFloat(SaveController.volumeMusic, value);
        public static float GetVolumeMusic()
        {
            return PlayerPrefs.GetFloat(SaveController.volumeMusic) == 0 ? 2 : PlayerPrefs.GetFloat(SaveController.volumeMusic);
        }


        public static void SetVolumeEffects(float value) => PlayerPrefs.SetFloat(SaveController.volumeSoundFX, value);
        public static float GetVolumeEffects()
        {
            return PlayerPrefs.GetFloat(SaveController.volumeSoundFX) == 0 ? 2 : PlayerPrefs.GetFloat(SaveController.volumeSoundFX);
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
