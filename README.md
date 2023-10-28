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
Если нарушен формат данных в файле с данными: программа не извлекает данные и не размещает их в структурах данных программы 2, а выводит информационное сообщение для пользователя.
