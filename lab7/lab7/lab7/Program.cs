using System;
using System.Collections.Generic;

namespace lab7
{
    class City
    {
        protected string name { get; set; }
        public City(string name)
        {
            this.name = name;
        }
    }

    class Building : City
    {
        protected string street { get; set; }
        protected int houseNumber { get; set; }
        protected double totalSquare { get; }
        public double payment { get; set; }
        public Building(string name, string street, int houseNumber, double totalSquare, double payment) : base(name)
        {
            this.street = street;
            this.houseNumber = houseNumber;
            this.totalSquare = totalSquare;
            this.payment = payment;
        }
    }

    class Rooms : Building
    {
        protected int number { get; set; }
        protected double square { get; set; }
        public Rooms(string name, string street, int houseNumber, double totalSquare, double payment, int number, double square) : base(name, street, houseNumber, totalSquare, payment)
        {
            this.number = number;
            this.square = square;
            //if (square == 0 || square < 0)
            //{
            //    throw new PloschaException($"ПОМИЛКА: Неможливо створити примiщення (зазначено некоректне значення площi - {square})");
            //}
        }
        public void PaymentApartment()
        {
            try
            {
                if (square == 0 || square < 0)
                {
                    throw new PloschaException($"ПОМИЛКА: Неможливо створити примiщення (зазначено некоректне значення площi - {square})");
                }
                else
                {
                    double res = Math.Round(payment * square, 2);
                    Console.WriteLine($"Цiна за оплату примiщення = {res} грн");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    class Flat : Rooms
    {
        protected List<string> fullName = new List<string>();
        public Flat(string name, string street, int houseNumber, double totalSquare, double payment, int number, double square) : base(name, street, houseNumber, totalSquare, payment, number, square) { }
        string x;
        protected void Add()
        {
            try
            {
                Console.WriteLine($"Квартира {number}");
                Console.WriteLine("Щоб додати мешканця у квартиру введiть лiтеру т, в iншому випадку введiть будь-що окрiм лiтери т");
                x = Console.ReadLine();
                while (x == "т")
                {
                    int q = -1; q++;
                    Console.WriteLine();
                    Console.Write($"ПIБ мешканця {fullName.Count + q}: ");
                    fullName.Add(Console.ReadLine());
                    Console.WriteLine();
                    Console.WriteLine("Додати ще мешканця?");
                    x = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        protected void Remove()
        {
            try
            {
                if (fullName.Count == 0)
                {
                    throw new KilkistException($"ПОМИЛКА: Вiдсутнiсть мешканцiв у квартирi");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Щоб видалити мешканця з квартири введiть лiтеру т, в iншому випадку введiть будь-що окрiм лiтери т");
                    x = Console.ReadLine();
                    while (x == "т")
                    {
                        Console.WriteLine();
                        Console.Write("Введiть номер особи: ");
                        int a = Convert.ToInt16(Console.ReadLine());
                        fullName.RemoveAt(a);
                        Console.WriteLine();
                        Console.WriteLine("Видалити ще мешканця?");
                        x = Console.ReadLine();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        protected void People()
        {
            try
            {
                if (fullName.Count != 0)
                {
                    Console.WriteLine();
                    Console.Write($"У квартрi {number} мешкає: "); ;
                    for (int i = 0; i < fullName.Count; i++)
                    {
                        Console.Write($"{fullName[i]}, ");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine();
        }
        public string Output()
        {
            try
            {
                Console.WriteLine($"Мiсто: {name}, вулиця: {street} {houseNumber}");
                Console.WriteLine($"Загальна площа будинку: {totalSquare}, базова щомiсячна оплата за кв.м площi {payment}");
                Console.WriteLine($"Номер квартири: {number}, площа квартири: {square}");
                PaymentApartment();
                Console.WriteLine();
                Add();
                Remove();
                People();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }
    }

    class Office : Rooms
    {
        protected string firm { get; set; }
        protected string activity { get; set; }
        public Office(string name, string street, int houseNumber, double totalSquare, double payment, int number, double square, string firm, string activity) : base(name, street, houseNumber, totalSquare, payment, number, square)
        {
            this.firm = firm;
            this.activity = activity;
        }
        public string Output()
        {
            try
            {
                Console.WriteLine($"Назва фiрми: {firm}, вид дiяльностi: {activity}");
                Console.WriteLine($"Мiсто: {name}, вулиця: {street} {houseNumber}");
                Console.WriteLine($"Загальна площа примiщення фiрми: {totalSquare}, базова щомiсячна оплата за кв.м площi {payment}");
                square = totalSquare;
                PaymentApartment();
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "";
        }
    }

    class KilkistException : Exception
    {
        public KilkistException(string aMessage) : base(aMessage) { }
    }

    class PloschaException : Exception
    {
        public PloschaException(string aMessage) : base(aMessage) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            City[] city = {
                new Flat("Кам'янець-Подiльський", "Шевченка", 9, 625, 4.752, 1, 42.5),
                new Flat("Кам'янець-Подiльський", "Шевченка", 9, 625, 4.752, 2, 0),
            };
            City[] city2 = {
                new Office("Київ", "Миру", 5, 813.67, 12.237, 0, 0, "ТОВ КиївБуд", "будiвництво"),
                new Office("Київ", "Київська", 3, 3271.15, 15.893, 0, 0, "ТОВ КиївАвто", "виготовлення автiвок")
            };
            foreach (Flat str in city)
            {
                Console.WriteLine(str.Output());
            }
            foreach (Office str in city2)
            {
                Console.WriteLine(str.Output());
            }
            Console.ReadKey();
        }
    }
}
