namespace CodParcial
{
    public class Productos
    {
        public string idProduct { get; set; }
        
        public string idBusiness { get; set; }
        
        public string name { get; set; }
        
        public string fk_product_business { get; set; }
        
        public Productos()
        {
            idProduct = "";
            idBusiness = "";
            name = "";
            fk_product_business = "";
        }
    }
}