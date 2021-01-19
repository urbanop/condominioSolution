using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CondominioSolution.Application.Services;
using CondominioSolution.Domain.Entities;
using CondominioSolution.Infra.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CondominioSolution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoradorController : ControllerBase
    {
        private readonly ICondominioService _moradorService;

        public MoradorController(ICondominioService moradorService)
        {
            _moradorService = moradorService;
        }

        [HttpGet]
        public List<Morador> Listar()
        {
            return _moradorService.ListarMoradores().ToList();
        }
    }
}
