using System;
using System.IO;

namespace Homework5Review
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            * Задание 1.
            * Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.
            */

            // Думаю ни для кого не секрет, что вызвать ввод с клавиатуры и поместить его в переменную можно через Console.ReadLine();
            var inputText = Console.ReadLine();

            // Для работы с файлами будем использовать класс File из пространства имен System.IO            
            // Запись строк (метод принимает массив из строк, но сам добавляет переносы строк в файл)
            File.WriteAllLines("task1_1.txt", new[] { inputText }); // https://docs.microsoft.com/en-us/dotnet/api/system.io.file.appendalllines?view=net-5.0
            // или можно таким образом, но добавлять перенос строки самостоятельно:
            File.WriteAllText("task1_2.txt", inputText + Environment.NewLine); // См. https://docs.microsoft.com/en-us/dotnet/api/system.io.file.appendalltext?view=net-5.0

            /*
            * Задание 2.
            * Написать программу, которая при старте дописывает текущее время в файл «startup.txt».
            */

            // Тут аналогично первому заданию нужно записывать в файл строку со временем.
            // Например таким образом:
            var startTimeText = $"{DateTime.Now.ToString()} - Запуск приложения";
            File.WriteAllText("startup.txt", inputText + Environment.NewLine);
            // Этот код можно поместить в отдельный файл и просто вызывать его первым в методы Main();


            /*
            * Задание 3.
            * Ввести с клавиатуры произвольный набор чисел (0...255) и записать их в бинарный файл.
            */

            // Вам необходимо распарсить строку на баты и записать их в файл.
            // Допустим, что пользователь ввел следующую строку:
            var inputBytesString = "1 40 20 2 32 34 5 200 128 93";

            // сперва разделяем строку по пробелам
            // См. https://docs.microsoft.com/en-us/dotnet/api/system.string.split?view=net-5.0
            var inputsArray = inputBytesString.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            // создаем массив для присвоения значений
            var byteArray = new byte[inputsArray.Length];

            // и парсим значения через цикл и заполняем массив
            for (int i = 0; i < inputsArray.Length; i++)
                byteArray[i] = byte.Parse(inputsArray[i]);

            // Полученный массив мы можем записать с помощью метода WriteAllBytes. См. https://docs.microsoft.com/en-us/dotnet/api/system.io.file.writeallbytes?view=net-5.0
            File.WriteAllBytes("task3.bin", byteArray);
            // Если открыть файл текстовым редактором, то можно увидеть, что не все символы читаемы

        }
    }
}
