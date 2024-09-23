namespace Sistema_Facturacion.models.Rol
{
    public class RolDto
    {
        public string RolId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }

        public static RolDto FromEntity(RolEntity entity)
        {
            return new RolDto
            {
                RolId = entity.RolId,
                Nombre = entity.Nombre,
                FechaCreacion = entity.FechaCreacion,
                Activo = entity.Activo == 1
            };
        }

        public static RolEntity ToEntity(RolDto dto)
        {
            return new RolEntity
            {
                RolId = dto.RolId,
                Nombre = dto.Nombre,
                FechaCreacion = dto.FechaCreacion,
                Activo = dto.Activo ? 1 : 0
            };
        }
    }
}
