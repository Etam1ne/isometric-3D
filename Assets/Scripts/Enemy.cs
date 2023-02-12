using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject _enemy;

    public float _maxHealth = 50;
    public float _currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(float AttackDamage)
    {
        _currentHealth -= AttackDamage;

        if (_currentHealth <= 0)
        {
            _enemy.SetActive(false);
        }
    }
}
