using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //ReadConsoleMassive();
            //MassiveMaxInRow();
            //MasiveSort();
            //CutString();
            //ReplaceInPoem();
            //PoemGeneration();
            Pyatnashki();

            Console.ReadLine();
        }

        public static void ReadConsoleMassive()
        {
            int[] array = new int[6];
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Insert the number: ");
                int number = int.Parse(Console.ReadLine());
                array[i] = number;
            }

            foreach (var intArr in array)
            {
                Console.Write(intArr + " ");
            }

        }

        public static void MassiveMaxInRow()
        {
            int[,] array = { { 5, 14, 8 }, { 64, 55, 3 }, { 41, 27, 16 } };
            int max = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (max < array[i, j])
                        max = array[i, j];
                }
                Console.WriteLine(max);
                max = 0;
            }
        }

        public static void MasiveSort()
        {
            int[] array = new int[5];
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("Insert the number: ");
                int number = int.Parse(Console.ReadLine());
                array[i] = number;
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }

            foreach (var arr in array)
            {
                Console.Write(arr + " ");
            }
        }

        public static void CutString()
        {
            Console.WriteLine("Write text: ");
            string text = Console.ReadLine();
            string shortText = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text.Length > 13)
                {
                    shortText = text.Substring(0, 13) + "...";
                }
            }
            Console.WriteLine(shortText);
        }

        public static void ReplaceInPoem()
        {
            Console.WriteLine("Write poem: ");
            string poem = Console.ReadLine();
            string[] words = poem.Split(new char[] { ';' });
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToLower().Replace("о", "а");
                words[i] = words[i].ToLower().Replace("л", "ль");
                words[i] = words[i].ToLower().Replace("ть", "т");
            }

            foreach (var wordsArray in words)
            {
                Console.WriteLine(wordsArray);
            }
        }

        public static void PoemGeneration()
        {
            Random letter = new Random();
            char[][] poem = new char[100][];
            for (int i = 0; i < 100; i++)
            {
                var word = new char[letter.Next(10)];
                for (int j = 0; j < word.Length; j++)
                {
                    word[j] = (char)letter.Next(1040 - 1, 1103 - 1);
                }

                poem[i] = word;
            }

            foreach (var words in poem)
            {
                Console.WriteLine(words);
            }
        }

        public static void Pyatnashki()
        {
            var num = GenerationNumber();
            PrintNumber(num);
            Movement(num);

        }

        public static int[,] GenerationNumber()
        {
            int[,] intArray = new int[4, 4];
            Random r = new Random();
            int num = 1;

            for (int i = 0; i < intArray.GetLength(0); i++)
            {
                for (int j = 0; j < intArray.GetLength(1); j++)
                {
                    intArray[i, j] = num++;
                }

                intArray[3, 3] = 0;
            }
            for (int i = 0; i < intArray.GetLength(0); i++)
            {
                for (int j = 0; j < intArray.GetLength(1); j++)
                {
                    int number = intArray[i, j];
                    int randomI = r.Next() % 4;
                    if (intArray[i, j] == 0 || intArray[randomI, j] == 0)
                        continue;
                    intArray[i, j] = intArray[randomI, j];
                    intArray[randomI, j] = number;

                }
            }

            return intArray;
        }

        public static void PrintNumber(int[,] intArray)
        {
            for (int i = 0; i < intArray.GetLength(0); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < intArray.GetLength(1); j++)
                {
                    Console.Write(intArray[i, j] + "\t");

                }
            }

            Console.WriteLine("\n");
        }

        public static void Movement(int[,] intArray)
        {
            int nullI = 3;
            int nullJ = 3;

            while (true)
            {
                var direction = Console.ReadKey().KeyChar;
                int i = nullI;
                int j = nullJ;
                switch (direction)
                {
                    case 'a':
                        j--;
                        break;
                    case 'd':
                        j++;
                        break;
                    case 'w':
                        i--;
                        break;
                    case 's':
                        i++;
                        break;
                }

                if (i >= 0 && i < 4 && j >= 0 && j < 4)
                {
                    int temp = intArray[i, j];
                    intArray[i, j] = intArray[nullI, nullJ];
                    intArray[nullI, nullJ] = temp;
                    nullI = i;
                    nullJ = j;
                    PrintNumber(intArray);
                }
            }
        }

    }
}
