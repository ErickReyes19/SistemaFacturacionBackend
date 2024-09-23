namespace Sistema_Facturacion.models.Rol
{
    public class RolEntity
    {
        public string RolId { get; set; } 
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Activo { get; set; }
    }
}
