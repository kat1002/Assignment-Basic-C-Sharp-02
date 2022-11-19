using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment_Basic_C_Sharp_02
{

    internal class Maths_Handler
    {
        public bool checkNegative(string data, int pos)
        {
            if (data[pos - 1] < '0' || data[pos - 1] > '9') return true;
            return false;
        }
        public string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public bool isNegative(string num, string data, char condition, int pos)
        {
            int newPos = 0;
            switch (condition)
            {
                case '-':
                    newPos = pos - 1 - num.Length;
                    if (newPos == 0 && data[newPos] == '-') return true;
                    if (newPos >= 0 && data[newPos] == '-' && (data[newPos - 1] < '0' || data[newPos - 1] > '9')) return true;
                    break;

                case '+':
                    if (data[pos + 1] == '-') return true;
                    break;
            }

            return false;
        }
        
        public double TakeNumber(string data, char condition, int pos)
        {
            double num = new double();
            string Num = "";

            //Console.WriteLine(condition + " " + pos);
            //Console.WriteLine(data);

            switch (condition)
            {
                case '-':
                    for(int i = pos - 1; i >= 0; --i)
                    {
                        if (data[i] == '.' || isNegative(Num, data, '-', pos))
                        {
                            Num += data[i];
                            continue;
                        }
                        if (data[i] < '0' || data[i] > '9') break;
                        Num += data[i];
                    }
                    Num = Reverse(Num);
                    break;
                case '+':
                    for (int i = pos + 1; i < data.Length; ++i)
                    {
                        if (data[i] == '.' || isNegative(Num, data, '+', pos))
                        {
                            Num += data[i];
                            continue;
                        }
                        if (data[i] < '0' || data[i] > '9') break;
                        Num += data[i];
                    }
                    break;
            }
            
            //Console.WriteLine(Num);
            
            num = Convert.ToDouble(Num);
            return num;
        }

        public void CalculationMethod(char condition, int position, ref string data)
        {
            double result = 0, num1 = 0, num2 = 0;
            string numChange = "", _equa = "";

            switch (condition)
            {
                case '+':
                    num1 = TakeNumber(data, '-', position);
                    num2 = TakeNumber(data, '+', position);
                    result = num1 + num2;
                    numChange = result.ToString();
                    break;

                case '-':
                    num1 = TakeNumber(data, '-', position);
                    num2 = TakeNumber(data, '+', position);
                    result = num1 - num2;
                    numChange = result.ToString();
                    break;

                case '*':
                    num1 = TakeNumber(data, '-', position);
                    num2 = TakeNumber(data, '+', position);
                    result = num1 * num2;
                    numChange = result.ToString();
                    break;

                case '/':
                    num1 = TakeNumber(data, '-', position);
                    num2 = TakeNumber(data, '+', position);

                    if (num2 == 0)
                    {
                        Console.WriteLine("Cant divide by 0! Auto exit");
                        Console.ReadKey();
                        System.Environment.Exit(0);
                    }
                    
                    result = num1 / num2;
                    numChange = result.ToString();
                    break;
            }

            _equa = num1.ToString() + data[position] + num2.ToString();
            //Console.WriteLine(_equa);
            //Console.WriteLine(numChange);
            int pos = data.IndexOf(_equa);
            data = data.Remove(pos, _equa.Length).Insert(pos, numChange);
        }

        public string CalculationHandler(ref string data)
        {
            //Console.WriteLine("-------");
            while((data.IndexOf('*') != -1) || (data.IndexOf('/') != -1))
            {
                if(data.IndexOf('*') != -1)
                {
                    CalculationMethod(data[data.IndexOf('*')],data.IndexOf('*'), ref data);
                }
                if(data.IndexOf('/') != -1)
                {
                    CalculationMethod(data[data.IndexOf('/')], data.IndexOf('/'), ref data);
                }
            }

            while ((data.IndexOf('+') != -1) || (data.IndexOf('-') > 0))
            {
                if (data.IndexOf('-') > 0 && !checkNegative(data, data.IndexOf('-')))
                {
                    CalculationMethod(data[data.IndexOf('-')], data.IndexOf('-'), ref data);
                }
                else if(data.IndexOf('+') != -1)
                {
                    CalculationMethod(data[data.IndexOf('+')], data.IndexOf('+'), ref data);
                }
            }
            
            //Console.WriteLine(data);
            
            return data;
        }

    }
}
