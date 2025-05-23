using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cura_Enemigo : Enemy
{
    //velocidad del proyectil 
    [SerializeField]
    float speed;

    //Determinamos el valor de cura
    [SerializeField]
    float pointCure;

    [SerializeField]
    Enemy hp;

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("zombie"))
        {
            Enemy zombie = other.gameObject.GetComponent<Enemy>();

            if (zombie != null)
            {
                zombie.HealthEnemy(pointCure);
                Debug.Log("Cur� al zombie!");
            }

            Destroy(gameObject);
            
        }
    }
    
}
