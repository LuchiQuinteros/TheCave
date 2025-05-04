using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : Entity
{
    [SerializeField] protected int _routine;
    [SerializeField] protected float _chronometer;
    [SerializeField] protected Quaternion angle;
    [SerializeField] protected float _degree;
    [SerializeField] public Transform target;
    [SerializeField] protected bool _attacking;
    [SerializeField] protected float _healing;
    [SerializeField] protected bool _detection;
    [SerializeField] protected bool _detectionAttack;
    [SerializeField] protected float _damageEnemy;
    //[SerializeField] Player damagePJ;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _currentHealth = _maxHealth;
    }

    /*
    public void Comportamiento_Enemigo()
    {
            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !_attacking)
            {
                var lookpos = target.transform.position - transform.position;

                lookpos.y = 0;

                var rotation = Quaternion.LookRotation(lookpos);

                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);

                _animator.SetBool("run", false);

                _animator.SetBool("run", true);

                transform.Translate(Vector3.forward * 2 * Time.deltaTime);

                _animator.SetBool("attack", false); 
            }
            else
            {
                _animator.SetBool("run", false);
                _animator.SetBool("walk", false);

                _animator.SetBool("attack", true);
                _attacking = true;
            }
    }
    */

    /*
    public void Final_Ani()
    {
        ani.SetBool("attack", false);
        attacking = false;
        attacking = false;

    }
    */

    private void Update()
    {
        //Comportamiento_Enemigo();
    }

    public void TakeDamageEnemy(float damage)
    {
        if (_currentHealth <= 0f) return;
        _currentHealth -= damage;

        if (_currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }

    /*
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("zombie"))
        {
            //TakeDamageEnemy(damagePJ.damagePJ);
        }
    }
    */

    void AttackingStart()
    {
        _animator.SetBool("AttackingEnemy", true);
    }

    void AttacingEnd()
    {
        _animator.SetBool("AttackingEnemy", false);
    }

    
    public void HealthEnemy(float curePoints)
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += curePoints;
        }

        if (_currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
    
}
