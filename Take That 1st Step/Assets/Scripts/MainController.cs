using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainController : MonoBehaviour
{

    [SerializeField]
    public GameObject Goal1;

    [SerializeField]
    public Button NewGoal;


    // Start is called before the first frame update
    // void Start() { }

    // Update is called once per frame
    // void Update() { }

    public void newGoalButtonHandler() {
        Debug.Log("Goal Created!");
        Goal1.SetActive(true);
    }

    public void deleteGoalButtonHandler()
    {
        Debug.Log("Goal Deleted!");
        Goal1.SetActive(false);
    }


}
