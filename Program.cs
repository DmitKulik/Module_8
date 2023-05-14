using System;
using System.IO;


// ������� 8.4.1
class BinaryExperiment
{
    const string SettingsFileName = @"C:\Users\uites\OneDrive\������� ����\BinaryFile.bin";

    static void Main()
    {
        // ���������
        ReadValues();
    }

    static void ReadValues()
    {
       
        string StringValue;
        

        if (File.Exists(SettingsFileName))
        {
            // ������� ������ BinaryReader � �������������� ��� ��������� ������ File.Open.
            using (BinaryReader reader = new BinaryReader(File.Open(SettingsFileName, FileMode.Open)))
            {
                // ��������� ������������������ ������ Read ��� ���������� ���������������� ���� ������.
               
                StringValue = reader.ReadString();
                
            }

            Console.WriteLine("�� ����� �������:");

            Console.WriteLine("������: " + StringValue);
            ;
        }
    }
}


