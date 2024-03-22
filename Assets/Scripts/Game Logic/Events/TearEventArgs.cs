using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TearEventArgs : EventArgs
{
    //ENUMS
    public enum EType
    {
        LOSS,
        SUCCESS
    }


    //DATA
    private TearOperation lostTear;
    public TearOperation LostTear { get { return lostTear; } }


    private EType eventType = EType.LOSS;
    public EType EventType { get { return eventType; } }




    //CONSTRUCTOR
    public TearEventArgs (TearOperation tear, EType eventType = EType.LOSS)
    {
        this.lostTear = tear;
        this.eventType = eventType;
    }

}
