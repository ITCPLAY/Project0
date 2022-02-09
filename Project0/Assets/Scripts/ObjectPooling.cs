using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    private GameObject player_prefab;
    private Stack<GameObject> objectPooling = new Stack<GameObject>();
   


    public ObjectPooling(GameObject player_prefab)
    {
        this.player_prefab = player_prefab;
    }

    public void SetPool(int num)
    {
        for (int i = 0; i < num;i++)
        {
            GameObject obje = Object.Instantiate(player_prefab);
           
            PushPooling(obje);
        }
    }
    public GameObject PopPooling()
    {
        if (objectPooling.Count>0)
        {
            GameObject obje = objectPooling.Pop();
            obje.gameObject.SetActive(true);

            return obje;
        }

        return Object.Instantiate(player_prefab);
        
    }

    public void PushPooling(GameObject obje)
    {
        obje.gameObject.SetActive(false);
        objectPooling.Push(obje);
    }
}




