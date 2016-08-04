using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Separate the construction of a complex object from its representation so that the same construction process can create different representations.
namespace BuilderPattern
{

    class Program
    {
        static void Main(string[] args)
        {
            IVehicleBuilder builder = new HeroBuilder();
            var vehicleCreator = new VehicleCreator(builder);
            var vehicle=vehicleCreator.CreateVehicle().GetVehicle(); //Here same method calls below also but both has different result
            Console.WriteLine(string.Format("ModelName:{0}\nSpeed:{1}\nBrand:{2}\n",vehicle.ModelName,vehicle.Speed,vehicle.BrandName));
            Console.WriteLine("----------------------------------------------------------");
            builder = new HondaBuilder();
            vehicleCreator=new VehicleCreator(builder);
            vehicle=vehicleCreator.CreateVehicle().GetVehicle();
            Console.WriteLine(string.Format("ModelName:{0}\nSpeed:{1}\nBrand:{2}\n", vehicle.ModelName, vehicle.Speed, vehicle.BrandName));
            Console.ReadKey();
        }
    }

    public class Vehicle
    {
        public string ModelName { get; set; }
        public string Speed { get; set; }
        public string BrandName { get; set; }
    }

    public interface IVehicleBuilder
    {
        void SetModelName();
        void SetSpeed();
        void SetBrand();
        Vehicle GetVehicle();
    }

    public class HeroBuilder :IVehicleBuilder
    {
        Vehicle _vehicle = new Vehicle();

        public void SetModelName()
        {
            _vehicle.ModelName = "Passion Plus";
        }

        public void SetSpeed()
        {
            _vehicle.Speed = "120Km/hr";
        }

        public void SetBrand()
        {
            _vehicle.BrandName = "Hero";
        }

        public Vehicle GetVehicle()
        {
            return _vehicle;
        }
    }

    public class HondaBuilder : IVehicleBuilder
    {
        Vehicle _vehicle = new Vehicle();

        public void SetModelName()
        {
            _vehicle.ModelName = "Unicorn 160cc";
        }

        public void SetSpeed()
        {
            _vehicle.Speed = "150Km/hr";
        }

        public void SetBrand()
        {
            _vehicle.BrandName = "Honda";
        }

        public Vehicle GetVehicle()
        {
            return _vehicle;
        }
    }

    public class VehicleCreator
    {
        readonly IVehicleBuilder _builder;
        public VehicleCreator(IVehicleBuilder builder)
        {
            _builder = builder;
        }
        public IVehicleBuilder CreateVehicle()
        {
            _builder.SetModelName();
            _builder.SetBrand();
            _builder.SetSpeed();
            return _builder;
        }
    }

}
