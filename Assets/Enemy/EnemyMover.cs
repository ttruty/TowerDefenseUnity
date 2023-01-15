using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private List<Waypoint> path = new List<Waypoint>();

    [SerializeField] private float waitTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        PrintWaypointName();
        StartCoroutine(PrintWaypointName());
    }

    IEnumerator PrintWaypointName()
    {
        foreach (Waypoint waypoint in path)
        { 
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
