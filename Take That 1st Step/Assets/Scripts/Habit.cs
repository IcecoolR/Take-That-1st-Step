using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Habit
{

    private string habit;
    private int daysFor;
    private int daysLeft;
    private bool completed;
    private bool completedToday;

    public Habit()
    {

        this.habit = "";
        this.daysFor = 7;
        this.daysLeft = 0;
        this.completed = true;
        this.completedToday = false;

    }

    public Habit(string habit, int daysFor) {

        this.habit = habit;
        this.daysFor = daysFor;
        this.daysLeft = daysFor;
        this.completed = true;
        this.completedToday = false;

    }

    public string getHabit() {
        return habit;
    }

    public void updateCompleted() {
        this.completed = this.completed && completedToday;
    }

    public void setCompleted(bool completed) {
        this.completed = completed;
    }

    public bool isCompleted() {
        return this.completed;
    }

    public void setCompletedToday(bool completedToday) {
        this.completedToday = completedToday;
    }

    public bool isCompletedToday() {
        return this.completedToday;
    }

    public int getDaysFor() {
        return daysFor;
    }

    public int getDaysLeft() {
        return daysLeft;
    }

    public void reduceDaysLeft(int number) {
        this.daysLeft = daysLeft - number;
    }

    public void setDaysLeft(int daysLeft) {
        this.daysLeft = daysLeft;
    }    

    public Goal createGoal() {
        return new Goal(habit);
    }
}
