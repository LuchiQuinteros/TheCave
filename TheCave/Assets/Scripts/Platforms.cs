using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platforms : MonoBehaviour
{

    public GameObject[] waypoints;

    [SerializeField]
    float platformSpeed;

    int waypointsIndex;

    [SerializeField]
    float cronometro;

    [SerializeField]
    float cronometroExit;

    [SerializeField]
    float localCronometro;

    private void Update()
    {
        MovePlatform();
    }
    

    public void MovePlatform()
    {
        //Comparamos la distancia que hay entre la plataforma y el punto al que va
        if (Vector3.Distance(transform.position, waypoints[waypointsIndex].transform.position) < 0.1f)
        {
            waypointsIndex++;

            if (waypointsIndex >= waypoints.Length)
            {
                waypointsIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointsIndex].transform.position, platformSpeed * Time.deltaTime);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cronometro += 1 * Time.deltaTime;

            if (cronometro >= 5)
            {
                collision.gameObject.transform.SetParent(null);

                Destroy(gameObject);

                cronometro = 0;
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.transform.SetParent(transform);

        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cronometroExit += 1 * Time.deltaTime;

            localCronometro = cronometro;

            collision.gameObject.transform.SetParent(null);

            if (cronometroExit >= 3)
            {
                localCronometro = 0;
            }
        }
    }

}
