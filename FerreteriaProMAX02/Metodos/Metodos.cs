using FerreteriaProMAX02.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace FerreteriaProMAX02.Metodos
{
    public class Metodos
    {
        //private string conn = "Server=.;Database=FERRETERIADB;User ID=WINDOWS\\mdelgadillo;Integrated Security=True;";
        //private string conn = "Data Source=sql5053.site4now.net;Initial Catalog=DB_A63B48_FerreteriaDB;Persist Security Info=True;User ID=DB_A63B48_FerreteriaDB_admin;password=bde92a58;";
        private string conn = "Data Source=.;integrated Security=sspi;initial catalog=FERRETERIADB;";

        public int USUARIO_LOGINL(String usuario, String contraseña)
        {
            SqlConnection PubsConn = new SqlConnection(conn);
            SqlCommand testCMD = new SqlCommand("UserPassword", PubsConn);
            PubsConn.Open();
            testCMD.CommandType = CommandType.StoredProcedure;
            testCMD.Parameters.AddWithValue("@usuario", usuario);
            testCMD.Parameters.AddWithValue("@password", contraseña);
            var r = 0;
            if (testCMD.ExecuteScalar() == null)
            {
                return r;
            }
            r = (int)testCMD.ExecuteScalar();
            PubsConn.Close();
            return r;
        }
        public int BuscarProd(int id_Producto)
        {
            SqlConnection PubsConn = new SqlConnection(conn);
            SqlCommand testCMD = new SqlCommand("BuscarProducto", PubsConn);
            PubsConn.Open();
            testCMD.CommandType = CommandType.StoredProcedure;
            testCMD.Parameters.AddWithValue("@idProducto", id_Producto);
            var r = 0;
            if (testCMD.ExecuteScalar() == null)
            {
                return r;
            }
            r = (int)testCMD.ExecuteScalar();
            PubsConn.Close();
            return r;
        }
        public int BuscarCedulaP(String cedula)
        {
            SqlConnection PubsConn = new SqlConnection(conn);
            SqlCommand testCMD = new SqlCommand("BuscarCedulaP", PubsConn);
            PubsConn.Open();
            testCMD.CommandType = CommandType.StoredProcedure;
            testCMD.Parameters.AddWithValue("@cedula", cedula);
            var r = 0;
            if (testCMD.ExecuteScalar() == null)
            {
                return r;
            }
            r = (int)testCMD.ExecuteScalar();
            PubsConn.Close();
            return r;
        }
        public int ObtenerVentaT()
        {
            SqlConnection PubsConn = new SqlConnection(conn);
            SqlCommand testCMD = new SqlCommand("ObtenerVenta", PubsConn);
            PubsConn.Open();
            testCMD.CommandType = CommandType.StoredProcedure;
            var r = 0;
            if (testCMD.ExecuteScalar() == null)
            {
                return r;
            }
            r = (int) testCMD.ExecuteScalar();
            PubsConn.Close();
            return r;
        }

        public int ObtenerCompraT()
        {
            SqlConnection PubsConn = new SqlConnection(conn);
            SqlCommand testCMD = new SqlCommand("ObtenerCompra", PubsConn);
            PubsConn.Open();
            testCMD.CommandType = CommandType.StoredProcedure;
            var r = 0;
            if (testCMD.ExecuteScalar() == null)
            {
                return r;
            }
            r = (int)testCMD.ExecuteScalar();
            PubsConn.Close();
            return r;
        }
        public int BuscarEmpleadoU(int usuario)
        {
            SqlConnection PubsConn = new SqlConnection(conn);
            SqlCommand testCMD = new SqlCommand("BuscarEmpleadoU", PubsConn);
            PubsConn.Open();
            testCMD.CommandType = CommandType.StoredProcedure;
            testCMD.Parameters.AddWithValue("@idusuario", usuario);
            var r = 0;
            if (testCMD.ExecuteScalar() == null)
            {
                return r;
            }
            r = (int)testCMD.ExecuteScalar();
            PubsConn.Close();
            return r;
        }
        public List<Persona> Get0(int codigo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection PubsConn = new SqlConnection(conn))
            {
                SqlCommand testCMD = new SqlCommand("BuscarCodigo", PubsConn);
                PubsConn.Open();
                testCMD.CommandType = CommandType.StoredProcedure;
                testCMD.Parameters.AddWithValue("@codigo", codigo);
                using (var da = new SqlDataAdapter(testCMD))
                {
                    da.Fill(dt);
                }
                var persona = from item in dt.AsEnumerable()
                              select new Persona
                              {
                                  Cedula = Convert.ToString(item["Cedula"]),
                                  nombre = Convert.ToString(item["Nombre"]),
                                  Primer_Apellido = Convert.ToString(item["Primer_Apellido"]),
                                  Codigo = Convert.ToInt32(item["Codigo"]),
                              };
                return persona.ToList();
            }

        }
        public List<Persona> Get1(String nombre)
        {
            DataTable dt = new DataTable();
            using (SqlConnection PubsConn = new SqlConnection(conn))
            {
                SqlCommand testCMD = new SqlCommand("BuscarNombre", PubsConn);
                PubsConn.Open();
                testCMD.CommandType = CommandType.StoredProcedure;
                testCMD.Parameters.AddWithValue("@nombre", nombre);
                using (var da = new SqlDataAdapter(testCMD))
                {
                    da.Fill(dt);
                }
                var persona = from item in dt.AsEnumerable()
                              select new Persona
                              {
                                  Cedula = Convert.ToString(item["Cedula"]),
                                  nombre = Convert.ToString(item["Nombre"]),
                                  Primer_Apellido = Convert.ToString(item["Primer_Apellido"]),
                                  Codigo = Convert.ToInt32(item["Codigo"]),
                              };
                return persona.ToList();
            }

        }
        public List<Persona> Get2(String cedula)
        {
            DataTable dt = new DataTable();
            using (SqlConnection PubsConn = new SqlConnection(conn))
            {
                SqlCommand testCMD = new SqlCommand("BuscarCedula", PubsConn);
                PubsConn.Open();
                testCMD.CommandType = CommandType.StoredProcedure;
                testCMD.Parameters.AddWithValue("@cedula", cedula);
                using (var da = new SqlDataAdapter(testCMD))
                {
                    da.Fill(dt);
                }
                var persona = from item in dt.AsEnumerable()
                              select new Persona
                              {
                                  Cedula = Convert.ToString(item["Cedula"]),
                                  nombre = Convert.ToString(item["Nombre"]),
                                  Primer_Apellido = Convert.ToString(item["Primer_Apellido"]),
                                  Codigo = Convert.ToInt32(item["Codigo"]),
                              };
                return persona.ToList();
            }

        }
        public List<Persona> Get3(String Apellido)
        {
            DataTable dt = new DataTable();
            using (SqlConnection PubsConn = new SqlConnection(conn))
            {
                SqlCommand testCMD = new SqlCommand("BuscarApellido", PubsConn);
                PubsConn.Open();
                testCMD.CommandType = CommandType.StoredProcedure;
                testCMD.Parameters.AddWithValue("@Apellido", Apellido);
                using (var da = new SqlDataAdapter(testCMD))
                {
                    da.Fill(dt);
                }
                var persona = from item in dt.AsEnumerable()
                              select new Persona
                              {
                                  Cedula = Convert.ToString(item["Cedula"]),
                                  nombre = Convert.ToString(item["Nombre"]),
                                  Primer_Apellido = Convert.ToString(item["Primer_Apellido"]),
                                  Codigo = Convert.ToInt32(item["Codigo"]),
                              };
                return persona.ToList();
            }

        }
        public List<DetalleVenta> Get4(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection PubsConn = new SqlConnection(conn))
            {
                SqlCommand testCMD = new SqlCommand("DetailsVentas", PubsConn);
                PubsConn.Open();
                testCMD.CommandType = CommandType.StoredProcedure;
                testCMD.Parameters.AddWithValue("@idVenta", id);
                using (var da = new SqlDataAdapter(testCMD))
                {
                    da.Fill(dt);
                }
                var persona = from item in dt.AsEnumerable()
                              select new DetalleVenta
                              {
                                  IdVenta = Convert.ToInt32(item["IdVenta"]),
                                  IdProducto = Convert.ToInt32(item["IdProducto"]),
                                  Cantidad = Convert.ToInt32(item["Cantidad"]),
                                  SubTOTAL = Convert.ToDecimal(item["SubTOTAL"]),
                                  Descuento = Convert.ToDecimal(item["Descuento"]),
                                  Iva = Convert.ToDecimal(item["Iva"]),
                                  Total = Convert.ToDecimal(item["Total"])
                              };
                return persona.ToList();
            }

        }
        public List<proveedore> Get5(String nombre)
        {
            DataTable dt = new DataTable();
            using (SqlConnection PubsConn = new SqlConnection(conn))
            {
                SqlCommand testCMD = new SqlCommand("BuscarProveedor", PubsConn);
                PubsConn.Open();
                testCMD.CommandType = CommandType.StoredProcedure;
                testCMD.Parameters.AddWithValue("@nombre", nombre);
                using (var da = new SqlDataAdapter(testCMD))
                {
                    da.Fill(dt);
                }
                var proveedor = from item in dt.AsEnumerable()
                              select new proveedore
                              {
                                  Nombre = Convert.ToString(item["Nombre"]),
                                  TipoProveedor = Convert.ToString(item["TipoProveedor"])
                              };
                return proveedor.ToList();
            }

        }
        public int BuscarProv(string nombre)
        {
            SqlConnection PubsConn = new SqlConnection(conn);
            SqlCommand testCMD = new SqlCommand("BuscarProveedorId", PubsConn);
            PubsConn.Open();
            testCMD.CommandType = CommandType.StoredProcedure;
            testCMD.Parameters.AddWithValue("@nombre", nombre);
            var r = 0;
            if (testCMD.ExecuteScalar() == null)
            {
                return r;
            }
            r = (int)testCMD.ExecuteScalar();
            PubsConn.Close();
            return r;
        }
        //public int Get4(int idDetall, int idVenta)
        //{
        //    SqlConnection PubsConn = new SqlConnection(conn);
        //    SqlCommand testCMD = new SqlCommand("buscaventad", PubsConn);
        //    PubsConn.Open();
        //    testCMD.CommandType = CommandType.StoredProcedure;
        //    testCMD.CommandType = CommandType.StoredProcedure;
        //    var r = 0;
        //    if (testCMD.ExecuteScalar() == null)
        //    {
        //        return r;
        //    }
        //    r = (int)testCMD.ExecuteScalar();
        //    PubsConn.Close();
        //    return r;
        //}

        public int BuscarRolU(int usuario)
        {
            SqlConnection PubsConn = new SqlConnection(conn);
            SqlCommand testCMD = new SqlCommand("sp_DettalleRoles", PubsConn);
            PubsConn.Open();
            testCMD.CommandType = CommandType.StoredProcedure;
            testCMD.Parameters.AddWithValue("@IdUsuario", usuario);
            var r = 0;
            if (testCMD.ExecuteScalar() == null)
            {
                return r;
            }
            r = (int)testCMD.ExecuteScalar();
            PubsConn.Close();
            return r;
        }
    }
}