using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseIntentionController : MonoBehaviour
{

    public enum ControllerType
    {
        Mouse,
        KeyBoard
    }

    public ControllerType controller;

    public float velocity;
    public float radialVelocity;


    //private void FixedUpdate()
    //{
    //    switch (controller)
    //    {
    //        case ControllerType.KeyBoard:
    //            //Movimiento
    //            if (Input.GetKey("w"))
    //            {
    //                transform.position += new Vector3(0, 0.01f * velocity, 0);
    //            }
    //            if (Input.GetKey("a"))
    //            {
    //                transform.position += new Vector3(-0.01f * velocity, 0, 0);
    //            }
    //            if (Input.GetKey("s"))
    //            {
    //                transform.position += new Vector3(0, -0.01f * velocity, 0);
    //            }
    //            if (Input.GetKey("d"))
    //            {
    //                transform.position += new Vector3(0.01f * velocity, 0, 0);
    //            }
    //            break;
    //        case ControllerType.Mouse:
    //            Vector3 worldPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
    //            transform.position = Vector3.MoveTowards(transform.position, worldPosition, Time.deltaTime * velocity);
    //            break;
    //    }
        

    //    //Rotacion
    //    if (Input.GetKey("q"))
    //    {
    //        transform.eulerAngles = transform.eulerAngles + 1f * new Vector3(0, 0, 1 * radialVelocity);
    //    }
    //    if (Input.GetKey("e"))
    //    {
    //        transform.eulerAngles = transform.eulerAngles - 1f * new Vector3(0, 0, 1 * radialVelocity);
    //    }
    //}

    public double[,] positionXY()
    {
        return new double[,] { { transform.position.x, transform.position.y } };
    }
}
