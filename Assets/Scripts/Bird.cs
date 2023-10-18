using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bird : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float rotateScale;
    public int score;
    public TMP_Text scoreText;
    public GameObject endScreen;
    Rigidbody2D rb;
    public GameObject yellowBird;
    public GameObject blueBird;
    public GameObject redBird;
    public GameObject flash;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }

        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotateScale);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Pipe.speed = 4;
        Pipe.speed = speed;

        ChooseSkin();
        
    }

    void ChooseSkin()
    {
        var rnd = Random.Range(0f, 1f);
        if (rnd < 0.33f)
        {
            yellowBird.SetActive(true);
        }
        else if (rnd < 0.66)
        {
            redBird.SetActive(true);
        }
        else
        {
            blueBird.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Die();
    }

    void Die()
    {
        Pipe.speed = 0;
        jumpSpeed = 0;
        Invoke("ShowMenu", 1f); //po sekundes iskvies funckija showMenu

        //var currentScene = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(currentScene);
        PlayerPrefs.SetInt("score",score);
        flash.SetActive(true);
    }

   

    void ShowMenu()
    {
        endScreen.SetActive(true);
        scoreText.gameObject.SetActive(false); //or scoreText.enabled = false;
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        scoreText.text = score.ToString();
        
    }
    
}
