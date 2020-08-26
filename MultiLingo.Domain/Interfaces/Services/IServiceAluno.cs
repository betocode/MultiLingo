using MultiLingo.Domain.Arguments.Aluno;
using MultiLingo.Domain.Entities;
using System;

namespace MultiLingo.Domain.Interfaces.Services
{
    public interface IServiceAluno
    {

        Aluno LoadAlunoById(Guid id);
        bool CheckIfExists(string Matricula);
        AddAlunoResponse Add(AddAlunoRequest aluno);
        EditAlunoResponse Edit(EditAlunoRequest aluno);
        bool Delete(Guid id);

       

        bool DeleteFromTurma(Guid idAluno, Guid idTurma);
    }
}
