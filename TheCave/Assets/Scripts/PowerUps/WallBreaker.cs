using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreaker : MonoBehaviour, IPowerUp
{
    void IPowerUp.PowerUpAction()
    {
        Debug.Log("Doy la propiedad a la espada de romper paredes específicas");
    }
}
