using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cura_Enemigo : MonoBehaviour
{
    //velocidad del proyectil 
    [SerializeField]
    float speed;

    //Determinamos el valor de cura
    [SerializeField]
    float pointCure;

    [SerializeField]
    Enemigos hp;

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("zombie"))
        {
            hp.currentHealth += pointCure;
        }
    }
}
