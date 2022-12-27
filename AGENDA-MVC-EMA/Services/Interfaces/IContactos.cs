using AGENDA_MVC_EMA.DTOS;

namespace AGENDA_MVC_EMA.Services.Interfaces
{
    public interface IContactos
    {
        public Task<IEnumerable<ResponseContactosDTO>> getContactos(string IdUser);
        public Task <ResponseContactosDTO> getContacto(int idContacto);

        public Task<bool> crearContacto(CreateContactosDTO nuevoContacto, string idUserCurrent);

        public Task <bool> updateContacto(UpdateContactosDTO uc, string idUserCurrent);

        public Task <MensajeContactosDTO> borrarContacto(int idContacto, string idUserCurrent);
    }
}
