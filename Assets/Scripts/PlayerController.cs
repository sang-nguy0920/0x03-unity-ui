using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;
    public float movement = 2000f;

    private int score = 0;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    public Text winLosetext;
    public Image winLoseBg;

    // Update is called once per frame
    void FixedUpdate()
    {
        if ( Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(movement * Time.deltaTime, 0 , 0);
        }

        if ( Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow) )
        {
            rb.AddForce(-movement * Time.deltaTime, 0 , 0);
        }

        if ( Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow) )
        {
            rb.AddForce(0, 0, movement * Time.deltaTime);
        }

        if ( Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow) )
        {
            rb.AddForce(0, 0, -movement * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            score += 1;
            // Debug.Log("Score: " + score );
            SetScoreText();
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Trap")
        {
            health -= 1;
            // Debug.Log("Health: " + health );
            SetHealthText();

        }

        if (other.gameObject.tag == "Goal")
        {
            winLosetext.text = "You win!";
            winLosetext.color = Color.black;
            winLoseBg.color = Color.green;
            winLoseBg.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
            // Debug.Log("You win!");
        }
    }

    void Update()
    {
        if (health == 0)
        {
            winLosetext.text = "Game Over!";
            winLosetext.color = Color.white;
            winLoseBg.color = Color.red;
            winLoseBg.gameObject.SetActive(true);
            StartCoroutine(LoadScene(3));
            // Debug.Log("Game Over!");
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        score = 0;
        health = 5;
    }
}
