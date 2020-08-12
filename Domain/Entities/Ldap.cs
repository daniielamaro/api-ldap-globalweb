namespace Domain.Entities
{
    public class Ldap : Entity
    {
        public string Host { get; set; }
        public string Dominio { get; set; }
        public string BaseDn { get; set; }
    }
}
