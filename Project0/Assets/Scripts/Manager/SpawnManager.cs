using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefab;
    private Stack<GameObject> PlayerStack = new Stack<GameObject>();
    private ObjectPooling pooling;
    public GameObject spawn1, spawn2;
    public int nwChoose, nwNum,currentCount;
    PlayerController playerController;
    GameObject obje;
   
    void Start()
    {

        pooling = new ObjectPooling(prefab);
        pooling.SetPool(100);

          for (int i = 0; i <PlayerController.Instance.player_Count ; i++)
          {
            // StartCoroutine(CreateObject());
            CreateObject();

        }
       
    }

    void Update()
    {
        // Debug.Log(PlayerController.Instance.player_Count);
       // Debug.Log("Trash gelen " + nwChoose);
        

    }

    public void CreateObject()
    {
            
            var a = Random.Range(spawn1.transform.position.x, spawn2.transform.position.x);
            var b = Random.Range(spawn1.transform.position.z, spawn2.transform.position.z);
            Vector3 konum = new Vector3(a, PlayerController.Instance.transform.position.y, b);
            obje = pooling.PopPooling();
            obje.transform.position = konum;
            obje.transform.parent = gameObject.transform;
            PlayerStack.Push(obje);



    }
  

    public void LogicalChoices()
    {
        // 1 = Addition
        // 2 = Subtraction
        // 3 = Multiplication
        // 4 = Division

        switch (nwChoose)
        {
           
            case 1:
                PlayerController.Instance.player_Count += nwNum;
                for (int i = 0; i < nwNum; i++)
                {
                    Debug.Log(PlayerController.Instance.player_Count);
                    CreateObject();
                    Debug.Log("girdi");
                    
                }
                break;
            case 2:
                PlayerController.Instance.player_Count -= nwNum;

                for (int i = 0; i < nwNum; i++)
                {
                    pooling.PushPooling(PlayerStack.Pop());
               
                }

                break;
            case 3:
                currentCount = PlayerController.Instance.player_Count; // Bir önceki player sayýmýzý tutuyoruz ki kaç obje üreteceðimizi kontrol edelim.
                PlayerController.Instance.player_Count *= nwNum;
                for (int i = currentCount; i < PlayerController.Instance.player_Count; i++)
                {
                  
                    CreateObject();
                }
                break;
            case 4:
               currentCount = PlayerController.Instance.player_Count / nwNum;
                PlayerController.Instance.player_Count -= currentCount;
                for (int i = 0; i < PlayerController.Instance.player_Count; i++)
                {
                    pooling.PushPooling(PlayerStack.Pop());

                }
                PlayerController.Instance.player_Count = currentCount;
                break;
            case 5:
            default:
                Debug.Log("Error");
                break;
        }

    }

  
}
