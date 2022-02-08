using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public GameObject[] dots;
    int controldotIndex = 0;
    Transform currentDotPosition;
    Vector3 pos;
    public float PlayerSpeed;
    public   bool isControlDot;
    LockManager lockController;

     void Awake()
    {
        Instance = this;
        lockController = FindObjectOfType<LockManager>();
    }
    void Start()
    {
       
        currentDotPosition = dots[0].transform;
        isControlDot = true;
        lockController.isLock = false;
       
    }
    
    void Update()
    {
       

        if (isControlDot)
        {
            Debug.Log(isControlDot);
            pos = currentDotPosition.position - transform.position;
            transform.Translate(pos.normalized * PlayerSpeed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, currentDotPosition.position) <= .1f)
            {
                NextDot();
            }
        }
       
        if (lockController.isLock == true)
        {
           
            ControlLock();
            Debug.Log(isControlDot);
            Debug.Log(controldotIndex);
            pos = currentDotPosition.position - transform.position;
            transform.Translate(pos.normalized * PlayerSpeed * Time.deltaTime, Space.World);

            if (Vector3.Distance(transform.position, currentDotPosition.position) <= .1f)
            {
                NextDot();
            }
        }
       
    }

    void NextDot()
    {

        if (controldotIndex >= dots.Length - 1) // 2
        {
            Debug.Log("false dödün");
            isControlDot = false;
            Debug.Log(isControlDot);
            return;
            

        }
        controldotIndex++; // 1 // 2
        currentDotPosition = dots[controldotIndex].transform;
                
    }
    void ControlLock()
    {
        if (isControlDot == false)
        {     
            controldotIndex = 0;
            isControlDot = true;
            currentDotPosition = dots[0].transform;
            Debug.Log(isControlDot);
           
            
        }



    }
}
