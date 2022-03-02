using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{

    public GameObject levelPanel;
    [SerializeField] GameObject startText;


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
