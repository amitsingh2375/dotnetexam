using ProductMvc.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductMvc.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            SqlConnection conn = new SqlConnection();
            List<Product> list = new List<Product>();
            try
            {
                conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductDB;Integrated Security=True";
                conn.Open();

                SqlCommand cmdSelect = new SqlCommand();
                cmdSelect.Connection = conn;
               
                cmdSelect.CommandType = System.Data.CommandType.Text;
                cmdSelect.CommandText = "select * from Products";

                SqlDataReader read = cmdSelect.ExecuteReader();
                while (read.Read())
                {
                    list.Add(new Product { ProductId = (int)read["ProductId"], ProductName = read["ProductName"].ToString(), Rate = (decimal)read["Rate"], Description = read["Description"].ToString(), CategoryName = read["CategoryName"].ToString() });
                }
                read.Close();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex;
            }
            finally
            {
                conn.Close();
            }
            return View(list);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            SqlConnection conn = new SqlConnection();
            Product obj = new Product();
            try
            {
                conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductDB;Integrated Security=True";
                conn.Open();

                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = conn;
               
           
                cmdUpdate.CommandType = System.Data.CommandType.Text;
                cmdUpdate.CommandText = "select * from Products where ProductId = @ProductId";

                cmdUpdate.Parameters.AddWithValue("@ProductId", id);

                SqlDataReader read = cmdUpdate.ExecuteReader();

                while (read.Read())
                {
                    obj = new Product { ProductId = (int)read["ProductId"], ProductName = read["ProductName"].ToString(), Rate = (decimal)read["Rate"], Description = read["Description"].ToString(), CategoryName = read["CategoryName"].ToString() };
                }
                read.Close();
            }
            catch
            {
                return View();
            }
            finally
            {
                conn.Close();
            }
            return View(obj);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product obj)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                conn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProductDB;Integrated Security=True";
                conn.Open();

                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = conn;
               
                cmdUpdate.CommandType = System.Data.CommandType.Text;
                cmdUpdate.CommandText = "UPDATE Products SET ProductName = @ProductName, Rate = @Rate, Description = @Description, CategoryName = @CategoryName where ProductId = @ProductId ";

                
                cmdUpdate.Parameters.AddWithValue("@ProductName", obj.ProductName);
                cmdUpdate.Parameters.AddWithValue("@Rate", obj.Rate);
                cmdUpdate.Parameters.AddWithValue("@Description", obj.Description);
                cmdUpdate.Parameters.AddWithValue("@CategoryName", obj.CategoryName);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                conn.Close();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}