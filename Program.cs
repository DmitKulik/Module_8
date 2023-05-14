using Microsoft.VisualBasic.FileIO;
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

                DirectoryInfo newDirectory = new DirectoryInfo(@"C:\Users\uites\OneDrive\Рабочий стол\66");// создание новой директории в корне вашего диска
                if (!newDirectory.Exists)
                    newDirectory.Create();

                var newPath = @"C:\Users\uites\OneDrive\Рабочий стол\66";


                // перемещение файла в корзину
                if (File.Exists(newPath))
                {
                    FileSystem.DeleteFile(
                    newPath,
                    UIOption.AllDialogs,
                    RecycleOption.SendToRecycleBin);
                }

                // перемещение папки в корзину
                if (Directory.Exists(newPath))
                {
                    FileSystem.DeleteDirectory(
                    newPath,
                    UIOption.AllDialogs,
                    RecycleOption.SendToRecycleBin);
                }
            }
        }
    }
}








