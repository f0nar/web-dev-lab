using System;
using System.Runtime.Serialization;

namespace CountriesGame.Bll.Exceptions
{
    [Serializable]
    public class DublicateFoundException : Exception
    {
        public string EntityName { get; }

        public DublicateFoundException() { }

        public DublicateFoundException(string message) : base(message) { }

        public DublicateFoundException(string message, Exception inner)
            : base(message, inner) { }

        public DublicateFoundException(string message, string entityName)
            : base(message)
        {
            this.EntityName = entityName;
        }

        protected DublicateFoundException(SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}