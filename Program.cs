using System;
using System.IO;


// Задание 8.4.1
class BinaryExperiment
{
    const string SettingsFileName = @"C:\Users\uites\OneDrive\Рабочий стол\BinaryFile.bin";

    static void Main()
    {
        // Считываем
        ReadValues();
    }

    static void ReadValues()
    {
       
        string StringValue;
        

        if (File.Exists(SettingsFileName))
        {
            // Создаем объект BinaryReader и инициализируем его возвратом метода File.Open.
            using (BinaryReader reader = new BinaryReader(File.Open(SettingsFileName, FileMode.Open)))
            {
                // Применяем специализированные методы Read для считывания соответствующего типа данных.
               
                StringValue = reader.ReadString();
                
            }

            Console.WriteLine("Из файла считано:");

            Console.WriteLine("Строка: " + StringValue);
            ;
        }
    }
}


