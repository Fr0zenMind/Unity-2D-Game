using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenBirdBullet : MonoBehaviour
{
    public float speed = 40f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {



        Player killPlayer = hitInfo.GetComponent<Player>();
        if (killPlayer != null)
            killPlayer.Die();


        Destroy(gameObject);
    }
}
