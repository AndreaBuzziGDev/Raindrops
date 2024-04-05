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
    //TODO: CHANGE VARIABLE NAME TO affectedTear OR SOMETHING
    private TearOperation affectedTear;
    public TearOperation AffectedTear { get { return affectedTear; } }


    private EType eventType = EType.LOSS;
    public EType EventType { get { return eventType; } }




    //CONSTRUCTOR
    public TearEventArgs (TearOperation tear, EType eventType = EType.LOSS)
    {
        this.affectedTear = tear;
        this.eventType = eventType;
    }

}
