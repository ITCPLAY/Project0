using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    EnemyManager enemyManager;
    Animator animator;
    public ParticleSystem Deat_PS;
    public bool isDestroy;
    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        animator = GetComponent<Animator>();
        isDestroy = false;

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player1")
        {

            // Destroy(gameObject);
             isDestroy = true;
              Death();
            
         
        }


    }
    private void OnCollisionExit(Collision collision)
    {

    }



    public void Death()
    {

        Instantiate(Deat_PS, transform.position, Quaternion.identity);
        // Destroy(gameObject);  
        gameObject.SetActive(false);
        enemyManager.enemyCount--;
        
    }

    
}



