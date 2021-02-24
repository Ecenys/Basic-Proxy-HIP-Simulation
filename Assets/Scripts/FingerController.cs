using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerController : MonoBehaviour
{
    public enum SimulationType
    {
        /// <summary> Custom tracking hardware is used, so offsets are calculated during Start(). </summary>
        Optimal,
        /// <summary> SenseGlove Vive Tracker Mount </summary>
        SenseGlove
    }

    public Transform intention;
    public Transform baseHand;

    public SimulationType simulationType = SimulationType.Optimal;

    private bool blocked = false;
    public GameObject[] obstacles;

    private void Start()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

    }

    private void Update()
    {
        if(simulationType == SimulationType.Optimal)
        {
            obstacles[0].GetComponent<BoxCollider>().isTrigger = false;
        }
        else
        {
            obstacles[0].GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    private void FixedUpdate()
    {
        if (simulationType == SimulationType.SenseGlove)
        {
            if(!blocked || Vector2.Distance(transform.position, baseHand.position) < Vector2.Distance(intention.position, baseHand.position))
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(intention.position.x, intention.position.y, 0), Time.deltaTime * 10);
                //transform.position = new Vector3(intention.position.x, intention.position.y, 0);
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(intention.position.x, intention.position.y, 0), Time.deltaTime * 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
            blocked = true;

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
            blocked = false;
    }
}
