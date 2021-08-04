using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class Player : MonoBehaviour
{
    public GameObject dieMenuUI;
    public int lives;
    public int score;
    public Text liveText;
    public Text scoreText;
    public bool invincible = false;
    public CircleCollider2D circleColider1;
    public CircleCollider2D circleColider2;
    public CircleCollider2D circleColider3;
    private void Start()
    {
        Time.timeScale = 1f;
        score = 0;
        setDifficulty();
    }

    private void setDifficulty()
    {
        string dif = File.ReadAllText(Application.dataPath + "/difficulty.txt");

        if(dif == "easy")
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().runSpeed = 23;
            GameObject.Find("Player").GetComponent<PlayerMovement>().nextDashTime = 2f;
            GameObject.Find("Player").GetComponent<Player>().lives = 5;
            GameObject.Find("Player").GetComponent<Weapon>().timeBetweenShooting = 0.5f;
        }
        if (dif == "mediu")
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().runSpeed = 22;
            GameObject.Find("Player").GetComponent<PlayerMovement>().nextDashTime = 2.5f;
            GameObject.Find("Player").GetComponent<Player>().lives = 4;
            GameObject.Find("Player").GetComponent<Weapon>().timeBetweenShooting = 0.75f;
        }
        if (dif == "hard")
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().runSpeed = 20;
            GameObject.Find("Player").GetComponent<PlayerMovement>().nextDashTime = 3f;
            GameObject.Find("Player").GetComponent<Player>().lives = 3;
            GameObject.Find("Player").GetComponent<Weapon>().timeBetweenShooting = 1f;
        }
    }

    void Update()
    {
        liveText.text ="Lives " + lives;
        scoreText.text = "Score " + score;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        RedBirdEnemy enemy = collision.gameObject.GetComponent<RedBirdEnemy>();
        PurpleMonster purpleEnemy = collision.gameObject.GetComponent<PurpleMonster>();
        MonsterBoss bossMonster = collision.gameObject.GetComponent<MonsterBoss>();

        if (!invincible) { 
        if (enemy != null)
        {
                invincible = true;
                lives--;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 15;
            liveText.text = "Lives " + lives;
                GetComponent<SpriteRenderer>().color = Color.red;
                StartCoroutine("Invulnerable");


                if (lives <= 0)
            {
                gameObject.SetActive(false);
                enemy.gameObject.SetActive(false);
                liveText.text = "Lives " + lives;
                    Time.timeScale = 0f;
                    dieMenuUI.SetActive(true);
                }
            
        }

        if(purpleEnemy != null)
        {
                invincible = true;
                lives--;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 15;
            liveText.text = "Lives " + lives;
                GetComponent<SpriteRenderer>().color = Color.red;
                StartCoroutine("Invulnerable");
                if (lives <= 0)
            {
                gameObject.SetActive(false);
                purpleEnemy.gameObject.SetActive(false);
                liveText.text = "Lives " + lives;
                    Time.timeScale = 0f;
                    dieMenuUI.SetActive(true);
                }
                
        }
        if(bossMonster != null)
        {
                invincible = true;
                lives--;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 15;
            liveText.text = "Lives " + lives;
                StartCoroutine("Invulnerable");
                GetComponent<SpriteRenderer>().color = Color.red;
                if (lives <= 0)
            {
                gameObject.SetActive(false);
                bossMonster.gameObject.SetActive(false);
                liveText.text = "Lives " + lives;
                    Time.timeScale = 0f;
                    dieMenuUI.SetActive(true);
                }
                
        }
        }

        //Vector2 direction = GetComponent<Rigidbody2D>().position;
        //if (collision.contacts[0].normal.y > -1 && collision.contacts[0].normal.y > 1)
        //GetComponent<Rigidbody2D>().AddForce(direction * 500);
        //GetComponent<Rigidbody2D>().AddForce(GetComponent<Rigidbody2D>().position * 1000);

    }
    
    public void Die()
    {
        //GetComponent<Rigidbody2D>().velocity = Vector2.up * 50;

        if (!invincible)
        {
        lives--;
        liveText.text = "Lives " + lives;
        invincible = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 15;
            GetComponent<SpriteRenderer>().color = Color.red;
            StartCoroutine("Invulnerable");
        }



        if (lives <= 0)
        {
            gameObject.SetActive(false);
            Time.timeScale = 0f;
            dieMenuUI.SetActive(true);


            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
            //SceneManager.LoadScene("Menu");


        }
        
    }

    IEnumerator Invulnerable()
    {
        yield return new WaitForSeconds(3f);
        invincible = false;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    void resetInvulnerability()
    {

        invincible = false;
    }
    


}
