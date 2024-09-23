namespace Sistema_Facturacion.models.Clientes
{
    public class ClienteEntity
    {
        public string ClienteId { get; set; }
        public string Nombre { get; set; } 
        public string Apellido { get; set; } 
        public string Correo { get; set; } 
        public string Telefono { get; set; } 
        public string Direccion { get; set; } 
        public int Activo { get; set; }
        public DateTime FechaRegistro { get; set; }

    }


}
