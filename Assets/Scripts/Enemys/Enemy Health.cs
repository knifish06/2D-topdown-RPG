using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int StartingHealth = 3;
    [SerializeField] private GameObject deathVFXPrefab;

    private int curentHealth;
    private KnockBack knockback;
    private Flash flash;


    private void Awake()
    {
        flash= GetComponent<Flash>();
        knockback= GetComponent<KnockBack>();
    }

    private void Start()
    {
        curentHealth = StartingHealth;
    }

    public void TakeDamage(int damage)
    {
        curentHealth -= damage;
        knockback.GetKnockedBack(PlayerController.Instance.transform , 15f );
        StartCoroutine(flash.FlashRoutine());
    }

    public void DetectDeath()
    {
        if (curentHealth <= 0)
        {
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }   
    }
}
