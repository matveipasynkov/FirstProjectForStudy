//Пасынков Матвей Евгеньевич БПИ237-2 Вариант 12
public class KDZ_Project_2
{
    /// <summary>
    /// Метод считывания массива B из файла
    /// </summary>
    /// <param name="B"></param>
    public static void InputFromFile(out double[][] B)
    {
        string name, path = @""; //инициализация переменной имени файла;
                                         //а также путь файла.

        string dir = Directory.GetCurrentDirectory(); //Заметим, что файл-исполнитель лежит в
        char separator = Path.DirectorySeparatorChar; // ../KDZ/KDZ_Project_1/bin/Debug/net6.0,
        string[] cataloges = dir.Split(separator); //а итоговый файл, нам нужно открыть в ../KDZ.
        int index = Array.IndexOf(cataloges, "KDZ"); //Тогда найдём путь до папки KDZ.

        for (int i = 0; i <= index; ++i)
        {
            path += cataloges[i] + separator;
        }

        Console.Write("Введите имя файла: "); //вводим имя файла
        name = Console.ReadLine();
        string[] inputNumbers;
        try //пытаемся открыть
        {
            path += separator + name;
            inputNumbers = File.ReadAllLines(path);
        }
        catch (ArgumentException e) //рассматриваем различные ошибки и просим пользователя ввести заново название файла
        {
            Console.WriteLine("Введено недопустимое название файла.");
            Console.Write("Попробуйте ещё раз. ");
            InputFromFile(out B);
            return;
        }
        catch (IOException e)
        {
            Console.WriteLine("Возникла проблема с открытием файла.");
            Console.Write("Попробуйте ещё раз. ");
            InputFromFile(out B);
            return;
        }

        catch (System.UnauthorizedAccessException e)
        {
            Console.WriteLine("Отказано в доступе к папке. Проблема, наиболее вероятно, связана с неправильным названием файла.");
            Console.Write("Попробуйте ещё раз. ");
            InputFromFile(out B);
            return;
        }

        catch (Exception e)
        {
            Console.WriteLine($"Возникла непредвиденная проблема при открытии файла.");
            Console.Write("Попробуйте ещё раз. ");
            InputFromFile(out B);
            return;
        }

        //далее начинаем проверку формата файла. 
        if (inputNumbers.Length == 0)
        {
            Console.Write("Вы передали пустой файл. Попробуйте ещё раз. ");
            InputFromFile(out B);
            return;
        }

        //Дополнительно проверяем размерность массива ссылок, который должны передать в файле. 
        int m; 
        if (!int.TryParse(inputNumbers[0], out m))
        {
            Console.Write("Вы передали файл неккоректного формата. Попробуйте ещё раз. ");
            InputFromFile(out B);
            return;
        }
        else if (m < 0)
        {
            Console.Write("Размерность массива ссылок должна быть больше 0. Попробуйте ещё раз. ");
            InputFromFile(out B);
            return;
        }
        else if (m != inputNumbers.Length - 1)
        {
            Console.Write("Указанная размерность массива ссылок не соответствует действительному. Попробуйте ещё раз. ");
            InputFromFile(out B);
            return;
        }
        else if (m == 0)
        {
            Console.Write("В файле нет данных. Попробуйте ещё раз. ");
            InputFromFile(out B);
            return;
        }

        //создаём массив B, в котором сохраним данные
        B = new double[m][];
        bool flag = true;
        int n = 0;

        for (int i = 1; i <= m; ++i) //находим максимальную длину массивов
        {
            var numbers = inputNumbers[i].Split("  ");
            n = Math.Max(numbers.Length, n);
        }

        for (int i = 1; i <= m; ++i) //сохраняем данные из файла в массив ссылок B
        {
            var numbers = inputNumbers[i].Split("  ");

            B[i - 1] = new double[n];

            for (int j = 0; j < numbers.Length; ++j)
            {
                double num;
                if (!double.TryParse(numbers[j], out num)) //если элемент не double
                {
                    flag = false;
                }
                else
                {
                    B[i - 1][j] = num;
                }
            }
        }

        //если массив данных некорректен.
        if (flag == false)
        {
            Console.Write("Вы передали файл неккоректного формата. Попробуйте ещё раз. ");
            InputFromFile(out B);
            return;
        }
    }

    /// <summary>
    /// Метод из задачи для обработки double[][] B, и сохранения в аналогичную структуру double[][] C
    /// </summary>
    /// <param name="B"></param>
    /// <param name="C"></param>
    public static void Change(double[][] B, ref double[][] C)
    {
        int m, n = B.GetLength(0); //инициализируем параметры размерности
        C = new double[n][];
        for (int i = 0; i < n; ++i)
        {
            m = B[i].Length;
            C[i] = new double[m - 1];
            int index_now = Math.Min(i, m - 1); //index_now - индекс массива, который удаляется в B. Заметим, что строк у B может быть больше, чем столбцов.
                                                //Тогда если номер строки больше числа столбцов, то удаляем 
            for (int j = 0; j < index_now; ++j) //последний элемент строки, иначе делаем по условию. Поэтому index_now = Math.Min(i, m - 1).
            {
                C[i][j] = B[i][j];
            }
            for (int j = index_now + 1; j < m; ++j)
            {
                C[i][j - 1] = B[i][j];
            }
        }
    }

    /// <summary>
    /// Вывод массива ссылок
    /// </summary>
    /// <param name="B"></param>
    public static void PrintArray(double[][] B)
    {
        for (int i = 0; i < B.GetLength(0); ++i)
        {
            for (int j = 0; j < B[i].Length; ++j)
            {
                Console.Write($"{B[i][j]:f3} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        do
        {
            try
            {
                Console.Clear(); //очищаем консоль для более приятной работы

                double[][] B;
                InputFromFile(out B);

                double[][] C = new double[B.GetLength(0)][];
                Change(B, ref C);

                Console.WriteLine("До форматирования: ");
                PrintArray(B);

                Console.WriteLine("После форматирования: ");
                PrintArray(C);
            }
            catch
            {
                Console.WriteLine($"Возникла непредвиденная проблема при работе с файлом");
            }
            Console.WriteLine("Нажмите ESC, чтобы завершить работу программы. Если вы хотите продолжить, то нажмите любую другую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}