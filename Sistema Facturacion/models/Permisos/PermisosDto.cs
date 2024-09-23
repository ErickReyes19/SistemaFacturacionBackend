namespace Sistema_Facturacion.models.Permiso
{
    public class PermisoDto
    {
        public string PermisoId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }

        public static PermisoDto FromEntity(PermisoEntity entity)
        {
            return new PermisoDto
            {
                PermisoId = entity.PermisoId,
                Nombre = entity.Nombre,
                FechaCreacion = entity.FechaCreacion,
                Activo = entity.Activo == 1
            };
        }

        public static PermisoEntity ToEntity(PermisoDto dto)
        {
            return new PermisoEntity
            {
                PermisoId = dto.PermisoId,
                Nombre = dto.Nombre,
                FechaCreacion = dto.FechaCreacion,
                Activo = dto.Activo ? 1 : 0
            };
        }
    }
}
