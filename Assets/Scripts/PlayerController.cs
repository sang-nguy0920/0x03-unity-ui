using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    private int score = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if ( Input.GetKey("d") )
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0 , 0);
        }

        if ( Input.GetKey("a") )
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0 , 0);
        }

        if ( Input.GetKey("w") )
        {
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);
        }

        if ( Input.GetKey("s") )
        {
            rb.AddForce(0, 0, -forwardForce * Time.deltaTime);
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
    }
}
