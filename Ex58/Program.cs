// Задача 58: Задайте две матрицы. Напишите программу,
// которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int[,] CreateMatrixRndInt (int row, int column, int min, int max)
{
	int[,] matrix = new int[row, column];
	Random rnd = new Random();
	
	for (int i = 0; i < row; i++)
	{
        for (int j = 0; j < column; j++)
        {
            matrix[i,j] = rnd.Next(min, max + 1);
        }
	}
	return matrix;
}

void PrintMatrix (int[,] matrix)
{
	for (int i = 0; i < matrix.GetLength(0); i++)
	{
		Console.Write("[");
		for (int j = 0; j < matrix.GetLength(1); j++)
		{
			if (j < matrix.GetLength(1) - 1) Console.Write($"{matrix[i,j]}, ");
			else Console.Write(matrix[i,j]);
		}
		Console.WriteLine("]");
	}
}

int[] GetRow(int[,] matr, int row)
{
    int[] arr = new int[matr.GetLength(1)];
    for (int i = 0; i < matr.GetLength(1); i++)
    {
        arr[i] = matr[row,i];
    }
    return arr;
}

int[] GetColumn(int[,] matr, int col)
{
    int[] arr = new int[matr.GetLength(0)];
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        arr[i] = matr[i,col];
    }
    return arr;
}

int RowMulOnColumn(int[] arr1, int[] arr2)
{
    int result = 0;
    for (int i = 0; i < arr1.Length; i ++)
    {
        result += arr1[i] * arr2[i];
    }
    return result;
}

int[,] MatrixMul(int[,] matr1, int[,] matr2)
{
    int[,] resultMatrix = new int[matr1.GetLength(0), matr2.GetLength(1)];
    for (int i = 0; i < resultMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < resultMatrix.GetLength(1); j++)
        {
            resultMatrix[i,j] = RowMulOnColumn(GetRow(matr1, i), GetColumn(matr2, j));
        }
    }
    return resultMatrix;
}

int[,] matrix1 = CreateMatrixRndInt(2, 2, 1, 10);
PrintMatrix(matrix1);
Console.WriteLine();

int[,] matrix2 = CreateMatrixRndInt(2, 2, 1, 10);
PrintMatrix(matrix2);
Console.WriteLine();

if(matrix1.GetLength(1) == matrix2.GetLength(0))
{
    int[,] mulMatrixResult = MatrixMul(matrix1, matrix2);
    PrintMatrix(mulMatrixResult);
}
else
{
    Console.WriteLine("Размеры матриц не подходят для умножения.");
}
