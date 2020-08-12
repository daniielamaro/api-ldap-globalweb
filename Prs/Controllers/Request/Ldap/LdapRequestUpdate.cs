namespace Prs.Controllers.Request.Ldap
{
    public class LdapRequestUpdate
    {
        public int Id { get; set; }
        public string Host { get; set; }
        public string Dominio { get; set; }
        public string BaseDn { get; set; }
    }
}
