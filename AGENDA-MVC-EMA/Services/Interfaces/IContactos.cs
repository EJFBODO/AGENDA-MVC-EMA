using AGENDA_MVC_EMA.DTOS;

namespace AGENDA_MVC_EMA.Services.Interfaces
{
    public interface IContactos
    {
        public IEnumerable<ResponseContactosDTO> getContactos(string IdUser);
        public ResponseContactosDTO getContacto(int idContacto);

        public bool crearContacto(CreateContactosDTO nuevoContacto, string idUserCurrent);

        public Task <bool> updateContacto(UpdateContactosDTO uc, string idUserCurrent);

        public MensajeContactosDTO borrarContacto(int idContacto, string idUserCurrent);
    }
}
