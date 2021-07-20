using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using VectorXD = MathNet.Numerics.LinearAlgebra.Vector<double>;
using MatrixXD = MathNet.Numerics.LinearAlgebra.Matrix<double>;
using DenseVectorXD = MathNet.Numerics.LinearAlgebra.Double.DenseVector;
using DenseMatrixXD = MathNet.Numerics.LinearAlgebra.Double.DenseMatrix;

public class PhysicsManager : MonoBehaviour
{
    [Header("Hand Components")]
    public GameObject intention;
    public GameObject proxy;
    public GameObject hip;

    [Header("Finger Components")]
    public GameObject fingerIntention;
    public GameObject fingerProxy;
    public GameObject fingerHip;

    private List<GameObject> m_objs;

    private void Start()
    {
        m_objs = new List<GameObject>() { hip, fingerHip};
    }

    //private void FixedUpdate()
    //{
    //    // TO BE COMPLETED
    //    VectorXD x = new DenseVectorXD(2);
    //    VectorXD v = new DenseVectorXD(2);
    //    VectorXD f = new DenseVectorXD(2);
    //    VectorXD xFinger = new DenseVectorXD(2);
    //    VectorXD vFinger = new DenseVectorXD(2);
    //    VectorXD fFinger = new DenseVectorXD(2);


    //    MatrixXD A = M;
    //    VectorXD b = M * v + TimeStep * f;
    //    MatrixXD dcdxT = dcdx.Transpose();

    //    MatrixXD MA = new DenseMatrixXD(m_numConstraints + m_numDoFs, m_numConstraints + m_numDoFs);
    //    MA.SetSubMatrix(0, 0, A);
    //    MA.SetSubMatrix(0, m_numDoFs, dcdxT);
    //    MA.SetSubMatrix(m_numDoFs, 0, dcdx);

    //    VectorXD Mb = new DenseVectorXD(m_numConstraints + m_numDoFs);
    //    Mb.SetSubVector(0, m_numDoFs, b);
    //    Mb.SetSubVector(m_numDoFs, m_numConstraints, TimeStep * c);

    //    VectorXD MV = MA.Solve(Mb);

    //    MV.CopySubVectorTo(v, 0, 0, m_numDoFs);

    //    v += (Minv * f);
    //    x += v;

    //    for (int i = 0; i < m_objs.Count; i++)
    //    {
    //        m_objs[i].SetVelocity(v);
    //        m_objs[i].SetPosition(x);
    //    }
    //}
}
