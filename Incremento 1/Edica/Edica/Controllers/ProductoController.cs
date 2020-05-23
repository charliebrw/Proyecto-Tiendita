using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Edica.Models;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Edica.Controllers
{
    public class ProductoController : Controller
    {
        Conexion cn = new Conexion();
        EdicasEntities m = new EdicasEntities();
        // GET: Producto
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.cad;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_M_Producto";
            cn.conectar();
            da.SelectCommand = cmd;
            da.Fill(dt);
            cn.desconectar();
            return View(dt);
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.IDCategoria = new SelectList(m.Categoria, "IDCategoria", "Nombre");
            ViewBag.RUC = new SelectList(m.Proveedor, "RUC", "Nombre");
            return View(new Producto());
        }

        // POST: Producto/Create
        [HttpPost]
        public ActionResult Create(Producto producto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.cad;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_A_Producto";
            cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
            cmd.Parameters.AddWithValue("@Cantidad", producto.Cantidad);
            cmd.Parameters.AddWithValue("@RUC", producto.RUC);
            cmd.Parameters.AddWithValue("@IDCategoria", producto.IDCategoria);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return RedirectToAction("Index");
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int id)
        {
            Producto producto = new Producto();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.cad;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_M_ProductoxID";
            cmd.Parameters.AddWithValue("@IDProducto", id);
            cn.conectar();
            da.SelectCommand = cmd;
            da.Fill(dt);
            cn.desconectar();

            if(dt.Rows.Count == 1)
            {
                producto.IDProducto = Convert.ToInt32(dt.Rows[0][0].ToString());
                producto.Nombre = dt.Rows[0][1].ToString();
                producto.PrecioVenta = Convert.ToDecimal(dt.Rows[0][2].ToString()); 
                producto.Cantidad = Convert.ToInt32(dt.Rows[0][3].ToString());
                producto.RUC = dt.Rows[0][4].ToString();
                producto.IDCategoria = Convert.ToInt32(dt.Rows[0][5].ToString());
                ViewBag.RUC = new SelectList(m.Proveedor, "RUC", "Nombre", producto.IDCategoria);
                ViewBag.IDCategoria = new SelectList(m.Categoria, "IDCategoria", "Nombre", producto.IDCategoria);
                return View(producto);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
        }

        // POST: Producto/Edit/5
        [HttpPost]
        public ActionResult Edit(Producto producto)
        {
           
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn.cad;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_C_Producto";
                cmd.Parameters.AddWithValue("@IDProducto",producto.IDProducto);
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@PrecioVenta", producto.PrecioVenta);
                cmd.Parameters.AddWithValue("@Cantidad", producto.Cantidad);
                cmd.Parameters.AddWithValue("@RUC", producto.RUC);
                cmd.Parameters.AddWithValue("@IDCategoria", producto.IDCategoria);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return RedirectToAction("Index");
            
         
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn.cad;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_E_Producto";
            cmd.Parameters.AddWithValue("@IDProducto", id);
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return RedirectToAction("Index");

        }
    }
}
