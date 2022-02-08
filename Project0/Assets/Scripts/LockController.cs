using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{
    
    public bool isLock;
    // public GameObject DestroyObject;
    public GameObject[] lockDot;
    LockManager lockManager;
    PlayerController playerController;
    void Start()
    {
         lockManager = GetComponentInParent<LockManager>();
        isLock = false;     
    }
     void Update()
    {
        if (isLock)
           // playerController.dots = lockDot;
        PlayerController.Instance.dots = lockDot;
    }
    void OnMouseDown()
    {       
        // Lock mantýðý gelecek.        
        for (int i = 0; i < lockDot.Length; i++)
        {
            lockManager.dotsNew[i] = lockDot[i];
            
        }
        lockManager.DotSet(this);
        
    }
  
}
