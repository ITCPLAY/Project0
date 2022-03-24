using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIManager : MonoBehaviour
{

    public GameObject levelPanel, gameOverPanel, levelCompletePanel;
    [SerializeField] GameObject startText;
    [SerializeField] Text playerNumberText, enemyNumberText;
    EnemyManager enemyManager;
    public bool isFinish;
    [SerializeField] int x, y, z, w;
    public GameObject awesomeText, greatText, wonderfulText;
    public int count, countLevelPanel = 0;

    private void Awake()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
    }
    private void Start()
    {
        isFinish = false;
        startText.SetActive(true);
        awesomeText.SetActive(false);
        greatText.SetActive(false);
        wonderfulText.SetActive(false);
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
        infoUser();
        FinishControl();
        if (isFinish == true)
        {
            if (countLevelPanel == 0)
            {
                StartCoroutine(LevelComplete());
                StartCoroutine(GameOver());
            }
            countLevelPanel++;
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


    IEnumerator LevelComplete()
    {
        if (PlayerController.Instance.player_Count > enemyManager.enemyCount)
        {
            Debug.Log("Level Complete");
            // Time.timeScale = 0;
            yield return new WaitForSeconds(1f);
            levelCompletePanel.SetActive(true);
            
        }
    }


    IEnumerator GameOver()
    {
        if (PlayerController.Instance.player_Count < enemyManager.enemyCount)
        {
            Debug.Log("Game Over");
            // Time.timeScale = 0;
            yield return new WaitForSeconds(1f);
            gameOverPanel.SetActive(true);
        }
    }


    public void FinishControl()
    {
        if (PlayerController.Instance.player_Count == 0 || enemyManager.enemyCount == 0)
        {
            PlayerController.Instance.isArena = false;
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



    #region UserInfo
    public void infoUser()
    {
        if (PlayerController.Instance.player_Count > x && PlayerController.Instance.player_Count < y)
        {
            if (count < 1)
            {
                awesomeText.SetActive(true);
                StartCoroutine(animText());
            }
            count++;

        }
        else if (PlayerController.Instance.player_Count >= y && PlayerController.Instance.player_Count < z)
        {
            if (count < 1)
            {
                greatText.SetActive(true);
                StartCoroutine(animText());
            }
            count++;
        }
        else if (PlayerController.Instance.player_Count >= z && PlayerController.Instance.player_Count < w)
        {
            if (count < 1)
            {
                wonderfulText.SetActive(true);
                StartCoroutine(animText());
            }
            count++;
        }
    }



    IEnumerator animText()
    {
        #region awesomeTextAnim
        awesomeText.GetComponent<RectTransform>().DOScale(1f, 1f);
        yield return new WaitForSeconds(0.2f);
        awesomeText.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);
        awesomeText.GetComponent<CanvasGroup>().DOFade(0f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        #endregion

        #region greatTextAnim
        greatText.GetComponent<RectTransform>().DOScale(1f, 1f);
        yield return new WaitForSeconds(0.2f);
        greatText.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);
        greatText.GetComponent<CanvasGroup>().DOFade(0f, 0.5f);
        yield return new WaitForSeconds(0.2f);


        #endregion

        #region wonderfulTextAnim
        wonderfulText.GetComponent<RectTransform>().DOScale(1f, 1f);
        yield return new WaitForSeconds(0.2f);
        wonderfulText.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);
        wonderfulText.GetComponent<CanvasGroup>().DOFade(0f, 0.5f);
        yield return new WaitForSeconds(0.2f);
        #endregion


    }

    #endregion


}
