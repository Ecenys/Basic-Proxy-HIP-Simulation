using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OD_BaseController : MonoBehaviour
{
    public float movementVelocity;
    public Transform origin;
    
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if (Input.GetKey("a"))
        {
            transform.position += new Vector3(-0.01f * movementVelocity, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            transform.position += new Vector3(0.01f * movementVelocity, 0, 0);
        }

        if (transform.position.x < origin.position.x)
            transform.position = new Vector3(origin.position.x, transform.position.y, transform.position.z);
    }
}
