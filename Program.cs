using System;

namespace Module_8{
    internal class Program{
        static void Main(){
            
        }
        public class Drive{ // класс Drive для представления диска в системе
            public Drive(string _name, long _totalSpace, long _freeSpace){
                Name = _name;
                TotalSpace = _totalSpace;
                FreeSpace = _freeSpace;
            }
            // инициализация свойства для хранения (Name TotalSpace FreeSpace) нового объекта в методе-конструкторе
            public string Name { get; }    
            public long TotalSpace { get; }
            public long FreeSpace { get; }
        }
        public enum DriveType{
            Usb,
            HDD,
            CD
        }
    }
}








