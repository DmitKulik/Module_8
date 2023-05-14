using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


//Напишите программу, которая считает размер папки на диске (вместе со всеми вложенными папками и файлами). 
//На вход метод принимает URL директории, в ответ — размер в байтах. 
namespace Task2{
    class Program{
        static void Main(){
            string _dir = @"C:\Users\uites\OneDrive\Рабочий стол\ВОТ"; // директория находится по адресу

            long _sizeDir = 0;

            SizeInBytes(_dir, ref _sizeDir);

            Console.WriteLine("Размер директории {0} байт", _sizeDir);
        }

        static void SizeInBytes(string _dir, ref long _sizeDir){
            if (Directory.Exists(_dir)){//проверка на существование
                DirectoryInfo _dirInfo = new DirectoryInfo(_dir);

                foreach (var _file in _dirInfo.GetFiles()){//файлы
                    _sizeDir = _file.Length;
                }

                foreach (var dir in _dirInfo.GetDirectories()){// директории
                    SizeInBytes(_dir, ref _sizeDir);
                }
            }
        }
    }
}