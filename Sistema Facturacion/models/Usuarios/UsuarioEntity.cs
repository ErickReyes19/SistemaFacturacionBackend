namespace Sistema_Facturacion.models.Usuarios
{
    public class UsuarioEntity
    {
        public string UsuarioId { get; set; } 
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string RolId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int Activo { get; set; } 
    }
}
