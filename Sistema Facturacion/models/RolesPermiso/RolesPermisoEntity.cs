using Sistema_Facturacion.models.Permiso;

public class RolesPermisosEntity
{
    public string Id { get; set; }  // Identificador único
    public string RolId { get; set; }
    public string PermisoId { get; set; }
    public DateTime FechaCreacion { get; set; }
    public RolEntity Rol { get; set; }
    public PermisoEntity Permiso { get; set; }
}
