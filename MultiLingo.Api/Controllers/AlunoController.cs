using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiLingo.Domain.Arguments.Aluno;
using MultiLingo.Domain.Entities;
using MultiLingo.Domain.Interfaces.Services;
using MultiLingo.Infra.Persistence;

namespace MultiLingo.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IServiceAluno _service;
        private readonly MultiLingoContext _context;
        public AlunoController(IServiceAluno service,MultiLingoContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet]

        public string Teste()
        {
            var resp = _service.LoadAlunoById(new Guid());
            return "oi";
        }

        [HttpPost]

        public AddAlunoResponse Post()
        {

            var aln = new AddAlunoRequest() { IdTurma = Guid.NewGuid(), Nome = "Teste", Matricula = "123456" };
            var response = _service.Add(aln);
            _context.SaveChanges();

            return response;

        }
    }
}
