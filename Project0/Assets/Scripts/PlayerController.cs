using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject[] dots;
    int controldotIndex = 0;
    Transform currentDotPosition;
    Vector3 pos;
    public float PlayerSpeed;
    bool isControlDot;

    void Start()
    {
        currentDotPosition = dots[0].transform;
        isControlDot = true;
    }

    
    void Update()
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
       


        void NextDot()
        {
            if(controldotIndex >= dots.Length-1) // 2
            {
                isControlDot = false;
                //  Lock kontrolleri gelecek.
                Debug.Log("You must go arena");
                return;
            }
            controldotIndex++; // 1 // 2
            currentDotPosition = dots[controldotIndex].transform;
            //dots[1].trasform;
        }

    }
}
