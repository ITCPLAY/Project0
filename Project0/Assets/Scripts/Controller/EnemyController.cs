using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    EnemyManager enemyManager;
   // public  NavMeshAgent enemy;
    Animator animator;
   
    void Start()
    {
        enemyManager = GetComponentInParent<EnemyManager>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
       // FollowPlayer();
    }

    public void FollowPlayer()
    {
         
        animator.SetBool("isIdle", false);
        animator.SetBool("isRun", true);

        // enemyManager.enemyPrefab[i]
          for (int i = 0; i < enemyManager.Enemy_Number; i++)
          {
            // enemy.SetDestination(enemyManager.Player[0].transform.position);
            enemyManager.enemyNav[i].SetDestination(enemyManager.Player[i].transform.position);
             
          }


      


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            enemyManager.Enemy_Number--;
            Debug.Log("Dead");
        }
    }
}
