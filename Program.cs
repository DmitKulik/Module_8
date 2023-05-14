using System;
using System.IO;

class BinaryExperiment
{
    const string SettingsFileName = "Settings.cfg";

    static void Main()
    {
        // �����
        WriteValues();
        // ���������
        ReadValues();
    }

    static void WriteValues()
    {
        // ������� ������ BinaryWriter � ���������, ���� ����� ��������� ����� ������
        using (BinaryWriter writer = new BinaryWriter(File.Open(SettingsFileName, FileMode.Create)))
        {
            // ���������� ������ � ������ �������
            writer.Write(20.666F);
            writer.Write(@"�������� ������");
            writer.Write(55);
            writer.Write(false);
        }
    }

    static void ReadValues()
    {
        float FloatValue;
        string StringValue;
        int IntValue;
        bool BooleanValue;

        if (File.Exists(SettingsFileName))
        {
            // ������� ������ BinaryReader � �������������� ��� ��������� ������ File.Open.
            using (BinaryReader reader = new BinaryReader(File.Open(SettingsFileName, FileMode.Open)))
            {
                // ��������� ������������������ ������ Read ��� ���������� ���������������� ���� ������.
                FloatValue = reader.ReadSingle();
                StringValue = reader.ReadString();
                IntValue = reader.ReadInt32();
                BooleanValue = reader.ReadBoolean();
            }

            Console.WriteLine("�� ����� �������:");

            Console.WriteLine("�����: " + FloatValue);
            Console.WriteLine("������: " + StringValue);
            Console.WriteLine("�����: " + IntValue);
            Console.WriteLine("������ �������� " + BooleanValue);
        }
    }
}


