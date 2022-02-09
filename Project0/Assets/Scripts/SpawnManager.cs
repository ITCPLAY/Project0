using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefab;
    private ObjectPooling pooling;
    public GameObject spawn1;
    public GameObject spawn2;

    void Start()
        {
        pooling = new ObjectPooling(prefab);
        pooling.SetPool(100);

        for (int i = 0; i<10;i++)
        {
            StartCoroutine(CreateObject());
        }

        }
    

    IEnumerator CreateObject()
    {
        
        while (true)
        {
            var a = Random.Range(spawn1.transform.position.x, spawn2.transform.position.x);
            var b = Random.Range(spawn1.transform.position.z, spawn2.transform.position.z);
            Vector3 konum = new Vector3(a,PlayerController.Instance.transform.position.y,b);
            GameObject obje = pooling.PopPooling();
            obje.transform.position = konum;
            obje.transform.parent = gameObject.transform;


            yield return new WaitForSeconds(1f);


            pooling.PushPooling(obje);
        }
    }

  
}