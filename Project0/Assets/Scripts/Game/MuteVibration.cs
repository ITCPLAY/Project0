using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteVibration : MonoBehaviour
{

    [SerializeField] Image VibOnIcon;
    [SerializeField] Image VibOffIcon;
    private bool muted1 = false;
    LockController lockController;
    private void Awake()
    {
        lockController = FindObjectOfType<LockController>();
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("vibration"))
        {
            PlayerPrefs.SetInt("vibration", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();

    }
    
    private void UpdateButtonIcon()
    {
        if (muted1 == false)
        {
            VibOnIcon.enabled = true;
            VibOffIcon.enabled = false;

        }
        else
        {
            VibOnIcon.enabled = false;
            VibOffIcon.enabled = true;

        }
    }
    public void OnButtonPress()
    {
        if (muted1 == false)
        {
            muted1 = true;
            lockController.vibration = true;
        }
        else
        {
            muted1 = false;
            lockController.vibration = false;
        }
        Save();
        UpdateButtonIcon();
    }

    private void Load()
    {
        muted1 = PlayerPrefs.GetInt("vibration") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("vibration", muted1 ? 1 : 0);
    }
}
