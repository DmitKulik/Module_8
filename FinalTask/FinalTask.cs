using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask{
    [Serializable]
    class Student{
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Student(string Name, string Group, DateTime DateOfBirth){

            this.Name = Name;
            this.Group = Group;
            this.DateOfBirth = DateOfBirth;
        }
    }
    class Program{
        static void Main(){

            string _programPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string _dir = Path.Combine(_programPath, "Students");
            string _filePath = Path.Combine(_programPath, "Students.dat");

            try{
                CreateDirectory(_dir);
                SortStudents(ref _dir, ref _filePath);
            }
            catch (Exception _ex){
                Console.WriteLine("Ошибка {0}", _ex.Message);
            }
        }

        static void CreateDirectory(string _dir){
            if (Directory.Exists(_dir)){
                DirectoryInfo _dirInfo = new DirectoryInfo(_dir);
                _dirInfo.Delete(true);
            }

            Directory.CreateDirectory(_dir);

            Console.WriteLine("Директория создана 'Students'.");
        }

        static Student[] FileSerializer(string _filePath)
        {

            BinaryFormatter _formatter = new BinaryFormatter();

            using var _fs = new FileStream(_filePath, FileMode.Open);
#pragma warning disable SYSLIB0011
            var _students = (Student[])_formatter.Deserialize(_fs);

            Console.WriteLine($"Десериализован файл {_filePath}.") ;

            return _students;
#pragma warning disable SYSLIB0011
        }

        static void SortStudents(ref string _dir, ref string _filePath)
        {

            var _students = FileSerializer(_filePath);

            foreach (var _student in _students){

                string _programPath = Path.Combine(_dir, _student.Group + ".txt");

                if (!File.Exists(_programPath)){

                    using (StreamWriter _sw = File.CreateText(_programPath)){

                        foreach (var _stud in _students){

                            if (_stud.Group == _student.Group){

                                _sw.WriteLine("{0} [{1}]", _stud.Name, _stud.DateOfBirth.ToShortDateString());
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Сортировка окончена");

            string[] _files = Directory.GetFiles(_dir);

            foreach (var _data in _files){Console.WriteLine(_data);}
        }
    }
}