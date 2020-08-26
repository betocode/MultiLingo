using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MultiLingo.Domain.Arguments;
using MultiLingo.Domain.Arguments.Usuario;
using MultiLingo.Domain.Entities;
using MultiLingo.Domain.Interfaces.Repositories;
using MultiLingo.Domain.Interfaces.Services;
using MultiLingo.Domain.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace MultiLingo.Domain.Services
{
    public class ServiceUsuario : IServiceUsuario
    {
        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfigurations _tokenConfigurations;

        public ServiceUsuario(IRepositoryUsuario repositoryUsuario, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations)
        {
            _repositoryUsuario = repositoryUsuario;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;

        }
        public UsuarioResponse Create(UsuarioRequest user)
        {
            var usuario = new Usuario(user.Login, user.Senha);
            usuario = _repositoryUsuario.Create(usuario);
            var tokenGenerated = GenerateToken(usuario);


            return new UsuarioResponse { Login = usuario.Login, Token = tokenGenerated.AccessToken };
        }


        public UsuarioResponse Login(UsuarioRequest user)
        {

            var entity = _repositoryUsuario.Login(user);

            if (entity == null)
            {
                throw new ArgumentException("usuario não encontrado");
            }

            var tokenGenerated = GenerateToken(entity);
            return new UsuarioResponse { Login = user.Login, Token = tokenGenerated.AccessToken };




        }

        public Usuario FindByLogin(string login)
        {
            var entity = _repositoryUsuario.FindByLogin(login);
            return entity;
        }


        private Token GenerateToken(Usuario entity)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
             new GenericIdentity(entity.Login),
             new[]
             {
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName,entity.Login),
             }


             );
            DateTime createdDate = DateTime.Now;
            DateTime expirationDate = createdDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            string token = CreateToken(identity, createdDate, expirationDate, handler);
            var tokenGenerated = SuccessObject(createdDate, expirationDate, token, entity);
            return tokenGenerated;
        }

        private string CreateToken(ClaimsIdentity identity, DateTime createdDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createdDate,
                Expires = expirationDate
            });
            var token = handler.WriteToken(securityToken);
            return token;
        }
        private Token SuccessObject(DateTime createdDate, DateTime expiredDate, string token, Usuario user)
        {
            return new Token
            {
                Authenticated = true,
                Created = createdDate.ToString("yyyy-MM-dd HH:mm:ss"),
                ExpirationDate = expiredDate.ToString("yyyy-MM-dd HH:mm:ss"),
                AccessToken = token,
                Login = user.Login,

            };

        }


    }
}
