using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MainController : MonoBehaviour
{

    [SerializeField]
    public GameObject Goal1;

    [SerializeField]
    public TMP_Text Goal1Text;

    [SerializeField]
    public GameObject NewGoalPanel;

    [SerializeField]
    public TMP_InputField NewGoalInf;


    // Start is called before the first frame update
    // void Start() { }

    // Update is called once per frame
    // void Update() { }

    public void newGoalButtonHandler() {
        Debug.Log("New Goal!");
        NewGoalPanel.SetActive(true);
    }

    public void closeNewGoalPanelButtonHandler() {
        Debug.Log("Panel Closed!");
        NewGoalPanel.SetActive(false);
        NewGoalInf.text = "";
    }

    public void createNewGoalButtonHandler() {
        if (NewGoalInf.text != "") {
            Debug.Log("Goal Created!");
            Goal goal1 = new Goal(NewGoalInf.text);
            Debug.Log(goal1.getGoal());
            Debug.Log(goal1.getTimeCreated());

            Goal1Text.text = goal1.getGoal();

            NewGoalPanel.SetActive(false);
            NewGoalInf.text = "";

            Goal1.SetActive(true);
        }
    }

    public void deleteGoal1ButtonHandler() {
        Debug.Log("Goal Deleted!");
        Goal1.SetActive(false);
    }

}