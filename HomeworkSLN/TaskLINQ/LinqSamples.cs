// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SampleSupport;
using Task;
using Task.Data;

// Version Mad01

namespace SampleQueries
{
    [Title("LINQ Module")]
    [Prefix("Linq")]
    public class LinqSamples : SampleHarness
    {
        private readonly DataSource dataSource = new DataSource();
        
        private bool ValidateZipCode(string val)
        {
            long number;
            return long.TryParse(val, out number);
        }

        private bool ValidatePhone(string phone)
        {
            var pattern = @"^(\([0-9]\))+?";
            return Regex.IsMatch(phone, pattern);
        }

        private List<GroupPriceEntity> SortProductsByPrice()
        {
            var sortedProducts = new List<GroupPriceEntity>();

            foreach (var prod in dataSource.Products)
                if (prod.UnitPrice <= 20M)
                    sortedProducts.Add(new GroupPriceEntity {product = prod, Group = 0});
                else if ((prod.UnitPrice > 20M) && (prod.UnitPrice <= 50M))
                    sortedProducts.Add(new GroupPriceEntity {product = prod, Group = 1});
                else
                    sortedProducts.Add(new GroupPriceEntity {product = prod, Group = 2});

            return sortedProducts;
        }


        [Category("Restriction Operators")]
        [Title("Task 1")]
        [Description("Выдает список всех клиентов, чей суммарный оборот (сумма всех заказов) превосходит некоторую величину X." +
            "Запросы выполнены для величин 20000, 35000 и 50000")]
        public void Linq001()
        {
            decimal[] amounts = { 20000, 35000, 50000 };
            
            foreach(decimal amount in amounts)
            {
                var customers = dataSource
                .Customers
                .Where(c => c.Orders.Sum(o => o.Total) > amount)
                .Select(c => new { name = c.CompanyName, total = c.Orders.Sum(o => o.Total) });

                ObjectDumper.Write(customers);

                System.Console.WriteLine();
            }

        }

        [Category("Restriction Operators")]
        [Title("Task 2")]
        [Description("Для каждого клиента выводит список поставщиков, находящихся в той же стране и в том же городе.")]
        public void Linq002()
        {
            System.Console.WriteLine("Вариант через цикл foreach:");

            foreach (var cust in dataSource.Customers)
            {
                var supplier = dataSource.Suppliers
                    .Where(s => s.Country == cust.Country && s.City == cust.City)
                    .Select(s => new { cust.CompanyName, s.SupplierName, suppCountry = s.Country, suppCity = s.City });

                ObjectDumper.Write(supplier);
            }
            
            System.Console.WriteLine();
            System.Console.WriteLine("Вариант через объединение данных:");

            var customersAndSuppliers = dataSource
                .Customers.Join(dataSource.Suppliers,
                cust => cust.Country,
                supp => supp.Country,
                (cust, supp) => new { cust.CompanyName, supp.SupplierName, cust.Country, cust.City, citySupp = supp.City })
                .Where(c => c.City == c.citySupp)
                .Select(c => c);

            ObjectDumper.Write(customersAndSuppliers);

            System.Console.WriteLine();
            System.Console.WriteLine("Вариант с группировкой данных:");

            foreach (var cust in dataSource.Customers)
            {
                var supplier = dataSource.Suppliers.GroupBy(supp =>
                {
                    if (supp.Country == cust.Country && supp.City == cust.City)
                        return $"CompanyName={cust.CompanyName} SupplierName={supp.SupplierName} Country={cust.Country} City={cust.City}";
                    return null;
                });

                foreach(var supp in supplier.OrderBy(supp => supp.Key))
                {
                    if (supp.Key != null)
                    System.Console.WriteLine(supp.Key);
                }
                    
            }


        }

        [Category("Restriction Operators")]
        [Title("Task 3")]
        [Description("Находит всех клиентов, у которых были заказы, превосходящие по сумме величину 9000")]
        public void Linq003()
        {
            decimal sum = 9000;

            var customers = dataSource.Customers
                .Where(c => c.Orders.Any(o => o.Total > sum))
                .Select(c => c.CompanyName);

            ObjectDumper.Write(customers);
           
        }

        [Category("Restriction Operators")]
        [Title("Task 4")]
        [Description("Выдает список клиентов с указанием, начиная с какого месяца какого года они стали клиентами ")]
        public void Linq004()
        {


            var customers = dataSource.Customers
                .SelectMany(c => c.Orders.Take(1),
                (c, o) => new {cust = c, ord = o})
                .Select(o => new {o.cust.CompanyName, FirstOrder = o.ord.OrderDate.ToString("MM.yyyy") });
                

            ObjectDumper.Write(customers);

        }

        [Category("Restriction Operators")]
        [Title("Task 5")]
        [Description("Выдает список клиентов с указанием, начиная с какого месяца какого года они стали клиентами." +
            " Сортирует список по году, месяцу, оборотам клиента (от максимального к минимальному) и имени клиента. ")]
        public void Linq005()
        {


            var customers = dataSource.Customers
                .SelectMany(c => c.Orders.Take(1),
                (c, o) => new { cust = c, ord = o })
                .OrderBy(o => o.ord.OrderDate.Year)
                .ThenBy(o => o.ord.OrderDate.Month)
                .ThenByDescending(o => o.ord.Total)
                .ThenBy(o => o.cust.CompanyName)
                .Select(o => new { Name = o.cust.CompanyName, FirstOrder = o.ord.OrderDate.ToString("MM.yyyy"), o.ord.Total });
                

            ObjectDumper.Write(customers);

        }

        [Category("Restriction Operators")]
        [Title("Task 6")]
        [Description("Выводит всех клиентов, у которых указан нецифровой код или не заполнен регион или в телефоне не указан код оператора.")]
        public void Linq006()
        {

            var customers = dataSource.Customers
                 .Where(c => ValidatePhone(c.Phone) == false)
                 .Select(c => new { c.CompanyName, c.Phone });

            ObjectDumper.Write(customers);

        }

        [Category("Restriction Operators")]
        [Title("Task 7")]
        [Description("Группирует все продукты по категориям, внутри – по наличию на складе, внутри последней группы сортирует по стоимости.")]
        public void Linq007()
        {
            var products = dataSource.Products.GroupBy(p => p.Category)
                .Select(g => new
                {
                    g.Key,
                   
                    ProductName = g.OrderByDescending(p => p.UnitPrice).GroupBy(s =>
                    {
                        if (s.UnitsInStock > 0)
                            return "Есть на складе";
                        else
                            return "Нет на складе";

                    })
                    

                });

            foreach (var i in products)
            {
                System.Console.WriteLine(i.Key);
                System.Console.WriteLine("------------------");
                foreach (var item in i.ProductName)
                {
                    System.Console.WriteLine(item.Key);
                    System.Console.WriteLine("+++++++++++++++");
                    foreach (var pr in item)
                    {
                        System.Console.WriteLine($"{pr.ProductName} {pr.UnitPrice}");
                    }
                    System.Console.WriteLine();
                }
                System.Console.WriteLine();
            }


        }

        [Category("Restriction Operators")]
        [Title("Task 8")]
        [Description("Группирует товары по группам «дешевые», «средняя цена», «дорогие».")]
        public void Linq008()
        {
            var products = dataSource.Products.OrderByDescending(o => o.UnitPrice).GroupBy(prod =>
            {
                if (prod.UnitPrice <= 20M)
                    return "Дешевые товары:";
                else if ((prod.UnitPrice > 20M) && (prod.UnitPrice <= 50M))
                    return "Средняя цена:";
                else
                    return "Дорогие товары:";
            });

            foreach (var prod in products)
            {
                System.Console.WriteLine(prod.Key);
                System.Console.WriteLine("---------------------");
                foreach (var p in prod)
                {
                    System.Console.WriteLine($"{p.ProductName} - {p.UnitPrice}") ;
                }
                System.Console.WriteLine();
            }


        }

        [Category("Restriction Operators")]
        [Title("Task 9")]
        [Description("Рассчитывает среднюю прибыльность каждого города и среднюю интенсивность.")]
        public void Linq009()
        {

          var profitability = dataSource.Customers.GroupBy(c => c.City)

                .Select(n => new
                {
                    n.Key,
                    
                    average = n.Where(c => c.Orders.Any(b => b.Total != 0))
                    .Select(s => 
                    {
                        decimal av = s.Orders.Average(a => a.Total);
                        return av;
                    }).Average(),
                    
                    count = n.Where(c => c.Orders.Any(b => b.Total != 0))
                    .Select(s =>
                    {
                        int ct = s.Orders.Count();
                        return ct;
                    }).Average()
                });

            
            foreach (var c in profitability.OrderByDescending(b => b.average))
            {
                
                System.Console.WriteLine($"{c.Key,-15} {c.average:F} {c.count,10:F}");
              
            }


        }

        [Category("Restriction Operators")]
        [Title("Task 10")]
        [Description("Выводит среднегодовую статистику активности клиентов по месяцам, по годам, по годам и месяцам.")]
        public void Linq010()
        {
            // статистика по месяцам
            var statisticMonth = dataSource.Customers
                .Select(c => new
                {
                    c.CompanyName,
                    c.Orders,
                    count = c.Orders.GroupBy(s => s.OrderDate.Month)
                    .Select(v => new
                    {
                        Month = v.Key,
                        Count = v.Count()
                    })
                });

            // статистика по годам
            var statisticYear = dataSource.Customers
                .Select(c => new
                {
                    c.CompanyName,
                    count = c.Orders.GroupBy(s => s.OrderDate.Year)
                    .Select(v => new
                    {
                        Year = v.Key,
                        Count = v.Count()
                    })
                });

            // статистика по годам и месяцам
            var statisticMonthAndYear = dataSource.Customers
                .Select(c => new
                {
                    c.CompanyName,
                    count = c.Orders.GroupBy(s => s.OrderDate.Year)
                    .Select(v => new
                    {
                        Year = v.Key,
                        Count = v.Count(),
                        Month = v.GroupBy(m => m.OrderDate.Month)
                        .Select(f => new
                        { 
                            Months = f.Key,
                            Counts = f.Count()
                        })
                    })
                });

            
            System.Console.WriteLine("СТАТИСТИКА АКТИВНОСТИ КЛИЕНТОВ ПО МЕСЯЦАМ");
            System.Console.WriteLine();
            foreach (var stat in statisticMonth)
            {
                System.Console.WriteLine(stat.CompanyName);

                foreach (var i in stat.count)
                {
                    System.Console.Write($"{i.Month,-3}");
                }

                System.Console.WriteLine();

                foreach (var i in stat.count)
                {
                    System.Console.Write($"{i.Count,-3}");
                }


                System.Console.WriteLine();
                System.Console.WriteLine();
            }

            System.Console.WriteLine("СТАТИСТИКА АКТИВНОСТИ КЛИЕНТОВ ПО ГОДАМ");
            System.Console.WriteLine();
            foreach (var stat in statisticYear)
            {
                System.Console.WriteLine(stat.CompanyName);

                foreach (var i in stat.count)
                {
                    System.Console.Write($"{i.Year,-5}");
                }

                System.Console.WriteLine();

                foreach (var i in stat.count)
                {
                    System.Console.Write($"{i.Count,-5}");
                }


                System.Console.WriteLine();
                System.Console.WriteLine();

            }

            System.Console.WriteLine("СТАТИСТИКА АКТИВНОСТИ КЛИЕНТОВ ПО ГОДАМ И МЕСЯЦАМ");
            System.Console.WriteLine();
            foreach (var stat in statisticMonthAndYear)
            {
                System.Console.WriteLine(stat.CompanyName);
                foreach (var year in stat.count)
                {
                    System.Console.WriteLine($"{year.Year,-5}");

                    foreach (var month in year.Month)
                    {
                        System.Console.Write($"{month.Months,-5}");
                    }

                    System.Console.WriteLine();

                    foreach (var count in year.Month)
                    {
                        System.Console.Write($"{count.Counts,-5}");
                    }

                    System.Console.WriteLine();
                    System.Console.WriteLine();
                }
            }



        }
    }
}