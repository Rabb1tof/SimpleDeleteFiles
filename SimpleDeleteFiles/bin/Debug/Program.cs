using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDeleteFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Console.Write("Введите/вставьте путь к папке: ");
            string sourceDirectory = Console.ReadLine();

            Console.Write("Введите имя расширения для удаление (* - все файлы): ");
            string patternFind = Console.ReadLine();

            var files = Directory.GetFiles(sourceDirectory, patternFind, SearchOption.TopDirectoryOnly);

            Console.WriteLine("Будут удалены следующие файлы:");
            foreach (var file in files)
            {
                Console.WriteLine($"  -> {file}");
            }

            ConsoleKey key;
            do
            {
                Console.WriteLine("Подтвердите изменения нажатием на кнопку Enter.");
                key = Console.ReadKey().Key;
            } while (key != ConsoleKey.Enter);

            Console.WriteLine("Выполнение...");
            foreach (var file in files)
            {
                File.Delete(file);
            }
        }
    }
}