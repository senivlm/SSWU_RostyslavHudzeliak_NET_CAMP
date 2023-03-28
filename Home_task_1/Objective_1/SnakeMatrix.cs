using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objective_1
{
    internal class SnakeMatrix
    {
        //static int n = 3, m = 4;
        //int[,] array = new int[n, m];
        int[,] array;
        // Чому немає конструктора?
        private void Matrix(int n = 3, int m = 4)
        {// Локальні змінні іменуються з маленької літери
            int Ibeg = 0, Ifin = 0, Jbeg = 0, Jfin = 0;
            array = new int[n, m];
            int number = 1;
            int i = 0;
            int j = 0;

            while (number <= n * m)
            {// не найоптимальніший підхід....
                array[i, j] = number;

                if (j == Jbeg && i < n - Ifin - 1)
                    ++i;                                                            // Move numbers down
                else if (i == n - Ifin - 1 && j < m - Jfin - 1)
                    ++j;                                                            // Move numbers to the right
                else if (j == m - Jfin - 1 && i > Jbeg)
                    --i;                                                            // Move numbers up
                else
                    --j;                                                            // Move numbers to the left

                if ((j == Ibeg + 1) && (i == Ibeg)) // && (Jbeg != m - Jfin - 2)
                {
                    ++Ibeg;                                                         // Shifts the beginning and end so that the data is not overwritten
                    ++Ifin;                                                         // and occupies empty cells
                    ++Jbeg;
                    ++Jfin;
                }
                ++number;
            }
        }

        private void BaseMatrix(int n = 3, int m = 4)
        {
            int Ibeg = 0, Ifin = 0, Jbeg = 0, Jfin = 0;
            //int n = 3, m = 4;
            array = new int[n, m];
            int number = 1;
            int i = 0;
            int j = 0;

            while (number <= n * m)
            {
                array[i, j] = number;
                if (i == Ibeg && j < m - Jfin - 1)
                    ++j;                                                            // Move numbers to the right
                else if (j == m - Jfin - 1 && i < n - Ifin - 1)
                    ++i;                                                            // Move numbers down
                else if (i == n - Ifin - 1 && j > Jbeg)
                    --j;                                                            // Move numbers to the left
                else
                    --i;                                                            // Move numbers up

                if ((i == Ibeg + 1) && (j == Jbeg) && (Jbeg != m - Jfin - 1))       // Shifts the beginning and end so that the data is not overwritten
                {                                                                   // and occupies empty cells
                    ++Ibeg;
                    ++Ifin;
                    ++Jbeg;
                    ++Jfin;
                }
                ++number;
            }
        }
        // має бути метод ToString замість методу print
        public void PrintMatrix()
        {
            for (int x = 0; x < array.GetLength(0); ++x)
            {
                for (int y = 0; y < array.GetLength(1); ++y)
                    Console.Write(array[x, y] + "\t");
                Console.WriteLine();
            }
        }
        public void Config()
        {
            int tempN = 0, tempM = 0, counter = 0;
            do
            {// перехід по мітках слід уникати...
            nLoop:
                try
                {
                    Console.WriteLine("Enter the width of the matrix");
                    tempM = Int32.Parse(Console.ReadLine());
                    if (tempM < 0)
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
                    tempN = Int32.Parse(Console.ReadLine());
                    if (tempN < 0)
                        goto mLoop;
                    counter++;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid format, numeric required\n");
                }

            } while (counter != 2);
// метод взяв на себе надлишкові обов'язки...
            Console.WriteLine("Select the bypass direction: ");
            Console.WriteLine("1 - Spiral matrix ");
            Console.WriteLine("2 - Basic spiral matrix ");

            int choice = 1;
            do
            {
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid format, or number.\n");
                }
            } while (choice != 1 && choice != 2);
            if (choice == 1)
                Matrix(tempN, tempM);
            else BaseMatrix(tempN, tempM);


        }
    }
}
