using gestion_assoc.Data;
using gestion_assoc.Models.Domain;
using gestion_assoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gestion_assoc.Controllers
{
    public class AssociationController : Controller
    {

        private readonly GestionAssocDbContext gestionAssocDbContext;

        public AssociationController(GestionAssocDbContext gestionAssocDbContext)
        {
            this.gestionAssocDbContext = gestionAssocDbContext;
        }

        public IActionResult Create()
        {
            return View();
        }



        
        [HttpPost]
        public async Task<IActionResult> Create(AddAssociationViewModel addAssociationRequest)
        {
            var association = new Association()
            {
                Id = Guid.NewGuid(),
                Nom = addAssociationRequest.Nom,
                Tel_1 = addAssociationRequest.Tel_1,
                Tel_2 = addAssociationRequest.Tel_2,
                Email = addAssociationRequest.Email,
                Adresse = addAssociationRequest.Adresse,
            };

            await gestionAssocDbContext.Associations.AddAsync(association);
            await gestionAssocDbContext.SaveChangesAsync();
            return RedirectToAction("List");
            
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var associations = await gestionAssocDbContext.Associations.ToListAsync();
            return View(associations);
        }
         
        public async Task<IActionResult> Read(Guid id)
        {
            var association = await gestionAssocDbContext.Associations.FirstOrDefaultAsync(x => x.Id == id);
            if (association != null)
            {
                var viewModel = new UpdateAssociationViewModel
                {
                    Id = association.Id,
                    Nom = association.Nom,
                    Annee_Creation = association.Annee_Creation,
                    Tel_1 = association.Tel_1,
                    Tel_2 = association.Tel_2,
                    Email= association.Email,
                    Adresse = association.Adresse,
                };

                return await Task.Run(() => View("Read", viewModel));
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Read(UpdateAssociationViewModel model)
        {
            var association = await gestionAssocDbContext.Associations.FindAsync(model.Id);
            if (association != null)
            {
                association.Nom = model.Nom;
                association.Annee_Creation = model.Annee_Creation;
                association.Tel_1 = model.Tel_1;
                association.Tel_2 = model.Tel_2;
                association.Email = model.Email;
                association.Adresse = model.Adresse;

                await gestionAssocDbContext.SaveChangesAsync();
                return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateAssociationViewModel model)
        {
            var association = await gestionAssocDbContext.Associations.FindAsync(model.Id);

            if (association != null)
            {
                gestionAssocDbContext.Associations.Remove(association);
                await gestionAssocDbContext.SaveChangesAsync();

                return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }
    }
}
    