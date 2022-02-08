using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{
    public bool isLock;
    // public GameObject DestroyObject;
    public GameObject[] lockDot;
     void Start()
    {
        isLock = false;
        
    }

    void Update()
    {
       
    }

    private void printName(GameObject go)
    {
        print(go.name);

    }

    void OnMouseDown()
    {
        isLock = true;
        if (isLock)
        {
            Destroy(gameObject);
            for (int i = 0; i < lockDot.Length; i++)
            {
                lockDot[i].SetActive(true);

            }
        }
        // Lock mantýðý gelecek.
       
       
        
    }

}
