using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preparcial.Modelo
{
    public class Inventario
    {
        //Hacen falta los setters
        
        public string idArticulo { get; set; }
        public string producto { get; set; }
        public string descripcion { get; set; }
        public string precio { get; set;}
        public string stock { get; set; }

        //Funcion con errores, que evita que acceda correctamente a la informacion
        public Inventario()
        {
            idArticulo = "";
            producto = "";
            descripcion = "";
            precio = "";
            stock = "";
        }
    }
}
