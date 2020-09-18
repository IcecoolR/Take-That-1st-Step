using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MainController : MonoBehaviour
{

    [SerializeField]
    public Button NewGoalbtn;

    [SerializeField]
    public GameObject Goal1;

    [SerializeField]
    public TMP_Text Goal1Text;

    [SerializeField]
    public GameObject Goal2;

    [SerializeField]
    public TMP_Text Goal2Text;

    [SerializeField]
    public GameObject Goal3;

    [SerializeField]
    public TMP_Text Goal3Text;

    [SerializeField]
    public GameObject Goal4;

    [SerializeField]
    public TMP_Text Goal4Text;

    [SerializeField]
    public GameObject NewGoalPanel;

    [SerializeField]
    public TMP_InputField NewGoalInf;

    private List<Goal> goals = new List<Goal>();


    // Start is called before the first frame update
    // void Start() { }

    // Update is called once per frame
    // void Update() { }

    public void updateGoals() {
        Debug.Log("Updating Goals!");
        if (goals.Count != 0)
        {
            if (goals.Count >= 1)
            {
                Debug.Log("1 GOAL!");
                Goal1Text.text = goals[0].getGoal();
                Goal1.SetActive(true);
                Goal2.SetActive(false);
            }
            if (goals.Count >= 2)
            {
                Debug.Log("2 GOALS!");
                Goal2Text.text = goals[1].getGoal();
                Goal2.SetActive(true);
                Goal3.SetActive(false);
            }
            if (goals.Count >= 3)
            {
                Debug.Log("3 GOALS!");
                Goal3Text.text = goals[2].getGoal();
                Goal3.SetActive(true);
                Goal4.SetActive(false);
                NewGoalbtn.gameObject.SetActive(true);
            }
            if (goals.Count >= 4)
            {
                Debug.Log("4 GOALS!");
                Goal4Text.text = goals[3].getGoal();
                Goal4.SetActive(true);
                NewGoalbtn.gameObject.SetActive(false);
            }
        }
        else {
            resetGoals();
        } 
    }

    public void resetGoals() {
        Goal1.SetActive(false);
        Goal2.SetActive(false);
        Goal3.SetActive(false);
        Goal4.SetActive(false);
    }

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
            Goal goal = new Goal(NewGoalInf.text);
            goals.Add(goal);

            updateGoals();

            NewGoalPanel.SetActive(false);
            NewGoalInf.text = "";

        }
    }

    public void deleteGoal1ButtonHandler() {
        Debug.Log("Goal Deleted!");
        goals.RemoveAt(0);
        updateGoals();
    }

    public void deleteGoal2ButtonHandler() {
        Debug.Log("Goal Deleted!");
        goals.RemoveAt(1);
        updateGoals();
    }

    public void deleteGoal3ButtonHandler() {
        Debug.Log("Goal Deleted!");
        goals.RemoveAt(2);
        updateGoals();
    }

    public void deleteGoal4ButtonHandler() {
        Debug.Log("Goal Deleted!");
        goals.RemoveAt(3);
        updateGoals();
    }

}