using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyManager : MonoBehaviour
{

    public GameObject SpawnPoint1, SpawnPoint2;
    [SerializeField] private GameObject prefab;
    [SerializeField] public int Enemy_Number;
    [SerializeField] public GameObject[] Player;
    public ArrayList Playerarray = new ArrayList();
    public GameObject[] enemyPrefab;
    public NavMeshAgent[] enemyNav;
    SpawnManager spawnManager;
    public int enemyCount;
    

    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        CreateEnemy();
        enemyCount = Enemy_Number;
    }

    private void Update()
    {


        if (PlayerController.Instance.isArena == true)
        {


            EnemyDestinationControl();
            FollowPlayer();



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

        for (int i = 0; i < PlayerController.Instance.player_Count; i++)
        {

            if (PlayerController.Instance.player_Count > 0 && Enemy_Number > 0)
            {

                enemyNav[i].SetDestination(Player[i].transform.position);


            }


        }

    }


    public void EnemyNumberControl()
    {
        enemyCount--;

    }

    
    
}
