using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerController : MonoBehaviour
{
    public enum SimulationType
    {
        Optimal,
        SenseGlove
    }

    public Transform intention;
    public Transform baseHand;

    public SimulationType simulationType = SimulationType.Optimal;

    private bool blocked = false;
    public GameObject[] obstacles;

    private void Start()
    {
        //obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

    }

    //private void Update()
    //{
    //    if(simulationType == SimulationType.Optimal)
    //    {
    //        GetComponent<SphereCollider>().isTrigger = false;
    //        //obstacles[0].GetComponent<BoxCollider>().isTrigger = false;
    //    }
    //    else
    //    {
    //        GetComponent<SphereCollider>().isTrigger = true;
    //        //obstacles[0].GetComponent<BoxCollider>().isTrigger = true;
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    if (simulationType == SimulationType.SenseGlove)
    //    {
    //        if(!blocked || Vector2.Distance(transform.position, baseHand.position) < Vector2.Distance(intention.position, baseHand.position))
    //            transform.position = Vector3.MoveTowards(transform.position, new Vector3(intention.position.x, intention.position.y, transform.position.z), Time.deltaTime * 10);
    //            //transform.position = new Vector3(intention.position.x, intention.position.y, 0);
    //    }
    //    else
    //        transform.position = Vector3.MoveTowards(transform.position, new Vector3(intention.position.x, intention.position.y, transform.position.z), Time.deltaTime * 10);
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Obstacle")
    //        blocked = true;

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Obstacle")
    //        blocked = false;
    //}
}
