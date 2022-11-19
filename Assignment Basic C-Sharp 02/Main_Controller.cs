using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;       

namespace Assignment_Basic_C_Sharp_02
{   
    internal class Main_Controller
    {
        Maths_Handler mhl = new Maths_Handler();

        #region Input

        public bool CheckInput(string data)
        {
            if (data.IndexOf("**") != -1 || data.IndexOf("++") != -1 || data.IndexOf("//") != -1) return false;

            data = data.Trim();
            for (int index = 0; index < data.Length; ++index)
            {
                if ((data[index] >= 32 && data[index] <= 57) || (data[index] == '[') || (data[index] == ']') || (data[index] == '{') || (data[index] == '}'))
                {
                    continue;
                }
                return false;
            }

            return true;
        }
        public string Format(string data)
        {
            string res = "";
            data = data.Trim();
            for (int index = 0; index < data.Length; ++index)
            {
                if (data[index] == ' ') continue;
                if (data[index] == '[' || data[index] == '{')
                {
                    res += '(';
                    continue;
                }
                if (data[index] == ']' || data[index] == '}')
                {
                    res += ')';
                    continue;
                }
                res += data[index];
            }
            
            while(res.IndexOf("  ") != -1)
            {
                res.Remove(res.IndexOf("  "), 1);
            }
            
            return res;
        }

        public void Input(ref string input)
        {
            StartInput:

            Console.Write("Enter your equation: ");
            input = Console.ReadLine();
            input = input.Trim();
            if (!CheckInput(input))
            {
                Console.WriteLine("Wrong input! Please try again!");
                goto StartInput;
            }
            input = Format(input);
        }

        #endregion

        #region Calculation Method

        public string querBac1(string _equa)
        {
            return mhl.CalculationHandler(ref _equa);
        }

        public string Calculating(string data)
        {
            int checkParent = 0;
            string _recur="";
            string _return="";
            foreach (var element in data)
            {
                if (element == '(')
                {
                    if (checkParent == 0)
                    {
                        _recur = "";
                    }
                    checkParent++;
                    if(checkParent > 1) _recur += "(";
                }
                else if (element == ')')
                {
                    if (checkParent > 1) _recur += ")";
                    checkParent--;
                    if (checkParent == 0)
                    {
                        _return += Calculating(_recur);
                    }
                }
                else
                {
                    if (checkParent == 0)
                    {
                        _return += element;
                    }

                    else
                    {
                        _recur += element;
                    }
                }
            
            }

            return querBac1(_return);
        }
        
        public void Calculate(string data)
        {
            Console.WriteLine(Calculating(data));
        }

        #endregion
    }
}
