// Задача 56: Задайте прямоугольный двумерный массив.
// Напишите программу, которая будет находить строку
// с наименьшей суммой элементов.
// 
// Например, задан массив:
// 
// 1 4 7 2
// 
// 5 9 2 3
// 
// 8 4 2 4
// 
// 5 2 6 7
// 
// Программа считает сумму элементов в каждой строке
// и выдаёт номер строки с наименьшей суммой элементов: 1 строка

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

int FindMinElementNumber(int[] arr)
{
    int min = arr[0];
    int minIndex = 1;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i] < min) 
        {
            minIndex = i + 1;
            min = arr[i];
        }
    }
    return minIndex;
}

void LessSumInRow(int[,] matrix)
{
    int[] minSum = new int[matrix.GetLength(0)];
	for (int i = 0; i < matrix.GetLength(0); i++)
	{

		int sum = 0;
		for (int j = 0; j < matrix.GetLength(1); j++)
		{
			sum += matrix[i,j];
		}
		minSum[i] = sum;
	}
    int minRow = FindMinElementNumber(minSum);
    Console.Write("Программа считает сумму элементов в каждой строке и выдаёт номер ");
    Console.WriteLine($"строки с наименьшей суммой элементов: {minRow} строка");
}

int[,] matrix = CreateMatrixRndInt(4, 4, 1, 10);
PrintMatrix(matrix);
Console.WriteLine();
LessSumInRow(matrix);
