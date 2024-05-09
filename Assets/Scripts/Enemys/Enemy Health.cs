using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int StartingHealth = 3;
    [SerializeField] private GameObject deathVFXPrefab;
    [SerializeField] private float knockBackThrust = 15f;

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
        knockback.GetKnockedBack(PlayerController.Instance.transform , knockBackThrust);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathRoutine());
    }

    private IEnumerator CheckDetectDeathRoutine()
    {
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
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
