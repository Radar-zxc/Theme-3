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
        public void AddItem()
        {
            Journals journal = ReadParameters();
            int indexCopy = CheckCopy(journal);
            if (indexCopy == -1)
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
        }
        public Journals ReadParameters()
        {
            Journals journal = new Journals();
            Console.Write("Введите название журнала: ");
            journal.Name = Console.ReadLine();
            Console.Write("Введите год издания журнала: ");
            journal.Year = IntInput();
            Console.Write("Введите издателя журнала: ");
            journal.Publisher = Console.ReadLine(); ;
            Console.Write("Введите количество журналов: ");
            journal.Count = IntInput();
            Console.Write("Введите периодичность журнала: ");
            journal.Period = Console.ReadLine();
            Console.Write("Введите номер журнала: ");
            journal.SerialNumber = IntInput();
            return journal;
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
                if (b.Name.Contains(name))
                {
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
                    bool found = false;
                    do
                    {
                        code = IntInput();
                        for (int i = 0; i < items.Count && !found; i++)
                        {
                            if (((Journals)items[i]).Code == code)
                            {
                                found = true;
                                item = (Journals)items[i];
                            }
                        }
                        if (found == false)
                        {
                            Console.WriteLine("Журнала с таким кодом нет в списке, повторите ввод");
                        }
                    } while (found == false);
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
                            Console.Write("Введите новое значение для параметра, после чего нажмите клавишу Enter: ");
                            journal.Name = Console.ReadLine();
                            break;
                        case "-year":
                            Console.Write("Введите новое значение для параметра, после чего нажмите клавишу Enter: ");
                            journal.Year = IntInput();
                            break;
                        case "-publisher":
                            Console.Write("Введите новое значение для параметра, после чего нажмите клавишу Enter: ");
                            journal.Publisher = Console.ReadLine();
                            break;
                        case "-count":
                            Console.Write("Введите новое значение для параметра, после чего нажмите клавишу Enter: ");
                            journal.Count = IntInput();
                            break;
                        case "-period":
                            Console.Write("Введите новое значение для параметра, после чего нажмите клавишу Enter: ");
                            journal.Period = Console.ReadLine();
                            break;
                        case "-serial_number":
                            Console.Write("Введите новое значение для параметра, после чего нажмите клавишу Enter: ");
                            journal.SerialNumber = IntInput();
                            break;
                        default:
                            Console.WriteLine("Введена неизвестная команда");
                            break;
                    }
                    do
                    {
                        Console.WriteLine("Завершить изменения (-y/-n) ? ");
                        str = Console.ReadLine();
                        if (str != "-y" && str != "-n")
                        {
                            Console.WriteLine("Введена неизвестная команда, повторите ввод");
                        }
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
            if (journal != null)
            {
                string str;
                Console.WriteLine("Вы уверены, что хотите удалить этот журнал? (-y/-n)");
                do
                {
                    str = Console.ReadLine();
                    if (str != "-y" && str != "-n")
                    {
                        Console.WriteLine("Введена неизвестная команда, повторите ввод");
                    }
                } while (str != "-y" && str != "-n");
                if (str == "-y")
                {
                    journals.Remove(journal);
                    Console.WriteLine("Журнал удален");
                }
            }
        }
    }
}
