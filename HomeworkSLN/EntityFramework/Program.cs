using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Northwind db = new Northwind())
            {
                var orders = from order in db.Order_Details
                             join product in db.Products on order.ProductID equals product.ProductID
                             join customer in db.Orders on order.OrderID equals customer.OrderID
                             where order.Product.Category.CategoryName == "Seafood"
                             select new
                             {
                                 category = product.Category.CategoryName,
                                 productName = product.ProductName,
                                 order = order.OrderID,
                                 unitPrice = order.UnitPrice,
                                 quantity = order.Quantity,
                                 discount = order.Discount,
                                 customer = customer.Customer.CompanyName
                             };


                // вывод с помощью методов расширения:

                //var orders = db.Products.Join(db.Order_Details,
                //    p => p.ProductID,
                //    o => o.ProductID,
                //    (p, o) => new                    
                //    {
                //        category = p.Category.CategoryName,
                //        productName = p.ProductName,
                //        order = o.OrderID,
                //        unitPrice = o.UnitPrice,
                //        quantity = o.Quantity,
                //        discount = o.Discount
                //    })
                //    .Join(db.Orders,
                //    ord => ord.order,
                //    cst => cst.OrderID,
                //    (ord, cst) => new
                //    {
                //        ord.category,
                //        ord.productName,
                //        ord.order,
                //        ord.unitPrice,
                //        ord.quantity,
                //        ord.discount,
                //        customer = cst.Customer.CompanyName
                //    })
                //    .Where(o => o.category == "Seafood").ToList();

                

                foreach (var order in orders)
                {
                    Console.WriteLine($"{order.order} {order.customer} {order.productName} {order.unitPrice} {order.quantity} {order.discount}");
                }
            }
        }
    }
}
