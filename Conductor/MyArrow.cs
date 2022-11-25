using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conductor
{
    internal class MyArrow
    {
        public static int Max;
        public static int Min;
        public static int Checker(int startPos , ref int count , string arrow = "->")
        {
            string empty = new string(' ', arrow.Length);
            int i = startPos;
            Console.SetCursorPosition(0, startPos);
            
            Console.Write(arrow);
            ConsoleKeyInfo key ;
            for (; ; )
            {

                key = Console.ReadKey(true);
                
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (i == count + startPos - 1)
                        continue;
                    Console.SetCursorPosition(0, i);
                    Console.Write(empty);
                    Console.SetCursorPosition(0, ++i);
                    Console.Write(arrow);
                }

                else if (key.Key == ConsoleKey.UpArrow)
                {
                    if (i == startPos)
                        continue;
                    Console.SetCursorPosition(0, i);
                    Console.Write(empty);
                    Console.SetCursorPosition(0, --i);
                    Console.Write(arrow);
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                   Console.Clear();
                   MyConductor.MyDrivers();
                    
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    return i;
                }

            }
           
        }
    }
}
