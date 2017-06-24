using System;

namespace CatApiWrapper
{
    public class InvalidRequestException : Exception
    {
        public InvalidRequestException(string message) : base(message)
        {


        }
    }
}