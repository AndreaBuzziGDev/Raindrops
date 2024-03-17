using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T instance;

    protected virtual void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Instance of this singleton " + (T)this + " already exists, deleting!");
            Destroy(gameObject);
        }
        else
        {
            //COMMENTED: DESIRED BEHAVIOUR ON CHILD CLASSES ACHIEVED BY LETTING THE START METHOD RE-PLAY.
            //TODO: MIGHT IMPROVE IF IN THE FUTURE THE CODE HAS A LOAD ORDER IN PLACE.
            //DontDestroyOnLoad(gameObject);
            instance = (T)this;
        }
    }

    public static T Instance
    {
        get
        {
            return instance;
        }
    }
}