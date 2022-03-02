using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyManager : MonoBehaviour
{
   
    public GameObject SpawnPoint1, SpawnPoint2;
   [SerializeField] private GameObject prefab;
    [SerializeField] public  int Enemy_Number;
    [SerializeField] public  GameObject[] Player;
    public GameObject[] enemyPrefab;
    public NavMeshAgent[] enemyNav;
    SpawnManager spawnManager;
   
    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        CreateEnemy();
    }

    private void Update()
    {
        TransformPrefabControl();  
    }

    public void CreateEnemy()
    {
      
        for (int i = 0; i < Enemy_Number; i++)
        {
            var a = Random.Range(SpawnPoint1.transform.position.x, SpawnPoint2.transform.position.x);
            var b = Random.Range(SpawnPoint1.transform.position.z, SpawnPoint2.transform.position.z);
            Vector3 konum = new Vector3(a, -9, b);
           enemyPrefab[i] =  Instantiate(prefab, konum,transform.rotation);
           
            
            
        }

                 
    }

    public void TransformPrefabControl()
    {
      
            spawnManager.arrayPlayer.CopyTo(Player, 0);
        for (int i = 0; i < Enemy_Number; i++)
        {
            enemyNav[i] = enemyPrefab[i].GetComponent<NavMeshAgent>();
        }
           // Player[i] = spawnManager.arrayPlayer[i];
        
    }

   
}
