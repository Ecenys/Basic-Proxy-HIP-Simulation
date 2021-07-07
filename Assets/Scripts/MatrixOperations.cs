using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Accord.Math;

namespace MatrixOperations
{
    public class MatrixOperations
    {
        public static double[,] solveAxb2by2(double[,] a, double[,] b)
        {
            double i = a[1, 0] / a[0, 0];
            a[1, 0] = a[1, 0] - a[0, 0] * i;
            a[1, 1] = a[1, 1] - a[0, 1] * i;
            b[1, 0] = b[1, 0] - b[0, 0] * i;

            double e = a[0, 1] / a[1, 1];
            a[0, 1] = a[0, 1] - a[1, 1] * e;
            b[0, 0] = b[0, 0] - b[1, 0] * e;

            b[0, 0] /= a[0, 0];
            b[1, 0] /= a[1, 1];

            return b;
        }

        public static double[,][,] solveAxb2by2(double[,][,] a, double[,][,] b)
        {
            double[,] o = multiply(a[1, 0], a[0, 0].Inverse());
            a[1, 0] = sub(a[1, 0], multiply(a[0, 0], o));
            a[1, 1] = sub(a[1, 1], multiply(a[0, 1], o));
            b[1, 0] = sub(b[1, 0], multiply(b[0, 0], o));

            double[,] e = multiply(a[0, 1], a[1, 1].Inverse());
            a[0, 1] = sub(a[0, 1], multiply(a[1, 1], e));
            b[0, 0] = sub(b[0, 0], multiply(b[1, 0], e));

            b[0, 0] = multiply(b[0, 0], a[0, 0].Inverse());
            b[1, 0] = multiply(b[1, 0], a[1, 1].Inverse());

            return b;
        }

        public static double[,] transpose(double[] vector)
        {
            int w = vector.GetLength(0);

            double[,] result = new double[1, w];

            for (int i = 0; i < w; i++)
            {
                result[1, i] = vector[i];
            }

            return result;
        }

        public static double[,] transpose(double[,] matrix)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);

            double[,] result = new double[h, w];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[j, i] = matrix[i, j];
                }
            }

            return result;
        }

        public static double[] multiply(double[] vector, double scalar)
        {
            int w = vector.GetLength(0);

            for (int i = 0; i < w; i++)
            {
                vector[i] *= scalar;
            }

            return vector;
        }

        public static double[,] multiply(double scalar, double[,] matrix)
        {
            return multiply(matrix, scalar);
        }


        public static double[,] multiply(double[,] matrix, double scalar)
        {
            int w = matrix.GetLength(0);
            int h = matrix.GetLength(1);

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    matrix[i, j] *= scalar;
                }
            }

            return matrix;
        }
        public static double[,] multiply(double[,] matrix1, double[,] matrix2)
        {
            var matrix1Rows = matrix1.GetLength(0);
            var matrix1Cols = matrix1.GetLength(1);
            var matrix2Rows = matrix2.GetLength(0);
            var matrix2Cols = matrix2.GetLength(1);

            if (matrix1Cols != matrix2Rows)
                if (matrix1Cols == 1 && matrix1Rows == 1)
                    multiply(matrix2, matrix1[0, 0]);
                else if (matrix2Cols == 1  && matrix2Rows == 1)
                    multiply(matrix1, matrix2[0, 0]);
                else
                    Debug.LogError("Multiplicación imposible, dimensiones incompatibles");
            double[,] product = new double[matrix1Rows, matrix2Cols];

            for (int matrix1_row = 0; matrix1_row < matrix1Rows; matrix1_row++)
            {
                for (int matrix2_col = 0; matrix2_col < matrix2Cols; matrix2_col++)
                {
                    for (int matrix1_col = 0; matrix1_col < matrix1Cols; matrix1_col++)
                    {
                        product[matrix1_row, matrix2_col] +=
                            matrix1[matrix1_row, matrix1_col] *
                            matrix2[matrix1_col, matrix2_col];
                    }
                }
            }

            return product;
        }


        public static double[,] add(double[,] matrix1, double[,] matrix2)
        {
            var matrix1Rows = matrix1.GetLength(0);
            var matrix1Cols = matrix1.GetLength(1);
            var matrix2Rows = matrix2.GetLength(0);
            var matrix2Cols = matrix2.GetLength(1);

            if(matrix1Cols != matrix2Cols || matrix1Rows != matrix2Rows)
                Debug.LogError("Suma imposible, dimensiones incompatibles");

            double[,] matrix3 = new double[matrix1Rows, matrix1Cols];

            for (int i = 0; i < matrix1Rows; i++)
            {
                for (int j = 0; j < matrix2Cols; j++)
                {
                    matrix3[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }

            return matrix3;
        }

        public static double[,] sub(double[,] matrix1, double[,] matrix2)
        {
            var matrix1Rows = matrix1.GetLength(0);
            var matrix1Cols = matrix1.GetLength(1);
            var matrix2Rows = matrix2.GetLength(0);
            var matrix2Cols = matrix2.GetLength(1);

            if (matrix1Cols != matrix2Cols || matrix1Rows != matrix2Rows)
                Debug.LogError("Resta imposible, dimensiones incompatibles");

            double[,] matrix3 = new double[matrix1Rows, matrix1Cols];

            for (int i = 1; i < matrix1Rows; i++)
            {
                for (int j = 1; j < matrix1Cols; j++)
                {
                    matrix3[i, j] = matrix1[i, j] - matrix2[i, j];
                }
            }

            return matrix3;
        }

    }
}
