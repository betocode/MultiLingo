using MultiLingo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLingo.Domain.Interfaces.Repositories
{
    public interface IRepositoryTurma
    {

        Turma Select(Guid id);

        Turma Update(Turma turma);

        Turma Create(Turma turma);

        bool Delete(Turma turma);
    }
}
