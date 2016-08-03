using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Prototype pattern is used for creating duplicate data by cloning or copying.
//Basically used where we have long process to create data like creating database object  after long DB procedure call.
namespace PrototypePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var emp1 = new Employee();
            emp1.Name = "Harshal";
            emp1.Dept = "GTCI";
            Console.WriteLine( emp1.GetDetails());
            Employee emp2 = (Employee)emp1.Clone();
            emp2.Dept = "IT";
            Console.WriteLine(emp2.GetDetails());
            Console.ReadLine();
        }
    }

    interface IProtoType
    {
        IProtoType Clone();
        string GetDetails();
    }

    class Employee:IProtoType
    {
        public string Name { get; set; }
        public string Dept { get; set; }

        public IProtoType Clone()
        {
            return (IProtoType)this.MemberwiseClone();
        }

        public string GetDetails()
        {
            return string.Format("{0}-{1}", Name, Dept);
        }
    }
}
