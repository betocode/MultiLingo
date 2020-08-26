using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiLingo.Domain.Arguments.Usuario;
using MultiLingo.Domain.Entities;
using MultiLingo.Domain.Interfaces.Services;
using MultiLingo.Infra.Transactions;
using Newtonsoft.Json;

namespace MultiLingo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServiceUsuario _service;
        private readonly IUnitOfWork _uof;
        public AuthController(IServiceUsuario service, IUnitOfWork uof)
        {
            _service = service;
            _uof = uof;
        }

        [HttpPost]
        public ContentResult Login(UsuarioRequest req)
        {

            ContentResult response = new ContentResult { ContentType = "application/json" };
            try
            {
                var result = _service.Login(req);
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Content = JsonConvert.SerializeObject(result);
                return response;
            }
            catch(Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Content = JsonConvert.SerializeObject(ex.Message);
                return response;
            }
        }

        [HttpPost]
        [Route("cadastro")]

        public ContentResult Register(UsuarioRequest req)
        {
            ContentResult response = new ContentResult { ContentType = "application/json" };

            try
            {
                var checkIfExists = _service.FindByLogin(req.Login);
                if (checkIfExists != null)
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    response.Content = JsonConvert.SerializeObject("Usuario já existe");
                    return response;
                }

                var result = _service.Create(req);
                _uof.Commit();

                response.StatusCode = (int)HttpStatusCode.OK;
                response.Content = JsonConvert.SerializeObject(result);
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Content = ex.Message;
                return response;
            }
        }
    }
}
