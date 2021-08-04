using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleMonster : MonoBehaviour
{
    [SerializeField]
    Transform player;

    //[SerializeField]
    //Transform enemy;

    public Transform playerBullet;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody2D rb2d;

    Player[] _isPlayerAlive;

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

        if (distToPlayer < agroRange)
        {
            //Code to chase player
            ChasePlayer();

        }
        else
        {
            //Stop chasing player
            StopChasingPlayer();
        }
    }

    void StopChasingPlayer()
    {
        rb2d.velocity = new Vector2(0, 0);

    }

    void ChasePlayer()
    {

        

            if (transform.position.x < (player.position.x-1))
        {
            //enemy is the left side of the player, so move right
            rb2d.velocity = new Vector2(moveSpeed, 0);
            transform.localScale = new Vector2(1f, 1f);


        }
        else if (transform.position.x > (player.position.x+1))
        {
            //enemy is the right side of the player, so move left
            rb2d.velocity = new Vector2(-moveSpeed, 0);
            transform.localScale = new Vector2(-1f, 1f);


        }
    }

    public void Die()
    {
        GameObject.Find("Player").GetComponent<Player>().score += 1;
        if (GameObject.Find("Player").GetComponent<Weapon>().timeBetweenShooting > 0.1f)
            GameObject.Find("Player").GetComponent<Weapon>().timeBetweenShooting -= 0.003f;

        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}
