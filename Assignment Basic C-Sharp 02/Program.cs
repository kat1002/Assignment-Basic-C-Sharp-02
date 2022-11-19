using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_Basic_C_Sharp_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartProgram:
            Main_Controller ctl = new Main_Controller();

            //Title
            string Title = "Assignment Basic C# 02";
            Console.SetCursorPosition((Console.WindowWidth - Title.Length) / 2, Console.CursorTop);
            Console.WriteLine(Title);

            //Input equation
            string input = "";
            ctl.Input(ref input);

            //Console.WriteLine(input);
            
            //Body

            ctl.Calculate(input);

            //End
            Console.Write("Do you want to end the program (Y/N): ");
            string option = Console.ReadLine();
            if(option == "y" || option == "Y") System.Environment.Exit(0);
            Console.Clear();
            goto StartProgram;
        }
    }
}
