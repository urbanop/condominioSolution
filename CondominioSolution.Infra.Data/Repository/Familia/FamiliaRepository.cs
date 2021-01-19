using CondominioSolution.Domain.Contracts;
using CondominioSolution.Domain.Entities;
using CondominioSolution.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CondominioSolution.Infra.Data.Repository
{
    public class FamiliaRepository : IFamiliaRepository
    {
        private readonly CondominioDbContext _condominioDbContext;

        public FamiliaRepository(CondominioDbContext condominioDbContext)
        {
            _condominioDbContext = condominioDbContext;
        }

        public IList<Familia> Listar()
        {
            return _condominioDbContext.Familia
                .Include(f => f.Condominio)
                .ToList();
        }
    }
}
