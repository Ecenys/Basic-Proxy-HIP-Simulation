using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicBallController : MonoBehaviour
{
    #region enum
    public enum Follow
    {
        Intention,
        Proxy
    }
    #endregion

    #region Public Variables
    public Transform intentionGraphic;
    public float movementVelocity;
    [Space]
    public Follow originData;
    [Space]
    public Transform axisOrigin;
    public Transform orginProxy;
    [Space]
    public GameObject baseProxy;
    public GameObject fingerProxy;
    #endregion

    #region Private Variables

    #endregion

    private void FixedUpdate()
    {
        switch (originData) {
            case Follow.Intention:
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    new Vector3(intentionGraphic.position.x, intentionGraphic.position.y, transform.position.z),
                    Time.deltaTime * movementVelocity
                    );
                break;
            case Follow.Proxy:
                transform.position = axisOrigin.position
                    + new Vector3(fingerProxy.transform.position.x - baseProxy.transform.position.x, 0, 0)
                    + new Vector3(0, Vector2.Distance(baseProxy.transform.position, orginProxy.transform.position), 0);
                break;

        }
    }
}
