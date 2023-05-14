using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


//�������� ���������, ������� ������� ������ ����� �� ����� (������ �� ����� ���������� ������� � �������). 
//�� ���� ����� ��������� URL ����������, � ����� � ������ � ������. 
namespace Task2{
    class Program{
        static void Main(){
            string _dir = @"C:\Users\uites\OneDrive\������� ����\���"; // ���������� ��������� �� ������

            long _sizeDir = 0;

            SizeInBytes(_dir, ref _sizeDir);

            Console.WriteLine("������ ���������� {0} ����", _sizeDir);
        }

        static void SizeInBytes(string _dir, ref long _sizeDir){
            if (Directory.Exists(_dir)){//�������� �� �������������
                DirectoryInfo _dirInfo = new DirectoryInfo(_dir);

                foreach (var _file in _dirInfo.GetFiles()){//�����
                    _sizeDir = _file.Length;
                }

                foreach (var dir in _dirInfo.GetDirectories()){// ����������
                    SizeInBytes(_dir, ref _sizeDir);
                }
            }
        }
    }
}