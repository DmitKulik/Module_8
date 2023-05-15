using System;
using System.IO;


/* 1 ������� + 
��������, ������� ����� ����� �� �������. ������������ ����� �� ������� 2. 
��������� �������.
�������� ������� ������ ������� � ������� ����� �����������.
��������, ������� ����� ����� ����� �������.
*/
namespace Task3{
    class Program{
        static void Main(){

            string _dir = @"C:\Users\uites\OneDrive\������� ����\���";

            long _sizeDirBefore = 0;
            long _sizeDirAfter = 0;

            SizeInBytes(_dir, ref _sizeDirBefore);

            Console.WriteLine("������ ���������� {0} ����", _sizeDirBefore);

            Cleare(_dir);
            SizeInBytes(_dir, ref _sizeDirAfter);

            Console.WriteLine("������� {0} ����", _sizeDirBefore);
            Console.WriteLine("������ ���������� {0} ����", _sizeDirAfter);
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

            if (Directory.Exists(_dir)){//�������� �� �������������
                DirectoryInfo _dirInfo = new DirectoryInfo(_dir);

                foreach (var _direct in _dirInfo.GetDirectories()){ //����������

                    if (DateTime.Now - _direct.LastAccessTime > TimeSpan.FromSeconds(1800)){ // ������� ��� �������� � ��������
                        _direct.Delete(true);// ���� �����
                        Console.WriteLine("��������� �������� ���������� {0}", _direct.Name);
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

            else { Console.WriteLine("�������� ����"); }
        }
    }
}