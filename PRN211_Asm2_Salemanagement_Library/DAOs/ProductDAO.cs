﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PRN211_Asm2_Salemanagement_Library.Models;

namespace PRN211_Asm2_Salemanagement_Library.DAOs
{
    public class ProductDAO
    {
        // Singleton pattern 
        private static ProductDAO _instance;
        private static readonly object _lock = new object();
        private ProductDAO() { }
        public static ProductDAO Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new ProductDAO();
                    }
                    return _instance;
                }
            }
        }

        //Get all products
        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                using (var db = new SaleManagermentContext())
                {
                    return db.Products.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //Get product by id
        public Product GetProductById(int id)
        {
            try
            {
                using (var db = new SaleManagermentContext())
                {
                    return db.Products.Find(id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //Get product by name
        public Product GetProductByName(string name)
        {
            try
            {
                using (var db = new SaleManagermentContext())
                {
                    return db.Products.Where(p => p.ProductName == name).FirstOrDefault();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //Add new product
        public bool AddProduct(Product product)
        {
            try
            {
                using (var db = new SaleManagermentContext())
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        //Update product
        public bool UpdateProduct(Product product)
        {
            try
            {
                using (var db = new SaleManagermentContext())
                {
                    db.Products.Update(product);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //Delete product
        public bool DeleteProduct(int id)
        {
            try
            {
                using (var db = new SaleManagermentContext())
                {
                    var product = db.Products.Find(id);
                    db.Products.Remove(product);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        //Search product by name
        public IEnumerable<Product> SearchProductByName(string name)
        {
            using (var db = new SaleManagermentContext())
            {
                return db.Products.Where(p => p.ProductName.Contains(name)).ToList();
            }
        }

        //Search product by id 
        public IEnumerable<Product> SearchProductById(int id)
        {
            using (var db = new SaleManagermentContext())
            {
                return db.Products.Where(p => p.ProductId == id).ToList();
            }
        }

        //Search product by price range
        public IEnumerable<Product> SearchProductByPriceRange(int min, int max)
        {
            using (var db = new SaleManagermentContext())
            {
                return db.Products.Where(p => p.UnitPrice >= min && p.UnitPrice <= max).ToList();
            }
        }

        //Search product by UnitInStock range
        public IEnumerable<Product> SearchProductByUnitInStockRange(int min, int max)
        {
            using (var db = new SaleManagermentContext())
            {
                return db.Products.Where(p => p.UnitslnStock >= min && p.UnitslnStock <= max).ToList();
            }
        }

        public bool CheckIdDuplicated(int id)
        {

            using (var db = new SaleManagermentContext())
            {
                bool check = db.Products.Where(x=>x.ProductId== id).Any();
                return check;
            }
        }
    }
}
