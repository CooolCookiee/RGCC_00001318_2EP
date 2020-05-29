using System;
using System.Collections.Generic;
using System.Data;

namespace CodigoParcial
{
    public static class UsuarioDAO1
    {
        public static List<Usuario> getLista()
        {
            string sql = "SELECT * FROM APPUSER";
            DataTable dt = ConnectionDB.ExecuteQuery(sql);
                    
            List<Usuario> lista = new List<Usuario>();
                    
            foreach(DataRow fila in dt.Rows)
            {
                Usuario u = new Usuario();

                u.iduser = fila[0].ToString();
                u.fullname = fila[1].ToString();
                u.username = fila[2].ToString();
                u.password = fila[3].ToString();
                u.userType = Convert.ToBoolean(fila[4].ToString());
                
                lista.Add(u);

            }

            return lista;
        }

        public static void crearNuevo(string usuario, string nombre)
        {
            string sql = String.Format("INSERT INTO APPUSER(fullname, username, password, userType) VALUES( "+
                                       $"'{nombre}',"+
                                       $"'{usuario}',"+
                                       $"'{usuario}',false)");


            ConnectionDB.ExecuteNonQuery(sql);
        }

    }
}