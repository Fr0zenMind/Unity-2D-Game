using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBoss : MonoBehaviour
{
    [SerializeField]
    Transform player;

    public int greenBirdHealth = 5;
    //[SerializeField]
    //Transform enemy;

    public Transform playerBullet;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    Transform shootingRangePoint;

    Rigidbody2D rb2d;

    Player[] _isPlayerAlive;

    bool right = true;
    bool ischanged = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        //print("distToPlayer" + distToPlayer);

        if (player.position.x < transform.position.x)
        {
            right = true;
            //isFacingLeft = true;
        }

        else
        {
            right = false;
            //isFacingLeft = false;
        }

        if (right == true && ischanged == false)
        {
            transform.Rotate(0f, 180f, 0f);
            shootingRangePoint.transform.Rotate(0f, 180f, 0f);
            right = false;
            ischanged = true;
        }
        else if (ischanged == true && right == false)
        {
            transform.Rotate(0f, 180f, 0f);
            shootingRangePoint.transform.Rotate(0f, 180f, 0f);
            ischanged = false;
            right = false;
        }






        float yDist = transform.position.y - player.position.y;

        if (yDist < 0)
            yDist *= -1;

        if (distToPlayer < agroRange && yDist < 3f)
        {
            //Code to chase player
            ChasePlayer();

        }
       

    }
    

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        transform.localScale = new Vector2(1.25f, 1.25f);




        /*

        if (transform.position.x < (player.position.x-1))
        {
            //enemy is the left side of the player, so move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(2.5f, 2.5f);


        }
        else if (transform.position.x > (player.position.x+1))
        {
            //enemy is the right side of the player, so move left
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-2.5f, 2.5f);

        }
        
        */




    }

    public void Die()
    {

        greenBirdHealth--;
        if(greenBirdHealth <= 0)
        {
            //gameObject.SetActive(false);
            Destroy(gameObject);
            GameObject.Find("Player").GetComponent<Player>().score += 3;
            if (GameObject.Find("Player").GetComponent<Weapon>().timeBetweenShooting > 0.1f)
            GameObject.Find("Player").GetComponent<Weapon>().timeBetweenShooting -= 0.006f;
        }
        
    }
}
