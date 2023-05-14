using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;

namespace Module_8
{
    internal class Program
    {
        static void Main(){
            var _filePatch = @"C:\Users\uites\source\repos\Module_8\Program.cs"; // путь до файла
            if (!File.Exists(_filePatch)){ //проверка на существование файла по указанному пути
                //если не существует - создаем и записываем в него строки
                using (StreamWriter _sw = File.CreateText(_filePatch)){
                    _sw.WriteLine("My test string 88");
                }
            }
            // Открываем файл и читаем его содержимое
            using (StreamReader _sr = File.OpenText(_filePatch)){
                string str = "";
                while ((str = _sr.ReadLine()) != null){ // Пока не кончатся строки - считываем из файла по одной и выводим в консоль
                    Console.WriteLine(str);
                }
            }

        }
    }
}








