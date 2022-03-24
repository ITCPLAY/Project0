using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour
{
    public bool isLock;
    public int size;
    public GameObject[] dotsNew;
   public  int Current_Grade=0;

    public void DotSet(LockController a)
    {
        StartCoroutine(SetData(a));

    }

    public void IslockExit(LockController a)
    {
        
        a.isLock = false;
        isLock = false;

    }
    IEnumerator SetData(LockController a)
    {
        PlayerController.Instance.dots = dotsNew;
        a.isLock = true;
        isLock = true;
        if (a.isLock)
        {
          

        }
        yield return new WaitForSeconds(0.3f);
        IslockExit(a);
    }

}
