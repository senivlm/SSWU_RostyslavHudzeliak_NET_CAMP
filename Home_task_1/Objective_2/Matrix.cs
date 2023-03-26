using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objective_2
{
    internal class Matrix
    {
        int[,] matrix;
        private void FillMatrix(int x = 5, int y = 4)                                                           // Fill matrix with random numbers
        {
            matrix = new int[y, x];
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    Random random = new Random();
                    matrix[i,j] = random.Next(10);
                }
            }
            MatrixLogic();
        }
        private void MatrixLogic()
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            PrintMatrix();                                                                          
            (int, int)[,] checkHorint = new (int x, int y)[rows, cols];
            (int, int) empty = (-1, -1);

            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    checkHorint[i, j] = empty;
                }

            void CheckHorizont((int x, int y) start, (int dx, int dy) step, (int, int)[,] check)                // Method to check horizontal lines
            {                                                                                                   // In matrix
                var (xend, yend) = start;
                int count = 0;
                while (xend < matrix.GetLength(0) && yend < matrix.GetLength(1) && matrix[xend, yend] == matrix[start.x, start.y])
                {
                    check[xend, yend] = start;
                    (xend, yend) = (xend + step.dx, yend + step.dy);
                    count++;
                }
                if (count == 1) check[start.x, start.y] = empty;
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (checkHorint[i, j] == empty)
                        CheckHorizont((i, j), (0, 1), checkHorint);
                }
            }

            int maxLenght = 0;
            var lines = new HashSet<((int x1, int y1) start, (int x2, int y2) end, int lenght, int color)>();   // Collection to keep information about lines    
            void MaxLenght((int i, int j) start, (int i, int j) end)
            {
                if (start == empty) return;

                var lenght = Math.Max(end.i - start.i, end.j - start.j);
                if (lenght > maxLenght)
                {
                    maxLenght = lenght;
                    lines.Clear();
                    lines.Add((start, end, lenght, matrix[start.i, start.j]));
                }
                if (lenght == maxLenght)
                    lines.Add((start, end, lenght, matrix[start.i, start.j]));
            }
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    MaxLenght(checkHorint[i, j], (i, j));
            foreach (var item in lines)                                                                         // Print information about lines
            {
                Console.WriteLine($"{item.start}-{item.end}, len={item.lenght + 1}, color={item.color}");
            }
        }

        private void PrintMatrix()                                                                              // Print matrix                
        {
            for (int x = 0; x < matrix.GetLength(0); ++x)
            {
                for (int y = 0; y < matrix.GetLength(1); ++y)
                    Console.Write(matrix[x, y] + " ");
                Console.WriteLine();
            }
        }
        public void Config()
        {
            int tempX = 0, tempY = 0, counter = 0;
            do
            {
            nLoop:
                try
                {
                    Console.WriteLine("Enter the width of the matrix");
                    tempX = Int32.Parse(Console.ReadLine());
                    if (tempX < 0)
                        goto nLoop;
                    counter++;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid format, numeric required\n");
                }

            mLoop:
                try
                {
                    Console.WriteLine("Enter the height of the matrix");
                    tempY = Int32.Parse(Console.ReadLine());
                    if (tempY < 0)
                        goto mLoop;
                    counter++;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid format, numeric required\n");
                }

            } while (counter != 2);
            FillMatrix(tempX, tempY);
        }
    }
}
