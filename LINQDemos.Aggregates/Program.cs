using LINQDemos.Shared.DataContext;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace LINQDemos.Aggregates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new AdventureWorksContext();
            var employees = context.Employees.ToList();
            Console.WriteLine(employees.Count());

            var myDeviceList = GetDevices();
            Console.WriteLine(JsonConvert.SerializeObject(myDeviceList));
            Console.WriteLine(JsonConvert.SerializeObject(myDeviceList.Count()));
            Console.WriteLine(JsonConvert.SerializeObject(myDeviceList.Max()));
            Console.WriteLine(JsonConvert.SerializeObject(myDeviceList.Min()));
            Console.WriteLine(JsonConvert.SerializeObject(myDeviceList.AsQueryable<Device>().Sum(d => d.Price)));
        }

        static List<Device> GetDevices()
        {
            return new List<Device> {
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Dish-washing Machine",
                    Price = 350.5m
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Refridgerator",
                    Price = 640m
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Mixer",
                    Price = 56.5m
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Cooker",
                    Price = 730.5m
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Toaster",
                    Price = 34.5m
                },
                new Device
                {
                    Id = Guid.NewGuid(),
                    Name = "Washing Machine",
                    Price = 510.5m
                },
            };
        }
    }

    class Device: IComparable
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            Device otherDevice = obj as Device;
            if (otherDevice != null)
                return this.Price.CompareTo(otherDevice.Price);
            else
                throw new ArgumentException("Object is not a Device");
        }
    }
}