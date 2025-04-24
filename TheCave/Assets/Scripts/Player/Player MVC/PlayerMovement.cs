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

    private float _crouchingSpeed, _standingSpeed;

    private Vector2 _direction;

    private Vector3 _camRel;

    public PlayerMovement(Transform pTransform, Transform camTransform , Rigidbody rb ,float pSpeed, float pRotSpeed, float jForce, float crouchingSpeed, float standingSpeed)
    {
        _transform = pTransform;

        _camTransform = camTransform;

        _rb = rb;

        _speed = pSpeed;

        _crouchingSpeed = crouchingSpeed;

        _standingSpeed = standingSpeed;

        _rotationSpeed = pRotSpeed;

        _jumpForce = jForce; 
    }

    //public void GetDir(Vector2 dir)
    //{
    //    _direction = dir;
    //}
    public void Movement(Vector2 dir)
    {
        //if(_direction.sqrMagnitude == 0)
        //{
        //    return;
        //}
        //else
        //{
            //Iguala los ejes del personaje a los de la cámara.
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


            //Establece la rotación del personaje siempre hacia donde se esté moviendo, pero relativo a la cámara.
            Quaternion rotateTo = Quaternion.LookRotation(_camRel, Vector3.up);

            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, rotateTo, _rotationSpeed * Time.fixedDeltaTime);
        
       
    }

    public void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    public void Duck()
    {
        _speed = _crouchingSpeed;
    }

    public void Standing()
    {
        _speed = _standingSpeed;
    }
}
