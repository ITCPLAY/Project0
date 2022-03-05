using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController.Instance.isArena = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PlayerController.Instance.isArena = false;
    }

}
