namespace Sistema_Facturacion.models.Usuarios
{
    public class UsuarioDto
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string RolId { get; set; }
        public bool Activo { get; set; }

        public static UsuarioEntity ToEntity(UsuarioDto dto)
        {
            return new UsuarioEntity
            {
                UsuarioId = Guid.NewGuid().ToString(),
                Nombre = dto.Nombre,
                Correo = dto.Correo,
                Contrasena = dto.Contrasena,
                RolId = dto.RolId,
                FechaCreacion = DateTime.Now,
                Activo = dto.Activo ? 1 : 0 
            };
        }
    }
}
