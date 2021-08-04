using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBirdShooting : MonoBehaviour
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


    // Start is called before the first frame update
    void Start()
    {
        if (timeWhenStart == Time.time)
            Shoot();

    }
    // Update is called once per frame
    void Update()
    {
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

        firePoint.transform.Rotate(0f, 0f, 90f);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y-1);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y+1);

        firePoint.position = new Vector3(firePoint.position.x+2, firePoint.position.y + 2);
        firePoint.transform.Rotate(0f, 0f, 315f);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        firePoint.transform.Rotate(0f, 0f, 45f);
        firePoint.position = new Vector3(firePoint.position.x-2, firePoint.position.y - 2);


        firePoint.position = new Vector3(firePoint.position.x -1, firePoint.position.y - 1);
        firePoint.transform.Rotate(0f, 0f, 180f);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        firePoint.transform.Rotate(0f, 0f, 180f);
        firePoint.position = new Vector3(firePoint.position.x + 1, firePoint.position.y + 1);

        firePoint.transform.Rotate(0f, 0f, 270f);
        


        //firePoint.position = new Vector3(firePoint.position.x - 3f, firePoint.position.y);





        /*
        if (enemy.position.x < player.position.x)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            

            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y + 0.5f, 0f);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y - 0.5f, 0f);

            

            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y + 1f, 0f);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y - 1f, 0f);
        }
        else if (enemy.position.x > player.position.x)
        {
            firePoint.transform.Rotate(0f, 180f, 0f);

            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            

            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y + 0.5f, 0f);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y - 0.5f, 0f);

            

            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y + 1f, 0f);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y - 1f, 0f);

            firePoint.transform.Rotate(0f, 180f, 0f);
        

        }
        */
    }
}
