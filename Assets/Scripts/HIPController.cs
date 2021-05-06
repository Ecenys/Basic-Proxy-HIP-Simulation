using Unity.Jobs;
using Unity.Collections;
using UnityEngine;

public class HIPController : MonoBehaviour
{
    public enum FVersion
    {
        Version1,
        Version2
    }
    public enum Part
    {
        Hand,
        Finger
    }

    #region InspectorVariables
    public GameObject intent;
    public GameObject physical;
    public FVersion calculationVersion;
    public Part part;

    public float b;
    public float h;
    public float m;

    public float kUser;
    public float kRender;
    
    [Space]
    
    [Range(0, 100)]
    public float forcePorcentage;
    #endregion

    #region PrivateValues
    [ReadOnly]
    public Vector3 FTotal;
    private Vector3 FDamping;
    private Vector3 FUser;
    private Vector3 FRender;

    private Vector3 T; //Kinetic energy
    private Vector3 V; //Potential energy
    private Vector3 L; //Lagragrian energy

    [ReadOnly]
    public Vector3 v;
    #endregion

    
    // Start is called before the first frame update
    void Start()
    {
        v = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    //void FixedUpdate()
    //{
    //    if ((intent.transform.position - physical.transform.position).magnitude <= 0.05f)
    //    {
    //        transform.position = physical.transform.position;
    //    }
    //    else
    //    {
    //        FDamping = -b * v;
    //        FUser = kUser * (intent.transform.position - transform.position);
    //        FRender = kRender * (physical.transform.position - transform.position);

    //        FTotal = FDamping + FUser + FRender;

    //        //Kinetic energy
    //        T = vectorTranspose(0.5f * m * v) * v ;
    //        //Debug.Log(T);
    //        V = vectorTranspose(FTotal) * transform.position;
    //        //Lagrange calculate
    //        L = T - V;


    //    }
    //    transform.rotation = intent.transform.rotation;
    //}

    private Matrix4x4 vectorTranspose(Vector3 vector)
    {
        Matrix4x4 matrix = new Matrix4x4();
        matrix[0, 0] = vector.x;
        matrix[1, 0] = vector.y;
        matrix[2, 0] = vector.z;

        return matrix;
    }

    public double[,] positionXY()
    {
        return new double[,] { { transform.position.x, transform.position.y } };
    }
    public double relativePositionDistance()
    {
        return transform.position.x;
    }

    public void setPositionXY(double[,] position)
    {
        transform.position = new Vector3((float)position[0, 0], (float)position[1, 0], 0);
    }

    public void setRelativePositionDistance(double position)
    {
        transform.position = new Vector3((float)position, 0, 0);
    }
}
