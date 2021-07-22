using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntentionGraphicController : MonoBehaviour
{
    #region Public Variables
    public Transform axisOrigin;
    public Transform orginProxy;
    [Space]
    public GameObject baseProxy;
    public GameObject fingerProxy;
    #endregion

    #region Private Variables

    #endregion

    // Update is called once per frame
    void Update()
    {
        transform.position = axisOrigin.position
            + new Vector3(fingerProxy.GetComponent<OD_FingerController>().relativeDistance, 0, 0)
            + new Vector3(0, Vector2.Distance(baseProxy.transform.position, orginProxy.transform.position), 0);
        
    }
}
