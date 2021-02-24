using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HIPController : MonoBehaviour
{
    private Vector3 FTotal;
    private Vector3 FDamping;
    private Vector3 FUser;
    private Vector3 FRender;

    private Vector3 v;

    public GameObject intent;
    public GameObject physical;

    public float b;
    public float h;
    public float m;

    public float kUser;
    public float kRender;

    public float forcePorcentage;

    // Start is called before the first frame update
    void Start()
    {
        v = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (forcePorcentage < 0)
            forcePorcentage = 0;
        if (forcePorcentage > 100)
            forcePorcentage = 100;

        FDamping = -b * v;
        FUser = kUser * (intent.transform.position - transform.position);
        FRender = kRender * (physical.transform.position - transform.position);

        FTotal = FDamping + FUser + FRender;

        v = v + (h / m) * (FTotal * (forcePorcentage/100));
        transform.position = transform.position + h * v;

    }
}
