using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
   
    public GameObject SpawnPoint1, SpawnPoint2;
   [SerializeField] private GameObject prefab;
    [SerializeField] public  int Enemy_Number;
    public GameObject[] enemyPrefab;
    void Start()
    {
        CreateEnemy();
    }

   
    public void CreateEnemy()
    {
      
        for (int i = 0; i < Enemy_Number; i++)
        {
            var a = Random.Range(SpawnPoint1.transform.position.x, SpawnPoint2.transform.position.x);
            var b = Random.Range(SpawnPoint1.transform.position.z, SpawnPoint2.transform.position.z);
            Vector3 konum = new Vector3(a, -9, b);
            Instantiate(prefab, konum,transform.rotation);
            enemyPrefab[i] = prefab;
            
        }

                 
    }



   
}
