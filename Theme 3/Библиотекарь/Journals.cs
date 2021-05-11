using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Theme_3.Библиотекарь
{
    class Journals:Base
    {
        public string Period { get; set; }
        public int SerialNumber { get; set; }
        public static int count = 0;
        public static ArrayList journals = new ArrayList();
        public override void ShowParameters(Base b)
        {
            base.ShowParameters(b);
            Journals journal = (Journals)b;
            Console.Write("Период     ");
            Console.WriteLine(journal.Period);
            Console.Write("Номер      ");
            Console.WriteLine(journal.SerialNumber);
            Console.WriteLine("---------------------------");
        }
        public override void AddItem()
        {
            bool res = false;
            do
            {
                try
                {
                    string str = Console.ReadLine();
                    string[] str1 = str.Split();
                    Journals journal = new Journals()
                    {
                        Name = str1[0],
                        Year = Int32.Parse(str1[1]),
                        Publisher = str1[2],
                        Count = Int32.Parse(str1[3]),
                        Period = str1[4],
                        SerialNumber = Int32.Parse(str1[5]),
                    };
                    int indexCopy = CheckCopy(journal);
                    if (indexCopy ==-1)
                    {
                        journals.Add(journal);
                        journal.Code = count++;
                        Console.WriteLine("Новая запись создана" + '\n');
                    }
                    else
                    {
                        if (CopyVerify())
                        {
                            journals.Add(journal);
                            journal.Code = count++;
                            Console.WriteLine("Новая запись создана" + '\n');
                        }
                        else
                        {
                            Console.WriteLine("Добавить количество к первой существующей записи? (-y/-n)");
                            if (YN_Verify()) 
                            {
                                ((Journals)journals[indexCopy]).Count += journal.Count;
                                Console.WriteLine("Количество успешно добавлено" + '\n');
                            }
                        }
                    }
                    res = true;
                }
                catch
                {
                    Console.WriteLine("Ошибка ввода, повторите попытку");
                }
            } while (!res);
        }
        public int CheckCopy(Journals j)
        {
            bool found = false;
            int i = 0;
            int copyIndex = -1;
            while(i < journals.Count && !found)
            {
                if (((Journals)journals[i]).Name == j.Name && ((Journals)journals[i]).Year == j.Year &&
                    ((Journals)journals[i]).Publisher == j.Publisher && ((Journals)journals[i]).Count == j.Count &&
                    ((Journals)journals[i]).Period == j.Period && ((Journals)journals[i]).SerialNumber == j.SerialNumber)
                {
                    found = true;
                    copyIndex = ((Journals)journals[i]).Code;
                }
                i++;
            }
            return copyIndex;
        }
        public ArrayList ShowItems(string name)
        {
            int i = 0;
            ArrayList foundJournals = new ArrayList();
            foreach (Journals b in journals)
            {
                if (b.Name == name)
                {
                    Console.WriteLine("---------------------------");
                    ShowParameters(b);
                    i++;
                    foundJournals.Add(b);
                }
            };
            return foundJournals;
        }
        public Journals ShowItem(string name)
        {
            ArrayList items = ShowItems(name);
            Journals item = null;
            int code;
            switch (items.Count)
            {
                case 0:
                    Console.WriteLine("Введенный журнал не найден");
                    break;
                case 1:
                    item = (Journals)items[0];
                    break;
                default:
                    Console.Write("Введите код нужного журнала: ");
                    code = IntInput();
                    int i = 0;
                    bool found = false;
                    while (i < items.Count && !found)
                    {
                        if (((Journals)items[i]).Code == code)
                        {
                            found = true;
                            item = (Journals)items[i];
                        }
                        i++;
                    }
                    ShowParameters(item);
                    break;
            }
            return item;
        }
        public void ChangeItem(string name)
        {
            Journals journal = ShowItem(name);
            string str = "";
            if (journal != null)
            {
                bool away = false;
                do
                {
                    ShowCommandForParameters();
                    Console.WriteLine("-period -serial_number");
                    Console.WriteLine("Введите какой параметр вы хотите изменить: ");
                    str = Console.ReadLine();
                    switch (str)
                    {
                        case "-name":
                            Console.Write("Введите новое значение для параметра: ");
                            journal.Name = Console.ReadLine();
                            break;
                        case "-year":
                            Console.Write("Введите новое значение для параметра: ");
                            journal.Year = IntInput();
                            break;
                        case "-publisher":
                            Console.Write("Введите новое значение для параметра: ");
                            journal.Publisher = Console.ReadLine();
                            break;
                        case "-count":
                            Console.Write("Введите новое значение для параметра: ");
                            journal.Count = IntInput();
                            break;
                        case "-period":
                            Console.Write("Введите новое значение для параметра: ");
                            journal.Period = Console.ReadLine();
                            break;
                        case "-serial_number":
                            Console.Write("Введите новое значение для параметра: ");
                            journal.SerialNumber = IntInput();
                            break;
                        default:
                            Guide.CommandVerify();
                            break;
                    }
                    do
                    {
                        Console.WriteLine("Завершить изменения (-y/-n) ? ");
                        str = Console.ReadLine();
                    } while (str != "-y" && str != "-n");
                    if (str == "-y")
                    {
                        away = true;
                    }
                } while (!away);
            }
        }
        public void DeleteItem(string name)
        {
            Journals journal = ShowItem(name);
            string str;
            Console.WriteLine("Вы уверены, что хотите удалить этот журнал? (-y/-n)");
            do
            {
                str = Console.ReadLine();
            } while (str != "-y" && str != "-n");
            if (str == "-y") { 
                journals.Remove(journal);
                Console.WriteLine("Журнал удален");
            }
        }
        public override void ReadFromFile()
        {

        }
        public override void ReadFromDataBase()
        {

        }
    }
}
