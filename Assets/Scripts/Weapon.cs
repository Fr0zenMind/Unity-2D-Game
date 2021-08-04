using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform firePoint;
    public GameObject bulletPrefab;

    public float timeWhenAllowedNextShoot = 0f;
    public float timeBetweenShooting = 5f;

    // Update is called once per frame
    void Update()
    {
     if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }   
    }

    private void Shoot()
    {
        // shooting logic
        //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        checkIfShouldShoot();
        
    }
    void checkIfShouldShoot()
    {
        if (timeWhenAllowedNextShoot <= Time.time)
        {

            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            timeWhenAllowedNextShoot = Time.time + timeBetweenShooting;


        }
    }

}
