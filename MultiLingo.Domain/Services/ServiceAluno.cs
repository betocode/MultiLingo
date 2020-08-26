using Microsoft.EntityFrameworkCore.Internal;
using MultiLingo.Domain.Arguments.Aluno;
using MultiLingo.Domain.Entities;
using MultiLingo.Domain.Interfaces.Repositories;
using MultiLingo.Domain.Interfaces.Services;
using System;

namespace MultiLingo.Domain.Services
{
    public class ServiceAluno : IServiceAluno

    {
        private readonly IRepositoryAluno _repository;
        private readonly IRepositoryAlunoTurma _repositoryAlunoTurma;
       
        public ServiceAluno(IRepositoryAluno repository, IRepositoryAlunoTurma repositoryAlunoTurma)
        {
            _repository = repository;
            _repositoryAlunoTurma = repositoryAlunoTurma;
        }
        public AddAlunoResponse Add(AddAlunoRequest aluno)
        {     
            var entity = new Aluno(aluno.Nome, aluno.Matricula);
            entity = _repository.Create(entity);
            var alunoTurma = new AlunoTurma(entity.IdAluno, aluno.IdTurma);
            _repositoryAlunoTurma.AddAluno(alunoTurma);
            return (AddAlunoResponse)entity;

        }





        public bool CheckIfExists(string matricula)
        {
            var entity = _repository.SelectByMatricula(matricula);
            if (entity != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

     

        public bool Delete(Guid id)
        {

            var turmas = _repositoryAlunoTurma.SelectAluno(id);
            if (turmas.Any())
            {
                throw new ArgumentException("Aluno não pode ser deletado pois está inserido em uma turma");
            }

            var entity = _repository.SelectById(id);
            entity.Delete();
            _repository.Delete(entity);
           
           
            return true;
        }

        public bool DeleteFromTurma(Guid idAluno, Guid idTurma)
        {
            var entity = new AlunoTurma(idAluno, idTurma);
            entity.Delete();
            _repositoryAlunoTurma.DeleteAlunoTurma(entity);
            return true;
        }

        public EditAlunoResponse Edit(EditAlunoRequest aluno)
        {
       
            var entity = _repository.SelectById(aluno.IdAluno);
            entity.ChangeAluno(aluno.Nome, aluno.Matricula);
            entity = _repository.Update(entity);
            return (EditAlunoResponse)entity;
        }

        public Aluno LoadAlunoById(Guid id)
        {
            var entity = _repository.SelectById(id);
            return entity;
        }
    }
}
