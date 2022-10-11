using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using ORM_Dapper;
using Org.BouncyCastle.Crypto.Engines;
//^^^^MUST HAVE USING DIRECTIVES^^^^
namespace ORM_Dapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            #region Departments
            //var repo = new DapperDepartmentRepository(conn);


            //Console.WriteLine("Type a new department name");
            //var newDepartment = Console.ReadLine();
            //repo.InsertDepartment(newDepartment);
            //var departments = repo.GetAllDepartments();
            //foreach (var dept in departments)
            //{
            //    Console.WriteLine(dept.Name);
            //}
            #endregion

            var productRepository = new DapperProductRepository(conn);
            
            var productToUpdate = productRepository.GetProduct(945);

            productToUpdate.Name = "Samantha test";
            productToUpdate.OnSale = false;
            productToUpdate.Price = 567;
            productToUpdate.CategoryID = 1;
            productToUpdate.StockLevel = 100;

            productRepository.UpdateProduct(productToUpdate);

            var products = productRepository.GetAllProducts();


            foreach (var product in products)
            {
                Console.WriteLine("Product Name: " + product.Name);
                Console.WriteLine("Product ProductID: " + product.ProductID);
                Console.WriteLine("Product CategoryID: " + product.CategoryID);
                Console.WriteLine("Product StockLevel: " + product.StockLevel);
                Console.WriteLine("Product OnSale: " + product.OnSale);
                Console.WriteLine("Product price: " + product.Price);
                Console.WriteLine();
                Console.WriteLine();
            }
        }

    }

}
