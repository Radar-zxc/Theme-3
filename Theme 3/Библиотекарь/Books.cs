using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Theme_3.Библиотекарь
{
    class Books:Base
    {
        public static ArrayList books = new ArrayList();
        public static int count = 0;
        public string Author { get; set; }
        public string Genre { get; set; }
        public void AddItem()
        {
            Books book = ReadParemeters();
            int indexCopy = CheckCopy(book);
            if (indexCopy == -1)
            {
                books.Add(book);
                book.Code = count++;
                Console.WriteLine("Новая запись создана" + '\n');
            }
            else
            {
                if (CopyVerify())
                {
                    books.Add(book);
                    book.Code = count++;
                    Console.WriteLine("Новая запись создана" + '\n');
                }
                else
                {
                    Console.WriteLine("Добавить количество к первой существующей записи? (-y/-n)");
                    if (YN_Verify())
                    {
                        ((Books)books[indexCopy]).Count += book.Count;
                        Console.WriteLine("Количество успешно добавлено" + '\n');
                    }
                }
            }
        }
        public Books ReadParemeters()
        {
            Books book = new Books();
            Console.Write("Введите название книги: ");
            book.Name = Console.ReadLine();
            Console.Write("Введите год издания книги: ");
            book.Year = IntInput();
            Console.Write("Введите издателя книги: ");
            book.Publisher = Console.ReadLine(); ;
            Console.Write("Введите количество книг: ");
            book.Count = IntInput();
            Console.Write("Введите имя автора книги: ");
            book.Author = Console.ReadLine();
            Console.Write("Введите жанр книги: ");
            book.Genre = Console.ReadLine();
            return book;
        }
        public int CheckCopy(Books j)
        {
            bool found = false;
            int i = 0;
            int copyIndex = -1;
            while (i < books.Count && !found)
            {
                if (((Books)books[i]).Name == j.Name && ((Books)books[i]).Year == j.Year &&
                    ((Books)books[i]).Publisher == j.Publisher && ((Books)books[i]).Count == j.Count &&
                    ((Books)books[i]).Author == j.Author && ((Books)books[i]).Genre == j.Genre)
                {
                    found = true;
                    copyIndex = ((Books)books[i]).Code;
                }
                i++;
            }
            return copyIndex;
        }
        public ArrayList ShowItems(string name)
        {
            int i = 0;
            ArrayList foundBooks = new ArrayList();
            foreach(Books b in books)
            {
                if (b.Name.Contains(name))
                {
                    ShowParameters(b);
                    i++;
                    foundBooks.Add(b);
                }
            };
            return foundBooks;
        }
        public override void ShowParameters(Base b)
        {
            base.ShowParameters(b);
            Books book = (Books)b;
            Console.Write("Автор      ");
            Console.WriteLine(book.Author);
            Console.Write("Жанр       ");
            Console.WriteLine(book.Genre);
            Console.WriteLine("---------------------------");
        }
        public Books ShowItem(string name)
        {
            ArrayList items = ShowItems(name);
            Books item =null;
            int code;
            switch (items.Count){
                case 0:
                    Console.WriteLine("Введенная книга не найдена");
                    break;
                case 1:
                    item = (Books)items[0];
                    break;
                default:
                    Console.Write("Введите код нужной книги: ");
                    bool found =false;
                    do
                    {
                        code = IntInput();
                        for (int i = 0; i < items.Count && !found; i++)
                        {
                            if (((Books)items[i]).Code== code)
                            {
                                found = true;
                                item = (Books)items[i];
                            }
                        }
                        if (found == false)
                        {
                            Console.WriteLine("Книги с таким кодом нет в списке, повторите ввод");
                        }
                    } while (found == false);
                    ShowParameters(item);
                    break;
            }
            return item;
        }
        public void ChangeItem(string name)
        {
            Books book  = ShowItem(name);
            string str="";
            if (book!= null)
            {
                bool away = false;
                do
                {
                    ShowCommandForParameters();
                    Console.WriteLine("-author -genre");
                    Console.WriteLine("Введите какой параметр вы хотите изменить: ");
                    str = Console.ReadLine();
                    switch (str)
                    {
                        case "-name":
                            Console.Write("Введите новое значение для параметра, после чего нажмите клавишу Enter: ");
                            book.Name = Console.ReadLine();
                            break;
                        case "-year":
                            Console.Write("Введите новое значение для параметра, после чего нажмите клавишу Enter: ");
                            book.Year = IntInput();
                            break;
                        case "-publisher":
                            Console.Write("Введите новое значение для параметра, после чего нажмите клавишу Enter: ");
                            book.Publisher=Console.ReadLine();
                            break;
                        case "-count":
                            Console.Write("Введите новое значение для параметра, после чего нажмите клавишу Enter: ");
                            book.Count = IntInput();
                            break;
                        case "-author":
                            Console.Write("Введите новое значение для параметра, после чего нажмите клавишу Enter: ");
                            book.Author= Console.ReadLine();
                            break;
                        case "-genre":
                            Console.Write("Введите новое значение для параметра, после чего нажмите клавишу Enter: ");
                            book.Genre = Console.ReadLine();
                            break;
                        case "":
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
            Books book = ShowItem(name);
            if (book != null)
            {
                string str;
                Console.WriteLine("Вы уверены, что хотите удалить эту книгу? (-y/-n)");
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
                    books.Remove(book);
                    Console.WriteLine("Книга удалена");
                }
            }
        }
    }
}
