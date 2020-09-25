using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{

    private List<Goal> goals;
    private List<Habit> habits;
    private List<bool> achievements;

    public Player() {
        goals = new List<Goal>();
        habits = new List<Habit>();
        achievements = new List<bool>();
        achievements.Add(true);
        achievements.Add(false);
        achievements.Add(false);
        achievements.Add(false);
        achievements.Add(false);
        achievements.Add(false);
        achievements.Add(false);
        achievements.Add(false);
        achievements.Add(false);
        achievements.Add(false);
    }

    public Player(List<Goal> goals, List<Habit> habits, List<bool> achievements) {
        this.goals = goals;
        this.habits = habits;
        this.achievements = achievements;
    }

    public void SavePlayer() {
        SaveLoadSystem.SaveSystem(this);
    }

    public void LoadPlayer() {
        PlayerData data = SaveLoadSystem.LoadPlayer();
        if (data != null)
        {
            this.setGoals(new List<Goal>(data.goals));
            this.setHabits(new List<Habit>(data.habits));
            this.setAchievements(new List<bool>(data.achievements));
        }
    }

    public List<Goal> getGoals() {
        return goals;
    }

    public List<Habit> getHabits() {
        return habits;
    }

    public List<bool> getAchievements() {
        return achievements;
    }

    public void setGoals(List<Goal> goals) {
        this.goals = goals;
    }

    public void setHabits(List<Habit> habits) {
        this.habits = habits;
    }

    public void setAchievements(List<bool> achievements) {
        this.achievements = achievements;
    }

}
