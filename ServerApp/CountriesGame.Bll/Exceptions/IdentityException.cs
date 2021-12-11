using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Identity;

namespace CountriesGame.Bll.Exceptions
{
    [Serializable]
    public class IdentityException : Exception
    {
        public IEnumerable<IdentityError> IdentityErrors { get; }

        public IdentityException() { }

        public IdentityException(string message) : base(message) { }

        public IdentityException(string message, Exception inner)
            : base(message, inner) { }

        public IdentityException(string message, IEnumerable<IdentityError> identityErrors)
            : base(message)
        {
            IdentityErrors = identityErrors;
        }

        protected IdentityException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }    
}