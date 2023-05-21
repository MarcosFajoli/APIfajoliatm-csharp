using System.Data;

namespace APIfajoliatm_csharp.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Update (string name) 
        {
            this.Name = name;
        }
    }
}
