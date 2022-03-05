using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    public GameObject levelPanel;
    [SerializeField] GameObject startText;
    [SerializeField] Text playerNumberText,enemyNumberText;
    EnemyManager enemyManager;

    private void Awake()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
    }
    private void Start()
    {
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
    }


    public void StartControl()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerController.Instance.isStart = true;
            startText.SetActive(false);
        }
    }
}
