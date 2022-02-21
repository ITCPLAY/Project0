using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    SpawnManager spawnManager;
    TrashManager trashManager;
     public  int Choose;
     public int Num;
     void Awake()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    void Start()
    {
        trashManager = GetComponentInParent<TrashManager>();
       
    }
    private void Update()
    {
        UpdateInformation();
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            trashManager.isTrigger = true;
            Debug.Log("Trigger Girdi: ");
            
            spawnManager.LogicalChoices();


        }

    }
    void OnTriggerExit(Collider other)
    {
        trashManager.isTrigger = false;
        StartCoroutine(DelayDestroy());
    }

     void UpdateInformation()
    {
        trashManager.choosee = Choose;
        trashManager.num = Num;
    }

    IEnumerator DelayDestroy()
    {

        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);


    }



}
