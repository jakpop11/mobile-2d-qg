using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float tapForce = 500f;
    Rigidbody2D playerRigidbody;

    //[SerializeField] Text scoreText;
    public static int Score = 0;

    [SerializeField] GameObject restartScreen;



    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        Score = 0;

        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //scoreText.text = Score.ToString();


        if (Input.GetMouseButtonDown(0))
        {
            playerRigidbody.AddForce(tapForce * Vector2.up);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            restartScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    // Called externally
    public void SetGameTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
