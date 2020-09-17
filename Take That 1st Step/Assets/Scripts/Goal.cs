using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    
    private string goal;
    private System.DateTime timeCreated;

    public Goal(string goal) {

        this.goal = goal;
        this.timeCreated = System.DateTime.Now;

    }

    public string getGoal() {
        return this.goal;
    }

}
