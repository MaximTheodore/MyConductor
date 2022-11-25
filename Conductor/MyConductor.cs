using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Conductor
{
    static class MyConductor
    {

      public static void MyDrivers()
        {
            Console.SetCursorPosition(50, 0);
            Console.WriteLine("Этот компьютер");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                Console.Write($"  {drive.Name}");
                
                if (drive.IsReady)
                {
                    Console.WriteLine($"  {drive.TotalFreeSpace/1024/1024/1024} Гб свободно из {drive.TotalSize/1024/1024/1024} Гб");
                }
               
            }
            MyArrow.Max = drives.Length;
            int selected = MyArrow.Checker(2, ref MyArrow.Max);
            MyDirectory(drives[selected-2].Name);
            MyArrow.Checker(2, ref MyArrow.Max);
        }
        private static void MyDirectory(string ty)
        {
            Console.Clear();
            Console.SetCursorPosition(30, 0);
            Console.WriteLine("Папка");
            Console.Write("------------------------------------------------------------------");
            Console.SetCursorPosition(5, 3);
            Console.Write("Название");
            Console.SetCursorPosition(35, 3);
            Console.WriteLine("Дата создания");
            Console.SetCursorPosition(63, 3);
            Console.WriteLine("Тип");
            DirectoryInfo[] dirs = new DirectoryInfo(ty).GetDirectories();
            int b = 4;
            foreach (DirectoryInfo s in dirs)
             {
                Console.SetCursorPosition(2, b);
                Console.Write($"{s.Name}");
                Console.SetCursorPosition(35, b);
                Console.Write($"{s.CreationTime}");
                Console.SetCursorPosition(62, b);
                Console.WriteLine($"{s.Extension} ");
                b=b+1;
             }
             MyArrow.Min =b - dirs.Length;
             MyArrow.Max = dirs.Length;
            int selected = MyArrow.Checker(MyArrow.Min, ref MyArrow.Max);
            AllFiles_in_directory(dirs[selected - 4].FullName);
            //MyArrow.Checker(MyArrow.Min, ref MyArrow.Max);
        }
        private static void AllFiles_in_directory(string i)
        {
            Console.Clear();
            Console.SetCursorPosition(30, 0);
            Console.WriteLine($"Папка {i}");
            Console.Write("------------------------------------------------------------------");
            Console.SetCursorPosition(5, 3);
            Console.Write("Название");
            Console.SetCursorPosition(53, 3);
            Console.WriteLine("Дата создания");
            Console.SetCursorPosition(78, 3);
            Console.WriteLine("Тип");
            var directory = new DirectoryInfo(i);
            int b = 4;
            if (directory.Exists) 
            { 
                DirectoryInfo[] dirs = directory.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    Console.SetCursorPosition(2, b);
                    Console.Write(dir.Name);
                    Console.SetCursorPosition(50, b);
                    Console.WriteLine(dir.CreationTime);
                    Console.SetCursorPosition(76, b);
                   
                    b++;
                }
                FileInfo[] files = directory.GetFiles();
                foreach (FileInfo file in files)
                {
                    Console.SetCursorPosition(2, b);
                    Console.WriteLine(file.Name);
                    Console.SetCursorPosition(50, b);
                    Console.WriteLine(file.CreationTime);
                    Console.SetCursorPosition(76, b);
                    Console.WriteLine(file.Extension);
                     b++;
                }
                MyArrow.Min = b - (dirs.Length + files.Length);
                MyArrow.Max = dirs.Length + files.Length+4;
                int selected = MyArrow.Checker(MyArrow.Min, ref MyArrow.Max);
                if (selected >= MyArrow.Min && selected-4 <= dirs.Length)
                {
                    AllFiles_in_directory(dirs[selected-4].FullName);
                 }
                else if (selected-4 > dirs.Length&& selected<=MyArrow.Max)
                {
                  Process.Start(new ProcessStartInfo { FileName = files[selected-dirs.Length-4].FullName, UseShellExecute = true });
                 }
                
            }
        }
       
    }
}
