using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salud : MonoBehaviour
{
    [SerializeField]
    public int vida;
    void Start()
    {
        Debug.Log($"La salud que tiene el personaje es {vida} Puntos");
    }
}
