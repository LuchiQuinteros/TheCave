using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : Entity
{
    [SerializeField] protected int _routine;
    [SerializeField] protected float _chronometer;
    [SerializeField] protected Quaternion angle;
    [SerializeField] protected float _degree;
    [SerializeField] protected bool _attacking;
    [SerializeField] protected float _healing;
    //[SerializeField] protected bool _detection;
    //[SerializeField] protected bool _detectionAttack;
    [SerializeField] protected float _damageEnemy;
    //[SerializeField] Player damagePJ;

    private Patrol _patrol;
    private Chase _chase;
    private Attack _attack;

    [SerializeField] private float _chaseDistance;
    [SerializeField] private float _attackDistance;
    [SerializeField] private float _wpChangeDistance;
    [SerializeField] private Transform _target;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private Transform _currentWp;
    [SerializeField] private NavMeshAgent _navAgent;

    private void Start()
    {
        _patrol = new Patrol(_animator, _waypoints);
        GetEssentials();
        _navAgent = GetComponent<NavMeshAgent>(); 
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
        if (_navAgent.destination != _currentWp.position) _navAgent.SetDestination(_currentWp.position);

        if(Vector3.SqrMagnitude(transform.position - _currentWp.position) <= _wpChangeDistance * _wpChangeDistance)
        {
            Debug.Log("Cambio de WP");
            _currentWp = _patrol.NextWP();
            _patrol.PatrolUpdate();
        }
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


