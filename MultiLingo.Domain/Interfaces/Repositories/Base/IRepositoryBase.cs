using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLingo.Domain.Interfaces.Repositories.Base
{
    public class IRepositoryBase<TEntidade,TId>
        where TEntidade : class
        where TId : struct
    {
    }
}
