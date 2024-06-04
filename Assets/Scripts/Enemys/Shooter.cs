using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour, IEnemy
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletMoveSpeed;
    [SerializeField] private int burstCount;
    [SerializeField] private float timeBetweenBursts;
    [SerializeField] private float restTime = 2f;

    public void Attack()
    {
        Vector2 targetDerection = PlayerController.Instance.transform.position - transform.position;

        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        newBullet.transform.right= targetDerection;
    }
}
