using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    [SerializeField] private float Health;
    public float currentHealth;


    [Header("Bullet Settings")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootForce;
    [SerializeField] private GameObject muzzle;
    [SerializeField] private float cooldown = 5;

    private float cooldownTimer;


    private void Start()
    {
        currentHealth = Health;
    }


    public void TakeDamage(float _damage)
    {
        currentHealth -= _damage;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }

    public void ShootAtPlayer()
    {
        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer > 0) return;

        cooldownTimer = cooldown;

        GameObject tempBullet = Instantiate(bulletPrefab, this.muzzle.gameObject.transform.position, Quaternion.identity) as GameObject; //shoots from enemies eyes
        Rigidbody tempRigidBodyBullet = tempBullet.GetComponent<Rigidbody>();
        tempRigidBodyBullet.velocity = this.muzzle.transform.forward * shootForce;
        Destroy(tempBullet, 1f);
    }
}
