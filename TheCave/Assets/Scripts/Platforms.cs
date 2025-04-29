using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    //hacemos un array para los waypoints de movimiento
    public GameObject[] waypoints;

    //velocidad de la plataforma
    [SerializeField]
    public float platformSpeed;

    //cantiadad de waypoints creados
    public int waypointsIndex;

    //timer de vida de la plataforma
    [SerializeField]
    public float cronometro;


    public bool test;

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
        //Pregunto si el personaje se encuentra sobre la plataforma
        if (collision.gameObject.CompareTag("Player"))
        {
            //Al estar encima de la plataforma empieza un contador
            cronometro += 1 * Time.deltaTime;

            //cuando el contador llega a 5 se desenparenta el personaje de la plataforma y se destruye la misma
            if (cronometro >= 5)
            {
                collision.gameObject.transform.SetParent(null);

                //test = true;

                cronometro = 0;
            }
        }
    }


    //cuando el personaje colisiona con la plataforma se parenta con ella para poder seguir el movimiento de la misma
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    //creo una corrutina para detener el tiempo y asi cuando el personaje sale de encima de la plataforma se reseta la "vida" de ella
    /*
    public IEnumerator myCourritine()
    {
        float countDown = 2f;

        yield return new WaitForSeconds(countDown);

        cronometro = 0;

        yield return null;
    }
    

    //cuando el personaje sale de encima de la plataforma llamamos a la corrutina y lo desenparentamos
    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(myCourritine());

            collision.gameObject.transform.SetParent(null);

        }
    }
    */

}
