using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntentionController : MonoBehaviour
{
    public float velocity = 1;

    public float minDistance;
    public float maxDistance;

    public Transform relativeObject;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("f"))
        {
            transform.localPosition += new Vector3(-0.01f * velocity, 0, 0);
        }
        if (Input.GetKey("r"))
        {
            transform.localPosition += new Vector3(0.01f * velocity, 0, 0);
        }

        if (transform.localPosition.x < minDistance)
            transform.localPosition = new Vector3(minDistance, 0, 0);
        if(transform.localPosition.x > maxDistance)
            transform.localPosition = new Vector3(maxDistance, 0, 0);
    }

    public double relativePositionDistance()
    {
        return Vector3.Distance(relativeObject.position, transform.position);
    }
}