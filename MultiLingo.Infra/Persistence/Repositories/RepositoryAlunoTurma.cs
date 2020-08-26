using MultiLingo.Domain.Entities;
using MultiLingo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiLingo.Infra.Persistence.Repositories
{
    public class RepositoryAlunoTurma : IRepositoryAlunoTurma
    {
        private readonly MultiLingoContext _context;
        public RepositoryAlunoTurma(MultiLingoContext context)
        {
            _context = context;
        }

        public void AddAluno(AlunoTurma entity)
        {     
            _context.AlunoTurma.Add(entity);
        }

        public void DeleteAlunoTurma(AlunoTurma entity)
        {
       
            _context.AlunoTurma.Update(entity);
        }

        public List<AlunoTurma> SelectTurma(Guid idTurma)
        {
            var entity = _context.AlunoTurma.Where(x => x.IdTurma.Equals(idTurma) && x.Ativo).ToList();
            return entity;
        }

        public void  DeleteAluno(List<AlunoTurma>alunoTurmas)
        {
            //var alunoTurmas = _context.AlunoTurma.Where(x => x.IdAluno.Equals(idAluno)).ToList();
            //foreach(var item in alunoTurmas)
            //{
            //    item.Delete();
            //}
            _context.AlunoTurma.UpdateRange(alunoTurmas);
           
        }


        public List<AlunoTurma> SelectAluno(Guid idAluno)
        {
            var entity = _context.AlunoTurma.Where(x => x.IdAluno.Equals(idAluno) && x.Ativo).ToList();
            return entity;
        }

    
    }
}
