using MultiLingo.Domain.Arguments.Aluno;
using MultiLingo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLingo.Domain.Interfaces.Services
{
    public interface IServiceAluno
    {

        Aluno LoadAlunoById(Guid id);
        bool CheckIfExists(Guid id);
        AddAlunoResponse Add(AddAlunoRequest aluno);
        EditAlunoResponse Edit(EditAlunoRequest aluno);
        bool Delete(Guid id);
    }
}
