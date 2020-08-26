using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiLingo.Domain.Arguments.Turma;
using MultiLingo.Domain.Entities;
using MultiLingo.Domain.Interfaces.Services;
using MultiLingo.Infra.Transactions;
using Newtonsoft.Json;

namespace MultiLingo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly IServiceTurma _service;
        private readonly IUnitOfWork _uof;
        public TurmaController(IServiceTurma service,IUnitOfWork uof)
        {
            _service = service;
            _uof = uof;

        }

        [HttpGet]
        [Route("{idTurma}")]
        public ContentResult GetTurma(Guid idTurma)
        {
            ContentResult response = new ContentResult { ContentType = "application/json" };
            try
            {
                var result = _service.LoadTurma(idTurma);
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

        public ContentResult PostTurma([FromBody]AddTurmaRequest req)
        {
            ContentResult response = new ContentResult { ContentType = "application/json" };
            try
            {
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

        public ContentResult PutTurma([FromBody] EditTurmaRequest req)
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
        [Route("{id}")]
        public ContentResult DeleteTurma(Guid id)
        {
            ContentResult response = new ContentResult { ContentType = "application/json" };

            try
            {
                var result = _service.Delete(id);
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
