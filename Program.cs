using System;
using System.IO;

namespace Module_8
{
    internal class Program
    {
        static void Main()
        { // Получить все файлы и папки корневого каталога: 
            {
                GetCatalogs(); //   Вызов метода получения директорий
            }

            static void GetCatalogs()
            {

                DirectoryInfo newDirectory = new DirectoryInfo(@"C:/1/newDirectory");// создание новой директории в корне вашего диска
                if (!newDirectory.Exists)
                    newDirectory.Create();


                DirectoryInfo dirInfo = new DirectoryInfo(@"C:/1/newDirectory");
                string newPath = @"C://RECYCLE"; // тут нужно к корзине обратиться но пока не понял как

                if (dirInfo.Exists && !Directory.Exists(newPath))
                    dirInfo.MoveTo(newPath);
            }
        }
    }
}








