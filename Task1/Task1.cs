using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


//�������� ���������, ������� ������ ������ ��� ����� �� ������  � �����, ������� �� �������������� ����� 30 ����� 
namespace Task1{
    class Program{
        static void Main(){

            string _dir = @"C:\Users\uites\OneDrive\������� ����\���"; // ���������� ��������� �� ������

            Cleare(_dir); // ����� ������� ������ � ����������
        }

        static void Cleare(string _dir){
            if (Directory.Exists(_dir)){//�������� �� �������������
                DirectoryInfo _dirInfo = new DirectoryInfo(_dir);

                foreach (var dir in _dirInfo.GetDirectories()){ //����������
                    if (DateTime.Now - dir.LastAccessTime > TimeSpan.FromSeconds(1800)){ // ������� ��� �������� � ��������
                        dir.Delete(true);// ���� �����
                        Console.WriteLine("��������� �������� ���������� {0}", dir.Name);
                    }
                    else
                        Console.WriteLine("��� ���������� �� ������� ����������, ��� ��������");
                }

                foreach (var _file in _dirInfo.GetFiles()){ //�����
                    if (DateTime.Now - _file.LastAccessTime > TimeSpan.FromSeconds(1800)){
                        _file.Delete();// ��� true �� �����, � ����� ����� ���� �� �����
                        Console.WriteLine("��������� �������� ����� {0}", _file.Name);
                    }
                    else
                        Console.WriteLine("��� ���������� �� ������� ������, ��� ��������");
                }
            }

            else{Console.WriteLine("�������� ����");}
        }
    }
}