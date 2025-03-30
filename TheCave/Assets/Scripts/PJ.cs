using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJ : MonoBehaviour
{
    [SerializeField]
    float maximaVelocidad;

    [SerializeField]
    float fuerzaSalto;

    [SerializeField]
    float modificadorVelocidad;

    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoviendoPj(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    void MoviendoPj(float horizontal, float vertical)
    {
        //Hacemos que el personaje pueda moverse, de manera horizontal como vertical
        Vector3 direccion = new Vector3(horizontal, 0, vertical).normalized;

        rb.MovePosition(transform.position + direccion * maximaVelocidad * Time.deltaTime);

        //El personaje con esta condicion tiene la opcion de poder ir agachado en el juego como si estuviera en sigilo

        if (Input.GetKeyDown(KeyCode.LeftControl)) maximaVelocidad /= modificadorVelocidad;

        else if (Input.GetKeyUp(KeyCode.LeftControl)) maximaVelocidad *= modificadorVelocidad;
    }

    void Jump()
    {
        //Realizamos que el personaje pueda saltar.
        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
    }
}
