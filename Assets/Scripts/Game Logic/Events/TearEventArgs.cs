using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TearEventArgs : EventArgs
{
    //DATA
    private TearOperation lostTear;
    public TearOperation LostTear { get { return lostTear; } }

    //CONSTRUCTOR
    public TearEventArgs (TearOperation tear)
    {
        this.lostTear = tear;
    }

}
