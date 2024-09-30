namespace Sistema_Facturacion.models.Usuarios
{
    public class UsuarioDto
    {
        public string UsuarioId { get; set; } // ID del usuario
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string RolId { get; set; } // ID del rol
        public string RolNombre { get; set; } // Nombre del rol del usuario
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

        public static UsuarioDto FromEntity(UsuarioEntity entity, string rolNombre, string rolId)
        {
            return new UsuarioDto
            {
                UsuarioId = entity.UsuarioId,
                Nombre = entity.Nombre,
                Correo = entity.Correo,
                Contrasena = entity.Contrasena, // Considera si deseas exponer la contraseña
                RolId = rolId, // ID del rol asociado
                RolNombre = rolNombre, // Nombre del rol asociado
                Activo = entity.Activo == 1 // Convertir int a bool
            };
        }
    }
}
