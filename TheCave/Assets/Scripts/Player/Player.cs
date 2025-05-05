using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{
    [SerializeField]
    private Transform _camTransform;

    [SerializeField]
    public int damagePJ;

    [SerializeField]
    private float _rotationSpeed;

    [SerializeField]
    private float _jumpForce;

    [SerializeField]
    private float _crouchingSpeed, _standingSpeed;

    [SerializeField]
    Enemy enemy;

    [SerializeField] Image life_Bar;


    Curandero quack;

    [SerializeField]
    bool _grounded;

    private PlayerMovement _playerMovement;

    private PlayerInputs _playerInputs;

    private PlayerView _playerView;

    [SerializeField]
    private CapsuleCollider _standingCollider;

    [SerializeField]
    private CapsuleCollider _crouchingCollider;


    //Aca el enemigo le saca salud al personaje
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("zombie"))
        {
            TakeDamage(/*enemy.damage*/5f);
        }

        if (coll.gameObject.CompareTag("zombie"))
        {
            enemy.TakeDamageEnemy(damagePJ);
        }

        if (coll.gameObject.CompareTag("curandero"))
        {
            quack.TakeDamageQuack(damagePJ);
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
        GetEssentials();
    }

    void Update()
    {

        _playerInputs.InputsUpdate(_grounded);
 
        Attacking();

        life_Bar.fillAmount = _currentHealth / _maxHealth;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //TakeDamage(100f);

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
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 3)
        {
            _grounded = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == 3)
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
