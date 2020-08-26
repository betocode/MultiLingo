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
        AddTurmaResponse Add(AddTurmaRequest turma);
        bool CheckIfTurmaIsAvailable(Guid idTurma);
        EditTurmaResponse Edit(EditTurmaRequest turma);

        bool Delete(Guid id);
    }
}
