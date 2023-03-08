using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoftde.Models;
namespace Microsoftde.Datas
{
    public class UserConexion
    {
        public static string GuardarUser(Usuarios usuarios)
        {
            using (SqlConnection connection = new SqlConnection(Conexion.Rutaconexion))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_registrar", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@nombre", usuarios.nombre);
                sqlCommand.Parameters.AddWithValue("@apellido", usuarios.apellido);
                sqlCommand.Parameters.AddWithValue("@fecha", usuarios.fecha);
                sqlCommand.Parameters.AddWithValue("@email", usuarios.email);
                sqlCommand.Parameters.AddWithValue("@dni", usuarios.dni);
                sqlCommand.Parameters.AddWithValue("@domicilio", usuarios.domicilio);
                sqlCommand.Parameters.AddWithValue("@passwrd", usuarios.passwrd);
                sqlCommand.Parameters.AddWithValue("@permiso", usuarios.permiso);
                try
                {
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    return "true";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }

        }
        public static bool Actualizaruser(Usuarios usuarios)
        {

            using (SqlConnection connection = new SqlConnection(Conexion.Rutaconexion))
            {
                SqlCommand sqlCommand = new SqlCommand("usp_modificar", connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@idUsuariso", usuarios.id);
                sqlCommand.Parameters.AddWithValue("@nombre", usuarios.nombre);
                sqlCommand.Parameters.AddWithValue("@apellido", usuarios.apellido);
                sqlCommand.Parameters.AddWithValue("@email", usuarios.email);
                sqlCommand.Parameters.AddWithValue("@fecha", usuarios.fecha);
                sqlCommand.Parameters.AddWithValue("@fecha", usuarios.fecha);
                sqlCommand.Parameters.AddWithValue("@fecha", usuarios.fecha);
                sqlCommand.Parameters.AddWithValue("@permiso", usuarios.permiso);
                sqlCommand.Parameters.AddWithValue("@permiso", usuarios.permiso);
                try
                {
                    connection.Open();
                    sqlCommand.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }

            }
        }
        public static List<Usuarios> ListarUser()
        {
            List<Usuarios> Lista = new List<Usuarios>();
            using (SqlConnection connection = new SqlConnection(Conexion.Rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("ListarUsuarios", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    //  cmd.ExecuteNonQuery();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new Usuarios()
                            {
                                 id = Convert.ToInt32(dr["id"]),
                                nombre = dr["nombre"].ToString(),
                                apellido = dr["apellido"].ToString(),
                                email = dr["email"].ToString(),
                                fecha = Convert.ToDateTime(dr["fecha"]),
                                dni = Convert.ToInt32(dr["dni"]),
                                domicilio = dr["domicilio"].ToString(),
                                passwrd = dr["passwrd"].ToString(),
                                permiso = dr["permiso"].ToString()
                            
                            });
                        }
                    }
                    return Lista;
                }
                catch (System.Exception)
                {

                    return Lista;
                }

            }
        }
        public static Usuarios Obtener(int idusuario)
        {
            Usuarios oUsuario = new Usuarios();
            using (SqlConnection oConexion = new SqlConnection(Conexion.Rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("usp_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", idusuario);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {

                        while (dr.Read())
                        {
                            oUsuario = new Usuarios()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                nombre = dr["nombre"].ToString(),
                                apellido = dr["apellido"].ToString(),
                                email = dr["email"].ToString(),
                                fecha = Convert.ToDateTime(dr["fecha"]),
                                dni = Convert.ToInt32(dr["dni"]),
                                domicilio = dr["domicilio"].ToString(),
                                passwrd = dr["passwrd"].ToString(),
                                permiso = dr["permiso"].ToString()
                            };
                        }

                    }



                    return oUsuario;
                }
                catch (Exception)
                {
                    return oUsuario;
                }
            }
        }
        public static bool Eliminar(int id)
        {
            using (SqlConnection oConexion = new SqlConnection(Conexion.Rutaconexion))
            {
                SqlCommand cmd = new SqlCommand("usp_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

    }
}