using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto_Cura : MonoBehaviour
{
    [SerializeField]
    int _cureAmount;

    public Salud _lifePj;

    [SerializeField]
    GameObject PJ;

    //Funcion en la cual declaramos que si el personaje colisiona con un objeto curativo, se le suma la salud.
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {

        _lifePj._life += _cureAmount;

        Destroy(gameObject);

        Debug.Log($"Se le sumo {_cureAmount} Puntos de salud al personaje");

        Debug.Log($"Su salud actual es de: {_lifePj._life} Puntos");

    }
}
