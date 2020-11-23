using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Funcionalidades;
namespace Entidades
{
    public static class DataBase
    {
        const string STRINGCONNEC = @"Data Source =.\SQLExpress;Database=TP4;Integrated Security=true;";
        static SqlConnection sqlConn;
        static SqlCommand command;

        static DataBase()
        {
            sqlConn = new SqlConnection();
            sqlConn.ConnectionString = STRINGCONNEC;
            command = new SqlCommand();
            command.Connection = sqlConn;
        }

        /// <summary>
        /// Valida Clave y Usuario en la Base de Datos
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public static bool validaUsuario(int usuario, string pass)
        {
        string sql = "select * from Personas inner join Empleados on Personas.Id = Empleados.IdPersona  where  username = @usuario and password = @password";
            command.CommandText = sql;
            command.Parameters.Clear();
            command.Parameters.Add(new SqlParameter("@usuario", usuario));
            command.Parameters.Add(new SqlParameter("@password", CreateMD5(pass)));
            try
            {
                sqlConn.Open();
                SqlDataReader dr = command.ExecuteReader();
                if (dr.Read())
                {
                    return true;
                }
            }
            catch (Exception)
            {
                throw new Exception("Usuario Inválido");
            }
            finally
            {
                sqlConn.Close();
            }
                return false;
        }

        /// <summary>
        /// Codifica la clave 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// Trae los Productos de la Base de Datos
        /// </summary>
        public static void TraerProductos()
        {
            string consulta = " Select * from productos ";
            try
            {
                command.CommandText = consulta;
                sqlConn.Open();
                Establecimiento.Productos.Clear();
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Establecimiento.Productos.Add(new Producto(int.Parse(dr["Id"].ToString()), dr["Nombre"].ToString(), float.Parse(dr["Precio"].ToString()), int.Parse(dr["Stock"].ToString())));
                }
            }
            catch (Exception)
            {
                throw new ExcepcionErrorBaseDato();
            }
            finally
            {
                sqlConn.Close();
            }
        }   

        /// <summary>
        /// Trae los Cliente de la Base de Datos
        /// </summary>
        public static void TraerClientes()
        {
            string consulta = " Select * from personas ";
            try
            {
                command.CommandText = consulta;
                sqlConn.Open();
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Establecimiento.Clientes.Add(new Cliente(int.Parse(dr["Id"].ToString()), dr["Nombre"].ToString(), dr["Apellido"].ToString(), int.Parse(dr["Dni"].ToString())));
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }
        }    

        /// <summary>
        /// Inserta un Producto
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="precio"></param>
        public static void InsertarProducto(string nombre, string precio)
        {
            string consulta = " INSERT INTO Productos ([Nombre],[Precio],[Stock]) VALUES (@Nombre ,@Precio,@Stock)";
            try
            {
                command.CommandText = consulta;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Nombre", nombre));
                command.Parameters.Add(new SqlParameter("@Precio", precio));
                command.Parameters.Add(new SqlParameter("@Stock", "0" ));
                sqlConn.Open();
                int retorno = command.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                sqlConn.Close();
            }
        }

        /// <summary>
        /// Agrega un Cliente
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        public static void InsertarCliente(string nombre, string apellido, string dni)
        {
            string consulta = " INSERT INTO Personas ([Nombre],[Apellido],[Dni]) VALUES (@Nombre ,@Apellido,@Dni)";
            try
            {
                command.CommandText = consulta;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@Nombre",      nombre));
                command.Parameters.Add(new SqlParameter("@Apellido",    apellido));
                command.Parameters.Add(new SqlParameter("@Dni",         dni ));
                sqlConn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
                TraerClientes();
            }
        }

        /// <summary>
        /// Modifica el Stock de un Producto
        /// </summary>
        /// <param name="id"></param>
        /// <param name="stock"></param>
        public static void UpdateProducto(int id, string stock)
        {
            string consulta = " UPDATE productos  SET [Stock] = @Stock WHERE id = @id";
            try
            {
                command.CommandText = consulta;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@id", id));
                command.Parameters.Add(new SqlParameter("@Stock", stock ));
                sqlConn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                sqlConn.Close();
                TraerProductos();
            }
        }
        
        /// <summary>
        /// Elimina un Producto (Para Ejemplo de Consola)
        /// </summary>
        /// <param name="nombre"></param>
        public static void BorrarProducto(string nombre)
        {
            string consulta = "DELETE FROM Productos WHERE [Nombre] = @nombre";

            try
            {
                command.CommandText = consulta;
                command.Parameters.Clear();
                command.Parameters.Add(new SqlParameter("@nombre", nombre ));
                sqlConn.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            finally
            {
                sqlConn.Close();
            }
        }



    }
}
