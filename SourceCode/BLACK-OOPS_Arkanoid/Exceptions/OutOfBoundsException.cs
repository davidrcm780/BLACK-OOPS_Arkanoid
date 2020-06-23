using System;

namespace BLACK_OOPS_Arkanoid.Exceptions
{
    public class OutOfBoundsException : Exception
    {
        public OutOfBoundsException(string Message) : base(Message) {}
    }
}