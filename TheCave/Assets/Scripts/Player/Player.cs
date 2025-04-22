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
    private float _crouchingSpeed, _standingSpeed;
    

    [SerializeField]
    bool _grounded;

    private PlayerMovement _playerMovement;

    private PlayerInputs _playerInputs;

    private PlayerView _playerView;

    [SerializeField]
    private CapsuleCollider _standingCollider;

    [SerializeField]
    private CapsuleCollider _crouchingCollider;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Manotazo"))
        {
            Debug.Log("Manotazo");
        }
    }

    private void Awake()
    {
        _playerMovement = new PlayerMovement(transform, _camTransform, _rb, _movementSpeed, _rotationSpeed, _jumpForce, _crouchingSpeed, _standingSpeed);

        _playerView = new PlayerView(_animator, _standingCollider, _crouchingCollider);

        _playerInputs = new PlayerInputs(_playerMovement, _playerView);
       
    }
    void Start()
    {
        GetRB();
        StartingHealth();
    }

    void Update()
    {

        _playerInputs.InputsUpdate(_grounded);
 
        Attacking();

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            TakeDamage(100f);
        }
    }

    private void FixedUpdate()
    {
       
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

    public void SetPlayer(Transform playerPosition)
    {
        playerPosition = transform;
    }
}
