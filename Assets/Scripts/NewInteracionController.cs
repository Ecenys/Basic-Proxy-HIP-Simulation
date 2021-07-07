using UnityEngine;
using static MatrixOperations.MatrixOperations;
using Accord.Math;
using VectorXD = MathNet.Numerics.LinearAlgebra.Vector<double>;
using MatrixXD = MathNet.Numerics.LinearAlgebra.Matrix<double>;
using DenseVectorXD = MathNet.Numerics.LinearAlgebra.Double.DenseVector;
using DenseMatrixXD = MathNet.Numerics.LinearAlgebra.Double.DenseMatrix;

public class NewInteracionController : MonoBehaviour
{
    [Header("General Parameters")]
    public float TimeStep = 1f;

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

    double[,] fX;
    double fZ;

    void FixedUpdate()
    {
        stepSymplectic();
    }

    private void stepSymplectic()
    {
        double[,] x = calculateX();
        double[,] v = calculateV();
        double[,] f = computeForces();
        double[,] Minv = calculateMinv();

        

        // v = v + TimeStep * Minv * f; 
        v = add(v, multiply(TimeStep, multiply(Minv, f)));
        // x = x + TimeStep * v
        x = add(x, multiply(TimeStep, v));

        setV(v);
        setX(x);
    }

    private double[,] calculateX()
    {
        ////M
        //double mX = hip.GetComponent<HIPController>().m;
        //double mZ = fingerHip.GetComponent<HIPController>().m;

        //double[,] firstComponent = multiply(Matrix.Identity(2), mX + mZ);
        //double[,] secondComponent = multiply(u, mZ);
        //double[,] thirdComponent = multiply(transpose(u), mZ);    
        //double fourthComponent = multiply(multiply(transpose(u), mZ), u)[0, 0];

        //M = new double[,]{
        //    {firstComponent[0,0], firstComponent[0,1], secondComponent[0,0]},
        //    {firstComponent[1,0], firstComponent[1,1], secondComponent[0,1]},
        //    {thirdComponent[0,0], thirdComponent[1,0], fourthComponent}
        //};

        ////b
        //b = computeForces();

        ////Solve M·X = b
        //X = Matrix.Solve(M, b);

        //return X;
        double[,] x = new double[,] {
            {hip.GetComponent<HIPController>().positionXY()[0,0] },
            {hip.GetComponent<HIPController>().positionXY()[0,1] },
            {fingerHip.GetComponent<HIPController>().relativePositionDistance() }
            };

        return x;

    }

    public double[,] calculateV()
    {
        double[,] v = new double[,] {
            {hip.GetComponent<HIPController>().v[0,0] },
            {hip.GetComponent<HIPController>().v[1,0] },
            {fingerHip.GetComponent<HIPController>().v[0,0] }
            };

        return v;
    }

    private double[,] computeForces()
    {
        double kXU = hip.GetComponent<HIPController>().kUser;
        double kZU = fingerHip.GetComponent<HIPController>().kUser;

        double[,] x = hip.GetComponent<HIPController>().positionXY();
        double z = fingerHip.GetComponent<HIPController>().relativePositionDistance();

        double[,] iX = intention.GetComponent<BaseIntentionController>().positionXY();
        double iZ = fingerIntention.GetComponent<IntentionController>().relativePositionDistance();

        fX = multiply(sub(iX, x), kXU);
        fZ = (iZ - z) * kZU;

        b = new double[,] {
            {fX[0,0]},
            {fX[0,1]},
            {fZ}
        };

        return b;
    }

    private double[,] calculateMinv()
    {
        double mX = hip.GetComponent<HIPController>().m;
        double mZ = fingerHip.GetComponent<HIPController>().m;

        double[,] minv = { 
            { 1.0 / mX, 0 ,         0}, 
            {0,         1.0 / mX,   0 }, 
            { 0,        0,          1.0 / mZ } };

        return minv;
    }

    private void setV(double[,] v){
        hip.GetComponent<HIPController>().v[0, 0] = v[0, 0];
        hip.GetComponent<HIPController>().v[1, 0] = v[1, 0];
        fingerHip.GetComponent<HIPController>().v[0, 0] = v[2, 0];
    }

    private void setX(double[,] x)
    {
        hip.GetComponent<HIPController>().setPositionXY(new double[,] { { x[0, 0] }, { x[1, 0] } });
        fingerHip.GetComponent<HIPController>().setRelativePositionDistance(x[2, 0]);
    }
}
