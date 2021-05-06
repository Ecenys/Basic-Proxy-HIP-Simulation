using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public enum SimulationType
    {
        /// <summary> Custom tracking hardware is used, so offsets are calculated during Start(). </summary>
        Optimal,
        /// <summary> SenseGlove Vive Tracker Mount </summary>
        SenseGlove
    }

    public Transform intention;

    //private void FixedUpdate()
    //{
    //    transform.position = Vector3.MoveTowards(transform.position, new Vector3(intention.position.x, intention.position.y, transform.position.z), Time.deltaTime * 10);
    //    transform.rotation = intention.rotation;
    //}
}
