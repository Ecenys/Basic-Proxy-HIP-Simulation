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
    public double[,] v = { {0}, {0} };

    public float kUser;
    public float kRender;

    public Transform relativeObject;
    public Transform baseHand;

    [Space]
    
    [Range(0, 100)]
    public float forcePorcentage;
    #endregion

    #region PrivateValues
    [ReadOnly]
    private Vector3 FTotal;
    private Vector3 FDamping;
    private Vector3 FUser;
    private Vector3 FRender;

    private Vector3 T; //Kinetic energy
    private Vector3 V; //Potential energy
    private Vector3 L; //Lagragrian energy
    #endregion

    public double[,] positionXY()
    {
        return new double[,] { { transform.position.x, transform.position.y } };
    }
    public double relativePositionDistance()
    {
        return Vector2.Distance(relativeObject.transform.position, transform.position);
    }
    public double fingerDistance()
    {
        return Vector2.Distance(baseHand.transform.position, transform.position);
    }

    public void setPositionXY(double[,] position)
    {
        transform.position = new Vector3((float)position[0, 0], (float)position[1, 0], 0);
    }

    public void setRelativePositionDistance(double position)
    {
        transform.position = relativeObject.position + 
            new Vector3(
                (float)position * Mathf.Cos(baseHand.GetComponent<IntentionController>().rotationRadians),
                (float)position * Mathf.Sin(baseHand.GetComponent<IntentionController>().rotationRadians), 
                0
            );
    }
}
