using CondominioSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioSolution.Domain.Contracts
{
    public interface IMoradorRepository
    {
        IList<Morador> Listar();
        Morador ObterPorId(int id);
        void Salvar(Morador morador);

        void Excluir(int id);
    }
}
