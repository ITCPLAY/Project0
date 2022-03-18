using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SettingsMenu : MonoBehaviour
{

    [Header("Space between menu items")]
    [SerializeField] Vector2 spacing;

    [Space]
    [Header("Main Button Rotation")]
    [SerializeField] float rotationDuration;
    [SerializeField] Ease rotationEase;

    [Space]
    [Header("Animation")]
    [SerializeField] float expandDuration;
    [SerializeField] float collapseDuration;
    [SerializeField] Ease expandEase;
    [SerializeField] Ease collapseEase;


    [Space]
    [Header("Fading")]
    [SerializeField] float expandFadeDuration;
    [SerializeField] float collapseFadeDuration;

    Button mainButton;
    SettingsMenuItem[] menuItems;
    bool isExpanded = false;

    Vector2 mainButtonPosition;
    int itemsCount;

    void Start()
    {
        itemsCount = transform.childCount - 1;
        menuItems = new SettingsMenuItem[itemsCount];
        for (int i = 0; i < itemsCount; i++)
        {
            menuItems[i] = transform.GetChild(i + 1).GetComponent<SettingsMenuItem>();
        }
        mainButton = transform.GetChild(0).GetComponent<Button>();
        mainButton.onClick.AddListener(ToggleMenu);
        mainButton.transform.SetAsLastSibling();

        mainButtonPosition = mainButton.transform.position;

        // Reset the all menu items position to mainButtonPosition
        resetPosition();
    }

    void resetPosition()
    {
        for (int i = 0; i < itemsCount; i++)
        {
            menuItems[i].trans.position = mainButtonPosition;
        }
    }

    void ToggleMenu()
    {
        isExpanded = !isExpanded;
        if (isExpanded)
        {
            //Menu opened
            for (int i = 0; i < itemsCount; i++)
            {
                // menuItems[i].trans.position = mainButtonPosition + spacing * (i + 1);
                menuItems[i].trans.DOMove(mainButtonPosition + spacing * (i + 1), expandDuration).SetEase(expandEase);
                menuItems[i].img.DOFade(1f, expandFadeDuration).From(0f);

            }
        }
        else
        {
            //Menu closed
            for (int i = 0; i < itemsCount; i++)
            {
                // menuItems[i].trans.position = mainButtonPosition;
                menuItems[i].trans.DOMove(mainButtonPosition , collapseDuration).SetEase(collapseEase);
                menuItems[i].img.DOFade(0f, collapseFadeDuration);
            }
        }
       
       
    }

    public void OnItemClick(int index)
    {
        //here you can add you logic 
        switch (index)
        {
            case 0:
                //first button
                Debug.Log("Info");
                break;
            case 1:
                //second button
                Debug.Log("Sounds");
                break;
            case 2:
                //third button
                Debug.Log("Vibration");
                break;
        }
    }
    void OnDestroy()
    {
        mainButton.onClick.RemoveListener(ToggleMenu);
    }
}
