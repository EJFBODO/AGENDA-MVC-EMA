using AGENDA_MVC_EMA.DTOS;
using AGENDA_MVC_EMA.Models;
using AGENDA_MVC_EMA.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AGENDA_MVC_EMA.Services
{
    public class ContactosServices : IContactos

    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public ContactosServices(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IEnumerable<ResponseContactosDTO> getContactos(string IdUser)
        {
            var listadoContactos = _context.Contactos
             .Include(x => x.User)
             .Where(c => c.idUser.Equals(IdUser))
             .Select(c => new ResponseContactosDTO(c)
             {
                 Id = c.Id,
                 Nombre = c.Nombre,
                 Apellido = c.Apellido,
                 Edad = c.Edad,
                 Direccion = c.Direccion,
                 Telefono = c.Telefono
             })
                .ToList();

            return listadoContactos;
        }


        public ResponseContactosDTO getContacto(int idContacto)
        {
            var contacto = _context.Contactos
                  .Where(c => c.Id == idContacto)
                 .Select(t => new ResponseContactosDTO(t))
                 .FirstOrDefault();

            return contacto;
        }

        public bool crearContacto(CreateContactosDTO nuevoContacto, string idUser)
        {
            var user = _userManager.FindByIdAsync(idUser);

            var c = new Contactos()
            {
                Nombre = nuevoContacto.Nombre,
                Apellido = nuevoContacto.Apellido,
                Edad = nuevoContacto.Edad,
                Direccion = nuevoContacto.Direccion,
                Telefono = nuevoContacto.Telefono

            };

            var result = _context.Contactos.Add(c);
            _context.SaveChanges();
            return true;
        }

        public bool updateContacto(UpdateContactosDTO uc, string idUser)
        {

            var user = _userManager.FindByIdAsync(idUser);

            var contacto = _context.Contactos
             
            .Where(c => c.Id== uc.Id)
            .FirstOrDefault();


            if (contacto != null)
            {
                contacto.Nombre = uc.Nombre;
                contacto.Apellido = uc.Apellido;
                contacto.Edad=uc.Edad;
                contacto.Direccion=uc.Direccion;
                contacto.Telefono = uc.Telefono;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public MensajeContactosDTO borrarContacto(int idContacto, string idUser)
        {

            var user = _userManager.FindByIdAsync(idUser);
            var contacto = _context.Contactos.Where(c => c.Id == idContacto).FirstOrDefault();

            if (contacto != null)
            {
                _context.Contactos.Remove(contacto);
                _context.SaveChanges();
                return new MensajeContactosDTO()
                {
                    estado = "Borrado",
                    Mensaje = $"El contacto con id: {idContacto} fue borrado correctamente"
                };
            }
            else
            {
                return new MensajeContactosDTO()
                {
                    estado = "Error",
                    Mensaje = $"El contacto con id: {idContacto} no existe en la base de datos"
                };
            }


        }




    }




}


