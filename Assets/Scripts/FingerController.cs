using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerController : MonoBehaviour
{

    public Transform intention;
    public Transform baseHand;

    private bool blocked = false;
    public GameObject[] obstacles;

    private void Start()
    {
        //obstacles = GameObject.FindGameObjectsWithTag("Obstacle");

    }
}
