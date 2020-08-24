using MultiLingo.Domain.Arguments.Turma;
using MultiLingo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLingo.Domain.Interfaces.Services
{
    public interface IServiceTurma
    {
        List<Turma> LoadAllTurmas();
        Turma LoadTurma(Guid id);
        AddTurmaRequest Add(AddTurmaResponse turma);

        EditTurmaRequest Edit(EditTurmaResponse turma);

        bool Delete(Guid id);
    }
}
