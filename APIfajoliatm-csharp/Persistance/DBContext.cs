using APIfajoliatm_csharp.Entities;

namespace APIfajoliatm_csharp.Persistance
{
    public class DBContext
    {
        public List<Account> Accounts { get; set; }
        public List<Client> Clients { get; set; }
        public DBContext()
        {
            Accounts = new List<Account>();
            Clients = new List<Client>();
        }
    }
}
