using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    EnemyManager enemyManager;
    Animator animator;
    public ParticleSystem Deat_PS;
    void Start()
    {
        enemyManager = GetComponentInParent<EnemyManager>();
        animator = GetComponent<Animator>();
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player1")
        {

            // Destroy(gameObject);
            Death();
          
            
        }
        
    }



    public void Death()
    {
        
        Instantiate(Deat_PS, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
       
    }
}

  

