using System;
using output = System.Console;
using Theme_3.Библиотекарь;
namespace Theme_3
{
    class Program
    {
        static void Main(string[] args)
        {
;
            Guide.GetCommand();
            /*Guide.MessageNewBook();
            ((Books)b).AddItem();
            ((Books)b).AddItem();
            ((Books)b).ShowItem("sf");

            */
            /*Books book = new Books();
            Guide.ShowCommands();
            Guide.MessageNewBook();
            book.AddNewBook();
            book.Show();*/
            /*
            Console.WriteLine("Hello World!");
            Auto audi = new Auto("Boris" , 100,50,2);
            Auto bmw = new Auto();
            output.WriteLine(Auto.GetCountAuto());
            output.WriteLine(audi.Owner);
            output.WriteLine(audi.MaxSpeed);
            Console.WriteLine(audi.Price);
            Console.WriteLine(audi.Weels);
            Console.WriteLine("------------------");
            Console.WriteLine(bmw.Owner);
            Console.WriteLine(bmw.MaxSpeed);
            Console.WriteLine(bmw.Price);
            Console.WriteLine(bmw.Weels);
            Console.WriteLine("------------------");
            audi.MaxSpeed = 200;
            audi.Price = 1000;
            Console.WriteLine(audi.MaxSpeed);
            Console.WriteLine(audi.Price);
            Console.WriteLine(audi.Weels=6);
            double mark = audi.GetMark();
            Console.WriteLine(mark);
            audi.ExpandAuto(123, 321, 2);
            Console.WriteLine("------------------");
            Console.WriteLine(audi.MaxSpeed);
            Console.WriteLine(audi.Price);
            Console.WriteLine(audi.Weels);
            int ax = 4 , ay=5 , az=6;
            Console.WriteLine($"{ax} {ay} {az}");
            audi.RefExpandAuto(ref ax, ref ay, ref az);
            Console.WriteLine($"{ax} {ay} {az}");
            audi.OutExpandAuto(200,out int q , out int w , out int e );
            Console.WriteLine("------------------");
            Console.WriteLine($"{q} {w} {e}");
            Console.WriteLine(audi.AutoSum(1, 2, 3, 4, 5, 6));
            GC.Collect();
            Console.WriteLine("------------------");
            Object a = new Auto();
            ((Auto)a).ExpandAuto(1, 2, 3);
            //(Auto)a.ExpandAuto(1, 2, 3); // опечатка на 126 странице 
            Console.WriteLine(audi.ToString());
            Console.WriteLine(audi.Equals(a));
            ToyCar b = new ToyCar();
            b.Print(); //normal
            Auto c = new ToyCar();
            c.Print(); //override
            b.Print1(); // base.
            c.Print1(); // обращение к классу Auto сразу
            Cactus cac = new Cactus();
            cac.Draw();
            Wood wood = new Palm();
            wood.Draw();
            wood = new Cactus();
            wood.Draw();
            Wood c1 = new Cactus()
            {
                area = "West",
                smell = "Spicy",
                color = "Cool",
                ripe = false
            };
            Palm palm = new Palm()
            {
                area = "East",
                color = "Coller",
                heigth = 20
            };
            Console.WriteLine(c1.area + c1.color + ((Cactus)c1).smell ); // c1.smell нельзя просто получить свойство наследника , но можно присвоить
            Console.WriteLine(palm.area + palm.color + palm.heigth); // свойства наследника получить можно
            Console.WriteLine("------------------");
            ((Cactus)c1).PrintAttr();
            */
        }
    }
    class Auto
    {
        static int countAuto=0;
        private int price;
        public string Owner { get; set; }

        public int MaxSpeed { get; set; }

        public static int GetCountAuto()
        {
            return countAuto;
        }
        public int Price
        {
            get { return price; }
            set
            { if (value > 0) price = value; }
        }
        public int Weels { get; set; }
        public Auto(string owner , int cost , int speed , int weels)
        {
            Owner = owner;
            price = cost;
            MaxSpeed = speed;
            Weels = weels;
            countAuto++;
        }
        public Auto()
        {
            Owner = "Smith";
            price = 0;
            MaxSpeed = 1;
            Weels = 4;
            countAuto++;
        }
        public double GetMark()
        {
            return price * 0.015 * MaxSpeed;
        }
        public void ExpandAuto (int pr , int sp , int wee)
        {
            price += pr;
            MaxSpeed += sp;
            Weels += wee;
        }
        public void RefExpandAuto(ref int x, ref int y , ref int z)
        {
            ExpandAuto(x, y, z);
            x = price;
            y = MaxSpeed;
            z = Weels;
        }
        public void OutExpandAuto (int n , out int x ,out int y ,out int z)
        {
            ExpandAuto(n, n, n);
            x = 12;
            y = 21;
            z = 121;
        }
        public int AutoSum (params int [] numbers)
        {
            int sum = 0;
            foreach(int x in numbers){
                sum = sum + x;
            }
            return sum;
        }
        public override string ToString()
        {
            return "Владелец - " + Owner;
        }
        public new bool Equals(Object obj)
        {
            Auto a = (Auto)obj;
            return (a.price == a.Weels);
        }
        public virtual void Print()
        {
            Console.WriteLine("Класс предок");
        }
        public void Print1()
        {
            Console.WriteLine("Класс предок");
        }
    }
    class ToyCar : Auto
    {
       static Auto car = new ToyCar();
        public bool check()
        {
            return base.Equals(car);
        }
        public override void Print()
        {
            Console.WriteLine("Класс наследник");
        }
        public new void Print1()
        {
            //Console.WriteLine("Класс наследник");
            base.Print1();
        }
    }
    abstract class Wood
    {
        public string color { get; set; }
        public string area { get; set; }
        abstract public void Draw();
    }
    class Cactus: Wood
    {
        public string smell { get; set; }
        public bool ripe { get; set; }
        public override void Draw()
        {
            Console.WriteLine("Это кактус");
        }
        public void PrintAttr()
        {
            Console.WriteLine(smell);
            Console.WriteLine(ripe);
            Console.WriteLine(color);
            Console.WriteLine(area);
        }
    }
    class Palm : Wood
    {
        public int heigth { get; set; }
        public override void Draw()
        {
            Console.WriteLine("Это пальма");
        }
    }

}
