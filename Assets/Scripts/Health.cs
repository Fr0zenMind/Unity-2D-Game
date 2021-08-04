using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player findPlayer = collision.gameObject.GetComponent<Player>();

        if(findPlayer != null)
        {
            GameObject.Find("Player").GetComponent<Player>().lives += 1;

            Destroy(gameObject);
        }
    }

}
