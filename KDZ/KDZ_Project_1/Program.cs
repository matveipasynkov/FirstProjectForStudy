//Пасынков Матвей Евгеньевич БПИ237-2 Вариант 12
public class KDZ_Project_1
{
    public static int Check_N(string n)
    {
        bool flag = false; //инициализируем флаг проверки корректности введённого N
        int number = 0; //переменная вывода
        while (!flag) //если N введено верно, то возвращаем N,
                      //иначе запускаем повторный ввод и просим пользователя ввести ещё раз N
        {
            if (int.TryParse(n, out number))
            {
                if (number > 0 && number <= 13)
                {
                    return number;
                }
                else
                {
                    Console.Write("Число N не лежит в ОДЗ попробуйте ещё раз: ");
                }
            }
            else
            {
                Console.Write("Введён неверный тип аргумента N, попробуйте ещё раз: ");
            }
            n = Console.ReadLine();
        }
        return 0;
    }

    public static int Check_M(string m)
    {
        bool flag = false; //инициализируем флаг проверки корректности введённого M
        int number = 0; //переменная вывода
        while (!flag) //если M введено верно, то возвращаем значение M,
                      //иначе запускаем повторный ввод и просим пользователя ввести ещё раз M
        {
            if (int.TryParse(m, out number))
            {
                if (number > 0 && number <= 17)
                {
                    return number;
                }
                else
                {
                    Console.Write("Число M не лежит в ОДЗ попробуйте ещё раз: ");
                }
            }
            else
            {
                Console.Write("Введён неверный тип аргумента M, попробуйте ещё раз: ");
            }
            m = Console.ReadLine();
        }
        return 0;
    }

    public static void Fill_A(int n, int m, out double[][] A)
    {
        int num = 0; //инициализируем n, которое из формулы в задании
        A = new double[n][]; //инициализируем A

        for (int i = 0; i < n; ++i) //заполняем A по формуле
        {
            A[i] = new double[m];
            for (int j = 0; j < m; ++j)
            {
                double numerator = (6 * num * num + 3 * num + 2);
                double denominator = (6 * num * num + 3 * num + 3);
                A[i][j] = Math.Pow(numerator / denominator, num);
                ++num;
            }
        }
    }

    public static void OutputInFile(double[][] A, int n, int m)
    {
        string name, result, path = @""; //инициализация переменной имени файла;
                                         //строки элементов массива, которая должна
                                         //сохраниться в файле;
                                         //а также путь файла.

        string dir = Directory.GetCurrentDirectory(); //Заметим, что файл-исполнитель лежит в
        char separator = Path.DirectorySeparatorChar; // ../KDZ/KDZ_Project_1/bin/Debug/net6.0,
        string[] cataloges = dir.Split(separator); //а итоговый файл, нам нужно сохранить в ../KDZ.
        int index = Array.IndexOf(cataloges, "KDZ"); //Тогда найдём путь до папки KDZ.

        for (int i = 0; i <= index; ++i)
        {
            path += cataloges[i] + separator;
        }

        Console.Write("Введите имя файла: "); //вводим имя файла
        name = Console.ReadLine();

        try // пытаемся создать/перезаписать файл с данным от пользователя именем
        {                                         // в ../KDZ/имя_файла.txt
            path += separator;
            path += name;
            result = $"{n}\n";

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < m - 1; ++j)
                {
                    result += $"{A[i][j]:f3}  ";
                }
                result += $"{A[i][m - 1]:f3}\n";
            }


            File.WriteAllText(path, result);

            Console.WriteLine("Данные успешно записаны в указанный вами файл."); //сообщение об успешном выполнении
        }
        catch (ArgumentException e) //рассматриваем различные ошибки и просим пользователя ввести заново название файла
        {
            Console.WriteLine("Введено недопустимое название файла.");
            Console.Write("Попробуйте ещё раз. ");
            OutputInFile(A, n, m);
            return;
        }
        catch (IOException e)
        {
            Console.WriteLine("Возникла проблема с открытием файла.");
            Console.Write("Попробуйте ещё раз. ");
            OutputInFile(A, n, m);
            return;
        }

        catch (System.UnauthorizedAccessException e)
        {
            Console.WriteLine("Отказано в доступе к папке. Проблема, наиболее вероятно, связана с неправильным названием файла.");
            Console.Write("Попробуйте ещё раз. ");
            OutputInFile(A, n, m);
            return;
        }

        catch (Exception e)
        {
            Console.WriteLine($"Возникла непредвиденная проблема при записи результата.");
            Console.Write("Попробуйте ещё раз. ");
            OutputInFile(A, n, m);
            return;
        }
    }

    static void Main(string[] args)
    {
        do
        {
            try
            {
                Console.Clear();
                int n, m; //инициализация переменных и ввод пользователем чисел с проверкой введённых значений

                Console.Write("Введите N (от 1 до 13 включительно): ");
                n = Check_N(Console.ReadLine()); //вводим и проверяем n на корректность

                Console.Write("Введите M (от 1 до 17 включительно): ");
                m = Check_M(Console.ReadLine()); //вводим и проверяем m на корректность

                double[][] A;
                Fill_A(n, m, out A); //заполняем A

                OutputInFile(A, n, m); //вывод в файл
            }
            catch
            {
                Console.WriteLine("Возникла проблема с введёнными данными.");
            }
            Console.WriteLine("Нажмите ESC, чтобы завершить работу программы. Если вы хотите продолжить, то нажмите любую другую кнопку.");
        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}