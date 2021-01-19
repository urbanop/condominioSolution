using CondominioSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CondominioSolution.Domain.Contracts
{
    public interface IFamiliaRepository
    {
        IList<Familia> Listar();
    }
}
