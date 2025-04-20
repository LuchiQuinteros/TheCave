using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField]
    private Transform _camTransform;

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private float _jumpForce;

    [SerializeField]
    private float _speedMultiplier;

    [SerializeField]
    bool _grounded;

    private PlayerMovement _playerMovement;

    private PlayerInputs _playerInputs;

    private PlayerView _playerView;

    [SerializeField]
    private CapsuleCollider _standingCollider;

    [SerializeField]
    private CapsuleCollider _crouchingCollider;

    private void Awake()
    {
        _playerMovement = new PlayerMovement(transform, _camTransform, _rb, _movementSpeed, _rotationSpeed, _jumpForce);

        _playerView = new PlayerView(_animator);

        _playerInputs = new PlayerInputs(_playerMovement, _playerView, _grounded);
        
    }
    void Start()
    {
        GetRB();
        StartingHealth();
    }

    void Update()
    {
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
        //if (_direction.sqrMagnitude != 0)
        //{
        //    _animator.SetBool("isRunning", true);


        //    //Movement(_direction);
        //}
        //else
        //{
        //    _animator.SetBool("isRunning", false);
        //}

        _playerInputs.InputsUpdate();
        
    }

    

    //void Jump()
    //{
    //    //Realizamos que el personaje pueda saltar.
    //    if (Input.GetKeyDown(KeyCode.Space) && _grounded)
    //    {
    //        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

    //        _animator.SetBool("isJumping", true);

    //    }
    //    else _animator.SetBool("isJumping", false);

    //}

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
        _playerInputs.input = false;
    }
}
