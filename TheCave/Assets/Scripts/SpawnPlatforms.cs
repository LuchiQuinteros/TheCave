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

    public GameObject[] waypointsCopy;

    [SerializeField]
    Platforms waypointsIndexCopy;

    [SerializeField]
    Platforms speeds;

    private void Update()
    {
        CheckSpawn();

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

}
