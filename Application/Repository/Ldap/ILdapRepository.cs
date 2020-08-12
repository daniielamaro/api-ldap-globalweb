using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository.Ldap
{
    public interface ILdapRepository
    {
        Task<bool> Login(string username, string password);
        Task<UserLdap> GetUser(string username, string password, string userTarget);
        Task<List<Domain.Entities.Ldap>> Execute();
    }
}
