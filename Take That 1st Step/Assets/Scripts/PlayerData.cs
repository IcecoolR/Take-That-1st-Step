using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{    
    public Goal[] goals;
    public Habit[] habits;
    public bool[] achievements;
    public int goalCount;
    public System.DateTime lastSave;

    public PlayerData(Player player) {

        goals = player.getGoals().ToArray();
        habits = player.getHabits().ToArray();
        achievements = player.getAchievements().ToArray();
        goalCount = player.getGoalCount();
        lastSave = player.getLastSaveTime();

    }

}
