using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curandero : MonoBehaviour
{
    //Vincular la cura de donde va a ser instanciada
    [SerializeField]
    GameObject cure;

    //Le indicamos a que enemigo curar
    [SerializeField]
    GameObject enemy;

    public Enemigos life;

    public Enemigos maxLife;

    //Determinamos el tiempo el cual instancie la cura
    [SerializeField]
    float chronometerCurander;

    //Preguntar si el enemigo al cual va a curar esta con vida o muerto
    private void Update()
    {
        CureEnemy();
    }

    void CureEnemy()
    {
        //Preguntamos si el enemigo se encuentra con vida en el juego o no para poder curarlo
        if (enemy != null && life.currentHealth < maxLife.maxHealth)
        {
            //si el enemigo existe la bala se dirije a su posicion
            Vector3 enemyPosition = enemy.transform.position - transform.position;

            chronometerCurander -= Time.deltaTime;

            if (chronometerCurander <= 0f)
            {
                //Una vez que se comprueba que el personaje existe, el enemigo comienza a curarlo
                GameObject bulletClone = Instantiate(cure, transform.position, Quaternion.identity);

                bulletClone.transform.forward = enemyPosition;

                chronometerCurander = 5f;
            }
        }
    }
}
