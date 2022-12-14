using AGENDA_MVC_EMA.DTOS;
using AGENDA_MVC_EMA.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AGENDA_MVC_EMA.Controllers
{
    public class ContactosController : Controller


    {
        private readonly IContactos _contactosServices;
        private readonly UserManager<IdentityUser> _userManager;
        public ContactosController(IContactos contactosServices, UserManager<IdentityUser> userManager)



        {
            _contactosServices = contactosServices;
            _userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var idUserCurrent = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _contactosServices.getContactos(idUserCurrent);
            return View(response);
        }

        public async Task<IActionResult> get(int idContacto)

        {


            var response = await _contactosServices.getContacto(idContacto);
            return View(response);
        }

        public IActionResult Form()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateContacto(CreateContactosDTO contacto, String idUser)

        {
            var idUserCurrent = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _contactosServices.crearContacto(contacto, idUserCurrent);
            return RedirectToAction("Index");

        }

        [Authorize]
        public async Task<IActionResult> Borrar(int Id, string idUser)

        {
            var idUserCurrent = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _contactosServices.borrarContacto(Id, idUserCurrent);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var contacto = await _contactosServices.getContacto(Id);

            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        [Authorize]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(UpdateContactosDTO update, string idUser)

        {
            var idUserCurrent = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var updateContacto = await _contactosServices.updateContacto(update, idUserCurrent);

            if (updateContacto)
            {
                return RedirectToAction("Index");

            }
            else
            {
                return NotFound();
            }

        }

    }
}
