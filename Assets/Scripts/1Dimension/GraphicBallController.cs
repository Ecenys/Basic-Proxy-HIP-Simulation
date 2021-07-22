using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicBallController : MonoBehaviour
{
    public Transform intentionGraphic;
    public float movementVelocity;

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(
            transform.position, 
            new Vector3(intentionGraphic.position.x, intentionGraphic.position.y, transform.position.z), 
            Time.deltaTime * movementVelocity
        );
    }
}
