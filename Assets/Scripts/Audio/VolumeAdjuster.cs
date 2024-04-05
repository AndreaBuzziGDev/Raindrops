using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeAdjuster : MonoBehaviour
{
    //ENUM
    public enum EVolumeType
    {
        MUSIC,
        SOUND_FX
    }

    //DATA
    [SerializeField] EVolumeType volumeType = EVolumeType.MUSIC;
    [SerializeField] List<AudioSource> sources = new();

    // Start is called before the first frame update
    void Start()
    {
        float value = GetMatchingPref(volumeType);
        foreach(AudioSource aSource in sources)
        {
            aSource.volume = value;
        }
    }

    //FUNCTIONALITIES
    private float GetMatchingPref(EVolumeType targetType)
    {
        switch (volumeType)
        {
            case EVolumeType.MUSIC:
                return UtilsPrefs.Options.GetVolumeMusic();
            default:
                return UtilsPrefs.Options.GetVolumeEffects();
        }
    }

}
