using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;
    public float movement = 2000f;

    private int score = 0;
    public int health = 5;

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
            Debug.Log("Score: " + score );
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Trap")
        {
            health -= 1;
            Debug.Log("Health: " + health );
        }

        if (other.gameObject.tag == "Goal")
        {
            Debug.Log("You win!");
        }
    }

    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
