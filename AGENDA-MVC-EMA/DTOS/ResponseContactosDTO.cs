using AGENDA_MVC_EMA.Models;


namespace AGENDA_MVC_EMA.DTOS
{
    public class ResponseContactosDTO
    {
        public ResponseContactosDTO() { }
        public ResponseContactosDTO(Contactos c)
        {
            Id = c.Id;
            Nombre = c.Nombre;
            Apellido = c.Apellido;
            Edad = c.Edad;
            Direccion = c.Direccion;
            Telefono = c.Telefono;

        }


        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int Edad { get; set; }

        public string Direccion { get; set; }

        public int Telefono { get; set; }

    }
}