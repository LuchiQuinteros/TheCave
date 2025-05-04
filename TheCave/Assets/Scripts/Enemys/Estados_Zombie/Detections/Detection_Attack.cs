using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection_Attack : Detection
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _detectionAttack = true;
            Debug.Log("Entroattack");
        }
    }
}
