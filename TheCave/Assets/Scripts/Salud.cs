using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salud : MonoBehaviour
{
    [SerializeField]
    public int _life;
    void Start()
    {
        Debug.Log($"La salud que tiene el personaje es {_life} Puntos");
    }
}
