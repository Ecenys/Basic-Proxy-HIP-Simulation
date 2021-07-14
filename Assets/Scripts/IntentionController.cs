using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntentionController : MonoBehaviour
{
    public float velocity = 1;
    public float wVelocity = 1;
    [Space]
    public float minDistance;
    public float maxDistance;
    [Space]
    public float rotation;
    [Space]
    public Transform relativeObject;

    [Space]
    public float rotationRadians;
    public float relativeDistance;

    // Update is called once per frame
    void FixedUpdate()
    {
        rotationRadians = ConvertToRadians(rotation);

        if (Input.GetKey("r"))
        {
            relativeDistance += 0.1f * velocity;
        }
        if (Input.GetKey("f"))
        {
            relativeDistance -= 0.1f * velocity;
        }
        if (Input.GetKey("q"))
        {
            rotationRadians += 0.1f * wVelocity;
        }
        if (Input.GetKey("e"))
        {
            rotationRadians -= 0.1f * wVelocity;
        }

        if (relativeDistance < minDistance)
            relativeDistance = minDistance;
        if (relativeDistance > maxDistance)
            relativeDistance = maxDistance;

        transform.localPosition = relativeObject.position + new Vector3(relativeDistance * Mathf.Cos(rotationRadians), relativeDistance * Mathf.Sin(rotationRadians), 0);


        rotation = ConvertToDegrees(rotationRadians);
    }

    public double relativePositionDistance()
    {
        return Vector2.Distance(relativeObject.position, transform.position);
    }

    private float ConvertToRadians(float angle)
    {
        return (Mathf.PI / 180) * angle;
    }

    private float ConvertToDegrees(float radians)
    {
        return (180 / Mathf.PI) * radians;
    }
}