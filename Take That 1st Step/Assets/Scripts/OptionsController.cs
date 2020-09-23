using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class OptionsController : MonoBehaviour
{
    
    [SerializeField]
    public GameObject InformationPanel;

    [SerializeField]
    public TMP_Text TitleText;

    [Header("Inspiration objects")]

    [SerializeField]
    public Button Inspirationbtn;

    [SerializeField]
    public GameObject InspirationObject;

    [Header("Achievements objects")]

    [SerializeField]
    public Button Achievementsbtn;

    [SerializeField]
    public GameObject AchievementsObject;

    [Header("About objects")]

    [SerializeField]
    public Button Aboutbtn;

    [SerializeField]
    public GameObject AboutObject;


    public void InspirationButtonHandler() {
        Debug.Log("Inspiration!");
        TitleText.text = "Inspiration";
        InspirationObject.SetActive(true);
        AchievementsObject.SetActive(false);
        AboutObject.SetActive(false);
        Inspirationbtn.interactable = false;
        Achievementsbtn.interactable = true;
        Aboutbtn.interactable = true;
        InformationPanel.SetActive(true);
    }

    public void CalendarButtonHandler() {
        Debug.Log("Achievements!");
        TitleText.text = "Achievements";
        InspirationObject.SetActive(false);
        AchievementsObject.SetActive(true);
        AboutObject.SetActive(false);
        Inspirationbtn.interactable = true;
        Achievementsbtn.interactable = false;
        Aboutbtn.interactable = true;
        InformationPanel.SetActive(true);
    }

    public void AboutButtonHandler() {
        Debug.Log("About!");
        TitleText.text = "About";
        InspirationObject.SetActive(false);
        AchievementsObject.SetActive(false);
        AboutObject.SetActive(true);
        Inspirationbtn.interactable = true;
        Achievementsbtn.interactable = true;
        Aboutbtn.interactable = false;
        InformationPanel.SetActive(true);
    }

    public void CloseInformationTabButtonHandler() {
        Debug.Log("Information Panel Closed!");
        InformationPanel.SetActive(false);
    }
}
