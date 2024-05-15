using EF1PJ1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;

namespace EF1PJ1
{
    public class Program
    {
        public static void Main()
        {
            using (var db = new postgresContext())
            {
                string targetDistrict = "Кировский";
                double minPrice = 1000000;
                double maxPrice = 2000000;
                var total1 = db.Objects.Where(o => o.DistrictNavigation.Name == targetDistrict && o.Cost <= maxPrice && o.Cost >= minPrice).ToList().OrderByDescending(p => p.Cost);
                Console.WriteLine("Задание 1-----------------------------------------------------");
                foreach (var item in total1)
                {
                    Console.WriteLine($"Адрес: {item.Adress} , Стоимость: {item.Cost},Район: {item.District}");
                }
                int cellcount = 2;
                var total2 = db.Sales.Where(a => a.ObjCodeNavigation.Cellcount == cellcount);
                Console.WriteLine("Задание 2-----------------------------------------------------");
                foreach (var item in total2)
                {
                    Console.WriteLine($"Фамилия: {item.CodeReNavigation.LastName}");
                }
                Console.WriteLine("Задание 3-----------------------------------------------------");
                var total3 = db.Sales.Where(a => a.ObjCodeNavigation.Cellcount == cellcount && a.ObjCodeNavigation.DistrictNavigation.Name == "Ленинский");
                double sum3 = total3.Sum(item => item.Price);
                Console.WriteLine("Сумма: ", sum3);
                Console.WriteLine("Задание 4-----------------------------------------------------");
                string real4 = "Иванов";
                var total4 = db.Sales.Where(a => a.CodeReNavigation.LastName == real4);
                double max4 = total4.Select(item => item.Price).Max();
                double min4 = total4.Select(item => item.Price).Min();
                Console.WriteLine("Максимальное: ", max4, "Минимальное: ", min4);
                Console.WriteLine("Задание 5-----------------------------------------------------");
                string real5 = "Иванов";
                string cr5 = "Безопасность";
                string nt5 = "Апартаменты";

                var total5 = db.Sales.Where(a => a.CodeReNavigation.LastName == real5 && a.ObjCodeNavigation.TypeNavigation.Nametype == nt5 && a.ObjCodeNavigation.Evaluations.Any(b => b.CrCodeNavigation.Name == cr5 && b.ObjCode == a.ObjCode));
                int c5 = total5.Count();
                double sum5 = total5.Sum(item => item.ObjCodeNavigation.Evaluations.Count());
                Console.WriteLine("Средняя цена: " + sum5 / c5);
                Console.WriteLine("Задание 6-----------------------------------------------------");
                int floor6 = 2;
                var total6 = db.Objects
                    .Where(a => a.Cellcount == floor6)
                    .Select(item => $"{item.DistrictNavigation.Name} - {item.Adress}, {item.Cost}, {item.Floor}")
                    .ToList();

                foreach (var item in total6)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("Задание 7-----------------------------------------------------");
                string propertyType = "апартаменты";

                var total7 = db.Sales
                    .Where(s => s.ObjCodeNavigation.TypeNavigation.Nametype == propertyType)
                    .GroupBy(s => s.CodeReNavigation.FirstName)
                    .Select(g => new { Realtor = g.Key, ApartmentCount = g.Count() });
                foreach (var item in total7)
                {
                    Console.WriteLine($"{item.Realtor} - {item.ApartmentCount}");
                }
                Console.WriteLine("Задание 8-----------------------------------------------------");
                var total8 = db.Objects
                       .GroupBy(p => p.DistrictNavigation.Name)
                       .Select(g => new
                       {
                           District = g.Key,
                           ExpensiveProperties = g.OrderByDescending(p => p.Cost)
                               .ThenBy(p => (long)p.Floor)
                               .Take(3)
                               .Select(p => new { Address = p.Adress, Cost = p.Cost, Floor = p.Floor })
                       });

                Console.WriteLine("District - Expensive Properties");
                foreach (var district in total8)
                {
                    Console.WriteLine($"District: {district.District}");
                    foreach (var property in district.ExpensiveProperties)
                    {
                        Console.WriteLine($"Address: {property.Address}, Cost: {property.Cost}, Floor: {property.Floor}");
                    }
                }
                Console.WriteLine("Задание 9-----------------------------------------------------");
                string realtorName = "Риелтор";
                var total9 = db.Sales
                .Where(s => s.CodeReNavigation.FirstName == realtorName)
                .GroupBy(s => s.Date.HasValue ? s.Date.Value.Year : 0)
                .Where(g => g.Count() > 2)
                .Select(g => g.Key);

                Console.WriteLine($"Years in which {realtorName} sold more than 2 objects:");
                foreach (var year in total9)
                {
                    Console.WriteLine(year);
                }
                Console.WriteLine("Задание 10-----------------------------------------------------");
                var total10 = db.Sales
                       .GroupBy(s => s.Date.HasValue ? s.Date.Value.Year : 0)
                       .Where(g => g.Count() >= 2 && g.Count() <= 3 && g.Key != 0)
                       .Select(g => g.Key);

                Console.WriteLine("Годы, в которых было размещено от 2 до 3 объектов недвижимости:");
                foreach (var year in total10)
                {
                    Console.WriteLine(year);
                }
                Console.WriteLine("Задание 11-----------------------------------------------------");
                var total11 = db.Sales
                    .Where(s => Math.Abs((double)(s.ObjCodeNavigation.Cost - s.Price) / s.Price) < 0.2)
                    .Select(g => new
                    {
                        Address = g.ObjCodeNavigation.Adress, g.ObjCodeNavigation.DistrictNavigation.Name
                    });
                foreach (var item in total11)
                {
                    Console.WriteLine("Адрес: ", item.Address," Район: ", item.Name);
                }

                Console.WriteLine("Задание 13-----------------------------------------------------");
                var total13 = db.Sales.GroupBy(s => s.CodeReNavigation)
                    .Where(g => g.Count() == 0)
                    .Select(g => g.Key);
                foreach (var item in total13)
                {
                    Console.WriteLine("ФИО: ", item.LastName, item.FirstName, item.Patronymic);
                }

            }
        }
    }
}