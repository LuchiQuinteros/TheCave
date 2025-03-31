using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto_Cura : MonoBehaviour
{
    [SerializeField]
    int cantidadCura;

    public Salud saludPj;

    [SerializeField]
    GameObject PJ;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {

        saludPj.vida += cantidadCura;

        Destroy(gameObject);

        Debug.Log($"Se le sumo {cantidadCura} Puntos de salud al personaje");

        Debug.Log($"Su salud actual es de: {saludPj.vida} Puntos");

    }
}
