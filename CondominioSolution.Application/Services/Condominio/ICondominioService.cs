using CondominioSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioSolution.Application.Services
{
    public interface ICondominioService 
    {
        IList<Morador> ListarMoradores();
        IList<Familia> ListarFamilias();
        Morador ObterMorador(int id);
        void SalvarMorador(Morador morador);
        void ExcluirMorador(int id);
    }
}
