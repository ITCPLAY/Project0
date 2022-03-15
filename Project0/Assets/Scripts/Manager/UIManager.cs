using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    public GameObject levelPanel,gameOverPanel,levelCompletePanel;
    [SerializeField] GameObject startText;
    [SerializeField] Text playerNumberText,enemyNumberText;
    EnemyManager enemyManager;
    public bool isFinish;

    private void Awake()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
    }
    private void Start()
    {
        isFinish = false;
        startText.SetActive(true);
    }
    public void OnPlayButton()
    {
        levelPanel.SetActive(true);
    }

    public void ExitPanel()
    {
        levelPanel.SetActive(false);
    }
    private void Update()
    {
        StartControl();
        playerNumberText.text = PlayerController.Instance.player_Count.ToString();
        enemyNumberText.text = enemyManager.enemyCount.ToString();
        FinishControl();
        if (isFinish == true)
        {

            LevelComplete();
            GameOver();
        }
    }


    public void StartControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerController.Instance.isStart = true;
            startText.SetActive(false);
        }
    }


   public void   LevelComplete()
    {
        if(PlayerController.Instance.player_Count > enemyManager.enemyCount)
        {
            Debug.Log("Level Complete");
           // Time.timeScale = 0;
            levelCompletePanel.SetActive(true);
        }
    }


    public void  GameOver()
    {
        if (PlayerController.Instance.player_Count < enemyManager.enemyCount)
        {
            Debug.Log("Game Over");
           // Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }


    public void FinishControl()
    {
        if (PlayerController.Instance.player_Count==0 || enemyManager.enemyCount==0)
        {
            isFinish = true;

        }
    }

    public void nextLevel()
    {
        PlayerController.Instance.GoNextLevel();
    }
    public void restart()
    {
        PlayerController.Instance.Restart();
    }
}
