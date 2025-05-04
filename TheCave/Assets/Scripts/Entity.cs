using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour, IDamageable
{
    [SerializeField] protected float _maxHealth;
    [SerializeField] protected float _currentHealth;
    [SerializeField] protected float _movementSpeed;
    [SerializeField] protected Rigidbody _rb;
    [SerializeField] protected Animator _animator;
    [SerializeField] protected float _damage;
    protected void GetRB()
    {
        _rb = GetComponent<Rigidbody>();
    }

    protected void StartingHealth()
    {
        _currentHealth = _maxHealth;

    }

    //Si el objeto el cual se queda sin vida llamamos a este metodo para indicar que murio
    protected virtual void Death()
    {
        Debug.Log("Muerte");
    }

    //Si el objeto el cual le inflijen algun tipo de dano se llama a este metodo para lograr dicha funcion
    public void TakeDamage(float damage)
    {
        if (_currentHealth <= 0f) return;
        _currentHealth -= damage;

        if (_currentHealth <= 0f)
        {
            Death();
        }
    }
}
