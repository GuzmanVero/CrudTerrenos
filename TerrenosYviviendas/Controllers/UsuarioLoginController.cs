using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Terrenos2.Models;

namespace Terrenos2.Controllers
{
    public class UsuarioLoginController : Controller
    {

        static string con = "Data Source=DESKTOP-TVRKDR8\\SQLEXPRESS;Initial Catalog=costaDelSol;Integrated Security=true";
        // GET: UsuarioLogin
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Usuario usuario, Cliente cliente)
        {
            bool registrado;
            string mensaje;

            if (usuario.Clave == usuario.ConfirmarClave)
            {

                usuario.Clave = ConvertirSha256(usuario.Clave);
            }
            else
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }
            using (SqlConnection cn = new SqlConnection(con))
            {

                SqlCommand cmd = new SqlCommand("RegistroUsuario", cn);
                cmd.Parameters.AddWithValue("Nombre", cliente.Nombre);
                cmd.Parameters.AddWithValue("Direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("Email", usuario.Email);
                //cmd.Parameters.AddWithValue("Email", cliente.Email);
                cmd.Parameters.AddWithValue("Clave", usuario.Clave);
                cmd.Parameters.Add("Registrado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 100).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                cmd.ExecuteNonQuery();

                registrado = Convert.ToBoolean(cmd.Parameters["Registrado"].Value);
                mensaje = cmd.Parameters["Mensaje"].Value.ToString();


            }
            ViewData["Mensaje"] = mensaje;

            if (registrado)
            {
                return RedirectToAction("Login", "UsuarioLogin");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            usuario.Clave = ConvertirSha256(usuario.Clave);

            using (SqlConnection cn = new SqlConnection(con))
            {

                SqlCommand cmd = new SqlCommand("ValidarUsuario", cn);
                cmd.Parameters.AddWithValue("Email", usuario.Email);
                cmd.Parameters.AddWithValue("Clave", usuario.Clave);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                usuario.UsuarioID = Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }

            if (usuario.UsuarioID != 0)
            {
                Session["usuario"] = usuario;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Mensaje"] = "usuario no encontrado";
                return View();
            }
        }

        public static string ConvertirSha256(string texto)
        {
            //using System.Text;
            //USAR LA REFERENCIA DE "System.Security.Cryptography"

            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}