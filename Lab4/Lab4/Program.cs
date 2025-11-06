using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Laba4
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
                Console.WriteLine("4. Игра 'Тетрис'");
                Console.WriteLine("5. Выход");
                Console.WriteLine("Ваш выбор:");
                int choice = IntCheck();

                switch (choice)
                {
                    case 1:
                        PlayGame();
                        break;
                    case 2:
                        Info();
                        break;
                    case 3:
                        Masiv();
                        break;
                    case 4:
                        PlayTetris();
                        break;
                    case 5:
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
                Console.WriteLine("Ошибка! Введите число:");
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

            double correctAnswer = Calculate();
            Console.WriteLine("Попробуйте угадать ответ. Сколько вам нужно попыток? Введите:");
            int tries = IntCheck();
            Console.WriteLine("У вас есть {0} попытки!", tries);
            double answer = DoubleCheck();

            if (answer != correctAnswer)
            {
                int counter = 1;
                while (counter < tries)
                {
                    if (answer != correctAnswer)
                        Console.WriteLine("Неверно! Осталось попыток {0}", tries - counter);
                    else
                    {
                        Console.WriteLine("Верно!");
                        break;
                    }
                    counter++;
                    answer = DoubleCheck();
                }
                if (counter == tries)
                    Console.WriteLine("Неверно! Осталось попыток {0}. Правильный ответ: {1}", tries - counter, correctAnswer);
            }
            else
                Console.WriteLine("Верно!");

            Console.WriteLine("Нажмите любую клавишу для выхода в меню...");
            Console.ReadKey();
            Console.Clear();
        }

        static double Calculate()
        {
            Console.WriteLine("Введите число а");
            double a = DoubleCheck();
            Console.WriteLine("Введите число b");
            double b = DoubleCheck();
            double f = Math.PI * ((Math.Log10(Math.Pow(b, 5))) / Math.Sin(a) + 1);
            double answer = Math.Round(f, 2);
            return answer;
        }

        static void Info()
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
                Console.WriteLine("Введите д или н");
                answer = Console.ReadLine().ToLower();
            }
            return answer == "д";
        }

        static void Masiv()
        {
            Console.WriteLine("Введите размер массива");
            int n = IntCheck();
            Console.WriteLine("Массив до сортировки:");

            int[] mass = MasivCreat(n);
            int[] massClone = MasivClone(mass);
            MassPrint(mass);

            Console.WriteLine("Массив после сортировки пузырьком");
            var bubbleWatch = Stopwatch.StartNew();
            MassPrint(BubbleSort(massClone));
            bubbleWatch.Stop();

            Console.WriteLine("Массив после сортировки вставкой");
            var insertWatch = Stopwatch.StartNew();
            MassPrint(InsertionSort(mass));
            insertWatch.Stop();

            Console.WriteLine("Время на сортировку пузырьком:{0}мс", bubbleWatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("Время на сортировку вставкой:{0}мс", insertWatch.Elapsed.TotalMilliseconds);
            Console.WriteLine("Нажмите любую клавишу для выхода в меню...");
            Console.ReadKey();
            Console.Clear();
        }

        static int[] MasivCreat(int n)
        {
            int[] masive = new int[n];
            int[] masive1 = RandomMasiv(masive, n);
            return masive1;
        }

        static int[] RandomMasiv(int[] a, int n)
        {
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                a[i] += rnd.Next(-1000000, 1000000);
            }
            return a;
        }

        static int[] MasivClone(int[] mass)
        {
            int[] masivClone = new int[mass.Length];
            for (int i = 0; i < mass.Length; i++)
            {
                masivClone[i] = mass[i];
            }
            return masivClone;
        }

        static void MassPrint(int[] mass)
        {
            if (mass.Length > 10)
            {
                Console.WriteLine("Длина массива больше 10. Невозможно вывести на экран");
            }
            else
            {
                Console.WriteLine("Ваш массив:");
                for (int i = 0; i < mass.Length; i++)
                {
                    Console.WriteLine(String.Format("m{0} = {1} ", i, mass[i]));
                }
            }
        }

        static int[] BubbleSort(int[] mass)
        {
            for (int i = 0; i < mass.Length - 1; i++)
            {
                for (int j = 0; j < mass.Length - i - 1; j++)
                {
                    if (mass[j] > mass[j + 1])
                    {
                        int temp = mass[j];
                        mass[j] = mass[j + 1];
                        mass[j + 1] = temp;
                    }
                }
            }
            return mass;
        }

        static int[] InsertionSort(int[] mass)
        {
            int newEl, location;
            for (int i = 1; i < mass.Length; i++)
            {
                newEl = mass[i];
                location = i - 1;
                while (location >= 0 && mass[location] > newEl)
                {
                    mass[location + 1] = mass[location];
                    location--;
                }
                mass[location + 1] = newEl;
            }
            return mass;
        }

        // ============ ТЕТРИС ============

        static void PlayTetris()
        {
            Console.Clear();
            Console.WriteLine(" === ТЕТРИС ===");
            Console.WriteLine("Управление:");
            Console.WriteLine("A - влево, D - вправо, S - вниз, W - поворот");
            Console.WriteLine("Q - выход в меню");
            Console.WriteLine("Нажмите любую клавишу для начала...");
            Console.ReadKey();

            TetrisGame game = new TetrisGame();
            game.Run();

            Console.Clear();
        }
    }

    // Класс для игры Тетрис
    class TetrisGame
    {
        private const int WIDTH = 10;
        private const int HEIGHT = 10;
        private char[,] field;
        private Tetromino currentPiece;
        private int currentX, currentY;
        private Random random;
        private int score;
        private bool gameOver;

        // Фигуры тетриса
        private static readonly char[][,] TETROMINOS = new char[][,]
        {
            new char[,] { { '█', '█', '█', '█' } }, // I
            new char[,] { { '█', '█' }, { '█', '█' } }, // O
            new char[,] { { ' ', '█', ' ' }, { '█', '█', '█' } }, // T
            new char[,] { { '█', ' ', ' ' }, { '█', '█', '█' } }, // L
            new char[,] { { ' ', ' ', '█' }, { '█', '█', '█' } }, // J
            new char[,] { { ' ', '█', '█' }, { '█', '█', ' ' } }, // S
            new char[,] { { '█', '█', ' ' }, { ' ', '█', '█' } }  // Z
        };

        public TetrisGame()
        {
            field = new char[HEIGHT, WIDTH];
            random = new Random();
            score = 0;
            gameOver = false;
            InitializeField();
            SpawnNewPiece();
        }

        // Инициализация игрового поля
        private void InitializeField()
        {
            for (int y = 0; y < HEIGHT; y++)
            {
                for (int x = 0; x < WIDTH; x++)
                {
                    field[y, x] = ' ';
                }
            }
        }

        // Создание новой фигуры
        private void SpawnNewPiece()
        {
            int pieceIndex = random.Next(TETROMINOS.Length);
            currentPiece = new Tetromino(TETROMINOS[pieceIndex]);
            currentX = WIDTH / 2 - currentPiece.Width / 2;
            currentY = 0;

            // Проверка на завершение игры
            if (CheckCollision(currentX, currentY, currentPiece.Shape))
            {
                gameOver = true;
            }
        }

        // Основной игровой цикл
        public void Run()
        {
            while (!gameOver)
            {
                DrawField();
                Console.WriteLine($"Очки: {score}");
                Console.WriteLine("Управление: A-влево, D-вправо, S-вниз, W-поворот, Q-выход");

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    ProcessInput(key);

                    if (key == ConsoleKey.Q)
                        break;
                }

                // Автоматическое падение
                if (!MovePiece(0, 1))
                {
                    LockPiece();
                    ClearLines();
                    SpawnNewPiece();
                }

                System.Threading.Thread.Sleep(200); // Задержка для игрового цикла
            }

            if (gameOver)
            {
                DrawField();
                Console.WriteLine("ИГРА ОКОНЧЕНА!");
                Console.WriteLine($"Финальный счет: {score}");
                Console.WriteLine("Нажмите любую клавишу...");
                Console.ReadKey();
            }
        }

        // Обработка ввода пользователя
        private void ProcessInput(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.A: // Влево
                    MovePiece(-1, 0);
                    break;
                case ConsoleKey.D: // Вправо
                    MovePiece(1, 0);
                    break;
                case ConsoleKey.S: // Вниз
                    MovePiece(0, 1);
                    break;
                case ConsoleKey.W: // Поворот
                    RotatePiece();
                    break;
            }
        }

        // Движение фигуры
        private bool MovePiece(int deltaX, int deltaY)
        {
            int newX = currentX + deltaX;
            int newY = currentY + deltaY;

            if (!CheckCollision(newX, newY, currentPiece.Shape))
            {
                currentX = newX;
                currentY = newY;
                return true;
            }
            return false;
        }

        // Поворот фигуры
        private void RotatePiece()
        {
            char[,] rotated = RotateMatrix(currentPiece.Shape);
            if (!CheckCollision(currentX, currentY, rotated))
            {
                currentPiece.Shape = rotated;
            }
        }

        // Проверка столкновений
        private bool CheckCollision(int x, int y, char[,] piece)
        {
            for (int py = 0; py < piece.GetLength(0); py++)
            {
                for (int px = 0; px < piece.GetLength(1); px++)
                {
                    if (piece[py, px] != ' ')
                    {
                        int fieldX = x + px;
                        int fieldY = y + py;

                        if (fieldX < 0 || fieldX >= WIDTH || fieldY >= HEIGHT)
                            return true;

                        if (fieldY >= 0 && field[fieldY, fieldX] != ' ')
                            return true;
                    }
                }
            }
            return false;
        }

        // Фиксация фигуры на поле
        private void LockPiece()
        {
            for (int py = 0; py < currentPiece.Shape.GetLength(0); py++)
            {
                for (int px = 0; px < currentPiece.Shape.GetLength(1); px++)
                {
                    if (currentPiece.Shape[py, px] != ' ')
                    {
                        int fieldX = currentX + px;
                        int fieldY = currentY + py;

                        if (fieldY >= 0)
                        {
                            field[fieldY, fieldX] = currentPiece.Shape[py, px];
                        }
                    }
                }
            }
        }

        // Очистка заполненных линий
        private void ClearLines()
        {
            int linesCleared = 0;

            for (int y = HEIGHT - 1; y >= 0; y--)
            {
                bool lineFull = true;
                for (int x = 0; x < WIDTH; x++)
                {
                    if (field[y, x] == ' ')
                    {
                        lineFull = false;
                        break;
                    }
                }

                if (lineFull)
                {
                    // Сдвиг всех строк выше вниз
                    for (int ny = y; ny > 0; ny--)
                    {
                        for (int x = 0; x < WIDTH; x++)
                        {
                            field[ny, x] = field[ny - 1, x];
                        }
                    }

                    // Очистка верхней строки
                    for (int x = 0; x < WIDTH; x++)
                    {
                        field[0, x] = ' ';
                    }

                    linesCleared++;
                    y++; // Проверяем ту же строку снова после сдвига
                }
            }

            // Начисление очков
            if (linesCleared > 0)
            {
                score += linesCleared * 100;
            }
        }

        // Отрисовка игрового поля
        private void DrawField()
        {
            Console.Clear();
            Console.WriteLine(" === ТЕТРИС ===");

            // Создаем временное поле для отрисовки с текущей фигурой
            char[,] tempField = (char[,])field.Clone();

            // Добавляем текущую фигуру на временное поле
            for (int py = 0; py < currentPiece.Shape.GetLength(0); py++)
            {
                for (int px = 0; px < currentPiece.Shape.GetLength(1); px++)
                {
                    if (currentPiece.Shape[py, px] != ' ')
                    {
                        int fieldX = currentX + px;
                        int fieldY = currentY + py;

                        if (fieldY >= 0 && fieldY < HEIGHT && fieldX >= 0 && fieldX < WIDTH)
                        {
                            tempField[fieldY, fieldX] = currentPiece.Shape[py, px];
                        }
                    }
                }
            }

            // Рисуем границы и поле
            Console.Write("┌");
            for (int x = 0; x < WIDTH; x++) Console.Write("──");
            Console.WriteLine("┐");

            for (int y = 0; y < HEIGHT; y++)
            {
                Console.Write("│");
                for (int x = 0; x < WIDTH; x++)
                {
                    Console.Write(tempField[y, x] + " ");
                }
                Console.WriteLine("│");
            }

            Console.Write("└");
            for (int x = 0; x < WIDTH; x++) Console.Write("──");
            Console.WriteLine("┘");
        }

        // Вращение матрицы (для поворота фигур)
        private char[,] RotateMatrix(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            char[,] rotated = new char[cols, rows];

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    rotated[x, rows - 1 - y] = matrix[y, x];
                }
            }

            return rotated;
        }
    }

    // Класс для представления тетромино
    class Tetromino
    {
        public char[,] Shape { get; set; }
        public int Width => Shape.GetLength(1);
        public int Height => Shape.GetLength(0);

        public Tetromino(char[,] shape)
        {
            Shape = shape;
        }
    }
}