using System.Data;
using System.Collections.Generic;
using Preparcial.Modelo;
using System;
using System.Windows.Forms;

namespace Preparcial.Controlador
{
    public static class ControladorUsuario
    {
        public static List<Usuario> GetUsuarios()
        {
            // Iniciando correctamente la lista
            List<Usuario> usuarios = new List<Usuario>();
            DataTable tableUsuarios = null;

            // try  innenesario
            tableUsuarios = ConexionBD.EjecutarConsulta("SELECT * FROM USUARIO");
            

            foreach(DataRow dr in tableUsuarios.Rows)
            {
                //Llenando correctamente la tabla
                        
                        Usuario u = new Usuario();
                        u.IdUsuario = dr[0].ToString();
                        u.NombreUsuario = dr[1].ToString();
                        u.Contrasena = dr[2].ToString();
                        u.Admin = Convert.ToBoolean(dr[3].ToString());

                        usuarios.Add(u);
            }

            return usuarios;
        }
        
        //Codigo innecesario, ya que la funcion anterior hace una parte de esto
        
        /*public static DataTable GetUsuariosTable()
        {
            DataTable tableUsuarios = null;

            try
            {
                tableUsuarios = ConexionBD.EjecutarConsulta("SELECT * FROM USUARIO");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }

            return tableUsuarios;
        }*/

        public static void ActualizarContrasena(string idUsuario, string nueva)
        {
            try
            {
                ConexionBD.EjecutarComando($"UPDATE USUARIO SET contrasenia = '{nueva}' " +
                    $"WHERE idUsuario = {idUsuario}");

                MessageBox.Show("Se ha actualizado la contrasena");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }

        public static void CrearUsuario(string usuario)
        {
            try
            {
                //No metia correctamente los datos ya que decia nombreUsuario y no nombre
                ConexionBD.EjecutarComando("INSERT INTO USUARIO(nombre, contrasenia, tipo)" +
                                           $" VALUES('{usuario}', '{usuario}', false)");

                MessageBox.Show("Se ha agregado el nuevo usuario, contrasenia igual al nombre");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error");
            }
        }
    }
}
