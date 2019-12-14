using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab1Grads
{
    static class Matrixes
    {
        public static void DivString(double[,] target, int number, double Tar)
        {
            for (int i = 0; i < target.GetLength(1); i++)
            {
                target[number,i] *= 1.0 / (Tar);
            }
        }

        public static  void SwapString(double[,] target, int number1, int number2)
        {
            double c;
            for (int i = 0; i < target.GetLength(1); i++)
            {
                c = target[number1,i];
                target[number1,i] = target[number2,i];
                target[number2,i] = c;
            }
        }

        public static void SubString(double[,] target, int number1, int number2, double Mult)
        {
            for (int i = 0; i < target.GetLength(1); i++)
            {
                target[number1,i] -= Mult * target[number2,i];
            }
        }

        public static double GetDet(double[,] target)
        {
            double[,] temp = new double[target.GetLength(0), target.GetLength(0)];
            int i, j;
            for (i = 0; i < target.GetLength(0); i++)
            {
                for (j = 0; j < target.GetLength(0); j++)
                {
                    temp[i,j] = target[i,j];
                }
            }
                //pryamoi hod
            for (i = 0; i < temp.GetLength(0); i++)
                {
                    if (temp[i,i] == 0)
                    {
                        j = i + 1;
                        for (; j < temp.GetLength(0); j++)
                        {
                            if (temp[j,i] != 0)
                            {
                                SwapString(temp, j, i);
                                break;
                            }
                        }
                        if (j == temp.GetLength(0))
                        {
                            return 0;
                        }
                    }
                    // DivString(temp, i, temp[i][i]);
                    for (j = i + 1; j < temp.GetLength(0); j++)
                    {
                        SubString(temp, j, i, temp[j,i] / temp[i,i]);
                    }
                }
            //obratnii
            for (i = temp.GetLength(0) - 1; i >= 0; i--)
            {
                for (j = i - 1; j >= 0; j--)
                {
                    SubString(temp, j, i, temp[j,i] / temp[i,i]);
                }
            }
            double result = 1;
            for (i = 0; i < temp.GetLength(0); i++)
            {
                result *= temp[i,i];
            }
            return result;
        }
        /// <summary>
        /// Умножает две матрицы
        /// </summary>
        /// <param name="target1">Первая матрица, размер Size1хSize3</param>
        /// <param name="target2">Втоаря матрица, размер Size3хSize2</param>
        /// <returns></returns>
        public static double[,] Multiply(double[,] target1, double[,] target2)
        {
            double sum = 0;
            int Size3 = target2.GetUpperBound(0) + 1;
            int Size1 = target1.GetUpperBound(0) + 1;
            int Size2 = (int)(((double)target2.Length) / Size3);
            double[,] result = new double[Size1, Size2];
            for (int i = 0; i < Size1; i++)
            {
                for (int j = 0; j < Size2; j++)
                {
                    sum = 0;
                    for (int k = 0; k < Size3; k++)
                    {
                        sum += target1[i, k] * target2[k, j];
                    }
                    //result[i][j] = sum;
                    result[i, j] = sum;
                }
            }
            return result;
        }

        public static double[,] GetReverse(double[,] target, int Length)
        {
            double[,] matrix = new double[Length,2 * Length];
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                {
                    matrix[i,j] = (target[i,j]);
                }
            }
            for (int i = 0; i < Length; i++)
            {
                matrix[i,i + Length] = 1;
            }
            double[] x = new double[Length];
            //pryamoi hod
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i,i] == 0)
                {
                    int j = i + 1;
                    for (; j < matrix.GetLength(0); j++)
                    {
                        if (matrix[j,i] != 0)
                        {
                            SwapString(matrix, j, i);
                            //apString(matrixres, j, i);
                            break;
                        }
                    }
                    if (j == matrix.GetLength(0))
                    {
                        return new double[0, 0];
                    }
                }
                //DivString(matrixres, i, matrix[i][i]);
                DivString(matrix, i, matrix[i,i]);
                for (int j = i + 1; j < matrix.GetLength(0); j++)
                {
                    //SubString(matrixres, matrix, j, i, matrix[j][i]);
                    SubString(matrix, j, i, matrix[j,i]);
                }
            }
            //obratnii
            for (int i = matrix.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    //SubString(matrixres, matrix, j, i, matrix[j][i]);
                    SubString(matrix, j, i, matrix[j,i]);
                }
            }

            double[,] result = new double[Length, Length];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    result[i, j] = matrix[i, j + matrix.GetLength(0)];//Math.Round()???
                }
            }
            return result;
        }

        public static double[,] GetTransp(double[,] target, int Length1, int Length2)
        {
            double[,] result = new double[Length2, Length1];
            int i, j;
            for (i = 0; i < Length1; i++)
            {
                for (j = 0; j < Length2; j++)
                {
                    result[j, i] = target[i, j];
                }
            }
            return result;
        }

        public static double[,] GetMinor(double[,] target, int n1, int n2)
        {
            double[,] result = new double[target.GetLength(0) - 1, target.GetLength(0) - 1];
            int i, j;
            for (i = 0; i < n1; i++)
            {
                for (j = 0; j < n2; j++)
                {
                    result[i,j] = target[i,j];
                }
                for (j = n2 + 1; j < target.GetLength(0); j++)
                {
                    result[i,j-1] = target[i,j];
                }
            }
            for (i = n1 + 1; i < target.GetLength(0); i++)
            {
                for (j = 0; j < n2; j++)
                {
                    result[i-1,j] = target[i,j];
                }
                for (j = n2 + 1; j < target.GetLength(0); j++)
                {
                    result[i-1,j - 1] = target[i,j];
                }
            }
            return result;
        }

        internal static int Multiply(double[,] p, int p_2, int DimNum, int DimNum_2)
        {
            throw new NotImplementedException();
        }

        public static double[,] CutMatrix(double[,] target, int Size1, int Size2)
        {
            double[,] result = new double[Size1, Size2];
            for (int i = 0; i < Math.Min(target.GetLength(0), Size1); i++)
            {
                for (int j = 0; j < Math.Min(target.GetLength(1), Size2);j++)
                {
                    result[i, j] = target[i, j];
                }
            }
            return result;
		}

		public static double[,] CutRowsColumns(double[,] target,  int RowNumber,int ColumnNumber)
		{
            return CutColumns(CutRows(target,RowNumber),ColumnNumber);
		}

        public static double[,] CutRows(double[,] target, int RowNumber)
        {
            int i, j, k;
            if(RowNumber < 0 || RowNumber > target.GetLength(0))
                return target;
            double[,] result = new double[target.GetLength(0)-1, target.GetLength(1)];
            for (i = 0; i < RowNumber; i++)
            {
                for (j = 0; j <  target.GetLength(1); j++)
                {
                    result[i, j] = target[i, j];
                }
            }
            for (; i < target.GetLength(0)-1; i++)
            {
                for (j = 0; j < target.GetLength(1); j++)
                {
                    result[i, j] = target[i+1, j];
                }
            }
            return result; 
        }

        public static double[,] CutColumns(double[,] target, int ColumnNumber)
        {
            int i, j, k;
            if (ColumnNumber < 0 || ColumnNumber > target.GetLength(1))
                return target;
            double[,] result = new double[target.GetLength(0), target.GetLength(1)-1];
            for (j = 0; j < target.GetLength(0); j++)
            {
                for (i = 0; i < ColumnNumber; i++)
                {
                    result[j, i] = target[j, i];
                }
                for (; i < target.GetLength(1) - 1; i++)
                {
                    result[j, i] = target[j, i+1];
                }
            }
            return result;
        }
    }
}
