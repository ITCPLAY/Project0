using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{

    public bool isLock;
    public GameObject[] lockDot;
    LockManager lockManager;
    public int Counter;
    SystemManager systemManager;
    void Start()
    {
        lockManager = GetComponentInParent<LockManager>();
        systemManager = GetComponentInParent<SystemManager>();
        isLock = false;
    }
    void OnMouseDown()
    {
        // Lock Systems.        
        for (int i = 0; i < systemManager.Systems.Length; i++)
        {
            if (systemManager.Systems[i] == true)
            {
                return;
            }
        }
        if (lockManager.Current_Grade == systemManager.grade)
        {
            systemManager.Systems[Counter] = true;
            lockManager.Current_Grade++;

            lockManager.dotsNew = lockDot;


            lockManager.DotSet(this);
        }
             
       

    }
   


}
