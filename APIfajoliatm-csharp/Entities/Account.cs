﻿namespace APIfajoliatm_csharp.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string Balance { get; set; }
        public string Type { get; set; }

        public void Update(Account account)
        {
            this.Balance = account.Balance;
            this.Type = account.Type;
        }
    }
}
