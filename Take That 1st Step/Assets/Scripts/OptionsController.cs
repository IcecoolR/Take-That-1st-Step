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

    [Header("Calendar objects")]

    [SerializeField]
    public Button Calendarbtn;

    [SerializeField]
    public GameObject CalendarObject;

    [Header("About objects")]

    [SerializeField]
    public Button Aboutbtn;

    [SerializeField]
    public GameObject AboutObject;


    public void InspirationButtonHandler() {
        Debug.Log("Inspiration!");
        TitleText.text = "Inspiration";
        InspirationObject.SetActive(true);
        CalendarObject.SetActive(false);
        AboutObject.SetActive(false);
        Inspirationbtn.interactable = false;
        Calendarbtn.interactable = true;
        Aboutbtn.interactable = true;
        InformationPanel.SetActive(true);
    }

    public void CalendarButtonHandler() {
        Debug.Log("Calendar");
        TitleText.text = "Calendar";
        InspirationObject.SetActive(false);
        CalendarObject.SetActive(true);
        AboutObject.SetActive(false);
        Inspirationbtn.interactable = true;
        Calendarbtn.interactable = false;
        Aboutbtn.interactable = true;
        InformationPanel.SetActive(true);
    }

    public void AboutButtonHandler() {
        Debug.Log("About!");
        TitleText.text = "About";
        InspirationObject.SetActive(false);
        CalendarObject.SetActive(false);
        AboutObject.SetActive(true);
        Inspirationbtn.interactable = true;
        Calendarbtn.interactable = true;
        Aboutbtn.interactable = false;
        InformationPanel.SetActive(true);
    }

    public void CloseInformationTabButtonHandler() {
        Debug.Log("Information Panel Closed!");
        InformationPanel.SetActive(false);
    }
}
