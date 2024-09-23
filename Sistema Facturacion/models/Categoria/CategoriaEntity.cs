namespace Sistema_Facturacion.models.Categoria
{
    public class CategoriaEntity
    {
        public string CategoriaId { get; set; } 
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Activo { get; set; }
    }
}
