using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public bool[] Systems;
    public int Length,grade;
    

    void Start()
    {
        for (int i = 0; i < Length; i++)
        {
            Systems[i] = false;
        }
       


    }

    
    
}
