using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cura_Enemigo : Enemigos
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

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("zombie"))
        {
            Enemigos zombie = other.gameObject.GetComponent<Enemigos>();

            if (zombie != null)
            {
                zombie.HealthEnemy(pointCure);
                Debug.Log("Curé al zombie!");
            }

            Destroy(gameObject);
            
        }
    }
    
}
