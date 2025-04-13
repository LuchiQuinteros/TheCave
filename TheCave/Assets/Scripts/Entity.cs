using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField]
    private float _maxHealth;
    [SerializeField]
    private float _currentHealth;

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

    public void TakeDamage(float damage)
    {
        if (_currentHealth <= 0) return;
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
