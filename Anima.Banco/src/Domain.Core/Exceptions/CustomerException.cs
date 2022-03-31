using System;
namespace Anima.Banco.Domain.Core.Exceptions
{
    public class CustomerException : Exception
    {
        public CustomerException(string message) : base(message)
        {

        }
    }
}
