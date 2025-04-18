using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    //Transforms
    [SerializeField]
    Transform target;

    [SerializeField]
    Transform gun;

    //Estadisticas
    [SerializeField]
    int hp;

    [SerializeField]
    float rotSpeed;

    [SerializeField]
    float range;

    [SerializeField]
    float fieldOfView; //"Cono" de vision para disparar 

    [SerializeField]
    float fireRate;

    //Disparos

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    Transform bulletSpawn;

    Vector3 dir;

    float shootTimer;

    private void Update()
    {
        //Direccion hacia el jugador
        dir = target.transform.position - transform.position;

        //Calculamos si la distancia esta en el rango
        if(Vector3.Distance(target.position, transform.position) <= range)
        {
            Quaternion targetRot = Quaternion.LookRotation(dir, Vector3.up);
            
            gun.rotation = Quaternion.RotateTowards(gun.rotation, targetRot, rotSpeed * 360 * Time.deltaTime);
            shootTimer += Time.deltaTime;
            if (shootTimer >= fireRate)
            {
                shootTimer = 0;
                //Shoot();
            }
        }


    }
}
