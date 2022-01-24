using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassController : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private GoalSpawner goalSpawner;
    private Transform goal;
    private RectTransform rectTransform;
    private Vector3 northDir = Vector3.zero;
    // Start is called before the first frame update
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        goal = goalSpawner.GetActiveGoal().transform;
        //var angle = Vector2.SignedAngle(new Vector2(goal.position.x, goal.position.z), new Vector2(player.position.x, player.position.z));

        northDir.z = player.eulerAngles.y;
        
        Vector3 dir = player.position - goal.position;

        var goalDir = Quaternion.LookRotation(dir);
        goalDir.z = -goalDir.y;
        goalDir.x = 0;
        goalDir.y = 0;
        //dir = goal.InverseTransformDirection(dir);
        //float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;

        //angle += 180; // from <-180,180> to <0,360>

        //rectTransform.rotation = Quaternion.Euler(0,0,angle);
        rectTransform.localRotation = goalDir * Quaternion.Euler(0,0,dir.z);

    }
}
