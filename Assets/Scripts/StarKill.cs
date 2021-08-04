using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarKill : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Player killPlayer = collision.gameObject.GetComponent<Player>();
        if (killPlayer != null)
            killPlayer.Die();
    }
}
