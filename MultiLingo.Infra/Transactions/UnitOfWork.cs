using MultiLingo.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLingo.Infra.Transactions
{

    public class UnitOfWork : IUnitOfWork
    {

        private readonly MultiLingoContext _context;
        public UnitOfWork(MultiLingoContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
