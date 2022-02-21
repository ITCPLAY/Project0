using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{

    public bool isLock;
    public GameObject[] lockDot;
    LockManager lockManager;
    void Start()
    {
        lockManager = GetComponentInParent<LockManager>();
        isLock = false;
    }
    void OnMouseDown()
    {
        // Lock mantýðý gelecek.        


        lockManager.dotsNew = lockDot;


        lockManager.DotSet(this);

    }



}
