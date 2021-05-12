using System;
using Theme_3.Библиотекарь;
namespace Theme_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Guide.GetCommand();
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
