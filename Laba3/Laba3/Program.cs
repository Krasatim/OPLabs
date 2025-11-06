using System;
using System.Diagnostics;

namespace Laba3
{
    class Program
    {
        static void Main()
        {
            int exit = 0;
            while (exit == 0)
            {
                Console.WriteLine(" == МЕНЮ ==");
                Console.WriteLine("1. Игра 'Угадайка'");
                Console.WriteLine("2. Об авторе");
                Console.WriteLine("3. Сортировка массивов");
                Console.WriteLine("4. Выход");
                Console.WriteLine("Ваш выбор:");
                int choice = IntCheck();

                switch (choice)
                {
                    case 1:
                        PlayGame();
                        break;
                    case 2:
                        ShowAuthorInfo();
                        break;
                    case 3:
                        SortArrays();
                        break;
                    case 4:
                        if (Exit())
                            exit = 1;
                        break;
                    default:
                        Console.WriteLine("Ошибка! Нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            Console.WriteLine("Нажмите любую клавишу, чтобы выйти...");
            Console.ReadKey();
            Console.WriteLine("До свидания!");
        }

        static int IntCheck()
        {
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
                Console.WriteLine("Ошибка! Введите целое число:");
            return number;
        }

        static double DoubleCheck()
        {
            double number;
            while (!double.TryParse(Console.ReadLine(), out number))
                Console.WriteLine("Ошибка! Введите число:");
            return number;
        }

        static void PlayGame()
        {
            Console.Clear();

            double correctAnswer = CalculateFunction();
            PlayGuessingGame(correctAnswer);

            Console.WriteLine("Нажмите любую клавишу для выхода в меню...");
            Console.ReadKey();
            Console.Clear();
        }

        static double CalculateFunction()
        {
            Console.WriteLine("Введите число a:");
            double a = DoubleCheck();
            Console.WriteLine("Введите число b:");
            double b = DoubleCheck();

            return CalculateFunctionValue(a, b);
        }

        static double CalculateFunctionValue(double a, double b)
        {
            double f = Math.PI * ((Math.Log10(Math.Pow(b, 5))) / Math.Sin(a) + 1);
            return Math.Round(f, 2);
        }

        static void PlayGuessingGame(double correctAnswer)
        {
            Console.WriteLine("Попробуйте угадать ответ. Сколько вам нужно попыток? Введите:");
            int maxTries = IntCheck();
            Console.WriteLine("У вас есть {0} попыток!", maxTries);

            int triesUsed = 0;
            bool guessedCorrectly = false;

            while (triesUsed < maxTries && !guessedCorrectly)
            {
                Console.WriteLine("Введите ваш ответ:");
                double userAnswer = DoubleCheck();
                triesUsed++;

                if (userAnswer == correctAnswer)
                {
                    Console.WriteLine("Верно!");
                    guessedCorrectly = true;
                }
                else
                {
                    int remainingTries = maxTries - triesUsed;
                    if (remainingTries > 0)
                    {
                        Console.WriteLine("Неверно! Осталось попыток: {0}", remainingTries);
                    }
                }
            }

            if (!guessedCorrectly)
            {
                Console.WriteLine("Попытки закончились! Правильный ответ: {0}", correctAnswer);
            }
        }

        static void ShowAuthorInfo()
        {
            Console.Clear();
            Console.WriteLine("Баймишев Тимур Ильясович. ИВТ 6 группа");
            Console.WriteLine("Нажмите любую клавишу для выхода в меню...");
            Console.ReadKey();
            Console.Clear();
        }

        static bool Exit()
        {
            Console.Write("Выйти? (д/н): ");
            string answer = Console.ReadLine().ToLower();
            while (answer != "д" && answer != "н")
            {
                Console.WriteLine("Введите д или н:");
                answer = Console.ReadLine().ToLower();
            }
            return answer == "д";
        }

        static void SortArrays()
        {
            Console.Clear();
            int arrayLength = GetArrayLength();
            int[] originalArray = CreateAndInitializeArray(arrayLength);
            int[] arrayClone = CreateArrayCopy(originalArray);

            Console.WriteLine("Массив до сортировки:");
            PrintArray(originalArray);

            Console.WriteLine("Массив после сортировки пузырьком:");
            var bubbleWatch = Stopwatch.StartNew();
            int[] bubbleSorted = BubbleSort(arrayClone);
            bubbleWatch.Stop();
            PrintArray(bubbleSorted);

            Console.WriteLine("Массив после сортировки вставками:");
            var insertionWatch = Stopwatch.StartNew();
            int[] insertionSorted = InsertionSort(originalArray);
            insertionWatch.Stop();
            PrintArray(insertionSorted);

            Console.WriteLine("Время на сортировку пузырьком: {0}мс", bubbleWatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("Время на сортировку вставками: {0}мс", insertionWatch.Elapsed.TotalMilliseconds);

            Console.WriteLine("Нажмите любую клавишу для выхода в меню...");
            Console.ReadKey();
            Console.Clear();
        }

        static int GetArrayLength()
        {
            int length;
            do
            {
                Console.WriteLine("Введите размер массива (больше 0):");
                length = IntCheck();
                if (length <= 0)
                    Console.WriteLine("Ошибка! Длина массива должна быть больше 0.");
            } while (length <= 0);

            return length;
        }

        static int[] CreateAndInitializeArray(int length)
        {
            int[] array = new int[length];
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                array[i] = rnd.Next(-1000000, 1000000);
            }

            return array;
        }

        static int[] CreateArrayCopy(int[] sourceArray)
        {
            int[] copy = new int[sourceArray.Length];
            for (int i = 0; i < sourceArray.Length; i++)
            {
                copy[i] = sourceArray[i];
            }
            return copy;
        }

        static void PrintArray(int[] array)
        {
            if (array.Length > 10)
            {
                Console.WriteLine("Массив не может быть выведен на экран, так как длина массива больше 10");
            }
            else
            {
                Console.WriteLine("Ваш массив:");
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine($"m[{i}] = {array[i]}");
                }
            }
        }

        static int[] BubbleSort(int[] array)
        {
            int[] sortedArray = array;

            for (int i = 0; i < sortedArray.Length - 1; i++)
            {
                for (int j = 0; j < sortedArray.Length - i - 1; j++)
                {
                    if (sortedArray[j] > sortedArray[j + 1])
                    {
                        int temp = sortedArray[j];
                        sortedArray[j] = sortedArray[j + 1];
                        sortedArray[j + 1] = temp;
                    }
                }
            }
            return sortedArray;
        }

        static int[] InsertionSort(int[] array)
        {
            int[] sortedArray = array;

            for (int i = 1; i < sortedArray.Length; i++)
            {
                int currentElement = sortedArray[i];
                int j = i - 1;

                while (j >= 0 && sortedArray[j] > currentElement)
                {
                    sortedArray[j + 1] = sortedArray[j];
                    j--;
                }
                sortedArray[j + 1] = currentElement;
            }
            return sortedArray;
        }
    }
}