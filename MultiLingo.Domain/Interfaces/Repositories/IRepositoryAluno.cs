using MultiLingo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLingo.Domain.Interfaces.Repositories
{
    public interface IRepositoryAluno
    {
        Aluno SelectByMatricula(string matricula);
        Aluno SelectById(Guid id);
        List<Aluno> List();

        Aluno Update(Aluno aluno);

        Aluno Create(Aluno aluno);

        bool Delete(Aluno aluno);
    }
}
