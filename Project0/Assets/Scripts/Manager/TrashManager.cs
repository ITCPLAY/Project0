using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    
    SpawnManager spawnManager;
    public bool isTrigger = false;

    public int choosee;
    public int num;

    void Awake()
    {

        spawnManager = FindObjectOfType<SpawnManager>();
    }
    void Update()
    {
      
        updtýnf();
        
    }
  
    void updtýnf()
    {
        spawnManager.nwChoose = choosee;
        spawnManager.nwNum = num;
    }
}
