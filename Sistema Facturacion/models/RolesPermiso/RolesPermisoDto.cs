namespace Sistema_Facturacion.models.RolesPermiso
{
    public class RolesPermisosDto
    {
        public string Id { get; set; }
        public string RolId { get; set; }
        public string PermisoId { get; set; }
        public DateTime FechaCreacion { get; set; }

        public static RolesPermisosDto FromEntity(RolesPermisosEntity entity)
        {
            return new RolesPermisosDto
            {
                Id = entity.Id,
                RolId = entity.RolId,
                PermisoId = entity.PermisoId,
                FechaCreacion = entity.FechaCreacion
            };
        }

        public static RolesPermisosEntity ToEntity(RolesPermisosDto dto)
        {
            return new RolesPermisosEntity
            {
                Id = dto.Id,
                RolId = dto.RolId,
                PermisoId = dto.PermisoId,
                FechaCreacion = dto.FechaCreacion
            };
        }
    }

    public class RolesPermisosUpsertDto
    {
        public string RolId { get; set; }
        public List<string> PermisosIds { get; set; }
    }
}
