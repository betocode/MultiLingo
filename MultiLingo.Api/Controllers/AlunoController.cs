using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiLingo.Domain.Arguments.Aluno;
using MultiLingo.Domain.Interfaces.Services;
using MultiLingo.Infra.Transactions;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MultiLingo.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]

    public class AlunoController : ControllerBase
    {
        private readonly IServiceAluno _service;
        private readonly IServiceTurma _serviceTurma;
        private readonly IUnitOfWork _uof;

        public AlunoController(IServiceAluno service, IServiceTurma serviceTurma, IUnitOfWork uof)
        {
            _service = service;
            _serviceTurma = serviceTurma;
            _uof = uof;
        }

        [HttpGet]
        [Route("{idAluno}")]
        public ContentResult GetAluno(Guid idAluno)
        {
            ContentResult response = new ContentResult { ContentType = "application/json" };
            try
            {
                var result = _service.LoadAlunoById(idAluno);
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Content = JsonConvert.SerializeObject(result);
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Content = JsonConvert.SerializeObject(ex.Message);
                return response;
            }
        }

        [HttpPost]

        public ContentResult PostAluno([FromBody] AddAlunoRequest req)
        {
            ContentResult response = new ContentResult { ContentType = "application/json" };
            try
            {
                var checkIfTurmaExist = _serviceTurma.LoadTurma(req.IdTurma);
                if (checkIfTurmaExist == null)
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Content = JsonConvert.SerializeObject("Turma não existe");
                    return response;
                }

                var checkIfTurmaIsAvailable = _serviceTurma.CheckIfTurmaIsAvailable(req.IdTurma);
                if (!checkIfTurmaIsAvailable)
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Content = JsonConvert.SerializeObject("Turma Cheia");
                    return response;
                }
                var result = _service.Add(req);
                _uof.Commit();

                response.StatusCode = (int)HttpStatusCode.OK;
                response.Content = JsonConvert.SerializeObject(result);
                return response;

            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Content = JsonConvert.SerializeObject(ex.Message);
                return response;
            }

        }

        [HttpPut]

        public ContentResult PutAluno([FromBody] EditAlunoRequest req)
        {
            ContentResult response = new ContentResult { ContentType = "application/json" };
            try
            {


                var result = _service.Edit(req);
                _uof.Commit();

                response.StatusCode = (int)HttpStatusCode.OK;
                response.Content = JsonConvert.SerializeObject(result);
                return response;

            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Content = JsonConvert.SerializeObject(ex.Message);
                return response;
            }

        }

        [HttpDelete]
        [Route("{idAluno}")]
        public ContentResult DeleteAluno(Guid idAluno)
        {
            ContentResult response = new ContentResult { ContentType = "application/json" };

            try
            {
                var result = _service.Delete(idAluno);
                _uof.Commit();

                response.StatusCode = (int)HttpStatusCode.OK;
                response.Content = JsonConvert.SerializeObject(result);
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Content = JsonConvert.SerializeObject(ex.Message);
                return response;
            }

        }

        [HttpDelete]

        public ContentResult DeleteAluno([FromQuery(Name = "IdAluno")] Guid idAluno, [FromQuery(Name = "IdTurma")] Guid idTurma)
        {
            ContentResult response = new ContentResult { ContentType = "application/json" };
            try
            {

                var result = _service.DeleteFromTurma(idAluno, idTurma);
                _uof.Commit();

                response.StatusCode = (int)HttpStatusCode.OK;
                response.Content = JsonConvert.SerializeObject(result);
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Content = JsonConvert.SerializeObject(ex.Message);
                return response;
            }

        }
    }
}
