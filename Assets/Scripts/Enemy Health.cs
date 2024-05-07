using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int StartingHealth = 3;

    private int curentHealth;

    private void Start()
    {
        curentHealth = StartingHealth;
    }

    public void TakeDamage(int damage)
    {
        curentHealth -= damage;
        Debug.Log(curentHealth);
        DetectDeath();
    }

    private void DetectDeath()
    {
        if (curentHealth <= 0)
        {
            Destroy(gameObject);
        }   
    }
}
