using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerController : MonoBehaviour
{

    public Transform intention;
    public Transform baseHand;

    [Space]
    public GameObject[] obstacles;

    [Space]
    public Transform relativeObject;


    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(intention.position.x, intention.position.y, intention.position.z), Time.deltaTime * 10);
        transform.rotation = intention.rotation;

    }
    
    public double relativePositionDistance()
    {
        return Vector2.Distance(relativeObject.transform.position, transform.position);
    }
}
