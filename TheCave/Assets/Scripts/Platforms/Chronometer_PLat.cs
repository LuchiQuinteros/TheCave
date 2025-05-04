using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chronometer_PLat : MonoBehaviour
{
    [SerializeField]
    float maxTime;

    [SerializeField]
    float curremntTime;

    [SerializeField]
    GameObject platform;

    private void Start()
    {
        curremntTime += maxTime;
    }

    private void Update()
    {
        SetActive();
    }

    void SetActive()
    {
        curremntTime -= Time.deltaTime;

        if (curremntTime <= maxTime / 2)
        {
            platform.SetActive(false);
        }
        if (curremntTime <= 0f)
        {
            curremntTime += maxTime;

            platform.SetActive(true);
        }
    }
}
