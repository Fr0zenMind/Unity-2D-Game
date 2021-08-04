using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 40f;
    public Rigidbody2D rb;
    

    void Start()
    {

        rb.velocity = transform.right * speed;

        //GameObject.Find("Player").GetComponent<Weapon>().timeBetweenShooting;



    }



    

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Debug.Log(hitInfo.name);
        
        
        RedBirdEnemy killEnemy = hitInfo.GetComponent<RedBirdEnemy>();
        if (killEnemy != null)
        {
            killEnemy.Die();
            //GameObject.Find("Player").GetComponent<Weapon>().timeBetweenShooting -= 0.01f;
        }
            

        PurpleMonster killEnemyPurpleMonster = hitInfo.GetComponent<PurpleMonster>();
        if (killEnemyPurpleMonster != null)
        {
            killEnemyPurpleMonster.Die();
            //GameObject.Find("Player").GetComponent<Weapon>().timeBetweenShooting -= 0.01f;
        }
            

        MonsterBoss killBossMonster = hitInfo.GetComponent<MonsterBoss>();
        if (killBossMonster != null)
            killBossMonster.Die();


        /*
        Player enemyBullet = hitInfo.GetComponent<Player>();
        if (enemyBullet != null)
            enemyBullet.Die();
        */

        Destroy(gameObject);
    }

    
    






    // Update is called once per frame
    void Update()
    {
        
    }
}
