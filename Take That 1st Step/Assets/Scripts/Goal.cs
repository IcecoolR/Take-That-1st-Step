using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{

    private string goal;

    public Goal()
    {
        this.goal = "";
    }

    public Goal(string goal)
    {
        this.goal = goal;
    }

    public string getGoal()
    {
        return this.goal;
    }

    public void setGoal(string goal)
    {
        this.goal = goal;
    }
}
