using CondominioSolution.Domain.Contracts;
using CondominioSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioSolution.Application.Services
{
    public class CondominioService : ICondominioService
    {
        private readonly IMoradorRepository _moradorRepository;
        private readonly IFamiliaRepository _familiaRepository;

        public CondominioService(IMoradorRepository moradorRepository, 
            IFamiliaRepository familiaRepository)
        {
            _moradorRepository = moradorRepository;
            _familiaRepository = familiaRepository;
        }

        public IList<Morador> ListarMoradores()
        {
            return _moradorRepository.Listar();
        }

        public Morador ObterMorador(int id)
        {
            return _moradorRepository.ObterPorId(id);
        }


        public IList<Familia> ListarFamilias() 
        {
            return _familiaRepository.Listar();
        }

        public void SalvarMorador(Morador morador)
        {
            try
            {
                if (morador != null)
                    _moradorRepository.Salvar(morador);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ExcluirMorador(int id)
        {
            try
            {
                if (id != 0)
                    _moradorRepository.Excluir(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
