using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefab;
    private Stack<GameObject> PlayerStack = new Stack<GameObject>();
    public ArrayList arrayPlayer = new ArrayList();
    private ObjectPooling pooling;
    public GameObject spawn1, spawn2;
    public int nwChoose, nwNum, currentCount,tempAry;
    PlayerController playerController;
    GameObject obje;
    private int j;

    void Start()
    {

        pooling = new ObjectPooling(prefab);
        pooling.SetPool(100);

        for (int i = 0; i < PlayerController.Instance.player_Count; i++)
        {

            CreateObject();
            StacktoArrayControl();
        }
        Debug.Log(arrayPlayer.Count);
       
    }
    private void Update()
    {
       // Debug.Log(arrayPlayer.Count);
        tempAry = arrayPlayer.Count;
        Debug.Log(tempAry);
        ///Debug.Log(arrayPlayer[4]);
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
                    StacktoArrayControl();

                }
                break;
            case 2:
                PlayerController.Instance.player_Count -= nwNum;

                for (int i = 0; i < nwNum; i++)
                {
                    pooling.PushPooling(PlayerStack.Pop());
                    arrayPlayer.RemoveRange(tempAry-nwNum,nwNum);

                }

                break;
            case 3:
                currentCount = PlayerController.Instance.player_Count;
                PlayerController.Instance.player_Count *= nwNum;
                for (int i = currentCount; i < PlayerController.Instance.player_Count; i++)
                {

                    CreateObject();
                    StacktoArrayControl();
                }
                break;
            case 4:
                currentCount = PlayerController.Instance.player_Count / nwNum;
                PlayerController.Instance.player_Count -= currentCount;
                for (int i = 0; i < PlayerController.Instance.player_Count; i++)
                {
                    pooling.PushPooling(PlayerStack.Pop());
                    arrayPlayer.RemoveRange(tempAry - PlayerController.Instance.player_Count, PlayerController.Instance.player_Count);

                }
                PlayerController.Instance.player_Count = currentCount;
                break;
            case 5:
            default:
                Debug.Log("Error");
                break;
        }

    }

    public void StacktoArrayControl()
    {
        arrayPlayer.Add(obje);
        
        
    }
  


}
