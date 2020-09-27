using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Habit
{

    private string habit;
    private int daysLeft;
    private bool completed;
    private bool completedToday;
    private System.DateTime timeCreated;

    public Habit()
    {

        this.habit = "";
        this.daysLeft = 0;
        this.completed = true;
        this.completedToday = false;
        this.timeCreated = System.DateTime.Now.Date;

    }

    public Habit(string habit, int daysLeft) {

        this.habit = habit;
        this.daysLeft = daysLeft;
        this.completed = true;
        this.completedToday = false;
        this.timeCreated = System.DateTime.Now.Date;

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

    public int getDaysLeft() {
        return daysLeft;
    }

    public void reduceDaysLeft(int number) {
        this.daysLeft = daysLeft - number;
    }

    public void setDaysLeft(int daysLeft) {
        this.daysLeft = daysLeft;
    }

    public System.DateTime getTimeCreated() {
        return timeCreated;
    }

    public Goal createGoal() {
        return new Goal(habit);
    }

}
