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
        public override void AddItem()
        {
            bool res = false;
            do
            {
                try
                {
                    string str = Console.ReadLine();
                    string[] str1 = str.Split();
                    Books book = new Books()
                    {
                        Name = str1[0],
                        Year = Int32.Parse(str1[1]),
                        Publisher = str1[2],
                        Count = Int32.Parse(str1[3]),
                        Author = str1[4],
                        Genre = str1[5],
                    };
                    int indexCopy = CheckCopy(book);
                    if (indexCopy == -1)
                    {
                        books.Add(book);
                        book.Code = count++;
                        Console.WriteLine("Новая запись создана"+'\n');
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
                                Console.WriteLine("Количество успешно добавлено"+'\n');
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
                //if (b.Name == name)
                if (b.Name.Contains(name))////////////изменение на contains
                {
                    Console.WriteLine("---------------------------");
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
                    code = IntInput();
                    int i = 0;
                    bool found = false;
                    while (i<items.Count && !found)
                    {
                        if (((Books)items[i]).Code == code) ///////неверная обработка случая если код не найден
                        {
                            found = true;
                            item = (Books)items[i];
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
                            Console.Write("Введите новое значение для параметра: ");
                            book.Name = Console.ReadLine();
                            break;
                        case "-year":
                            Console.Write("Введите новое значение для параметра: ");
                            book.Year = IntInput();
                            break;
                        case "-publisher":
                            Console.Write("Введите новое значение для параметра: ");
                            book.Publisher=Console.ReadLine();
                            break;
                        case "-count":
                            Console.Write("Введите новое значение для параметра: ");
                            book.Count = IntInput();
                            break;
                        case "-author":
                            Console.Write("Введите новое значение для параметра: ");
                            book.Author= Console.ReadLine();
                            break;
                        case "-genre":
                            Console.Write("Введите новое значение для параметра: ");
                            book.Genre = Console.ReadLine();
                            break;
                        case "":
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
            Books book = ShowItem(name);
            if (book != null)
            {
                string str;
                Console.WriteLine("Вы уверены, что хотите удалить эту книгу? (-y/-n)");
                do
                {
                    str = Console.ReadLine();
                } while (str != "-y" && str != "-n");
                if (str == "-y")
                {
                    books.Remove(book);
                    Console.WriteLine("Книга удалена");
                }
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
