using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Finish : MonoBehaviour
{
    public GameObject FinishMenuUI;

    //public TextAsset scoreText;
    //public TextMesh scoreText;
    //public Text scoreText;
    public TextMeshProUGUI scoreText;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Player findPlayer = collision.gameObject.GetComponent<Player>();

        if (findPlayer != null)
        {
            Time.timeScale = 0f;
            scoreText.text = "Score " + (GameObject.Find("Player").GetComponent<Player>().score + (GameObject.Find("Player").GetComponent<Player>().lives *10));
            FinishMenuUI.SetActive(true);
        }
    }
}
