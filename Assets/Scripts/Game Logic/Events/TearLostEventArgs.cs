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
    private EType eventType = EType.LOSS;
    public EType EventType { get { return eventType; } }

    private TearOperation lostTear;
    public TearOperation LostTear { get { return lostTear; } }

    //CONSTRUCTOR
    public TearEventArgs (TearOperation tear)
    {

        this.lostTear = tear;
    }

}
