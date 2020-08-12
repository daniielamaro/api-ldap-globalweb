using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository.Ldap;
using Domain.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prs.Controllers.Request;
using Prs.Controllers.Request.Ldap;

namespace Prs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LdapController : ControllerBase
    {
        private readonly ILdapRepository ldapRepository;

        public LdapController(ILdapRepository ldapRepository)
        {
            this.ldapRepository = ldapRepository;
        }

        [HttpPost("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll() => Ok(await ldapRepository.Execute());
    }
}
