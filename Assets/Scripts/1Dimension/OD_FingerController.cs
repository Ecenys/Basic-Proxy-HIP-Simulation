using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OD_FingerController : MonoBehaviour
{
    public Transform relativeObject;
    [Space]
    public float minDistance;
    public float maxDistance;
    [Space]
    public float relativeDistance;
    [Space]
    public float movementVelocity = 1;

    private void FixedUpdate()
    {
        if (Input.GetKey("r"))
        {
            relativeDistance += 0.1f;
        }
        if (Input.GetKey("f"))
        {
            relativeDistance -= 0.1f;
        }

        if (relativeDistance < minDistance)
            relativeDistance = minDistance;
        if (relativeDistance > maxDistance)
            relativeDistance = maxDistance;

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(relativeDistance + relativeObject.position.x, relativeObject.position.y, 0), movementVelocity * Time.deltaTime);
    }
}
