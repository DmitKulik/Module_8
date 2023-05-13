using System;
using System.IO;

namespace Module_8{
    internal class Program{
        static void Main()
        { // Получить все файлы и папки корневого каталога: 
            {
                GetCatalogs(); //   Вызов метода получения директорий
            }

            static void GetCatalogs()
            {
                string dirName = @"/"; // Прописываем путь к корневой директории MacOS (для Windows скорее всего тут будет "C:\\")
                if (Directory.Exists(dirName)) // Проверим, что директория существует
                {
                    Console.WriteLine("Папки:");
                    string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

                    foreach (string d in dirs) // Выведем их все
                        Console.WriteLine(d);

                    Console.WriteLine();
                    Console.WriteLine("Файлы:");
                    string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога

                    foreach (string s in files)   // Выведем их все
                        Console.WriteLine(s);

                }
                //метод, который считает количество файлов и папок в корне вашего диска и выводит итоговое количество объектов
                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(@"/" /* Или С:\\ для Windows */ );
                    if (dirInfo.Exists)
                    {
                        Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                    }

                    DirectoryInfo newDirectory = new DirectoryInfo(@"/newDirectory");// создание новой директории в корне вашего диска
                    if (!newDirectory.Exists)
                        newDirectory.Create();

                    Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                // метод удаления каталога
                try
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(@"/newDirectory");
                    dirInfo.Delete(true); // Удаление со всем содержимым
                    Console.WriteLine("Каталог удален");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}








