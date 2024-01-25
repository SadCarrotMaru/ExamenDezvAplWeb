using Examen.Data;
using Examen.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        private readonly ExamenContext _ExamenContext;

        public DatabaseController(ExamenContext examencontext)
        {
            _ExamenContext = examencontext;
        }

        [HttpGet("CarteGet")]
        public async Task<IActionResult> GetCarte()
        {
            return Ok(await _ExamenContext.Carti.ToListAsync());
        }

        [HttpPost("CartePost")]
        public async Task<IActionResult> Create(CarteRequestModel cartemodel)
        {
            var newCarte = new Carte
            {
                Id = Guid.NewGuid(),
                Nume = cartemodel.Nume,
                Subiect = cartemodel.Subiect,
                Pret = cartemodel.Pret
            };


            if (cartemodel.Autori != null && cartemodel.Autori.Any())
            {
                foreach (var autorId in cartemodel.Autori)
                {
                    var autor = await _ExamenContext.Autori.FindAsync(autorId);
                    
                    if (autor != null)
                    {

                        if (autor.ModelsRelations == null)
                        {
                            autor.ModelsRelations = new List<ModelsRelation>();
                        }

                        if (newCarte.ModelsRelations == null)
                        {
                            newCarte.ModelsRelations = new List<ModelsRelation>();
                        }

                        var MR = new ModelsRelation{ Carte = newCarte, Autor = autor, AutorId = autorId, CarteId = newCarte.Id };

                        newCarte.ModelsRelations.Add(MR);
                        autor.ModelsRelations.Add(MR);
                    }
                }
            }

            
            await _ExamenContext.AddAsync(newCarte);
            await _ExamenContext.SaveChangesAsync();

            return Ok(newCarte);
        }

        [HttpGet("AutorGet")]
        public async Task<IActionResult> GetAutor()
        {
            return Ok(await _ExamenContext.Autori.ToListAsync());
        }

        [HttpPost("AutorPost")]
        public async Task<IActionResult> Create(AutorRequestModel autormodel)
        {
            var newAutor = new Autor
            {
                Id = Guid.NewGuid(),
                Nume = autormodel.Nume,
                Varsta = autormodel.Varsta,
                LocNastere = autormodel.LocNastere
            };

            var editura = await _ExamenContext.Edituri.FindAsync(autormodel.IdEditura);
            if (editura != null)
            {
                newAutor.IdEditura = autormodel.IdEditura;
                newAutor.EdituraCarte = editura;
            }

            if (autormodel.Carti != null && autormodel.Carti.Any())
            {
                foreach (var carteId in autormodel.Carti)
                {
                    var carte = await _ExamenContext.Carti.FindAsync(carteId);

                    if (carte != null)
                    {

                        if (carte.ModelsRelations == null)
                        {
                            carte.ModelsRelations = new List<ModelsRelation>();
                        }

                        if (newAutor.ModelsRelations == null)
                        {
                            newAutor.ModelsRelations = new List<ModelsRelation>();
                        }

                        var MR = new ModelsRelation { Autor = newAutor, Carte = carte, AutorId = newAutor.Id, CarteId = carteId };

                        newAutor.ModelsRelations.Add(MR);
                        carte.ModelsRelations.Add(MR);
                    }
                }
            }


            await _ExamenContext.AddAsync(newAutor);
            await _ExamenContext.SaveChangesAsync();

            return Ok(newAutor);
        }

        [HttpGet("EdituraGet")]
        public async Task<IActionResult> GetEditura()
        {
            return Ok(await _ExamenContext.Edituri.ToListAsync());
        }

        [HttpPost("EdituraPost")]

        public async Task<IActionResult> Create(EdituraRequestModel edituramodel)
        {
            var newEditura = new Editura
            {
                Id = Guid.NewGuid(),
                Nume = edituramodel.Nume,
                Vechime = edituramodel.Vechime
            };

            await _ExamenContext.AddAsync(newEditura);
            await _ExamenContext.SaveChangesAsync();

            return Ok(newEditura);
        }


    }
}
