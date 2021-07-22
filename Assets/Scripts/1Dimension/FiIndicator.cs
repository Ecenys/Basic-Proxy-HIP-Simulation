using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiIndicator : MonoBehaviour
{
    #region Public Variables
    public GameObject proxyFinger;
    #endregion

    #region Private Variables
    private Transform relativeObject;
    private float relativeDistance;
    #endregion

    private void Start()
    {
        relativeObject = proxyFinger.GetComponent<OD_FingerController>().relativeObject;
    }

    private void FixedUpdate()
    {
        relativeDistance = proxyFinger.GetComponent<OD_FingerController>().relativeDistance;
        transform.position = new Vector3(relativeObject.position.x + relativeDistance, transform.position.y, transform.position.z);
    }
}
