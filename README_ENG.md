# FirstProjectForStudy
This is my first project that was assigned as homework in higher education.

# Task
## Project 1
The user should enter integer values N and M from the keyboard, where 0 < N ≤ 13; 0 < M ≤ 17. 

Next, we need to create a method that creates an array of N one-dimensional arrays of size M each, where the values of the elements of A are assigned in a row (without taking into account dimension transitions) according to the formula: ((6 * n ^ 2 + 3 * n + 2) / (6 * n ^ 2 + 3 * n + 3)) ^ n, n >= 0 is an integer. Moreover, A is passed with the out modifier, and the method itself returns the void type.  

For example, N = 3 and M = 4 generated arrays of arrays (an example with data rounding for convenience of presentation in the task) can look like this:  
1,00 0,92 0,94 0,96  
0,96 0,97 0,97 0,98  
0,98 0,98 0,98 0,99  

The obtained array should be written to a text file, the name of which the user enters from the keyboard. The location of the file is the folder with the solution, above the level of both project folders. When the solution is restarted, a new data file is created on the new input data; the name is requested from the user again. If the file already exists, the data in it is overwritten. The first line of the file specifies the dimensionality of the reference array (an integer). Then on each line of the file, the array pointed to by the next reference of the reference array; elements are separated by exactly two spaces; numbers are formatted to 3 digits after the decimal separator.  

Example:  
3  
1,000 0,917 0,940 0,955  
0,964 0,971 0,975 0,978  
0,981 0,983 0,984 0,986  

## Project 2
The program receives file names for reading from the user and reads files of the format defined by the output data format requirements of project 1.  
If the file is not found on the disk / not opened for arbitrary reasons: the program displays an information message to the user.  
If the data format in the data file is broken: the program does not extract the data and does not place it in the data structures of project 2, but displays an information message to the user.
If the file exists on disk, has been successfully opened and contains data of a valid format: the program creates data structure B (an array of real one-dimensional arrays).  

Next, a method must be created where a reference to B and a new reference to a similar structure C are passed by value.  
After that, the following operation should be performed: Compress each row by one element with a shift to the left. The element index is determined by the line index. Thus, in the zero line the zero element will disappear, in the first line - the first element, etc. The size of each one-dimensional array is reduced by one after compression.  

For example, from structure B before processing (an example with data rounding for convenience of presentation in the variant):  
1,00 0,92 0,94 0,96  
0,96 0,97 0,97 0,98  
0,98 0,98 0,98 0,99  

Post-treatment:  
0,92 0,94 0,96  
0,96 0,97 0,98  
0,98 0,98 0,99  

The results of data transformations B are written to the structure C and become available to the calling code.  
At the end, the program displays the data before and after the changes on the screen in formatted form, i.e. line by line, separating elements by a single space and formatted with the precision specified when the file was created in project 1. 

## General program requirements
1) all program code should be written in the C# programming language, taking into account the use of .net 6.0.
2) the source code must contain comments explaining non-obvious fragments and solutions, code summary, description of code goals (see materials of lecture 1).
3) identifiers used in the program must comply with the rules and conventions of C# identifier naming (https://learn.microsoft.com/ruru/dotnet/csharp/fundamentals/coding-style/identifier-names).
4) the code submitted for verification must conform to Microsoft's general C# code conventions
(https://learn.microsoft.com/ru-ru/dotnet/csharp/fundamentals/coding-style/codingconventions).
5) when moving the project folder (copying / transferring to another device), the files must be opened by the program as successfully as on the creator's computer, i.e. regardless of the paths.
6) if data is loaded from a non-rectangular representation into a rectangular one, the missing elements on the right side are completed with zero real values.
7) the program does not allow the user to solve problems while incorrect data is entered from the keyboard.
8) the program handles exceptional situations related to (1) input and conversion / conversion of data both from the keyboard and from files; (2) to the
creation, initialization, access to array and string elements.
9)  both programs submitted for testing must solve all the tasks, compile successfully, not close without explanations in case of incorrect variants of operation and not crash.
