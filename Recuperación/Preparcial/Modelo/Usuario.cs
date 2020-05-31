namespace Preparcial.Modelo
{
    public class Usuario
    {
        public string IdUsuario { get; set; }

        public string NombreUsuario { get; set; }

        public string Contrasena { get; set; }

        public bool Admin { get; set; }

        //Funcion con errores, que evita que acceda correctamente a la informacion
        public Usuario()
        {

            IdUsuario = "";
            NombreUsuario = "";
            Contrasena = "";
            Admin = false;
        }
    }
}
