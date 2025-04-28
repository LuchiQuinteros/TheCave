using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    [SerializeField]
    GameObject platforms;

    [SerializeField]
    Transform platformTransform;

    [SerializeField]
    public Platforms timer;

    [SerializeField]
    float chronometer;

    private void Update()
    {
        CheckSpawn();
        MoveAlongWaypoints();
    }

    void CheckSpawn()
    {
        if (timer.test)
        {
            StartCoroutine(timer.myCourritine());
            Spawn();
            timer.test = false;
        }
    }

    void Spawn()
    {
        Instantiate(platforms, platformTransform.position, Quaternion.identity);
    }

    void MoveAlongWaypoints()
    {
        if (timer.waypoints.Length == 0) return; // safety check

        // Move towards the current waypoint
        transform.position = Vector3.MoveTowards(
            transform.position,
            timer.waypoints[timer.waypointsIndex].transform.position,
            timer.platformSpeed * Time.deltaTime
        );

        // If reached the waypoint, go to the next
        if (Vector3.Distance(transform.position, timer.waypoints[timer.waypointsIndex].transform.position) < 0.1f)
        {
            timer.waypointsIndex++;

            if (timer.waypointsIndex >= timer.waypoints.Length)
            {
                timer.waypointsIndex = 0;
            }
        }
    }
}
