using LINQDemos.Shared.DataContext;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LINQDemos.Aggregates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new AdventureWorksContext();
            var employees = context.Employees.ToList();

            Console.WriteLine(employees.Count());
            
        }
    }
}