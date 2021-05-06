using UnityEngine;
using static MatrixOperations.MatrixOperations;
using Accord.Math;
using VectorXD = MathNet.Numerics.LinearAlgebra.Vector<double>;
using MatrixXD = MathNet.Numerics.LinearAlgebra.Matrix<double>;
using DenseVectorXD = MathNet.Numerics.LinearAlgebra.Double.DenseVector;
using DenseMatrixXD = MathNet.Numerics.LinearAlgebra.Double.DenseMatrix;

public class NewInteracionController : MonoBehaviour
{
    [Header("Hand Components")]
    public GameObject intention;
    public GameObject proxy;
    public GameObject hip;

    [Header("Finger Components")]
    public GameObject fingerIntention;
    public GameObject fingerProxy;
    public GameObject fingerHip;
    public double[,] u = new double[,] { { 1, 0 } };

    //Components of M·x=b
    private double[,] M;
    private double[,] X;
    private double[,] b;

    void FixedUpdate()
    {
        //M
        double mX = hip.GetComponent<HIPController>().m;
        double mZ = fingerHip.GetComponent<HIPController>().m;

        double[,] firstComponent = multiply(Matrix.Identity(2), mX + mZ);
        double[,] secondComponent = multiply(u, mZ);
        double[,] thirdComponent = multiply(transpose(u), mZ);
        double fourthComponent = multiply(multiply(transpose(u), mZ), u)[0,0];

        M = new double[,]{
            {firstComponent[0,0], firstComponent[0,1], secondComponent[0,0]},
            {firstComponent[1,0], firstComponent[1,1], secondComponent[0,1]},
            {thirdComponent[0,0], thirdComponent[1,0], fourthComponent}
        };

        //b
        double kXU = hip.GetComponent<HIPController>().kUser;
        double kZU = fingerHip.GetComponent<HIPController>().kUser;

        double[,] x = hip.GetComponent<HIPController>().positionXY();
        double z = fingerHip.GetComponent<HIPController>().relativePositionDistance();

        double[,] iX = intention.GetComponent<BaseIntentionController>().positionXY();
        double iZ = fingerIntention.GetComponent<IntentionController>().relativePositionDistance();

        double[,] fX = multiply(sub(iX, x), kXU);
        double fZ = (iZ - z) * kZU;

        b = new double[,] {
            {fX[0,0]},
            {fX[0,1]},
            {fZ}
        };

        //Solve M·X = b
        X = Matrix.Solve(M,b);

        hip.GetComponent<HIPController>().setPositionXY(new double[,] { { X[0, 0] }, { X[1,0] } });
        fingerHip.GetComponent<HIPController>().setRelativePositionDistance(X[2, 0]);

        //Debug.Log("El resultado de Mx=b es " + X[0, 0] + ", " + X[1, 0] + ", " + X[2, 0]);
    }
}
