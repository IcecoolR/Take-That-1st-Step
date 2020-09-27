using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{

    private List<Goal> goals;
    private List<Habit> habits;
    private List<bool> achievements;
    private int goalCount;
    private System.DateTime lastSave;

    public Player() {
        this.goals = new List<Goal>();
        this.habits = new List<Habit>();
        this.achievements = new List<bool>();
        this.achievements.Add(true);
        this.achievements.Add(false);
        this.achievements.Add(false);
        this.achievements.Add(false);
        this.achievements.Add(false);
        this.achievements.Add(false);
        this.achievements.Add(false);
        this.achievements.Add(false);
        this.achievements.Add(false);
        this.achievements.Add(false);
        this.goalCount = 0;
        this.lastSave = System.DateTime.Now;
    }

    public Player(List<Goal> goals, List<Habit> habits, List<bool> achievements) {
        this.goals = goals;
        this.habits = habits;
        this.achievements = achievements;
        this.goalCount = 0;
        this.lastSave = System.DateTime.Now;
    }

    public void SavePlayer() {
        this.lastSave = System.DateTime.Now;
        SaveLoadSystem.SaveSystem(this);
    }

    public void LoadPlayer() {
        PlayerData data = SaveLoadSystem.LoadPlayer();
        if (data != null)
        {
            this.setGoals(new List<Goal>(data.goals));
            this.setHabits(new List<Habit>(data.habits));
            this.setAchievements(new List<bool>(data.achievements));
            this.setGoalCount(data.goalCount);
            this.setLastSaveTime(data.lastSave);
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

    public int getGoalCount() {
        return goalCount;
    }

    public System.DateTime getLastSaveTime() {
        return lastSave;
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

    public void setLastSaveTime(System.DateTime lastSave) {
        this.lastSave = lastSave;
    }

    public void incrementGoalCount() {
        this.goalCount = goalCount + 1;
    }

    public void setGoalCount(int goalCount) {
        this.goalCount = goalCount;
    }
}
