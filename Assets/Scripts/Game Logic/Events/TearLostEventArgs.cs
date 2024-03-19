using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TearLostEventArgs : EventArgs
{
    //DATA
    private TearOperation lostTear;
    public TearOperation LostTear { get { return lostTear; } }

    //CONSTRUCTOR
    public TearLostEventArgs (TearOperation tear)
    {
        this.lostTear = tear;
    }

}
