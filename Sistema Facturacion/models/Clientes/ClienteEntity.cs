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

        public static ClienteEntity ToEntity(ClienteDto clienteDto)
        {
            return new ClienteEntity
            {
                ClienteId = clienteDto.ClienteId,
                Nombre = clienteDto.Nombre,
                Apellido = clienteDto.Apellido,
                Correo = clienteDto.Correo,
                Telefono = clienteDto.Telefono,
                Direccion = clienteDto.Direccion,
                Activo = clienteDto.Activo ? 1 : 0,
                FechaRegistro = clienteDto.FechaRegistro
            };
        }
    }


}
