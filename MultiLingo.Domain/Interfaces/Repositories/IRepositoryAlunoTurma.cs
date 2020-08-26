using MultiLingo.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MultiLingo.Domain.Interfaces.Repositories
{
    public interface IRepositoryAlunoTurma
    {
        void DeleteAlunoTurma(AlunoTurma alunoTurmas);
        void DeleteAluno(List<AlunoTurma> entity);

        List<AlunoTurma> SelectTurma(Guid idTurma);
        List<AlunoTurma> SelectAluno(Guid idAluno);
        void AddAluno(AlunoTurma entity);
    }
}
