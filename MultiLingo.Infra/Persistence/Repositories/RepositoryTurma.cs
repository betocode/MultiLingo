using MultiLingo.Domain.Entities;
using MultiLingo.Domain.Interfaces.Repositories;
using System;
using System.Linq;

namespace MultiLingo.Infra.Persistence
{
    public class RepositoryTurma : IRepositoryTurma
    {
        private readonly MultiLingoContext _context;
      
        public RepositoryTurma(MultiLingoContext context)
        { 
            _context = context;
         
           
        }
        public Turma Create(Turma turma)
        {
            _context.Turma.Add(turma);
            return turma;
        }

        public bool Delete(Turma turma)
        {
         

            _context.Turma.Update(turma);
           
            return true;

        }

        public Turma Select(Guid id)
        {
            var turma = _context.Turma.Where(x => x.IdTurma.Equals(id) && x.IsDeletado == false).FirstOrDefault();
            return turma;
        }

        public Turma Update(Turma turma)
        {
            _context.Turma.Update(turma);
            return turma;
        }
    }
}
