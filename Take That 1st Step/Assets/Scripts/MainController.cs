using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class MainController : MonoBehaviour
{

    [Header("Main Objects")]

    [SerializeField]
    public Button Todaybtn;

    [SerializeField]
    public Button Habitsbtn;

    [SerializeField]
    public Button NewGoalbtn;

    [SerializeField]
    public GameObject ExtraGoals;

    [SerializeField]
    public TMP_Text ExtraGoalsText;

    public OptionsController optionsController;

    [Header("Goal 1")]

    [SerializeField]
    public GameObject Goal1;

    [SerializeField]
    public TMP_Text Goal1Text;

    [SerializeField]
    public Button Goal1Completedbtn;

    [SerializeField]
    public TMP_Text Habit1DaysLeftText;

    [Header("Goal 2")]

    [SerializeField]
    public GameObject Goal2;

    [SerializeField]
    public TMP_Text Goal2Text;

    [SerializeField]
    public Button Goal2Completedbtn;

    [SerializeField]
    public TMP_Text Habit2DaysLeftText;

    [Header("Goal 3")]

    [SerializeField]
    public GameObject Goal3;

    [SerializeField]
    public TMP_Text Goal3Text;

    [SerializeField]
    public Button Goal3Completedbtn;

    [SerializeField]
    public TMP_Text Habit3DaysLeftText;

    [Header("Goal 4")]

    [SerializeField]
    public GameObject Goal4;

    [SerializeField]
    public TMP_Text Goal4Text;

    [SerializeField]
    public Button Goal4Completedbtn;

    [SerializeField]
    public TMP_Text Habit4DaysLeftText;

    [Header("Goal 5")]

    [SerializeField]
    public GameObject Goal5;

    [SerializeField]
    public TMP_Text Goal5Text;

    [SerializeField]
    public Button Goal5Completedbtn;

    [SerializeField]
    public TMP_Text Habit5DaysLeftText;

    [Header("Goal 6")]

    [SerializeField]
    public GameObject Goal6;

    [SerializeField]
    public TMP_Text Goal6Text;

    [SerializeField]
    public Button Goal6Completedbtn;

    [SerializeField]
    public TMP_Text Habit6DaysLeftText;

    [Header("Goal 7")]

    [SerializeField]
    public GameObject Goal7;

    [SerializeField]
    public TMP_Text Goal7Text;

    [SerializeField]
    public Button Goal7Completedbtn;

    [SerializeField]
    public TMP_Text Habit7DaysLeftText;

    [Header("Goal 8")]

    [SerializeField]
    public GameObject Goal8;

    [SerializeField]
    public TMP_Text Goal8Text;

    [SerializeField]
    public Button Goal8Completedbtn;

    [SerializeField]
    public TMP_Text Habit8DaysLeftText;

    [Header("New Goal Panel")]

    [SerializeField]
    public GameObject NewGoalPanel;

    [SerializeField]
    public TMP_Text NewGoalPanelTitle;

    [SerializeField]
    public TMP_InputField NewGoalInf;

    [SerializeField]
    public TMP_Text NumberOfDaysText;

    [SerializeField]
    public TMP_Dropdown NumberOfDaysDropdown;

    private bool isTodaySelected = true;
    private Player player = new Player();
    private List<Goal> goals = new List<Goal>();
    private List<Habit> habits = new List<Habit>();


    void Start()
    {
        player.LoadPlayer();

        goals = player.getGoals();
        habits = player.getHabits();
        optionsController.initaliseAchievements();

        System.DateTime time = System.DateTime.Now;
        System.DateTime lastSave = player.getLastSaveTime();

        if (lastSave.Date == time.Date) { }
        else if (lastSave.AddDays(1).Date == time.Date)
        {
            goals.Clear();

            for (int i = 0; i < habits.Count; i++)
            {
                habits[i].reduceDaysLeft(1);
                if (habits[i].getDaysLeft() == 0)
                {
                    if (habits[i].isCompleted())
                    {
                        if (habits[i].getDaysFor() >= 14)
                        {
                            optionsController.achievementGot(8);
                        }
                        if (habits[i].getDaysFor() >= 31)
                        {
                            optionsController.achievementGot(9);
                        }
                    }
                    habits.RemoveAt(i);
                    i--;
                }
                else
                {
                    habits[i].updateCompleted();
                    habits[i].setCompletedToday(false);
                }
            }

            foreach (Habit i in habits)
            {
                if (goals.Find(x => (x.getGoal() == i.getHabit())) == null && !i.isCompletedToday())
                {
                    goals.Add(i.createGoal());
                }
            }

            SaveState();
        }
        else {

            goals.Clear();

            int difference = (lastSave - time).Days;

            for (int i = 0; i < habits.Count; i++) {
                habits[i].reduceDaysLeft(difference);
                if (habits[i].getDaysLeft() <= 0) {
                    habits.RemoveAt(i);
                    i--;
                }
                else
                {
                    habits[i].setCompleted(false);
                    habits[i].setCompletedToday(false);
                }
            }

            foreach (Habit i in habits)
            {
                if (goals.Find(x => (x.getGoal() == i.getHabit())) == null && !i.isCompletedToday())
                {
                    goals.Add(i.createGoal());
                }
            }

            SaveState();
        }

        updateGoals();
    }

    public Player getPlayer()
    {
        return player;
    }

    public void SaveState()
    {
        player.SavePlayer();
    }

    private void updateGoals()
    {
        resetGoals();
        NewGoalbtn.gameObject.SetActive(true);
        if (isTodaySelected)
        {

            if (goals.Count != 0)
            {
                if (goals.Count >= 1)
                {
                    Goal1Text.text = goals[0].getGoal();
                    Goal1Completedbtn.gameObject.SetActive(true);
                    Habit1DaysLeftText.gameObject.SetActive(false);
                    Goal1.SetActive(true);
                    Goal2.SetActive(false);
                }
                if (goals.Count >= 2)
                {
                    Goal2Text.text = goals[1].getGoal();
                    Goal2Completedbtn.gameObject.SetActive(true);
                    Habit2DaysLeftText.gameObject.SetActive(false);
                    Goal2.SetActive(true);
                    Goal3.SetActive(false);
                }
                if (goals.Count >= 3)
                {
                    Goal3Text.text = goals[2].getGoal();
                    Goal3Completedbtn.gameObject.SetActive(true);
                    Habit3DaysLeftText.gameObject.SetActive(false);
                    Goal3.SetActive(true);
                    Goal4.SetActive(false);
                }
                if (goals.Count >= 4)
                {
                    Goal4Text.text = goals[3].getGoal();
                    Goal4Completedbtn.gameObject.SetActive(true);
                    Habit4DaysLeftText.gameObject.SetActive(false);
                    Goal4.SetActive(true);
                    Goal5.SetActive(false);
                }
                if (goals.Count >= 5)
                {
                    Goal5Text.text = goals[4].getGoal();
                    Goal5Completedbtn.gameObject.SetActive(true);
                    Habit5DaysLeftText.gameObject.SetActive(false);
                    Goal5.SetActive(true);
                    Goal6.SetActive(false);
                }
                if (goals.Count >= 6)
                {
                    Goal6Text.text = goals[5].getGoal();
                    Goal6Completedbtn.gameObject.SetActive(true);
                    Habit6DaysLeftText.gameObject.SetActive(false);
                    Goal6.SetActive(true);
                    Goal7.SetActive(false);
                }
                if (goals.Count >= 7)
                {
                    Goal7Text.text = goals[6].getGoal();
                    Goal7Completedbtn.gameObject.SetActive(true);
                    Habit7DaysLeftText.gameObject.SetActive(false);
                    Goal7.SetActive(true);
                    Goal8.SetActive(false);
                }
                if (goals.Count >= 8)
                {
                    Goal8Text.text = goals[7].getGoal();
                    Goal8Completedbtn.gameObject.SetActive(true);
                    Habit8DaysLeftText.gameObject.SetActive(false);
                    Goal8.SetActive(true);
                    NewGoalbtn.gameObject.SetActive(false);
                }
                if (goals.Count >= 9)
                {
                    ExtraGoalsText.text = $"+{goals.Count - 8}";
                    ExtraGoals.gameObject.SetActive(true);
                }
                else
                {
                    ExtraGoals.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            ExtraGoals.gameObject.SetActive(false);
            if (habits.Count != 0)
            {
                if (habits.Count >= 1)
                {
                    Goal1Text.text = habits[0].getHabit();
                    Goal1Completedbtn.gameObject.SetActive(false);
                    Habit1DaysLeftText.text = "Days Remaining: " + habits[0].getDaysLeft();
                    Habit1DaysLeftText.gameObject.SetActive(true);
                    Goal1.SetActive(true);
                    Goal2.SetActive(false);
                }
                if (habits.Count >= 2)
                {
                    Goal2Text.text = habits[1].getHabit();
                    Goal2Completedbtn.gameObject.SetActive(false);
                    Habit2DaysLeftText.text = "Days Remaining: " + habits[1].getDaysLeft();
                    Habit2DaysLeftText.gameObject.SetActive(true);
                    Goal2.SetActive(true);
                    Goal3.SetActive(false);
                }
                if (habits.Count >= 3)
                {
                    Goal3Text.text = habits[2].getHabit();
                    Goal3Completedbtn.gameObject.SetActive(false);
                    Habit3DaysLeftText.text = "Days Remaining: " + habits[2].getDaysLeft();
                    Habit3DaysLeftText.gameObject.SetActive(true);
                    Goal3.SetActive(true);
                    Goal4.SetActive(false);
                }
                if (habits.Count >= 4)
                {
                    Goal4Text.text = habits[3].getHabit();
                    Goal4Completedbtn.gameObject.SetActive(false);
                    Habit4DaysLeftText.text = "Days Remaining: " + habits[3].getDaysLeft();
                    Habit4DaysLeftText.gameObject.SetActive(true);
                    Goal4.SetActive(true);
                    Goal5.SetActive(false);
                }
                if (habits.Count >= 5)
                {
                    Goal5Text.text = habits[4].getHabit();
                    Goal5Completedbtn.gameObject.SetActive(false);
                    Habit5DaysLeftText.text = "Days Remaining: " + habits[4].getDaysLeft();
                    Habit5DaysLeftText.gameObject.SetActive(true);
                    Goal5.SetActive(true);
                    Goal6.SetActive(false);
                }
                if (habits.Count >= 6)
                {
                    Goal6Text.text = habits[5].getHabit();
                    Goal6Completedbtn.gameObject.SetActive(false);
                    Habit6DaysLeftText.text = "Days Remaining: " + habits[5].getDaysLeft();
                    Habit6DaysLeftText.gameObject.SetActive(true);
                    Goal6.SetActive(true);
                    Goal7.SetActive(false);
                }
                if (habits.Count >= 7)
                {
                    Goal7Text.text = habits[6].getHabit();
                    Goal7Completedbtn.gameObject.SetActive(false);
                    Habit7DaysLeftText.text = "Days Remaining: " + habits[6].getDaysLeft();
                    Habit7DaysLeftText.gameObject.SetActive(true);
                    Goal7.SetActive(true);
                    Goal8.SetActive(false);
                }
                if (habits.Count >= 8)
                {
                    Goal8Text.text = habits[7].getHabit();
                    Goal8Completedbtn.gameObject.SetActive(false);
                    Habit8DaysLeftText.text = "Days Remaining: " + habits[7].getDaysLeft();
                    Habit8DaysLeftText.gameObject.SetActive(true);
                    Goal8.SetActive(true);
                    NewGoalbtn.gameObject.SetActive(false);
                }
            }
        }
    }

    private void resetGoals()
    {
        Goal1.SetActive(false);
        Goal2.SetActive(false);
        Goal3.SetActive(false);
        Goal4.SetActive(false);
        Goal5.SetActive(false);
        Goal6.SetActive(false);
        Goal7.SetActive(false);
        Goal8.SetActive(false);
    }

    private void updateNewGoalPopup()
    {
        if (isTodaySelected)
        {
            if (goals.Count < 8)
            {
                NewGoalPanelTitle.text = "New Step";
                NewGoalInf.placeholder.GetComponent<TMP_Text>().text = "Enter a step for today...";
                NumberOfDaysText.gameObject.SetActive(false);
                NumberOfDaysDropdown.gameObject.SetActive(false);
            } else {
                NewGoalPanel.SetActive(false);
                NewGoalbtn.interactable = true;
            }
        }
        else
        {
            if (habits.Count < 8) {
                NewGoalPanelTitle.text = "New Habit";
                NewGoalInf.placeholder.GetComponent<TMP_Text>().text = "Enter a new habit...";
                NumberOfDaysDropdown.value = 2;
                NumberOfDaysText.gameObject.SetActive(true);
                NumberOfDaysDropdown.gameObject.SetActive(true);
            } else {
                NewGoalPanel.SetActive(false);
                NewGoalbtn.interactable = true;
            }
        }
        NewGoalInf.text = "";
    }

    public void todayButtonHandler()
    {
        Todaybtn.interactable = false;
        isTodaySelected = true;
        updateNewGoalPopup();
        updateGoals();
        Habitsbtn.interactable = true;
    }

    public void habitButtonHandler()
    {
        Habitsbtn.interactable = false;
        isTodaySelected = false;
        updateNewGoalPopup();
        updateGoals();
        Todaybtn.interactable = true;
    }

    public void newGoalButtonHandler()
    {
        NewGoalbtn.interactable = false;
        NewGoalPanel.SetActive(true);
        updateNewGoalPopup();
    }

    public void closeNewGoalPanelButtonHandler()
    {
        NewGoalbtn.interactable = true;
        NewGoalPanel.SetActive(false);
        updateNewGoalPopup();
    }

    public void createNewGoalButtonHandler()
    {
        if (NewGoalInf.text != "")
        {

            bool isAlreadyPresent = false;
            
            if (isTodaySelected)
            {

                foreach (Goal i in goals)
                {
                    if (i.getGoal() == NewGoalInf.text)
                    {
                        isAlreadyPresent = true;
                    }
                }

                if (!isAlreadyPresent)
                {

                    optionsController.achievementGot(1);
                    Goal goal = new Goal(NewGoalInf.text);
                    goals.Add(goal);

                    updateGoals();

                    NewGoalbtn.interactable = true;
                    NewGoalPanel.SetActive(false);
                    NewGoalInf.text = "";

                    SaveState();
                }

            }
            else
            {

                foreach (Habit i in habits)
                {
                    if (i.getHabit() == NewGoalInf.text)
                    {
                        isAlreadyPresent = true;
                    }
                }

                if (!isAlreadyPresent)
                {

                    Habit habit = new Habit(NewGoalInf.text, int.Parse(NumberOfDaysDropdown.options[NumberOfDaysDropdown.value].text));
                    habits.Add(habit);
                    if (!goals.Exists(x => x.getGoal() == habit.getHabit())) {
                        goals.Add(habit.createGoal());
                    }

                    optionsController.achievementGot(2);
                    if (habits.Count == 2) {
                        optionsController.achievementGot(6);
                    }
                    else if (habits.Count == 6) {
                        optionsController.achievementGot(7);
                    }

                    updateGoals();

                    NewGoalbtn.interactable = true;
                    NewGoalPanel.SetActive(false);
                    NewGoalInf.text = "";

                    SaveState();
                }
            }        
        }
    }

    public void Goal1ButtonHandler(bool completed)
    {
        if (isTodaySelected)
        {
            if (habits.Find(x => (x.getHabit() == Goal1Text.text)) != null)
            {
                habits.Find(x => (x.getHabit() == Goal1Text.text)).setCompletedToday(completed);
            }

            if (completed) {
                optionsController.achievementGot(3);
                player.incrementGoalCount();
                if (player.getGoalCount() == 20) {
                    optionsController.achievementGot(4);
                }
                if (player.getGoalCount() == 100) {
                    optionsController.achievementGot(5);
                }
            }

            goals.RemoveAt(0);
        }
        else
        {
            if (goals.Find(x => (x.getGoal() == Goal1Text.text)) != null)
            {
                goals.Remove(goals.Find(x => (x.getGoal() == Goal1Text.text)));
            }
            habits.RemoveAt(0);
        }
        SaveState();
        updateGoals();
    }

    public void Goal2ButtonHandler(bool completed)
    {
        if (isTodaySelected)
        {
            if (habits.Find(x => (x.getHabit() == Goal2Text.text)) != null)
            {
                habits.Find(x => (x.getHabit() == Goal2Text.text)).setCompletedToday(completed);
            }

            if (completed)
            {
                optionsController.achievementGot(3);
                player.incrementGoalCount();
                if (player.getGoalCount() == 20)
                {
                    optionsController.achievementGot(4);
                }
                if (player.getGoalCount() == 100)
                {
                    optionsController.achievementGot(5);
                }
            }


            goals.RemoveAt(1);
        }
        else
        {
            if (goals.Find(x => (x.getGoal() == Goal2Text.text)) != null)
            {
                goals.Remove(goals.Find(x => (x.getGoal() == Goal2Text.text)));
            }
            habits.RemoveAt(1);
        }
        SaveState();
        updateGoals();
    }

    public void Goal3ButtonHandler(bool completed)
    {
        if (isTodaySelected)
        {
            if (habits.Find(x => (x.getHabit() == Goal3Text.text)) != null)
            {
                habits.Find(x => (x.getHabit() == Goal3Text.text)).setCompletedToday(completed);
            }

            if (completed)
            {
                optionsController.achievementGot(3);
                player.incrementGoalCount();
                if (player.getGoalCount() == 20)
                {
                    optionsController.achievementGot(4);
                }
                if (player.getGoalCount() == 100)
                {
                    optionsController.achievementGot(5);
                }
            }


            goals.RemoveAt(2);
        }
        else
        {
            if (goals.Find(x => (x.getGoal() == Goal3Text.text)) != null)
            {
                goals.Remove(goals.Find(x => (x.getGoal() == Goal3Text.text)));
            }
            habits.RemoveAt(2);
        }
        SaveState();
        updateGoals();
    }

    public void Goal4ButtonHandler(bool completed)
    {
        if (isTodaySelected)
        {
            if (habits.Find(x => (x.getHabit() == Goal4Text.text)) != null)
            {
                habits.Find(x => (x.getHabit() == Goal4Text.text)).setCompletedToday(completed);
            }

            if (completed)
            {
                optionsController.achievementGot(3);
                player.incrementGoalCount();
                if (player.getGoalCount() == 20)
                {
                    optionsController.achievementGot(4);
                }
                if (player.getGoalCount() == 100)
                {
                    optionsController.achievementGot(5);
                }
            }


            goals.RemoveAt(3);
        }
        else
        {
            if (goals.Find(x => (x.getGoal() == Goal4Text.text)) != null)
            {
                goals.Remove(goals.Find(x => (x.getGoal() == Goal4Text.text)));
            }
            habits.RemoveAt(3);
        }
        SaveState();
        updateGoals();
    }

    public void Goal5ButtonHandler(bool completed)
    {
        if (isTodaySelected)
        {
            if (habits.Find(x => (x.getHabit() == Goal5Text.text)) != null)
            {
                habits.Find(x => (x.getHabit() == Goal5Text.text)).setCompletedToday(completed);
            }

            if (completed)
            {
                optionsController.achievementGot(3);
                player.incrementGoalCount();
                if (player.getGoalCount() == 20)
                {
                    optionsController.achievementGot(4);
                }
                if (player.getGoalCount() == 100)
                {
                    optionsController.achievementGot(5);
                }
            }

            
            goals.RemoveAt(4);
        }
        else
        {
            if (goals.Find(x => (x.getGoal() == Goal5Text.text)) != null)
            {
                goals.Remove(goals.Find(x => (x.getGoal() == Goal5Text.text)));
            }
            habits.RemoveAt(4);
        }
        SaveState();
        updateGoals();
    }

    public void Goal6ButtonHandler(bool completed)
    {
        if (isTodaySelected)
        {
            if (habits.Find(x => (x.getHabit() == Goal6Text.text)) != null)
            {
                habits.Find(x => (x.getHabit() == Goal6Text.text)).setCompletedToday(completed);
            }

            if (completed) {
                optionsController.achievementGot(3);
                player.incrementGoalCount();
                if (player.getGoalCount() == 20)
                {
                    optionsController.achievementGot(4);
                }
                if (player.getGoalCount() == 100)
                {
                    optionsController.achievementGot(5);
                }
            }


            goals.RemoveAt(5);
        }
        else
        {
            if (goals.Find(x => (x.getGoal() == Goal6Text.text)) != null)
            {
                goals.Remove(goals.Find(x => (x.getGoal() == Goal6Text.text)));
            }
            habits.RemoveAt(5);
        }
        SaveState();
        updateGoals();
    }

    public void Goal7ButtonHandler(bool completed)
    {
        if (isTodaySelected)
        {
            if (habits.Find(x => (x.getHabit() == Goal7Text.text)) != null)
            {
                habits.Find(x => (x.getHabit() == Goal7Text.text)).setCompletedToday(completed);
            }

            if (completed) {
                optionsController.achievementGot(3);
                player.incrementGoalCount();
                if (player.getGoalCount() == 20)
                {
                    optionsController.achievementGot(4);
                }
                if (player.getGoalCount() == 100)
                {
                    optionsController.achievementGot(5);
                }
            }


            goals.RemoveAt(6);
        }
        else
        {
            if (goals.Find(x => (x.getGoal() == Goal7Text.text)) != null)
            {
                goals.Remove(goals.Find(x => (x.getGoal() == Goal7Text.text)));
            }
            habits.RemoveAt(6);
        }
        SaveState();
        updateGoals();
    }

    public void Goal8ButtonHandler(bool completed)
    {
        if (isTodaySelected)
        {
            if (habits.Find(x => (x.getHabit() == Goal8Text.text)) != null)
            {
                habits.Find(x => (x.getHabit() == Goal8Text.text)).setCompletedToday(completed);
            }

            if (completed) {
                optionsController.achievementGot(3);
                player.incrementGoalCount();
                if (player.getGoalCount() == 20)
                {
                    optionsController.achievementGot(4);
                }
                if (player.getGoalCount() == 100)
                {
                    optionsController.achievementGot(5);
                }
            }


            goals.RemoveAt(7);
        }
        else
        {
            if (goals.Find(x => (x.getGoal() == Goal8Text.text)) != null)
            {
                goals.Remove(goals.Find(x => (x.getGoal() == Goal8Text.text)));
            }
            habits.RemoveAt(7);
        }
        SaveState();
        updateGoals();
    }
}