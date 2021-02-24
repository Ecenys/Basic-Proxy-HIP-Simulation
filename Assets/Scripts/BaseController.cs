using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{

    public float velocity;
    public float radialVelocity;


    private void FixedUpdate()
    {
        //Movimiento
        if (Input.GetKey("w"))
        {
            transform.position += new Vector3(0, 0.01f * velocity, 0);
        }
        if (Input.GetKey("a"))
        {
            transform.position += new Vector3(-0.01f * velocity, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            transform.position += new Vector3(0, -0.01f * velocity, 0);
        }
        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(0.01f * velocity, 0, 0);
        }

        //Rotacion
        if (Input.GetKey("q"))
        {
            transform.eulerAngles = transform.eulerAngles + 1f * new Vector3(0, 0, 1 * radialVelocity);
        }
        if (Input.GetKey("e"))
        {
            transform.eulerAngles = transform.eulerAngles - 1f * new Vector3(0, 0, 1 * radialVelocity);
        }
    }
}
