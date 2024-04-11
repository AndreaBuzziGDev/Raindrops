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
    
    //LIFECYCLE FUNCTIONS
    // Start is called before the first frame update
    void Start()
    {
        //NB: THIS SHOULD WORK IN REAL TIME... HANDLE AN EVENT
        UI_MainOptions.VolumeChanged += HandleVolumeChangeEvent;

        float value = GetMatchingPref(volumeType);
        foreach(AudioSource aSource in sources)
        {
            aSource.volume = value-1;
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

    //EVENT HANDLING
    private void HandleVolumeChangeEvent(object sender, VolumeChangeEventArgs e)
    {
        //TODO: COMMON FACTOR WITH START
        float value = GetMatchingPref(volumeType);
        foreach(AudioSource aSource in sources)
        {
            aSource.volume = value-1;
        }
    }

}
