using Aduanas.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Aduanas.Logica
{
    public class LO_Usuario
    {
        public Usuarios EncontrarUsuario(string usuario, string clave)
        {
            Usuarios objeto = new Usuarios();

            using (SqlConnection conexion = new SqlConnection("server= localhost; database= Aduanas; integrated security = true;"))
            {
                string query = "SELECT usuario, Clave, idRol FROM empleados WHERE usuario = @usuario AND clave = @clave";

                SqlCommand cmd = new SqlCommand(query, conexion);

                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@clave", clave);
                cmd.CommandType = CommandType.Text;

                conexion.Open();

                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        objeto = new Usuarios()
                        {
                            usuario = reader["usuario"].ToString(),
                            clave = reader["Clave"].ToString(),
                            idRol = (Rol)reader["idRol"]
                        };
                    }
                }

            }


                return objeto;
        }


    }
}
