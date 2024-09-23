namespace Sistema_Facturacion.models.Categoria
{
    public class CategoriaDto
    {
        public string CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Activo { get; set; }

        public static CategoriaDto FromEntity(CategoriaEntity entity)
        {
            return new CategoriaDto
            {
                CategoriaId = entity.CategoriaId,
                Nombre = entity.Nombre,
                Descripcion = entity.Descripcion,
                FechaCreacion = entity.FechaCreacion,
                Activo = entity.Activo == 1
            };
        }

        public static CategoriaEntity ToEntity(CategoriaDto dto)
        {
            return new CategoriaEntity
            {
                CategoriaId = dto.CategoriaId,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                FechaCreacion = dto.FechaCreacion,
                Activo = dto.Activo ? 1 : 0
            };
        }
    }
}
