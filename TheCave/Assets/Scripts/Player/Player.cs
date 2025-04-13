using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField]
    private Transform _camTransform;

    [SerializeField]
    float _rotationSpeed;

    [SerializeField]
    float _jumpForce;

    [SerializeField]
    float _speedMultiplier;

    [SerializeField]
    bool _grounded;

    private PlayerMovement _playerMovement;

    [SerializeField]
    private CapsuleCollider _standingCollider;

    [SerializeField]
    private CapsuleCollider _crouchingCollider;


    //Vector de dirección
    //private Vector3 _direction;
    Vector2 _direction;

    //Vector indicador de posición de la cámara
    private Vector3 _camRel;


    private void Awake()
    {
        _playerMovement = new PlayerMovement();
    }
    void Start()
    {
        GetRB();
        StartingHealth();
    }

    void Update()
    {
        float h = (Input.GetAxisRaw("Horizontal")); 

        float v = (Input.GetAxisRaw("Vertical"));

        _direction = new Vector2(h, v);

        Jump();

        Ducking();

        Attacking();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            TakeDamage(100f);
        }
    }

    private void FixedUpdate()
    {
        //Si el jugador se mueve, el modelo siempre apuntará en la dirección que se está moviendo.
        if (_direction.sqrMagnitude != 0)
        {
            _animator.SetBool("isRunning", true);

            Movement(_direction);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }


    }

    void Movement(Vector2 dir)
    {
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


        _rb.MovePosition(transform.position + _camRel.normalized * _movementSpeed * Time.fixedDeltaTime);

        //Establece la rotación del personaje siempre hacia donde se esté moviendo, pero relativo a la cámara.
        Quaternion rotateTo = Quaternion.LookRotation(_camRel, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotateTo, _rotationSpeed * Time.fixedDeltaTime);
    }

    void Jump()
    {
        //Realizamos que el personaje pueda saltar.
        if (Input.GetKeyDown(KeyCode.Space) && _grounded)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

            _animator.SetBool("isJumping", true);

        }
        else _animator.SetBool("isJumping", false);

    }

    void Ducking()
    {
        //El personaje con esta condicion tiene la opcion de poder ir agachado en el juego como si estuviera en sigilo

        //if (Input.GetKeyDown(KeyCode.LeftControl)) _movementSpeed /= _speedMultiplier;

        //else if (Input.GetKeyUp(KeyCode.LeftControl)) _movementSpeed *= _speedMultiplier;

        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            _movementSpeed /= _speedMultiplier;

            _animator.SetBool("isDucking", true);

            _crouchingCollider.enabled = true;
            _standingCollider.enabled = false;
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            _animator.SetBool("isDucking", false);

            _movementSpeed *= _speedMultiplier;

            _crouchingCollider.enabled = false;
            _standingCollider.enabled = true;
        }
        
    }

    void Attacking()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetBool("isAttacking", true);
        }
    }

    //Evitamos que el jugador siga saltando en el aire y no este volando.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            _grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            _grounded = false;
        }
    }

    protected override void Death()
    {
        //base.Death();
        Debug.Log("El player murió");
    }
}
