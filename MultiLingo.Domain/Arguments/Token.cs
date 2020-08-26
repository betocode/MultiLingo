using System;
using System.Collections.Generic;
using System.Text;

namespace MultiLingo.Domain.Arguments
{
    public class Token
    {
        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string ExpirationDate { get; set; }
        public string AccessToken { get; set; }
        public string Login { get; set; }

      
    }
}
