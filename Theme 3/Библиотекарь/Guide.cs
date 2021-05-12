using System;
using System.Collections.Generic;
using System.Text;

namespace Theme_3.Библиотекарь
{
    static class Guide
    {
        public static string CurrentCommand { get; set; }
        public static void ShowCommands()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Ввод новой книги: -book");
            Console.WriteLine("Ввод нового журнала: -journal");
            Console.WriteLine("Изменение параметров позиции: -change");
            Console.WriteLine("Поиск позиции по названию и ее вывод на экран: -search");
            Console.WriteLine("Удаление существующей позиции: -delete");
            Console.WriteLine("Справка: -help");
            Console.WriteLine("Завершение работы: -end");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~"+'\n');
        }
        public static void MessageNewBook()
        {
            Console.WriteLine("Введите параметры книги каждый в новой строке: " +
                "Название ГодВыпуска Издатель Количество Автор Жанр" );
        }
        public static void MessageNewJournal()
        {
            Console.WriteLine("Введите параметры журнала каждый в новой строке: " +
                "Название ГодВыпуска Издатель Количество Периодичность Номер");
        }
        public static void SearchBook()
        {
            Console.Write("Введите имя книги, которую нужно найти : ");
        }
        public static void DeleteBook()
        {
            Console.Write("Введите имя книги, которую нужно удалить : ");
        }
        public static void ChangeBook()
        {
            Console.Write("Введите имя книги, данные о которой нужно изменить : ");
        }
        public static void SearchJornal()
        {
            Console.Write("Введите имя журнала, который нужно найти : ");
        }
        public static void DeleteJournal()
        {
            Console.Write("Введите имя журнала, который нужно удалить : ");
        }
        public static void ChangeJournal()
        {
            Console.Write("Введите имя журнала, данные о котором нужно изменить : ");
        }
        public static void CommandVerify()
        {
            string cmd;
            do
            {
                Console.WriteLine("Неверный формат ввода, повторите попытку");
                CurrentCommand = Console.ReadLine();
                cmd= CurrentCommand;
            } while (cmd != "-book" && cmd != "-journal" && cmd != "-change" &&
                cmd != "-search" && cmd != "-delete" && cmd != "-end" && cmd !="-help");
        }
        public static string BookOrJournal()
        {
            Console.WriteLine("Введите команду -book или -journal");
            CurrentCommand = Console.ReadLine();
            if (CurrentCommand!= "-book" && CurrentCommand!= "-journal")
            {
                VerifyBookOrJournal();
            }
            return CurrentCommand;
        }
        public static void VerifyBookOrJournal()
        {
            bool verify = false;
            while (!verify)
            {
                Console.WriteLine("Введена неверная команда, повторите ввод");
                CurrentCommand = Console.ReadLine();
                if (CurrentCommand == "-book" || CurrentCommand == "-journal")
                {
                    verify = true;
                }
            }
        }
        public static void GetCommand()
        {
            Books book = new Books();
            Journals journal = new Journals();
            bool away = false;
            bool verify = false;
            ShowCommands();
            do
            {
                if (!verify)
                {
                    Console.WriteLine("Введите команду ");
                    CurrentCommand = Console.ReadLine();
                }
                verify = false;
                string res = "";
                switch (CurrentCommand)
                {
                    case "-book":
                        MessageNewBook();
                        book.AddItem();
                        break;
                    case "-journal":
                        MessageNewJournal();
                        journal.AddItem();
                        break;
                    case "-change":
                        Console.WriteLine("Изменить параметры книги или журнала ?");
                        res = BookOrJournal();
                        if (res == "-book")
                        {
                            Console.WriteLine("Введите имя книги: ");
                            res = Console.ReadLine();
                            book.ChangeItem(res);
                        }
                        else
                        {
                            Console.WriteLine("Введите имя журнала: ");
                            res = Console.ReadLine();
                            journal.ChangeItem(res);
                        }
                        break;
                    case "-search":
                        res = BookOrJournal();
                        if (res == "-book")
                        {
                            Console.WriteLine("Введите имя книги: ");
                            res = Console.ReadLine();
                            book.ShowItem(res);
                        }
                        else
                        {
                            Console.WriteLine("Введите имя журнала: ");
                            res = Console.ReadLine();
                            journal.ShowItem(res);
                        }
                        break;
                    case "-delete":
                        res = BookOrJournal();
                        if (res == "-book")
                        {
                            Console.WriteLine("Введите имя книги: ");
                            res = Console.ReadLine();
                            book.DeleteItem(res);
                        }
                        else
                        {
                            Console.WriteLine("Введите имя журнала: ");
                            res = Console.ReadLine();
                            journal.DeleteItem(res);
                        }
                        break;
                    case "-help":
                        ShowCommands();
                        break;
                    case "-end":
                        away = true;
                        break;
                    default:
                        CommandVerify();
                        verify = true;
                        break;
                }
            } while (!away);
        }
    }
}
