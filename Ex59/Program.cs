// Задача 59: Задайте двумерный массив из целых чисел.
// Напишите программу, которая удалит строку и столбец, на
// пересечении которых расположен наименьший элемент
// массива.

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

int[] FindMinInMatrix(int[,] matr)
{
    int[] arr = new int[2];
    int min = matr[0,0];
    for (int i = 0; i < matr.GetLength(0); i++)
    {
        for (int j = 0; j < matr.GetLength(1); j++)
        {
            if (matr[i,j] < min)
            {
                min = matr[i,j];
                arr[0] = i;
                arr[1] = j;
            }
        }
    }
    return arr;
}

int[,] DeleteMinRowAndColumn(int[,] matr)
{
    int[,] matrix = new int[matr.GetLength(0) - 1, matr.GetLength(1) - 1];
    int[] arr = FindMinInMatrix(matr);

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (i < arr[0])
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j < arr[1]) matrix[i,j] = matr[i,j];
                else matrix[i,j] = matr[i,j + 1];
            }
        }
        else
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (j < arr[1]) matrix[i,j] = matr[i + 1,j];
                else matrix[i,j] = matr[i + 1,j + 1];
            }
        }
    }
    return matrix;
}

int[,] matrix = CreateMatrixRndInt(4,4,10,99);
PrintMatrix(matrix);
Console.WriteLine();
int[,] matrixChange = DeleteMinRowAndColumn(matrix);
PrintMatrix(matrixChange);
