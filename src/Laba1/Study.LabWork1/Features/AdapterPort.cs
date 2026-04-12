using System;
using System.Runtime.InteropServices.Marshalling;

namespace DataClass
{
    public class Data
    {
        public int id;
        public String name;
        public int age;
        public double speed;

        public override string ToString()
        {
            String s = new String(name + "|" + age + "|" + speed);
            return s;
        }

    }
}

namespace CSVParser
{
    using DataClass;

    class CsvParcer
    {



        public Data ReadData(String filename, int id)  {

            if (id < 0)
            {
                Console.WriteLine("Данные из памяти");
                Data d = new Data();
                d.id = 0;
                d.name = "Name From Base";
                d.speed = 123 * 0.3;
                d.age = 900;
                return d;
            }
            else return null;
        }
    }
}

namespace Study.LabWork1.Features
{

    using DataClass;
    using CSVParser;


    public class Client
    {

        Data ClientData;

        public void request(ITarget target, int id)
        {
            Console.WriteLine("Клиент запрашивает данные");
            ClientData = target.GetData(id);
            Console.WriteLine("Клиент получил данные: " + ClientData + "\n");

        }


    }

    public interface ITarget
    {
        public Data GetData(int id);
    }
    public class Dud
    {
        public Data RandomData()
        {
            var rand = new Random();
            Data d = new Data();
            d.id = 0;
            d.name = "Jane Doe";
            d.speed = rand.Next() * 0.3;
            d.age = rand.Next();
            return d;
        }

    }
    public class Adapter : ITarget
    {

        private Dud dud;

        public Adapter(Dud d)
        {
            dud = d;
        }

        public Data GetData(int id)
        {

            Console.WriteLine("Заглушка генерирует случайные данные");
            return dud.RandomData();
        }

    }


    public class RealBase : ITarget
    {
        
        
        public Data GetData(int id)
        {
            CsvParcer parcer = new CsvParcer();
            return parcer.ReadData("DATABASE.csv", id);
        }
        
        

    }



}
