using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyManager : MonoBehaviour
{

    public GameObject SpawnPoint1, SpawnPoint2;
    [SerializeField] private GameObject prefab;
    SpawnManager spawnManager;
    public int Enemy_Number;
    public GameObject[] Player;
    public ArrayList Playerarray = new ArrayList();
    public GameObject[] enemyPrefab;
    public NavMeshAgent[] enemyNav;
    UIManager uIManager;
    EnemyController enemyController;
    public int enemyCount;
    public int controlEnemy = 0;

    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        enemyController = FindObjectOfType<EnemyController>();
        uIManager = FindObjectOfType<UIManager>();
        CreateEnemy();
        enemyCount = Enemy_Number;
    }

    private void Update()
    {

        // Debug.Log("Enemy Count :" + enemyCount);
        if (PlayerController.Instance.isArena == true)
        {
            //EnemyDestinationControl();
            if (controlEnemy == 0)
            {
                FollowPlayer();
            }
            controlEnemy++;

        }
       
    }

    public void CreateEnemy()
    {

        for (int i = 0; i < Enemy_Number; i++)
        {
            var a = Random.Range(SpawnPoint1.transform.position.x, SpawnPoint2.transform.position.x);
            var b = Random.Range(SpawnPoint1.transform.position.z, SpawnPoint2.transform.position.z);
            Vector3 konum = new Vector3(a, -9, b);
            enemyPrefab[i] = Instantiate(prefab, konum, transform.rotation);

        }
    }

    public void EnemyDestinationControl()
    {
        if (PlayerController.Instance.isArena == true)
        {
            Player = new GameObject[spawnManager.tempAry];
            spawnManager.arrayPlayer.CopyTo(Player, 0);
            for (int i = 0; i < Enemy_Number; i++)
            {

                enemyNav[i] = enemyPrefab[i].GetComponent<NavMeshAgent>();

            }

        }

    }

    public void FollowPlayer()
    {

        // animator.SetBool("isIdle", false);
        //animator.SetBool("isRun", true);

        for (int i = 0; i < Enemy_Number; i++)
        {

            if (PlayerController.Instance.player_Count > 0 && Enemy_Number > 0)
            {
                if (enemyNav[i].isOnNavMesh == false)
                {
                    enemyNav[i].Warp(enemyPrefab[i].transform.position);
                }
                enemyNav[i].SetDestination(Player[i].transform.position);


            }
           
           
        }
        
    }


    public void EnemyNumberControl()
    {

        enemyCount--;

    }



}
