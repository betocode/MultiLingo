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

        private readonly MultiLingoContext _context;
    
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

        public Aluno SelectByMatricula(string matricula)
        {
            var entity = _context.Aluno.Where(x => x.Matricula.Equals(matricula) && x.IsDeletado.Equals(false)).FirstOrDefault();
            return entity;
        }

        public Aluno SelectById(Guid id)
        {
            var entity = _context.Aluno.Where(x => x.IdAluno.Equals(id)).FirstOrDefault();
            return entity;
        }
        public Aluno Update(Aluno aluno)
        {
            _context.Aluno.Update(aluno);
            return aluno;
        }
    }
}
