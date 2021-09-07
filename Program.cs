using System;
using System.IO;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /*
            string path = @"D:\XXX\WorkingFiles\C#_2021\Task1";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists){
                dirInfo.Create();
            }*/
            /*
            using (FileStream fstream = File.OpenRead($"{path}\\note.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");
            }*/
            /*
            string textFromFile;

            using (FileStream fstream = File.OpenRead($"{path}\\note.txt"))
            {
                byte[] array = new byte[fstream.Length];
                // асинхронное чтение файла
                await fstream.ReadAsync(array, 0, array.Length);

                textFromFile = System.Text.Encoding.Default.GetString(array);
                //Console.WriteLine($"Текст из файла: {textFromFile}");
            }
            */

            string file = File.ReadAllText("array1.txt");
            var info = file.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int[][] array = new int[info.Length][];

            foreach(var line in info)
            {
                var chars = line.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
                
                Console.WriteLine(i);

            Console.ReadKey();
        }
    }
}
