using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float timeWhenAllowedNextShoot = 0f;
    public float timeBetweenShooting = 5f;
    [SerializeField]
    Transform player;
    [SerializeField]
    Transform enemy;
    [SerializeField]
    float agroRange;
    void Start()
    {
        Shoot();
        
    }
    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(enemy.position, player.position);
        if (distToPlayer<agroRange)
        checkIfShouldShoot();
    }
    void checkIfShouldShoot()
    {
        if (timeWhenAllowedNextShoot <= Time.time)
        {

            if (enemy.position.x < player.position.x)
                Shoot();
            else
            {
                firePoint.transform.Rotate(0f, 180f, 0f);
                Shoot();
                firePoint.transform.Rotate(0f, 180f, 0f);
            }
            timeWhenAllowedNextShoot = Time.time + timeBetweenShooting;


                //Shoot();
                //timeWhenAllowedNextShoot = Time.time + timeBetweenShooting;
            
        }
    }

    void Shoot()
    {
        //Code that does your shooting here
        //var lastPosition = transform.position;
        //var direction = transform.position - lastPosition;
        //var localDirection = transform.InverseTransformDirection(direction);

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        

        /*

        if (enemy.position.x < player.position.x)
        {
            //enemy is the left side of the player, so move right
            //rb2d.velocity = new Vector2(moveSpeed, 0);
            //transform.localScale = new Vector2(0.7f, 0.7f);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        }
        else if (enemy.position.x > player.position.x)
        {
            //enemy is the right side of the player, so move left
            //rb2d.velocity = new Vector2(-moveSpeed, 0);
            //transform.localScale = new Vector2(-0.7f, 0.7f);
            firePoint.transform.Rotate(0f, 180f, 0f);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            firePoint.transform.Rotate(0f, 180f, 0f);

        }
        
        */

        /*

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        firePoint.position = new Vector3(firePoint.position.x - 1.5f, firePoint.position.y, 0);

        firePoint.transform.Rotate(0f, 180f, 0f);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        firePoint.position = new Vector3(firePoint.position.x + 1.5f, firePoint.position.y, 0);
        firePoint.transform.Rotate(0f, 180f, 0f);

        */

        /*

        firePoint.transform.Rotate(0f, 0f, 90f);

        firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y + 1, 0);  
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);       
        firePoint.position = new Vector3(firePoint.position.x + 1, firePoint.position.y, 0);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y - 1, 0);

        firePoint.transform.Rotate(0f, 0f, 180f);

        firePoint.position = new Vector3(firePoint.position.x, firePoint.position.y - 1, 0);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        firePoint.position = new Vector3(firePoint.position.x - 1, firePoint.position.y, 0);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        firePoint.position = new Vector3(firePoint.position.x + 1, firePoint.position.y + 1, 0);

        firePoint.transform.Rotate(0f, 0f, 90f);
        */

        /*

        firePoint.transform.Rotate(0f, 0f, 45f);
        
        firePoint.position = new Vector3(firePoint.position.x + 1, firePoint.position.y + 1, 0);
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        firePoint.position = new Vector3(firePoint.position.x - 1, firePoint.position.y - 1, 0);

        firePoint.transform.Rotate(0f, 0f, 315f);

        */

        //Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);


    }
    


}
