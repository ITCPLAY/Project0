using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasic : MonoBehaviour
{

    PlayerController PlayerController;
    SpawnManager spawnManager;
    Animator animator;
    public ParticleSystem Death_PS_player;
   
    void Start()
    {
        animator = GetComponent<Animator>();
        PlayerController = GetComponentInParent<PlayerController>();
        spawnManager = FindObjectOfType<SpawnManager>();
    }

   
    void Update()
    {
        AnimatorControl();
    }


    private void AnimatorControl()
    {
        if (PlayerController.Instance.isStart == false)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isIdle", true);
        }
        else
        {
            if (PlayerController.isControlDot == true)
            {
                animator.SetBool("isRunning", true);
                animator.SetBool("isIdle", false);

            }
            else
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isIdle", true);
            }
        }
       
    }

    #region Death Functions


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            Death_Player();
            Debug.Log("Pushluyor");

        }
    }

    public void Death_Player()
    {
        Instantiate(Death_PS_player, transform.position, Quaternion.identity);
        spawnManager.CalledDestroy();
        PlayerController.player_Count--;
    }


    #endregion

}
