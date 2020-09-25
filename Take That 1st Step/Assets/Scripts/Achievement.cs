using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Achievement
{

    private string title;
    private string description;
    private bool completed;

    public Achievement() {
        this.title = "";
        this.description = "";
        this.completed = false;
    }

    public Achievement(string title) {
        this.title = title;
        this.description = "";
        this.completed = false;
    }

    public Achievement(string title, bool completed) {
        this.title = title;
        this.description = "";
        this.completed = completed;
    }

    public Achievement(string title, string description, bool completed) {
        this.title = title;
        this.description = description;
        this.completed = completed;
    }

    public string getTitle() {
        return title;
    }

    public void setTitle(string title) {
        this.title = title;
    }

    public string getDescription() {
        return description;
    }

    public void setDescription(string description) {
        this.description = description;
    }

    public bool isCompleted() {
        return completed;
    }

    public void setCompleted(bool completed) {
        this.completed = completed;
    }

}
