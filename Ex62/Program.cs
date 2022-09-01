// Задача 62. Напишите программу,
// которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int[,] CreateMatrixSpiralInt (int row, int column)
{
	int[,] matrix = new int[row, column];
    int count = 1;

    for (int j = 0; j < column; j++)
    {
        matrix[0, j] = count;
        count++;
    }

    for (int i = 1; i < row; i++)
    {
        matrix[i, column - 1] = count;
        count++;
    }

    for (int j = column - 2; j >= 0; j--)
    {
        matrix[row - 1, j] = count;
        count++;
    }

    for (int i = row - 2; i > 0; i--)
    {
        matrix[i, 0] = count;
        count++;
    }

    int n = 1;
    int k = 1;

    while (count < row * column)
    {
        while (matrix[n, k + 1] == 0)
        {
            matrix[n, k] = count;
            count++;
            k++;
        }

        while (matrix[n + 1, k] == 0 && n < row)
        {
            matrix[n, k] = count;
            count++;
            n++;
        }

        while (matrix[n, k - 1] == 0 && k >= 0)
        {
            matrix[n, k] = count;
            count++;
            k--;
        }

        while (matrix[n - 1, k] == 0 && n >= 0)
        {
            matrix[n, k] = count;
            count++;
            n--;
        }
    }

    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < column; j++)
        {
            if (matrix[i, j] == 0)
            {
                matrix[i, j] = count;
            }
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

int[,] matrix = CreateMatrixSpiralInt(4,4);
PrintMatrix(matrix);
