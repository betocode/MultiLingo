using MultiLingo.Domain.Arguments.Turma;
using MultiLingo.Domain.Entities;
using MultiLingo.Domain.Interfaces.Repositories;
using MultiLingo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLingo.Domain.Services
{
    public class ServiceTurma : IServiceTurma
    {
        private readonly IRepositoryTurma _repositoryTurma;

        public ServiceTurma(IRepositoryTurma repositoryTurma)
        {
            _repositoryTurma = repositoryTurma;
        }
        public AddTurmaRequest Add(AddTurmaResponse turma)
        {
            throw new NotImplementedException();
        }


        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public EditTurmaRequest Edit(EditTurmaResponse turma)
        {
            throw new NotImplementedException();
        }

        public List<Turma> LoadAllTurmas()
        {
            throw new NotImplementedException();
        }

     

        public Turma LoadTurma(Guid id)
        {
            return _repositoryTurma.Select(id);
        }
    }
}
