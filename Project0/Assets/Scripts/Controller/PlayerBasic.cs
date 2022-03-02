using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasic : MonoBehaviour
{

    PlayerController PlayerController;
    LockManager lockManager;
    Animator animator;
   
   
    void Start()
    {
        animator = GetComponent<Animator>();
        PlayerController = GetComponentInParent<PlayerController>();
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
}
