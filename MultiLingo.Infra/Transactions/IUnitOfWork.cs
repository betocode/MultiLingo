using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLingo.Infra.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
