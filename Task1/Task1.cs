using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


//Напишите программу, которая чистит нужную нам папку от файлов  и папок, которые не использовались более 30 минут 
namespace Task1{
    class Program{
        static void Main(){

            string _dir = @"C:\Users\uites\OneDrive\Рабочий стол\ВОТ"; // директория находится по адресу

            Cleare(_dir); // метод очистки файлов и директории
        }

        static void Cleare(string _dir){
            if (Directory.Exists(_dir)){//проверка на существование
                DirectoryInfo _dirInfo = new DirectoryInfo(_dir);

                foreach (var dir in _dirInfo.GetDirectories()){ //директории
                    if (DateTime.Now - dir.LastAccessTime > TimeSpan.FromSeconds(1800)){ // условие для удаления в секундах
                        dir.Delete(true);// даем добро
                        Console.WriteLine("Произошло удаление директории {0}", dir.Name);
                    }
                    else
                        Console.WriteLine("Нет подходящих по условию директорий, для удаления");
                }

                foreach (var _file in _dirInfo.GetFiles()){ //файлы
                    if (DateTime.Now - _file.LastAccessTime > TimeSpan.FromSeconds(1800)){
                        _file.Delete();// тут true не нужно, в файле файла быть не может
                        Console.WriteLine("Произошло удаление файла {0}", _file.Name);
                    }
                    else
                        Console.WriteLine("Нет подходящих по условию файлов, для удаления");
                }
            }

            else{Console.WriteLine("Неверный путь");}
        }
    }
}