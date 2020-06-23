using System;

namespace BLACK_OOPS_Arkanoid.Exceptions
{
    public class EmptyNicknameException : Exception
    {
        public EmptyNicknameException(string Message) : base(Message) { }
    }
}