using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Memoery_management
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            Customer ali = new Customer();

            ali.FirstName = "ali";
            ali.LastName = "ali last";
            ali.Id = 1;
            ali.HomeAdress = new Adress() { City = "İstanbul", Street = "AliStreet", Country = "Turkey" };



            //Customer veli = ali;
            //Customer veli = ali.ShallowCopy();
            Customer veli = ali.DeepCopy();

            ali.FirstName = "new name";
            veli.HomeAdress.City = "Ankara";


            Console.WriteLine($"City : {ali.HomeAdress.City}");
            Console.WriteLine($"Name : {ali.FirstName}");
            Console.WriteLine($"LastName : {ali.LastName}");
            Console.WriteLine($"ID : {ali.Id}");

        }
    }

    [Serializable]
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Adress HomeAdress { get; set; }


        public Customer ShallowCopy()
        {
            return (Customer) this.MemberwiseClone();
        }

        public Customer DeepCopy()
        {
            using(var ms = new MemoryStream())
            {
                var formater = new BinaryFormatter();
                formater.Serialize(ms, this);
                ms.Position = 0;
                return (Customer)formater.Deserialize(ms);
            }
        }
    }

    [Serializable]
    public class Adress
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }



    }
}
