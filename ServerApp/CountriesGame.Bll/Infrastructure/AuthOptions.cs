using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CountriesGame.Bll.Infrastructure
{
    public class AuthOptions
    {
        private SymmetricSecurityKey _symmetricSecurityKey;

        public string Key { get; set; }

        public int AccessExpiration { get; set; }

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            if (Key == null)
                throw new InvalidOperationException("Key is not initialized");
            
            return _symmetricSecurityKey ??= new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(Key));
        }
    }
}