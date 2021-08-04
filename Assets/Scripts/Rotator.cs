using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationPerSecond = 45f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationPerSecond * Time.deltaTime , 0, 0);
    }
}
