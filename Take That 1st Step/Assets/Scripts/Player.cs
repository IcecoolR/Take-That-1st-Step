using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{

    private List<Goal> goals;
    private List<Habit> habits;
    private List<Achievement> achievements;

    public Player() {
        goals = new List<Goal>();
        habits = new List<Habit>();
        achievements = new List<Achievement>();
    }

    public Player(List<Goal> goals, List<Habit> habits, List<Achievement> achievements) {
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
            this.setAchievements(new List<Achievement>(data.achievements));
        }
    }

    public List<Goal> getGoals() {
        return goals;
    }

    public List<Habit> getHabits() {
        return habits;
    }

    public List<Achievement> getAchievements() {
        return achievements;
    }

    public void setGoals(List<Goal> goals) {
        this.goals = goals;
    }

    public void setHabits(List<Habit> habits) {
        this.habits = habits;
    }

    public void setAchievements(List<Achievement> achievements) {
        this.achievements = achievements;
    }

}
