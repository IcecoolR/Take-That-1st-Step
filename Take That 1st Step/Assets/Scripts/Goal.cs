using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{

    private string goal;
    private System.DateTime timeCreated;

    public Goal() {
        this.goal = "";
    }

    public Goal(string goal) {
        this.goal = goal;
        this.timeCreated = System.DateTime.Now.Date;
    }

    public string getGoal() {
        return this.goal;
    }

    public void setGoal(string goal) {
        this.goal = goal;
        this.timeCreated = System.DateTime.Now.Date;
    }

    public System.DateTime getTimeCreated() {
        return this.timeCreated;
    }
}
