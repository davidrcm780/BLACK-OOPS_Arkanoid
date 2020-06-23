using System;

namespace BLACK_OOPS_Arkanoid.Exceptions
{
    public class OutOfLifes : Exception
    {
        public OutOfLifes(string Message) : base(Message) { }
    }
}