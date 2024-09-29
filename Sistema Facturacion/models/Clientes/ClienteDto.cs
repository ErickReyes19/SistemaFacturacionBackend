
namespace Sistema_Facturacion.models.Clientes
{
    public class ClienteDto
    {
        public string ClienteId { get; set; }
        public string Identidad { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaRegistro { get; set; }

        public static ClienteDto FromEntity(ClienteEntity clienteEntity)
        {
            return new ClienteDto
            {
                ClienteId = clienteEntity.ClienteId,
                Nombre = clienteEntity.Nombre,
                Identidad = clienteEntity.Identidad,
                Apellido = clienteEntity.Apellido,
                Correo = clienteEntity.Correo,
                Telefono = clienteEntity.Telefono,
                Direccion = clienteEntity.Direccion,
                Activo = clienteEntity.Activo == 1,
                FechaRegistro = clienteEntity.FechaRegistro
            };
        }

        public static ClienteEntity ToEntity(ClienteDto clienteDto)
        {
            return new ClienteEntity
            {
                ClienteId = clienteDto.ClienteId,
                Nombre = clienteDto.Nombre,
                Identidad = clienteDto.Identidad,
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
