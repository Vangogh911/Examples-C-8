// Задача 54: Задайте двумерный массив. Напишите программу,
// которая упорядочит по убыванию элементы
// каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

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

void PrintMatrix(int[,] matrix)
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

int[] ConvertMatrixRowToArray (int [,] matr, int row)
{
    int[] arr = new int[matr.GetLength(1)];
    for (int i = 0; i < matr.GetLength(1); i++)
    {
        arr[i] = matr[row,i];
    }
    return arr;
}

void SortMaxToMin (int[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        for(int j = i + 1; j < arr.Length; j++)
        {
            if (arr[i] < arr[j])
            {
                int buf = arr[j];
                arr[j] = arr[i];
                arr[i] = buf;
            }
        }
    }
}

void SortRowsMaxToMin (int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
	{
        int[] array = ConvertMatrixRowToArray(matrix, i);
        SortMaxToMin(array);
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i,j] = array[j];
        }
    }
}

int[,] matrix = CreateMatrixRndInt(3, 4, 1, 10);
PrintMatrix(matrix);
Console.WriteLine();
SortRowsMaxToMin(matrix);
PrintMatrix(matrix);
