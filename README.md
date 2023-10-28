# ProjectForUniversity1Rus (english version: soon)
Это мой первый проект, который был задан в качестве домашнего задания в вузе.

# Задание
## Проект 1
Пользователь должен ввести с клавиатуры целые значения N и M, где 0 < N ≤ 13; 0 < M ≤ 17. 

Далее необходимо создать метод, который создаёт массив из N одномерных массивов размера M каждый, где значения элементов A назначаются подряд (без учёта переходов по измерениям) по формуле: ((6 * n ^ 2 + 3 * n + 2) / (6 * n ^ 2 + 3 * n + 3)) ^ n, n >= 0 - целое. Причём A передаётся с модификатором out, а сам метод возвращает тип void.  

Например, N = 3 и M = 4 сформированные массивы массивов (пример с округлением данных для удобства представления в задании) могут выглядеть примерно так:  
1,00 0,92 0,94 0,96  
0,96 0,97 0,97 0,98  
0,98 0,98 0,98 0,99  

Полученный массив необходимо записать в текстовый файл, имя которого пользователь вводит с клавиатуры. Место размещения файла - папка с решением, выше уровня обоих папок проектов. При повторных запусках решения на новых входных данных создаётся новый файл для данных; имя запрашивается у пользователя повторно. Если файл уже существует, данные в нем перезаписываются. На первой строке файла указана размерность массива ссылок (целое число). Далее на каждой строке файла массив, на который указывает очередная ссылка массива ссылок; элементы разделяются ровно двумя пробелами; числа отформатированы с точностью 3 знака после десятичного разделителя.  

Пример:  
3  
1,000 0,917 0,940 0,955  
0,964 0,971 0,975 0,978  
0,981 0,983 0,984 0,986  

## Проект 2
Программа получает имена файлов для чтения от пользователя и читает файлы формата, определённого требованиями к формату выходных данных проекта 1.  
Если файл не обнаружен на диске / не открывается по произвольным причинам: программа выводит информационное сообщение пользователю.  
Если нарушен формат данных в файле с данными: программа не извлекает данные и не размещает их в структурах данных проекта 2, а выводит информационное сообщение для пользователя.
Если файл существует на диске, успешно открылся и содержит данные допустимого формата: программа создаёт структуру данных В (массив вещественных одномерных массивов).  

Далее должен быть создан метод, где по значению передается ссылка В и новая ссылка на аналогичную структуру С.  
После этого нужно произвести следующую операцию: Произвести сжатие каждой строки на один элемент со сдвигом влево. Индекс элемента определяется индексом строки. Так в нулевой строке исчезнет нулевой элемент, в первой – первый и т.д. Размер каждого одномерного массива после сжатия уменьшается на единицу.  

Например, из структуры В до обработки (пример с округлением данных для удобства представления в варианте):  
1,00 0,92 0,94 0,96  
0,96 0,97 0,97 0,98  
0,98 0,98 0,98 0,99  

После обработки:  
0,92 0,94 0,96  
0,96 0,97 0,98  
0,98 0,98 0,99  

Результаты преобразований данных В записываются в структуру C и становятся доступными вызывающему коду.  
В конце программа выводит данные до и после изменений на экран в отформатированном виде, то есть по строкам, разделяя элементы одним пробелом и форматируя с точностью, заданной при создании файла в проекте 1.  

## Общие требования к программе
1) весь программный код должен быть написан на языке программирования C# с учётом использования .net 6.0.
2) исходный код должен содержать комментарии, объясняющие неочевидные фрагменты и решения, резюме кода, описание целей кода (см. материалы лекции 1).
3) использованные в программе идентификаторы должны соответствовать правилам и соглашениям об именовании идентификаторов C# (https://learn.microsoft.com/ruru/dotnet/csharp/fundamentals/coding-style/identifier-names).
4) представленный к проверке код должен отвечать общим соглашениям о коде C# Microsoft
(https://learn.microsoft.com/ru-ru/dotnet/csharp/fundamentals/coding-style/codingconventions).
5) при перемещении папки проекта (копировании / переносе на другое устройство) файлы должны открываться программой также успешно, как и на компьютере создателя, т.е. вне зависимости от путей.
6) если загрузка данных происходит из непрямоугольного представления в прямоугольное, то недостающие элементы справа достраиваются нулевыми вещественными значениями.
7) программа не допускает пользователя до решения задач, пока вводятся некорректные данные с клавиатуры.
8) программа обрабатывает исключительные ситуации, связанные (1) со вводом и преобразованием / приведением данных как с клавиатуры, так и из файлов; (2) с
созданием, инициализацией, обращением к элементам массивов и строк.
9) обе представленные к проверке программы должны решать все поставленные задачи, успешно компилироваться, не закрываться без пояснений при некорректных вариантах
работы и не завешаться аварийно. 
