using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField]
   SpawnPlatforms timer; // referencia al timer

    private int waypointsIndex = 0;

    private void Update()
    {
        MoveAlongWaypoints();
    }

    void MoveAlongWaypoints()
    {
        if (timer.timer.waypoints.Length == 0) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            timer.timer.waypoints[waypointsIndex].transform.position,
            timer.timer.platformSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, timer.timer.waypoints[waypointsIndex].transform.position) < 0.1f)
        {
            waypointsIndex++;
            if (waypointsIndex >= timer.timer.waypoints.Length)
            {
                waypointsIndex = 0;
            }
        }
    }
}

