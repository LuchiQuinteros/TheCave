using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField]
    protected float _maxHealth;

    [SerializeField]
    protected float _currentHealth;

    [SerializeField]
    protected float _movementSpeed;

    [SerializeField]
    protected Rigidbody _rb;

    [SerializeField]
    protected Animator _animator;


    protected void GetRB()
    {
        _rb = GetComponent<Rigidbody>();
    }

    protected void StartingHealth()
    {
        _currentHealth = _maxHealth;
    }

    virtual protected void TakeDamage(float damage)
    {
        if (_currentHealth <= 0f) return;
        _currentHealth -= damage;

        if (_currentHealth <= 0f)
        {
            Death();
        }
    }

    protected virtual void Death()
    {
        Debug.Log("Muerte");
    }
}
