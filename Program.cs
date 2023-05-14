using Microsoft.VisualBasic.FileIO;
using System;
using System.IO;

namespace Module_8
{
    internal class Program
    {
        static void Main(){ // ������ � ���� Program.cs ������� ���� � �����
            var FileInfo = new FileInfo(@"C:\Users\uites\source\repos\Module_8\Program.cs"); // ���� �� �����
           
            
                using (StreamWriter _sw = FileInfo.AppendText()){
                    _sw.WriteLine("// Time:" + DateTime.Now);
                }
            
            // ��������� ���� � ������ ��� ����������
            using (StreamReader _sr = FileInfo.OpenText()){
                string str = "";
                while ((str = _sr.ReadLine()) != null){ // ���� �� �������� ������ - ��������� �� ����� �� ����� � ������� � �������
                    Console.WriteLine(str);
                }
            }

        }
    }
}










// Time:14.05.2023 23:16:40
// Time:14.05.2023 23:17:11
