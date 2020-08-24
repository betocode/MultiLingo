using MultiLingo.Domain.Entities;
using MultiLingo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiLingo.Infra.Persistence
{
    public class RepositoryAluno : IRepositoryAluno
    {

        protected readonly MultiLingoContext _context;
        public RepositoryAluno(MultiLingoContext context)
        {
            _context = context;
        }
        public Aluno Create(Aluno aluno)
        {
            _context.Aluno.Add(aluno);
            return aluno;
        }

        public bool Delete(Aluno aluno)
        {
            _context.Aluno.Update(aluno);
            return true;
        }

        public List<Aluno> List()
        {
            return _context.Aluno.ToList();
        }

        public Aluno SelectById(Guid id)
        {
            var aluno = _context.Aluno.Where(x => x.IdAluno.Equals(id)).FirstOrDefault();
            return aluno;
        }

        public Aluno Update(Aluno aluno)
        {
            _context.Aluno.Update(aluno);
            return aluno;
        }
    }
}
