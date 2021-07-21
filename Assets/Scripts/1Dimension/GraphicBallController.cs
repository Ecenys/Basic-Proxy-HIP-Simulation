using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicBallController : MonoBehaviour
{
    public Transform axisOrigin;
    public Transform orginProxy;
    public GameObject baseProxy;
    public GameObject fingerProxy;

    private void FixedUpdate()
    {
        transform.position = axisOrigin.position 
            + new Vector3(fingerProxy.transform.position.x - baseProxy.transform.position.x, 0, 0) 
            + new Vector3(0, Vector2.Distance(baseProxy.transform.position, orginProxy.transform.position), 0);
    }
}
