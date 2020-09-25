using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Habit
{

    private string habit;
    private int daysLeft;
    private bool completed;
    private System.DateTime timeCreated;

    public Habit()
    {

        this.habit = "";
        this.daysLeft = 0;
        this.completed = true;
        this.timeCreated = System.DateTime.Now.Date;

    }

    public Habit(string habit, int daysLeft) {

        this.habit = habit;
        this.daysLeft = daysLeft;
        this.completed = true;
        this.timeCreated = System.DateTime.Now.Date;

    }

    public string getHabit() {
        return habit;
    }

    public void setCompleted(bool completed) {
        this.completed = this.completed && completed;
    }

    public bool isCompleted() {
        return this.completed;
    }

    public int getDaysLeft() {
        return daysLeft;
    }

    public System.DateTime getTimeCreated() {
        return timeCreated;
    }

    public Goal createGoal() {
        return new Goal(habit);
    }

}
