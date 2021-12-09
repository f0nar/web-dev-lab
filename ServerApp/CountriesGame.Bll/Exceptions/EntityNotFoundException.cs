using System;
using System.Runtime.Serialization;

namespace CountriesGame.Bll.Exceptions
{
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public string EntityName { get; }

        public EntityNotFoundException() { }

        public EntityNotFoundException(string message) : base(message) { }

        public EntityNotFoundException(string message, Exception inner)
            : base(message, inner) { }

        public EntityNotFoundException(string message, string entityName)
            : base(message)
        {
            this.EntityName = entityName;
        }

        protected EntityNotFoundException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}