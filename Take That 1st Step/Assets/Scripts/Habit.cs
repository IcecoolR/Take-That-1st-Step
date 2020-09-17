using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habit : MonoBehaviour
{

    private string habit;
    private int daysLeft;
    private System.DateTime timeCreated;

    public Habit(string habit, int daysLeft) {

        this.habit = habit;
        this.daysLeft = daysLeft;
        this.timeCreated = System.DateTime.Now;

    }

    public string getHabit() {
        return habit;
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
