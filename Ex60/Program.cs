// Задача 60. ...Сформируйте трёхмерный массив
// из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив,
// добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

int[,,] Create3DMatrixInt (int row, int column, int depth)
{
	int[,,] matrix = new int[row, column, depth];
    int count = 10;
	if ((row * column * depth) < 90)
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < column; j++)
            {
                for (int k = 0; k < column; k++)
                {
                matrix[i,j,k] = count;
                count++;
                }
            }
        }
    }
    else
    {
    Console.WriteLine("Указанные параметры не подходят для составления массива с уникальными двузначными числами.");
    }
    return matrix;
}

void Print3DMatrix (int[,,] matrix)
{
	for (int i = 0; i < matrix.GetLength(0); i++)
	{
		for (int j = 0; j < matrix.GetLength(1); j++)
		{
            for (int k = 0; k < matrix.GetLength(2); k++)
            {
			Console.WriteLine($"{matrix[i,j,k]}({i},{j},{k})");
            }
		}
	}
}

int[,,] matrix3D = Create3DMatrixInt(4,4,4);
Print3DMatrix(matrix3D);
