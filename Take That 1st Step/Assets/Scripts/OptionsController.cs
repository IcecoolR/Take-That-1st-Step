using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static MainController;
using TMPro;

public class OptionsController : MonoBehaviour
{
    
    [SerializeField]
    public GameObject InformationPanel;

    [SerializeField]
    public TMP_Text TitleText;

    [Header("Inspiration objects")]

    [SerializeField]
    public Button Inspirationbtn;

    [SerializeField]
    public GameObject InspirationObject;

    [Header("Achievements objects")]

    [SerializeField]
    public Button Achievementsbtn;

    [SerializeField]
    public GameObject AchievementsObject;

    [SerializeField]
    public Image Ach1Background;

    [SerializeField]
    public TMP_Text Ach1Title;

    [SerializeField]
    public TMP_Text Ach1Description;

    [SerializeField]
    public Image Ach2Background;

    [SerializeField]
    public TMP_Text Ach2Title;

    [SerializeField]
    public TMP_Text Ach2Description;

    [SerializeField]
    public Image Ach3Background;

    [SerializeField]
    public TMP_Text Ach3Title;

    [SerializeField]
    public TMP_Text Ach3Description;

    [SerializeField]
    public Image Ach4Background;

    [SerializeField]
    public TMP_Text Ach4Title;

    [SerializeField]
    public TMP_Text Ach4Description;

    [SerializeField]
    public Image Ach5Background;

    [SerializeField]
    public TMP_Text Ach5Title;

    [SerializeField]
    public TMP_Text Ach5Description;

    [SerializeField]
    public Image Ach6Background;

    [SerializeField]
    public TMP_Text Ach6Title;

    [SerializeField]
    public TMP_Text Ach6Description;

    [SerializeField]
    public Image Ach7Background;

    [SerializeField]
    public TMP_Text Ach7Title;

    [SerializeField]
    public TMP_Text Ach7Description;

    [SerializeField]
    public Image Ach8Background;

    [SerializeField]
    public TMP_Text Ach8Title;

    [SerializeField]
    public TMP_Text Ach8Description;

    [SerializeField]
    public Image Ach9Background;

    [SerializeField]
    public TMP_Text Ach9Title;

    [SerializeField]
    public TMP_Text Ach9Description;

    [SerializeField]
    public Image Ach10Background;

    [SerializeField]
    public TMP_Text Ach10Title;

    [SerializeField]
    public TMP_Text Ach10Description;

    [Header("About objects")]

    [SerializeField]
    public Button Aboutbtn;

    [SerializeField]
    public GameObject AboutObject;

    public MainController mainController;
    
    private int buttonSelected = 0;
    private List<Achievement> achievements = new List<Achievement>();
    private List<bool> completedAch = new List<bool>();


    public void initaliseAchievements() {
        completedAch = mainController.getPlayer().getAchievements();

        achievements.Add(new Achievement(Ach1Title.text, completedAch[0]));
        achievements.Add(new Achievement(Ach2Title.text, completedAch[1]));
        achievements.Add(new Achievement(Ach3Title.text, completedAch[2]));
        achievements.Add(new Achievement(Ach4Title.text, completedAch[3]));
        achievements.Add(new Achievement(Ach5Title.text, completedAch[4]));
        achievements.Add(new Achievement(Ach6Title.text, completedAch[5]));
        achievements.Add(new Achievement(Ach7Title.text, completedAch[6]));
        achievements.Add(new Achievement(Ach8Title.text, completedAch[7]));
        achievements.Add(new Achievement(Ach9Title.text, completedAch[8]));
        achievements.Add(new Achievement(Ach10Title.text, completedAch[9]));

        updateAchievements();
    }

    public void achievementGot(int index) {
        achievements[index].setCompleted(true);
        completedAch[index] = true;

        mainController.getPlayer().setAchievements(completedAch);
        mainController.SaveState();
        updateAchievements();
    }

    private void updateAchievements() {

        if (achievements[0].isCompleted()) {
            Ach1Background.GetComponent<Image>().color = new Color32(0, 200, 0, 255);
        }

        if (achievements[1].isCompleted()) {
            Ach2Background.GetComponent<Image>().color = new Color32(0, 200, 0, 255);
        }

        if (achievements[2].isCompleted()) {
            Ach3Background.GetComponent<Image>().color = new Color32(0, 200, 0, 255);
        }

        if (achievements[3].isCompleted()) {
            Ach4Background.GetComponent<Image>().color = new Color32(0, 200, 0, 255);
        }

        if (achievements[4].isCompleted()) {
            Ach5Background.GetComponent<Image>().color = new Color32(0, 200, 0, 255);
        }

        if (achievements[5].isCompleted()) {
            Ach6Background.GetComponent<Image>().color = new Color32(0, 200, 0, 255);
        }

        if (achievements[6].isCompleted()) {
            Ach7Background.GetComponent<Image>().color = new Color32(0, 200, 0, 255);
        }
        
        if (achievements[7].isCompleted()) {
            Ach8Background.GetComponent<Image>().color = new Color32(0, 200, 0, 255);
        }

        if (achievements[8].isCompleted()) {
            Ach9Background.GetComponent<Image>().color = new Color32(0, 200, 0, 255);
        }

        if (achievements[9].isCompleted()) {
            Ach10Background.GetComponent<Image>().color = new Color32(0, 200, 0, 255);
        }
    }

    public void InspirationButtonHandler() {
        Debug.Log("Inspiration!");
        if (buttonSelected != 1)
        {
            TitleText.text = "Inspiration";
            InspirationObject.SetActive(true);
            AchievementsObject.SetActive(false);
            AboutObject.SetActive(false);
            InformationPanel.SetActive(true);
            buttonSelected = 1;
        }
        else {
            CloseInformationTabButtonHandler();
        }
    }

    public void AchievementsButtonHandler() {
        Debug.Log("Achievements!");
        if (buttonSelected != 2)
        {
            updateAchievements();
            TitleText.text = "Achievements";
            InspirationObject.SetActive(false);
            AchievementsObject.SetActive(true);
            AboutObject.SetActive(false);
            InformationPanel.SetActive(true);
            buttonSelected = 2;
        }
        else
        {
            CloseInformationTabButtonHandler();
        }
    }

    public void AboutButtonHandler() {
        Debug.Log("About!");
        if (buttonSelected != 3)
        {
            TitleText.text = "About";
            InspirationObject.SetActive(false);
            AchievementsObject.SetActive(false);
            AboutObject.SetActive(true);
            InformationPanel.SetActive(true);
            buttonSelected = 3;
        }
        else
        {
            CloseInformationTabButtonHandler();
        }
    }

    public void CloseInformationTabButtonHandler() {
        Debug.Log("Information Panel Closed!");
        buttonSelected = 0;
        InformationPanel.SetActive(false);
    }
}
