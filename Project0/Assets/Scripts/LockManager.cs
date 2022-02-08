using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockManager : MonoBehaviour
{
    public bool isLock;
    public GameObject[] dotsNew;
   
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
        a.isLock = true;
        isLock = true;
        if (a.isLock)
        {
            // Destroy(gameObject);
            Debug.Log("Destroy");

        }
        yield return new WaitForSeconds(0.3f);
        IslockExit(a);
    }

}
