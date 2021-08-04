using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 40f;
    public Rigidbody2D rb;
    

    void Start()
    {

        rb.velocity = transform.right * speed;
        
    }



    

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name);

        /*
        RedBirdEnemy playerBullet = hitInfo.GetComponent<RedBirdEnemy>();
        if (playerBullet != null)
            playerBullet.Die();
        */

        
        Player killPlayer = hitInfo.GetComponent<Player>();
        if (killPlayer != null)
            killPlayer.Die();
        

        Destroy(gameObject);
    }

    
    






    // Update is called once per frame
    void Update()
    {
        
    }
}
