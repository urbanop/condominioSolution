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
    public class MoradorRepository : IMoradorRepository
    {
        private readonly CondominioDbContext _condominioDbContext;

        public MoradorRepository(CondominioDbContext condominioDbContext)
        {
            _condominioDbContext = condominioDbContext;
        }

        public void Excluir(int id)
        {
            try
            {
                Morador morador = ObterPorId(id);

                if (morador != null)
                {
                    _condominioDbContext.Morador.Remove(morador);
                    _condominioDbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IList<Morador> Listar()
        {
            return _condominioDbContext.Morador
                .Include(m => m.Familia)
                .ThenInclude(f => f.Condominio)
                .ToList();
        }

        public Morador ObterPorId(int id)
        {
            return _condominioDbContext.Morador
                .Include(m => m.Familia)
                .ThenInclude(f => f.Condominio)
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }

        public void Salvar(Morador morador)
        {
            try
            {
                Morador m = ObterPorId(morador.Id);
                if (m != null)
                {
                    _condominioDbContext.Entry<Morador>(m).State = EntityState.Detached;
                    _condominioDbContext.SaveChanges();

                    _condominioDbContext.Morador.Update(morador);
                }
                else
                {
                    _condominioDbContext.Morador.Add(morador);
                }
                _condominioDbContext.SaveChanges();

                var pedidoSalvo = ObterPorId(morador.Id);
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
        }
    }
}
