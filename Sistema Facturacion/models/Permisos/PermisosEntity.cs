namespace Sistema_Facturacion.models.Permiso
{
    public class PermisoEntity
    {
        public string PermisoId { get; set; } 
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Activo { get; set; } 
    }
}
