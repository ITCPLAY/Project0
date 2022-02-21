using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{

    public bool isLock;
    public GameObject[] lockDot,System;
    LockManager lockManager;
    public int Counter;
    void Start()
    {
        lockManager = GetComponentInParent<LockManager>();
        isLock = false;
    }
    void OnMouseDown()
    {
        // Lock mantýðý gelecek.        

       /* if (lockManager.LockSystems[0] == true || lockManager.LockSystems[1] == true)
        {
            return;
        }
        if (Counter == 0)
        {
            lockManager.LockSystems[0] = true;

        }
        else
        {
            lockManager.LockSystems[1]=true;
        }*/
        lockManager.dotsNew = lockDot;


        lockManager.DotSet(this);

    }
   


}
