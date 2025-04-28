using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    [SerializeField]
    int routine;

    [SerializeField]
    public float maxHealth;

    [SerializeField]
    public float currentHealth;

    [SerializeField]
    public float damage;

    [SerializeField]
    float chronometer;

    [SerializeField]
    Animator ani;

    [SerializeField]
    Quaternion angle;

    [SerializeField]
    float degree;

    [SerializeField]
    Transform target;

    [SerializeField]
    bool attacking;

    private void Start()
    {
        ani = GetComponent<Animator>();

        currentHealth = maxHealth;
    }

    public void Comportamiento_Enemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            ani.SetBool("run", false);

            chronometer += 1 * Time.deltaTime;

            if (chronometer >= 4)
            {

                routine = Random.Range(0, 2);
                chronometer = 0;
            }

            switch (routine)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;
                case 1:
                    degree = Random.Range(0, 360);

                    angle = Quaternion.Euler(0, degree, 0);

                    routine++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angle, 0.5f);

                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);

                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !attacking)
            {
                var lookpos = target.transform.position - transform.position;

                lookpos.y = 0;

                var rotation = Quaternion.LookRotation(lookpos);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);

                ani.SetBool("run", false);

                ani.SetBool("run", true);

                transform.Translate(Vector3.forward * 2 * Time.deltaTime);

                ani.SetBool("attack", false);
            }
            else
            {
                ani.SetBool("run", false);
                ani.SetBool("walk", false);

                ani.SetBool("attack", true);
                attacking = true;
            }
         
        }
    }

    public void Final_Ani()
    {
        Debug.Log("Evento");
        ani.SetBool("attack", false);
        attacking = false;
        attacking = false;

    }

    private void Update()
    {
        Comportamiento_Enemigo();
    }

    public void TakeDamageEnemy(float damage)
    {
        if (currentHealth <= 0f) return;
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }



}
