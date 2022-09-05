using gestion_assoc.Data;
using gestion_assoc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gestion_assoc.Controllers
{
    public class ActiviteController : Controller
    {

        private readonly GestionAssocDbContext gestionAssocDbContext;

        public ActiviteController(GestionAssocDbContext gestionAssocDbContext)
        {
            this.gestionAssocDbContext = gestionAssocDbContext;
        }

        public IActionResult Create()
        {
            return View();
        }

   [HttpPost]
        public async Task<IActionResult> Create(Activite addActiviteRequest)
        {
            var activite = new Activite()
            {
                Id = Guid.NewGuid(),
                Nom = addActiviteRequest.Nom,
                Libelle = addActiviteRequest.Libelle,
                Date_prev = addActiviteRequest.Date_prev,
                Date_exec = addActiviteRequest.Date_exec,
                Type = addActiviteRequest.Type,
                Besoins = addActiviteRequest.Besoins,
                CompteRendu = addActiviteRequest.CompteRendu,
                Lieu = addActiviteRequest.Lieu,
            };

            await gestionAssocDbContext.Activites.AddAsync(activite);
            await gestionAssocDbContext.SaveChangesAsync();
            return RedirectToAction("List");
            
        }

          [HttpGet]
        public async Task<IActionResult> List()
        {
            var activites = await gestionAssocDbContext.Activites.ToListAsync();
            return View(activites);
        }


     public async Task<IActionResult> Read(Guid id)
        {
            var activite = await gestionAssocDbContext.Activites.FirstOrDefaultAsync(x => x.Id == id);
            if (activite != null)
            {
                var viewModel = new Activite
                {
                  Id = activite.Id,
                Nom = activite.Nom,
                Libelle = activite.Libelle,
                Date_prev = activite.Date_prev,
                Date_exec = activite.Date_exec,
                Type = activite.Type,
                Besoins = activite.Besoins,
                CompteRendu = activite.CompteRendu,
                Lieu = activite.Lieu,
                };

                return await Task.Run(() => View("Read", viewModel));
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Read(Activite model)
        {
            var activite = await gestionAssocDbContext.Activites.FindAsync(model.Id);
            if (activite != null)
            {
                activite.Nom = model.Nom;
                activite.Libelle = model.Libelle;
                activite.Date_prev = model.Date_prev;
                activite.Date_exec = model.Date_exec;
                activite.Type = model.Type;
                activite.Besoins = model.Besoins;
                activite.CompteRendu = model.CompteRendu;
                activite.Lieu = model.Lieu;

                await gestionAssocDbContext.SaveChangesAsync();
                return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Activite model)
        {
            var activite = await gestionAssocDbContext.Activites.FindAsync(model.Id);

            if (activite != null)
            {
                gestionAssocDbContext.Activites.Remove(activite);
                await gestionAssocDbContext.SaveChangesAsync();

                return RedirectToAction("List");
            }

            return RedirectToAction("List");
        }
       
     

   
    }
}
    