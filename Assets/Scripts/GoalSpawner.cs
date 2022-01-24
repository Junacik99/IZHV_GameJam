using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] goals;
    [SerializeField]
    private GameObject firstGoal;
    private GameObject activeGoal;
    private void Awake()
    {
        goals = GameObject.FindGameObjectsWithTag("Goal");
        foreach (GameObject goal in goals)
            goal.SetActive(false);

        //SelectRandomGoal();
        activeGoal = firstGoal;
        activeGoal.SetActive(true);
    }

    public void SelectRandomGoal()
    {
        activeGoal = goals[Random.Range(0, goals.Length)];
        activeGoal.SetActive(true);
    }

    public GameObject GetActiveGoal() => activeGoal;
    
}
