using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Theme_3.Библиотекарь
{
    class Base
    {
        public int Code { get; set; }
        public string Name { get; set; } 
        public int Year { get; set; }
        public string Publisher { get; set; }
        public int Count { get; set; }
        public virtual void ShowParameters(Base b)
        {
            Console.WriteLine("---------------------------");
            Console.Write("Код        ");
            Console.WriteLine(b.Code);
            Console.Write("Имя        ");
            Console.WriteLine(b.Name);
            Console.Write("Год        ");
            Console.WriteLine(b.Year);
            Console.Write("Издатель   ");
            Console.WriteLine(b.Publisher);
            Console.Write("Количество ");
            Console.WriteLine(b.Count);
        }
        public virtual void ShowCommandForParameters()
        {
            Console.WriteLine("Список команд для изменения параметров: ");
            Console.Write("-name -year -publisher -count ");
        }
        public int IntInput()
        {
            int x;
            bool check = Int32.TryParse(Console.ReadLine(), out x);
            while (!check)
            {
                Console.WriteLine("Неверный формат ввода, повторите попытку");
                check = Int32.TryParse(Console.ReadLine(), out x);
            }
            return x;
        }
        public bool YN_Verify()
        {
            string str = "";
            bool result;
            do
            {
                str = Console.ReadLine();
            } while (str != "-y" && str != "-n");
            if (str == "-y")
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
        public bool CopyVerify()
        {
            Console.WriteLine("Данный предмет уже есть в списке, создать для него новую запись? (-y/-n)");
            return YN_Verify();
        }
    }
}
