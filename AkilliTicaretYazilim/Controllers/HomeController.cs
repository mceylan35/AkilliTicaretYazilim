using AkilliTicaretYazilim.DBContext;
using AkilliTicaretYazilim.DbModels;
using AkilliTicaretYazilim.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AkilliTicaretYazilim.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AkilliTicaretContext _context;

        public HomeController(ILogger<HomeController> logger, AkilliTicaretContext context)
        {
            _logger = logger;
            _context = context;
        } 
        public IActionResult GetOrderStatistics()
        {
            return View(getOrderStatistics(ProductAddOperation()));
        }
        public IActionResult GetProductsOfCategory(int categoryID)
        {
            return View(getProductsOfCategoryAndDescendants(categoryID));
        }
        private List<Order> ProductAddOperation()
        {
            List<Order> orders = new List<Order>();
            Order order = new Order();
            order.products = new List<Product>();

            order.products.Add(_context.Products.Select(i => new Product { ID = i.ID, CategoryID = (int)i.CategoryID, Price = i.Price }).FirstOrDefault(i => i.ID == 1));
            order.products.Add(_context.Products.Select(i => new Product { ID = i.ID, CategoryID = (int)i.CategoryID, Price = i.Price }).FirstOrDefault(i => i.ID == 4));

            Order order2 = new Order();
            order2.products = new List<Product>();
            order.products.Add(_context.Products.Select(i => new Product { ID = i.ID, CategoryID = (int)i.CategoryID, Price = i.Price }).FirstOrDefault(i => i.ID == 2));
            order.products.Add(_context.Products.Select(i => new Product { ID = i.ID, CategoryID = (int)i.CategoryID, Price = i.Price }).FirstOrDefault(i => i.ID == 1));
            order.products.Add(_context.Products.Select(i => new Product { ID = i.ID, CategoryID = (int)i.CategoryID, Price = i.Price }).FirstOrDefault(i => i.ID == 4));
            order.products.Add(_context.Products.Select(i => new Product { ID = i.ID, CategoryID = (int)i.CategoryID, Price = i.Price }).FirstOrDefault(i => i.ID == 3));

            orders.Add(order);
            orders.Add(order2);
            return orders;
        }

       

        public OrderStatistics getOrderStatistics(List<Order> orders)
        {
            OrderStatistics orderStatistics = new OrderStatistics();

            OrderStatisticCategory orderStatisticCategory = new OrderStatisticCategory();
            orderStatistics.categories = new List<OrderStatisticCategory>();

            foreach (var order in orders)
            {
                foreach (var product in order.products.GroupBy(x => x.CategoryID))//kategori bazı gruplama
                {
                   
                    foreach (var item in product)
                    {
                        
                        orderStatisticCategory.NumberOfProductsSold++;
                       
                        orderStatisticCategory.TotalPriceOfProductsSold += item.Price;
                  
                    }

                    orderStatistics.categories.Add(orderStatisticCategory);
                    orderStatisticCategory = new OrderStatisticCategory();
                }
            }

            return orderStatistics;
        }

        public List<Product> getProductsOfCategoryAndDescendants(int categoryID)
        {
            List<Product> products = new List<Product>();
            var listCategory = GetChildCategory(categoryID, new List<Categories>());

            foreach (var item in listCategory)
            {
               var productList= _context.Products.Where(i => i.CategoryID == item.ID).Select(s=>new Product { ID=s.ID,  CategoryID= (int)s.CategoryID  }).ToList();
                products.AddRange(productList);
            }
            return products;
          
        }
       
        public List<Categories> GetChildCategory(int categoryID, List<Categories> categories)
        {
           var categoriesList= _context.Categories.Where(i => i.ParentID == categoryID).ToList();
            if (categoriesList.Any())
            {
                foreach (var item in categoriesList)
                {
                    if (item.InverseParent==null)
                    {
                        item.InverseParent = new List<Categories>();
                    }
                    GetChildCategory(item.ID, item.InverseParent.ToList());
                    if (!categories.Contains(item))
                    {
                        categories.Add(item);
                    }
                }
            }

            return categories;

        }
      
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
