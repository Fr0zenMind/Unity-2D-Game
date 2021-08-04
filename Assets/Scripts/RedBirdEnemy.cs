using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBirdEnemy : MonoBehaviour
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

    [SerializeField]
    Transform shootingRangePoint;

    bool right = true;
    bool ischanged = false;




    //bool isFacingLeft = false;

    

    //private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //target = player.GetComponent<Transform>();
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
        else if(ischanged == true && right == false)
        {
            transform.Rotate(0f, 180f, 0f);
            shootingRangePoint.transform.Rotate(0f, 180f, 0f);
            ischanged = false;
            right = false;
        }

        /*
        
            RaycastHit2D hit = Physics2D.Linecast(shootingRangePoint.position, Vector2.right * (agroRange), 1 << LayerMask.NameToLayer("Action"));
        

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
                ChasePlayer();
        }

        */





        //if (CanSeePlayer(agroRange))
        //{
        //agro enemy
        //ChasePlayer();
        //}


        float yDist = rb2d.transform.position.y - player.position.y;

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
    }

    /*
    bool CanSeePlayer(float distance)
    {
        bool val = false;
        var castDist = distance;

        if (isFacingLeft)
        {
            castDist = -distance;
        }


       Vector2 endPos = shootingRangePoint.position + Vector3.right * castDist;

        //Vector2 endPos = Quaternion.Euler(60, 0, 0) * Vector3.forward;
        //Vector2 endPos =Vector3.forward * castDist;

        //float endPos = Vector3.Distance(shootingRangePoint.position, player.position);
        RaycastHit2D hit = Physics2D.Linecast(shootingRangePoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));

        //RaycastHit2D hit = Physics2D.Linecast(shootingRangePoint.po)

        


        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                val = true;
            }
            else
            {
                val = false;
            }


            //Debug.DrawLine(rb2d.transform.position, endPos, Color.blue);
            Debug.DrawLine(shootingRangePoint.position, hit.point, Color.yellow);


        }
        else
        {
            Debug.DrawLine(shootingRangePoint.position, endPos, Color.red);
        }

        return val;
    }
    */



    public void Die()
    {
        GameObject.Find("Player").GetComponent<Player>().score += 1;
        if (GameObject.Find("Player").GetComponent<Weapon>().timeBetweenShooting > 0.1f)
            GameObject.Find("Player").GetComponent<Weapon>().timeBetweenShooting -= 0.003f;
        Destroy(gameObject);
    }

    //gameObject.SetActive(false);
    /*
    IEnumerator ChangeRotation()
    {
        while (!right)
        {
            yield return null;
        }
        //transform.Rotate(0f, 180f, 0f);
    }
    */

    /*
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name);
        
        Destroy(gameObject);
    }
    */





}