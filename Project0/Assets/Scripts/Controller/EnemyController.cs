using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    EnemyManager enemyManager;
    public NavMeshAgent enemy;
    [SerializeField] Transform Player;
    Animator animator;
    void Start()
    {
        enemyManager = GetComponentInParent<EnemyManager>();
        animator = GetComponent<Animator>();
    }

    

    public void FollowPlayer()
    {

        animator.SetBool("isIdle", false);
        animator.SetBool("isRun", true);
        enemy.SetDestination(Player.position);


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log("Dead");
        }
    }
}
