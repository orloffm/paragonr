using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Paragonr.Application.Auth.Commands.Login;
using Paragonr.Application.Dtos;
using Paragonr.Application.Infrastructure;
using Paragonr.Application.Interfaces;
using Paragonr.Domain.Entities;
using Paragonr.WebApi.Infrastructure;

namespace Paragonr.WebApi.Controllers
{
    [Authorize]
    public class AuthController : BaseController
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginCommand command)
        {
            var loginResponse = await Mediator.Send(command);

            if (!loginResponse.IsAuthorized)
            {
                return this.Unauthorized();
            }

            return Ok();
        }
    }
}
