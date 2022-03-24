using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
public class PlayerController : MonoBehaviour
{
    int currentScene;
    public static PlayerController Instance;
    public GameObject[] dots;
    int controldotIndex = 0;
    Transform currentDotPosition;
    Vector3 pos;
    public float PlayerSpeed;
    public bool isControlDot,isStart,isArena;
    LockManager lockController;
    EnemyManager enemyManager;
    public int player_Count;
    public NavMeshAgent[] playerNav;
    SpawnManager spawnManager;
    public int control = 0;

    void Awake()
    {
        Instance = this;
        lockController = FindObjectOfType<LockManager>();
        enemyManager = FindObjectOfType<EnemyManager>();
        spawnManager = FindObjectOfType<SpawnManager>();
    }
    void Start()
    {
        currentScene = PlayerPrefs.GetInt("ReachLevel", 1);
        currentDotPosition = dots[0].transform;
        isControlDot = true;
        lockController.isLock = false;

    }

    void Update()
    {
        if (isArena == true )
        {
            playerNav = new NavMeshAgent[spawnManager.tempAry];
            PlayerDestinationControl();
            EnemyFollow();
            Debug.Log("enemy follow sonrasi");
            
        }

        if (isStart == true)
        {

            if (isControlDot)
            {

                pos = currentDotPosition.position - transform.position;
                transform.Translate(pos.normalized * PlayerSpeed * Time.deltaTime, Space.World);

                if (Vector3.Distance(transform.position, currentDotPosition.position) <= .1f)
                {
                    NextDot();
                }
            }

            if (lockController.isLock == true)
            {
                pos = currentDotPosition.position - transform.position;
                transform.Translate(pos.normalized * PlayerSpeed * Time.deltaTime, Space.World);

                if (Vector3.Distance(transform.position, currentDotPosition.position) <= .1f)
                {
                    NextDot();
                }
                ControlLock();
            }

        }
      
       

    }

    void NextDot()
    {

        if (controldotIndex >= dots.Length - 1)
        {

            isControlDot = false;

            return;
        }
        controldotIndex++;
        currentDotPosition = dots[controldotIndex].transform;

    }
    void ControlLock()
    {
        if (isControlDot == false)
        {
            controldotIndex = 0;
            isControlDot = true;

            currentDotPosition = dots[0].transform;

        }
    }

    public void GoNextLevel()
    {
        if (currentScene == SceneManager.GetActiveScene().buildIndex)
        {
            PlayerPrefs.SetInt("ReachLevel", currentScene + 1);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlayerDestinationControl()
    {
        if (isArena == true)
        {
            enemyManager.EnemyDestinationControl();
            for (int i = 0; i < player_Count; i++)
            {
                playerNav[i] = enemyManager.Player[i].GetComponent<NavMeshAgent>();
            }
        }

    }
    
    public void EnemyFollow()
    {
        for (int i = 0; i < enemyManager.Enemy_Number; i++)
        {
            if(player_Count > 0 && enemyManager.Enemy_Number > 0)
            {
               //  playerNav[i].SetDestination(enemyManager.enemyPrefab[i].transform.position);

                if (playerNav[i].isOnNavMesh == false)
                {
                    playerNav[i].Warp(enemyManager.Player[i].transform.position);
                }

                playerNav[i].SetDestination(enemyManager.enemyPrefab[i].transform.position);

            }
        }
    }

}
