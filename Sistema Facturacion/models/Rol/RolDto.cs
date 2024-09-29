namespace Sistema_Facturacion.models.Rol
{
    public class RolDto
    {
        public string RolId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }

        // Nueva propiedad para los permisos
        public List<string> PermisosIds { get; set; } = new List<string>();

        public static RolDto FromEntity(RolEntity entity, List<string> permisosIds = null)
        {
            return new RolDto
            {
                RolId = entity.RolId,
                Nombre = entity.Nombre,
                Descripcion = entity.Descripcion,
                FechaCreacion = entity.FechaCreacion,
                Activo = entity.Activo == 1,
                PermisosIds = permisosIds ?? new List<string>()
            };
        }

        public static RolEntity ToEntity(RolDto dto)
        {
            return new RolEntity
            {
                RolId = dto.RolId,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                FechaCreacion = dto.FechaCreacion,
                Activo = dto.Activo ? 1 : 0
            };
        }
    }

}
