using MultiLingo.Domain.Arguments.Aluno;
using MultiLingo.Domain.Entities;
using MultiLingo.Domain.Interfaces.Repositories;
using MultiLingo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace MultiLingo.Domain.Services
{
    public class ServiceAluno : IServiceAluno

    {
        private readonly IRepositoryAluno _repository;
        public ServiceAluno(IRepositoryAluno repository)
        {
            _repository = repository;
        }
        public AddAlunoResponse Add(AddAlunoRequest aluno)
        {
            var aln = new Aluno();
            aln.IdAluno = Guid.NewGuid();
            aln.IdTurma = aluno.IdTurma;
            aln.Nome = aluno.Nome;
            aln.Matricula = aluno.Matricula;
            aln = _repository.Create(aln);

            var response = new AddAlunoResponse { Nome = aln.Nome };
            return response;

        }

        public bool CheckIfExists(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public EditAlunoResponse Edit(EditAlunoRequest aluno)
        {
            throw new NotImplementedException();
        }

        public Aluno LoadAlunoById(Guid id)
        {
            var gid = new Guid();
            return new Aluno();
        }
    }
}
