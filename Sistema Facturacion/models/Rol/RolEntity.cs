using Sistema_Facturacion.models.RolesPermiso;
using Sistema_Facturacion.models.Usuarios;

public class RolEntity
{
    public string RolId { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaCreacion { get; set; }
    public int Activo { get; set; }
    public ICollection<UsuarioEntity> Usuarios { get; set; } = new List<UsuarioEntity>(); 
    public ICollection<RolesPermisosEntity> RolesPermisos { get; set; } = new List<RolesPermisosEntity>();
}
