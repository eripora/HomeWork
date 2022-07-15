using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace File_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для начала работы с файловым менеджером введите команду Help:");
            string name;
            bool end = true;
            do
            {
                name = Console.ReadLine();

                switch (name)
                {
                    case "Help":
                        Console.WriteLine("Info -Выводит список файлов в каталоге\nGoToC-Переход в каталог\nDeleteFile-Удаление файла по имени\nDeleteM-Удаление файла по маске\nCreateFile-Создание файла\nCopyFile-Копирование файла");
                        break;
                    case "Info":
                        List<string> q = new List<string>();
                        Console.WriteLine("Введите путь каталога");
                        string p = Console.ReadLine();
                        int s = 0;
                        DirectoryInfo dir = new DirectoryInfo(p);
                        foreach (var item in dir.GetFiles())
                        {
                            q.Add(item.Name);
                            s++;
                        }
                        bool flag = true;
                        while (flag)
                        {
                            flag = false;
                            for (int k = 0; k < s - 1; ++k)
                                if (q[k].CompareTo(q[k + 1]) > 0)
                                {
                                    string buf = q[k];
                                    q[k] = q[k + 1];
                                    q[k + 1] = buf;
                                    flag = true;
                                }
                        }
                        for (int k = 0; k < s; ++k)
                            Console.WriteLine("{0} ", q[k]);
                        break;


                    case "GoToC":
                        string filePath = "E:\\Новая папка\\Новая папка\\Новая папка";
                        string directoryName;
                        int i = 0;

                        while (filePath != null)
                        {
                            directoryName = Path.GetDirectoryName(filePath);
                            Console.WriteLine("GetDirectoryName('{0}') returns '{1}'",
                                filePath, directoryName);
                            filePath = directoryName;
                            if (i == 1)
                            {
                                filePath = directoryName + @"\";
                            }
                            i++;
                        }
                        break;

                    case "DeleteFile":
                        string DeleteThis;
                        string pyt;
                        Console.WriteLine("Введите имя");
                        DeleteThis = Console.ReadLine();
                        Console.WriteLine("Введите путь");
                        pyt = Console.ReadLine();
                        string[] Files = Directory.GetFiles(pyt);

                        foreach (string file in Files)
                        {
                            if (file.ToUpper().Contains(DeleteThis.ToUpper()))
                            {
                                File.Delete(file);
                            }
                        }
                        break;

                    case "DeleteM":
                        string DeleteThis1;
                        string path1;
                        Console.WriteLine("Введите маску");
                        DeleteThis1 = Console.ReadLine();
                        Console.WriteLine("Введите путь");
                        path1 = Console.ReadLine();
                        string[] files = Directory.GetFiles(path1, DeleteThis1);
                        Console.WriteLine("Всего файлов {0}.", files.Length);
                        foreach (string f in files)
                        {
                            Console.WriteLine(f);
                            File.Delete(f);
                        }

                        break;

                    case "CreateFile":
                        string path2;
                        Console.WriteLine("Введите путь куда создать и имя файла");
                        path2 = Console.ReadLine();
                        File.Create(path2);
                        break;

                    case "CopyFile":
                        Console.WriteLine("Введите путь копируемого файла");
                        string pathToFile = Console.ReadLine();
                        Console.WriteLine("Введите путь куда копировать");
                        string pathToFile1 = Console.ReadLine();
                        File.Copy(pathToFile, pathToFile1, true);
                        break;
                    case "Exit":
                        end = false;
                        break;

                    default:
                        Console.WriteLine("Введена не правильная команда");
                        break;
                }
            } while (end != false);
        }
    }
}

