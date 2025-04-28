using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        other.gameObject.TryGetComponent<Enemigos>(out Enemigos enemigos);

        
    }
}
