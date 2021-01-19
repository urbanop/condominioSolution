using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CondominioSolution.UI.ViewModel;
using CondominioSolution.Application.Services;
using CondominioSolution.Domain.Entities;

namespace CondominioSolution.UI.Controllers
{
    public class MoradorController : Controller
    {
        private readonly ICondominioService _condominioService;

        public MoradorController(ICondominioService condominioService)
        {
            _condominioService = condominioService;
        }

        // GET: Morador
        public async Task<IActionResult> Index()
        {
            List<MoradorViewModel> moradoresViewModel = new List<MoradorViewModel>();

            var moradores = _condominioService.ListarMoradores();

            foreach (var item in moradores)
            {
                moradoresViewModel.Add(new MoradorViewModel
                {
                    Bairro = item.Familia.Condominio.Bairro,
                    Condominio = item.Familia.Condominio.Nome,
                    Familia = item.Familia.Nome,
                    Nome = item.Nome,
                    Id = item.Id,
                    Id_Familia = item.Id_Familia,
                    QuantidadeBichosEstimacao = item.QuantidadeBichosEstimacao

                });
            }

            return View(moradores);
        }

        // GET: Morador/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var morador = _condominioService.ObterMorador(id);
                      
            if (morador == null)
            {
                return NotFound();
            }

            MoradorViewModel moradorViewModel = new MoradorViewModel
            {
                Bairro = morador.Familia.Condominio.Bairro,
                Condominio = morador.Familia.Condominio.Nome,
                Familia = morador.Familia.Nome,
                Nome = morador.Nome,
                Id = morador.Id,
                Id_Familia = morador.Id_Familia,
                QuantidadeBichosEstimacao = morador.QuantidadeBichosEstimacao
            };

            return View(moradorViewModel);
        }

        // GET: Morador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Morador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Id_Familia,Nome,QuantidadeBichosEstimacao,Familia,Condominio,Bairro")] MoradorViewModel moradorViewModel)
        {
            if (ModelState.IsValid)
            {
                var familia = _condominioService.ListarFamilias().Where(o => o.Id == moradorViewModel.Id_Familia).FirstOrDefault();
                Morador morador = new Morador
                {
                    Familia = familia,
                    Id_Familia = familia.Id,
                    Nome = moradorViewModel.Nome,
                    QuantidadeBichosEstimacao = moradorViewModel.QuantidadeBichosEstimacao
                };


                _condominioService.SalvarMorador(morador);

                return RedirectToAction(nameof(Index));
            }
            return View(moradorViewModel);
        }

        // GET: Morador/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var morador = _condominioService.ObterMorador(id);

            if (morador == null)
            {
                return NotFound();
            }

            MoradorViewModel moradorViewModel = new MoradorViewModel
            {
                Bairro = morador.Familia.Condominio.Bairro,
                Condominio = morador.Familia.Condominio.Nome,
                Familia = morador.Familia.Nome,
                Nome = morador.Nome,
                Id = morador.Id,
                Id_Familia = morador.Id_Familia,
                QuantidadeBichosEstimacao = morador.QuantidadeBichosEstimacao
            };

            return View(moradorViewModel);
        }

        // POST: Morador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Id_Familia,Nome,QuantidadeBichosEstimacao,Familia,Condominio,Bairro")] MoradorViewModel moradorViewModel)
        {
            if (id != moradorViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var familia = _condominioService.ListarFamilias().Where(o => o.Id == moradorViewModel.Id_Familia).FirstOrDefault();

                    Morador morador = new Morador
                    {
                        Familia = familia,
                        Id_Familia = familia.Id,
                        Id = moradorViewModel.Id,
                        Nome = moradorViewModel.Nome,
                        QuantidadeBichosEstimacao = moradorViewModel.QuantidadeBichosEstimacao
                    };

                    _condominioService.SalvarMorador(morador);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MoradorViewModelExists(moradorViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(moradorViewModel);
        }

        // GET: Morador/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var morador = _condominioService.ObterMorador(id);
            
            if (morador == null)
            {
                return NotFound();
            }

            MoradorViewModel moradorViewModel = new MoradorViewModel
            {
                Bairro = morador.Familia.Condominio.Bairro,
                Condominio = morador.Familia.Condominio.Nome,
                Familia = morador.Familia.Nome,
                Nome = morador.Nome,
                Id = morador.Id,
                Id_Familia = morador.Id_Familia,
                QuantidadeBichosEstimacao = morador.QuantidadeBichosEstimacao
            };


            return View(moradorViewModel);
        }

        // POST: Morador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _condominioService.ExcluirMorador(id);

            return RedirectToAction(nameof(Index));
        }

        private bool MoradorViewModelExists(int id)
        {
            return _condominioService.ListarMoradores().Any(e => e.Id == id);
        }
    }
}
