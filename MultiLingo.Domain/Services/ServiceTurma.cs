using Microsoft.EntityFrameworkCore.Internal;
using MultiLingo.Domain.Arguments.Turma;
using MultiLingo.Domain.Entities;
using MultiLingo.Domain.Enum;
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
        private readonly IRepositoryAlunoTurma _repositoryAlunoTurma;

        public ServiceTurma(IRepositoryTurma repositoryTurma, IRepositoryAlunoTurma repositoryAlunoTurma)
        {
            _repositoryTurma = repositoryTurma;
            _repositoryAlunoTurma = repositoryAlunoTurma;
        }
        public AddTurmaResponse Add( AddTurmaRequest turma)
        {
            var entity = new Turma(turma.Nome);
            entity = _repositoryTurma.Create(entity);
            return (AddTurmaResponse)entity;
        }

        public bool CheckIfTurmaIsAvailable(Guid idTurma)
        {

            var check = _repositoryAlunoTurma.SelectTurma(idTurma);
            if (check.Count == (int)TurmaEnum.Limite)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        public bool Delete(Guid id)
        {
           
            var turmaList = _repositoryAlunoTurma.SelectTurma(id);
            if(turmaList.Any())
            {
                return false;
            }

            var turma = _repositoryTurma.Select(id);
            turma.Delete();
            _repositoryTurma.Delete(turma);
            return true;
        }

        public EditTurmaResponse Edit( EditTurmaRequest turma)
        {
            var entity = _repositoryTurma.Select(turma.IdTurma);
            entity.ChangeName(turma.Nome);
            entity = _repositoryTurma.Update(entity);
            return (EditTurmaResponse)entity;
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
