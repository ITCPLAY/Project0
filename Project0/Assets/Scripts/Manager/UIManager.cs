using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject levelPanel;


    public void OnPlayButton()
    {
        levelPanel.SetActive(true);
    }

    public void ExitPanel()
    {
        levelPanel.SetActive(false);
    }
}
