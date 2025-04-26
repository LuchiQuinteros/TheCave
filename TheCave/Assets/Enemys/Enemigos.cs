using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    [SerializeField]
    int rutina;

    [SerializeField]
    float cronometro;

    [SerializeField]
    Animator ani;

    [SerializeField]
    Quaternion angulo;

    [SerializeField]
    float grado;

    [SerializeField]
    Transform target;

    [SerializeField]
    bool atacando;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void Comportamiento_Enemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            ani.SetBool("run", false);

            cronometro += 1 * Time.deltaTime;

            if (cronometro >= 4)
            {

                rutina = Random.Range(0, 2);
                cronometro = 0;
            }

            switch (rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;
                case 1:
                    grado = Random.Range(0, 360);

                    angulo = Quaternion.Euler(0, grado, 0);

                    rutina++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);

                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);

                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !atacando)
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
                atacando = true;
            }
         
        }
    }

    public void Final_Ani()
    {
        Debug.Log("Evento");
        ani.SetBool("attack", false);
        atacando = false;
        atacando = false;

    }

    private void Update()
    {
        Comportamiento_Enemigo();
    }


    
}
