using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    
    [SerializeField]
    public GameObject InformationPanel;


    public void InspirationButtonHandler() {
        Debug.Log("Inspiration!");
        InformationPanel.SetActive(true);
    }

    public void CalendarButtonHandler() {
        Debug.Log("Calendar!");
        InformationPanel.SetActive(true);
    }

    public void AboutButtonHandler() {
        Debug.Log("About!");
        InformationPanel.SetActive(true);
    }

    public void CloseInformationTabButtonHandler() {
        Debug.Log("Information Panel Closed!");
        InformationPanel.SetActive(false);
    }
}
