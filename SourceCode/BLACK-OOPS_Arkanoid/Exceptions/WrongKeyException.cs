using System;

namespace BLACK_OOPS_Arkanoid.Exceptions
{
    public class WrongKeyException : Exception
    {
        public WrongKeyException(string message) : base(message){}
    }
}