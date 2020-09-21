using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MainController : MonoBehaviour
{

    [SerializeField]
    public Button Todaybtn;

    [SerializeField]
    public Button Habitsbtn;

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
    public GameObject Goal5;

    [SerializeField]
    public TMP_Text Goal5Text;

    [SerializeField]
    public GameObject Goal6;

    [SerializeField]
    public TMP_Text Goal6Text;

    [SerializeField]
    public GameObject Goal7;

    [SerializeField]
    public TMP_Text Goal7Text;

    [SerializeField]
    public GameObject Goal8;

    [SerializeField]
    public TMP_Text Goal8Text;

    [SerializeField]
    public TMP_Text NewGoalPanelTitle;

    [SerializeField]
    public GameObject NewGoalPanel;

    [SerializeField]
    public TMP_InputField NewGoalInf;

    private bool isTodaySelected = true;

    private List<Goal> goals = new List<Goal>();
    private List<Habit> habits = new List<Habit>();


    // Start is called before the first frame update
    // void Start() { }

    // Update is called once per frame
    // void Update() { }

    public void updateGoals() {
        resetGoals();
        NewGoalbtn.gameObject.SetActive(true);
        if (isTodaySelected)
        {
            Debug.Log("Updating Goals!");

            foreach (Habit i in habits) {
                if (goals.Find(x => (x.getGoal() == i.getHabit())) == null && !i.isCompleted()) {
                    goals.Add(i.createGoal());
                }
            }
            if (goals.Count != 0)
            {
                if (goals.Count >= 1)
                {
                    Debug.Log("1 Goal!");
                    Goal1Text.text = goals[0].getGoal();
                    Goal1.SetActive(true);
                    Goal2.SetActive(false);
                }
                if (goals.Count >= 2)
                {
                    Debug.Log("2 Goals!");
                    Goal2Text.text = goals[1].getGoal();
                    Goal2.SetActive(true);
                    Goal3.SetActive(false);
                }
                if (goals.Count >= 3)
                {
                    Debug.Log("3 Goals!");
                    Goal3Text.text = goals[2].getGoal();
                    Goal3.SetActive(true);
                    Goal4.SetActive(false);
                }
                if (goals.Count >= 4)
                {
                    Debug.Log("4 Goals!");
                    Goal4Text.text = goals[3].getGoal();
                    Goal4.SetActive(true);
                    Goal5.SetActive(false);
                }
                if (goals.Count >= 5)
                {
                    Debug.Log("5 Goals!");
                    Goal5Text.text = goals[4].getGoal();
                    Goal5.SetActive(true);
                    Goal6.SetActive(false);
                }
                if (goals.Count >= 6)
                {
                    Debug.Log("6 Goals!");
                    Goal6Text.text = goals[5].getGoal();
                    Goal6.SetActive(true);
                    Goal7.SetActive(false);
                }
                if (goals.Count >= 7)
                {
                    Debug.Log("7 Goals!");
                    Goal7Text.text = goals[6].getGoal();
                    Goal7.SetActive(true);
                    Goal8.SetActive(false);
                }
                if (goals.Count >= 8)
                {
                    Debug.Log("8 Goals!");
                    Goal8Text.text = goals[7].getGoal();
                    Goal8.SetActive(true);
                    NewGoalbtn.gameObject.SetActive(false);
                }
            }
        }
        else {
            Debug.Log("Updating Habits!");
            if (habits.Count != 0)
            {
                if (habits.Count >= 1)
                {
                    Debug.Log("1 Habit!");
                    Goal1Text.text = habits[0].getHabit();
                    Goal1.SetActive(true);
                    Goal2.SetActive(false);
                }
                if (habits.Count >= 2)
                {
                    Debug.Log("2 Habits!");
                    Goal2Text.text = habits[1].getHabit();
                    Goal2.SetActive(true);
                    Goal3.SetActive(false);
                }
                if (habits.Count >= 3)
                {
                    Debug.Log("3 Habits!");
                    Goal3Text.text = habits[2].getHabit();
                    Goal3.SetActive(true);
                    Goal4.SetActive(false);
                }
                if (habits.Count >= 4)
                {
                    Debug.Log("4 Habits!");
                    Goal4Text.text = habits[3].getHabit();
                    Goal4.SetActive(true);
                    Goal5.SetActive(false);
                }
                if (habits.Count >= 5)
                {
                    Debug.Log("5 Habits!");
                    Goal5Text.text = habits[4].getHabit();
                    Goal5.SetActive(true);
                    Goal6.SetActive(false);
                }
                if (habits.Count >= 6)
                {
                    Debug.Log("6 Habits!");
                    Goal6Text.text = habits[5].getHabit();
                    Goal6.SetActive(true);
                    Goal7.SetActive(false);
                }
                if (habits.Count >= 7)
                {
                    Debug.Log("7 Habits!");
                    Goal7Text.text = habits[6].getHabit();
                    Goal7.SetActive(true);
                    Goal8.SetActive(false);
                }
                if (habits.Count >= 8)
                {
                    Debug.Log("8 Habits!");
                    Goal8Text.text = habits[7].getHabit();
                    Goal8.SetActive(true);
                    NewGoalbtn.gameObject.SetActive(false);
                }
            }
        }
    }

    public void resetGoals() {
        Goal1.SetActive(false);
        Goal2.SetActive(false);
        Goal3.SetActive(false);
        Goal4.SetActive(false);
        Goal5.SetActive(false);
        Goal6.SetActive(false);
        Goal7.SetActive(false);
        Goal8.SetActive(false);
    }

    public void updateNewGoalPopup() {
        if (isTodaySelected) {
            NewGoalPanelTitle.text = "New Step";
            NewGoalInf.placeholder.GetComponent<TMP_Text>().text = "Enter a step for today...";
        } else {
            NewGoalPanelTitle.text = "New Habit";
            NewGoalInf.placeholder.GetComponent<TMP_Text>().text = "Enter a new habit...";
        }
        NewGoalInf.text = "";
    }

    public void todayButtonHandler() {
        Debug.Log("Today!");
        Todaybtn.interactable = false;
        isTodaySelected = true;
        updateNewGoalPopup();
        updateGoals();
        Habitsbtn.interactable = true;
    }

    public void habitButtonHandler() {
        Debug.Log("Habits!");
        Habitsbtn.interactable = false;
        isTodaySelected = false;
        updateNewGoalPopup();
        updateGoals();
        Todaybtn.interactable = true;
    }

    public void newGoalButtonHandler() {
        Debug.Log("New Goal!");
        NewGoalbtn.interactable = false;
        NewGoalPanel.SetActive(true);
    }

    public void closeNewGoalPanelButtonHandler() {
        Debug.Log("Panel Closed!");
        NewGoalbtn.interactable = true;
        NewGoalPanel.SetActive(false);
        NewGoalInf.text = "";
    }

    public void createNewGoalButtonHandler() {
        NewGoalbtn.interactable = true;
        if (isTodaySelected)
        {
            if (NewGoalInf.text != "")
            {
                Debug.Log("Goal Created!");
                Goal goal = new Goal(NewGoalInf.text);
                goals.Add(goal);

                updateGoals();

                NewGoalPanel.SetActive(false);
                NewGoalInf.text = "";

            }
        }
        else {
            if (NewGoalInf.text != "")
            {
                Debug.Log("Habit Created!");
                Habit habit = new Habit(NewGoalInf.text, 7);
                habits.Add(habit);

                updateGoals();

                NewGoalPanel.SetActive(false);
                NewGoalInf.text = "";

            }
        }
    }

    public void deleteGoal1ButtonHandler() {
        if (isTodaySelected)
        {
            Debug.Log("Goal Deleted!");
            if (habits.Find(x => (x.getHabit() == Goal1Text.text)) != null) {
                habits.Find(x => (x.getHabit() == Goal1Text.text)).setCompleted(true);
            }
            goals.RemoveAt(0);
        }
        else {
            Debug.Log("Habit Deleted!");
            if (goals.Find(x => (x.getGoal() == Goal1Text.text)) != null) {
                goals.Remove(goals.Find(x => (x.getGoal() == Goal1Text.text)));
            }
            habits.RemoveAt(0);
        }
        updateGoals();
    }

    public void deleteGoal2ButtonHandler() {
        if (isTodaySelected)
        {
            Debug.Log("Goal Deleted!");
            if (habits.Find(x => (x.getHabit() == Goal2Text.text)) != null) {
                habits.Find(x => (x.getHabit() == Goal2Text.text)).setCompleted(true);
            }
            goals.RemoveAt(1);
        }
        else
        {
            Debug.Log("Habit Deleted!");
            if (goals.Find(x => (x.getGoal() == Goal2Text.text)) != null) {
                goals.Remove(goals.Find(x => (x.getGoal() == Goal2Text.text)));
            }
            habits.RemoveAt(1);
        }
        updateGoals();
    }

    public void deleteGoal3ButtonHandler() {
        if (isTodaySelected)
        {
            Debug.Log("Goal Deleted!");
            if (habits.Find(x => (x.getHabit() == Goal3Text.text)) != null) {
                habits.Find(x => (x.getHabit() == Goal3Text.text)).setCompleted(true);
            }
            goals.RemoveAt(2);
        }
        else
        {
            Debug.Log("Habit Deleted!");
            if (goals.Find(x => (x.getGoal() == Goal3Text.text)) != null) {
                goals.Remove(goals.Find(x => (x.getGoal() == Goal3Text.text)));
            }
            habits.RemoveAt(2);
        }
        updateGoals();
    }

    public void deleteGoal4ButtonHandler() {
        if (isTodaySelected)
        {
            Debug.Log("Goal Deleted!");
            if (habits.Find(x => (x.getHabit() == Goal4Text.text)) != null) {
                habits.Find(x => (x.getHabit() == Goal4Text.text)).setCompleted(true);
            }
            goals.RemoveAt(3);
        }
        else
        {
            Debug.Log("Habit Deleted!");
            if (goals.Find(x => (x.getGoal() == Goal4Text.text)) != null) {
                goals.Remove(goals.Find(x => (x.getGoal() == Goal4Text.text)));
            }
            habits.RemoveAt(3);
        }
        updateGoals();
    }

    public void deleteGoal5ButtonHandler() {
        if (isTodaySelected)
        {
            Debug.Log("Goal Deleted!");
            if (habits.Find(x => (x.getHabit() == Goal5Text.text)) != null) {
                habits.Find(x => (x.getHabit() == Goal5Text.text)).setCompleted(true);
            }
            goals.RemoveAt(4);
        }
        else
        {
            Debug.Log("Habit Deleted!");
            if (goals.Find(x => (x.getGoal() == Goal5Text.text)) != null) {
                goals.Remove(goals.Find(x => (x.getGoal() == Goal5Text.text)));
            }
            habits.RemoveAt(4);
        }
        updateGoals();
    }

    public void deleteGoal6ButtonHandler() {
        if (isTodaySelected)
        {
            Debug.Log("Goal Deleted!");
            if (habits.Find(x => (x.getHabit() == Goal6Text.text)) != null) {
                habits.Find(x => (x.getHabit() == Goal6Text.text)).setCompleted(true);
            }
            goals.RemoveAt(5);
        }
        else
        {
            Debug.Log("Habit Deleted!");
            if (goals.Find(x => (x.getGoal() == Goal6Text.text)) != null) {
                goals.Remove(goals.Find(x => (x.getGoal() == Goal6Text.text)));
            }
            habits.RemoveAt(5);
        }
        updateGoals();
    }

    public void deleteGoal7ButtonHandler() {
        if (isTodaySelected)
        {
            Debug.Log("Goal Deleted!");
            if (habits.Find(x => (x.getHabit() == Goal7Text.text)) != null) {
                habits.Find(x => (x.getHabit() == Goal7Text.text)).setCompleted(true);
            }
            goals.RemoveAt(6);
        }
        else
        {
            Debug.Log("Habit Deleted!");
            if (goals.Find(x => (x.getGoal() == Goal7Text.text)) != null) {
                goals.Remove(goals.Find(x => (x.getGoal() == Goal7Text.text)));
            }
            habits.RemoveAt(6);
        }
        updateGoals();
    }

    public void deleteGoal8ButtonHandler() {
        if (isTodaySelected)
        {
            Debug.Log("Goal Deleted!");
            if (habits.Find(x => (x.getHabit() == Goal8Text.text)) != null) {
                habits.Find(x => (x.getHabit() == Goal8Text.text)).setCompleted(true);
            }
            goals.RemoveAt(7);
        }
        else
        {
            Debug.Log("Habit Deleted!");
            if (goals.Find(x => (x.getGoal() == Goal8Text.text)) != null) {
                goals.Remove(goals.Find(x => (x.getGoal() == Goal8Text.text)));
            }
            habits.RemoveAt(7);
        }
        updateGoals();
    }

}