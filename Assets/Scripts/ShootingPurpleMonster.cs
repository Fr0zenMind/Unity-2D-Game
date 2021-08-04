using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPurpleMonster : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float timeWhenAllowedNextShoot = 0f;
    public float timeBetweenShooting = 5f;
    public float timeWhenStart = 3f;
    [SerializeField]
    Transform player;
    [SerializeField]
    Transform enemy;
    [SerializeField]
    float agroRange;

    // Start is called before the first frame update
    void Start()
    {
        if (timeWhenStart == Time.time)
        Shoot();

    }
    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(enemy.position, player.position);
        if (distToPlayer < agroRange)
            checkIfShouldShoot();
    }

    

    void checkIfShouldShoot()
    {
        if (timeWhenAllowedNextShoot <= Time.time)
        {
            Shoot();
            timeWhenAllowedNextShoot = Time.time + timeBetweenShooting;
        }
    }

    void Shoot()
    {
        if (enemy.position.x < player.position.x)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y + 0.25f, 0f);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y - 0.25f, 0f);

            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y + 0.5f, 0f);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y - 0.5f, 0f);

            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y + 0.75f, 0f);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y - 0.75f, 0f);

            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y + 1f, 0f);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y - 1f, 0f);
        }
        else if (enemy.position.x > player.position.x)
        {
            firePoint.transform.Rotate(0f, 180f, 0f);

            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y + 0.25f, 0f);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y - 0.25f, 0f);

            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y + 0.5f, 0f);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y - 0.5f, 0f);

            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y + 0.75f, 0f);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y - 0.75f, 0f);

            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y + 1f, 0f);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y - 1f, 0f);

            firePoint.transform.Rotate(0f, 180f, 0f);

        }
    }
}
