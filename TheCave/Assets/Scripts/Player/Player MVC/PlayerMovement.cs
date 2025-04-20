using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    private Transform _transform;

    private Transform _camTransform;

    private Rigidbody _rb;

    private float _speed;

    private float _rotationSpeed;

    private float _jumpForce;

    private Vector2 _direction;

    private Vector3 _camRel;

    public PlayerMovement(Transform pTransform, Transform camTransform , Rigidbody rb ,float pSpeed, float pRotSpeed, float jForce)
    {
        _transform = pTransform;

        _camTransform = camTransform;

        _rb = rb;

        _speed = pSpeed;

        _rotationSpeed = pRotSpeed;

        _jumpForce = jForce; 
    }

    public void Movement(Vector2 dir)
    {
        //Iguala los ejes del personaje a los de la c�mara.
        Vector3 fwd = _camTransform.forward;

        Vector3 rht = _camTransform.right;

        fwd.y = 0;

        rht.y = 0;

        //fwd = fwd.normalized;

        //rht = fwd.normalized;

        Vector3 fwdRel = dir.y * fwd.normalized;

        Vector3 rhtRel = dir.x * rht.normalized;

        _camRel = fwdRel + rhtRel;


        _rb.MovePosition(_transform.position + _camRel.normalized * _speed * Time.fixedDeltaTime);

        //Establece la rotaci�n del personaje siempre hacia donde se est� moviendo, pero relativo a la c�mara.
        Quaternion rotateTo = Quaternion.LookRotation(_camRel, Vector3.up);

        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, rotateTo, _rotationSpeed * Time.fixedDeltaTime);
    }

    public void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }
}
