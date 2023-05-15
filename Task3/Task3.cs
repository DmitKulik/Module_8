using System;
using System.IO;


/* 1 задание + 
Показать, сколько весит папка до очистки. Использовать метод из задания 2. 
Выполнить очистку.
Показать сколько файлов удалено и сколько места освобождено.
Показать, сколько папка весит после очистки.
*/
namespace Task3{
    class Program{
        static void Main(){

            string _dir = @"C:\Users\uites\OneDrive\Рабочий стол\ВОТ";

            long _sizeDirBefore = 0;
            long _sizeDirAfter = 0;

            SizeInBytes(_dir, ref _sizeDirBefore);

            Console.WriteLine("Размер директории {0} байт", _sizeDirBefore);

            Cleare(_dir);
            SizeInBytes(_dir, ref _sizeDirAfter);

            Console.WriteLine("Удалено {0} байт", _sizeDirBefore);
            Console.WriteLine("Размер директории {0} байт", _sizeDirAfter);
        }

        static void SizeInBytes(string _dir, ref long _sizeDir){

            if (Directory.Exists(_dir)){
                DirectoryInfo _dirInfo = new DirectoryInfo(_dir);

                foreach (var _file in _dirInfo.GetFiles()){
                    _dir += _file.Length;
                }

                foreach (var _dirin in _dirInfo.GetDirectories()){
                    SizeInBytes(_dir, ref _sizeDir);
                }
            }
        }
        static void Cleare(string _dir){

            if (Directory.Exists(_dir)){//проверка на существование
                DirectoryInfo _dirInfo = new DirectoryInfo(_dir);

                foreach (var _direct in _dirInfo.GetDirectories()){ //директории

                    if (DateTime.Now - _direct.LastAccessTime > TimeSpan.FromSeconds(1800)){ // условие для удаления в секундах
                        _direct.Delete(true);// даем добро
                        Console.WriteLine("Произошло удаление директории {0}", _direct.Name);
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

            else { Console.WriteLine("Неверный путь"); }
        }
    }
}