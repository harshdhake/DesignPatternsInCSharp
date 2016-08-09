using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Adapter pattern acts as a bridge between two incompatible interfaces.
//This pattern involves a single class called adapter which is responsible for communication between two independent or incompatible interfaces.

//  A  >> B(Adpter) >> C   
//A and C are independents

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            HRSystem hrSystemAdapter = new HRSystem();
            Company companyObj = new Company(hrSystemAdapter);
            companyObj.DisplayEmployees();
            Console.ReadKey();
        }
    }


    public class Company        //Sytem A
    {
        private ICompany _company;
        public Company(HRSystem hrSystem)
        {
            _company = hrSystem;
        }
        public void DisplayEmployees()
        {
            var list = _company.GetEmployees();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

    }
    public interface ICompany
    {
        IList<string> GetEmployees();
    }

    public class HRSystem : EmpRepository, ICompany //Adapter B
    {
        private EmpRepository _empRep = new EmpRepository();
        public IList<string> GetEmployees()
        {
            return _empRep.GetEmployees();
        }
    }

    public class EmpRepository      /// System C
    {
        public IList<string> GetEmployees()
        {
            IList<string> empList = new List<string>();
            empList.Add("Harshal");
            empList.Add("Shyam");
            empList.Add("Jay");
            return empList;
        }
    }
}
