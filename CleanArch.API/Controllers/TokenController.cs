﻿using CleanArch.API.Models;
using CleanArch.Domain.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;
        private readonly IConfiguration _configuration; // serve para pegar a secrectkey do token dentro do appsettings.json

        public TokenController(IAuthenticate authenticate, IConfiguration configuration)
        {
            _authenticate = authenticate ??
                throw new ArgumentNullException(nameof(authenticate));
            _configuration = configuration;
        }

        [HttpPost("CreateUser")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult> CreateUser([FromBody] LoginModel userInfo)
        {
            var result = await _authenticate.RegisterUser(userInfo.Email, userInfo.Password);
            if (result)
            {
                //return GenerationToken(userInfo);
                return Ok($"User {userInfo.Email} was create successfully");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Inavalid create attemp.");
                return BadRequest(ModelState);
            }
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
        {
            var result = await _authenticate.AuthenticateAsync(userInfo.Email, userInfo.Password);
            if (result)
            {
                return GenerationToken(userInfo);
                //return Ok($"User {userInfo.Email} login successfully");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Inavalid Login attemp.");
                return BadRequest(ModelState);
            }
        }

        private UserToken GenerationToken(LoginModel userInfo)
        {
            //declarações do usuário 
            var claims = new[]
            {
                new Claim("email", userInfo.Email),
                new Claim("password", userInfo.Password),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) //Jti é o ID  do cliente
            };

            //gerar chave privada para assinar o token
            var privatekey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

            //gerar a assinatura digital
            // HmacSha256 gera uma chave de 64 bytes
            var credentials = new SigningCredentials(privatekey, SecurityAlgorithms.HmacSha256);

            //definir o tempo de expiração
            var expiration = DateTime.UtcNow.AddMinutes(10);

            //gerar o token
            JwtSecurityToken token = new JwtSecurityToken(
                //emissor
                issuer: _configuration["Jwt:Issuer"],
                //audiencia
                audience: _configuration["Jwt:Audience"],
                //claims
                claims: claims,
                //data de expiração
                expires: expiration,
                //assinatura digital
                signingCredentials: credentials
                );
            return new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
