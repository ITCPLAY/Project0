using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    int currentScene;
    public static PlayerController Instance;
    public GameObject[] dots;
    int controldotIndex = 0;
    Transform currentDotPosition;
    Vector3 pos;
    public float PlayerSpeed;
    public bool isControlDot,isStart;
    LockManager lockController;
    public int player_Count;

    void Awake()
    {
        Instance = this;
        lockController = FindObjectOfType<LockManager>();
    }
    void Start()
    {
        currentScene = PlayerPrefs.GetInt("ReachLevel", 1);
        currentDotPosition = dots[0].transform;
        isControlDot = true;
        lockController.isLock = false;

    }

    void Update()
    {

        if (isStart == true)
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

            if (lockController.isLock == true)
            {
                pos = currentDotPosition.position - transform.position;
                transform.Translate(pos.normalized * PlayerSpeed * Time.deltaTime, Space.World);

                if (Vector3.Distance(transform.position, currentDotPosition.position) <= .1f)
                {
                    NextDot();
                }
                ControlLock();
            }

        }
       

    }

    void NextDot()
    {

        if (controldotIndex >= dots.Length - 1)
        {

            isControlDot = false;

            return;
        }
        controldotIndex++;
        currentDotPosition = dots[controldotIndex].transform;

    }
    void ControlLock()
    {
        if (isControlDot == false)
        {
            controldotIndex = 0;
            isControlDot = true;

            currentDotPosition = dots[0].transform;

        }
    }

    public void GoNextLevel()
    {
        if (currentScene == SceneManager.GetActiveScene().buildIndex)
        {
            PlayerPrefs.SetInt("ReachLevel", currentScene + 1);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }


}
