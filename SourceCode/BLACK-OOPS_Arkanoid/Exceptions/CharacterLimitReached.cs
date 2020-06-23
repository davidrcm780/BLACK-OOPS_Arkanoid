using System;

namespace BLACK_OOPS_Arkanoid.Exceptions
{
    public class CharacterLimitReached : Exception
    {
        public CharacterLimitReached(string Message) : base(Message) { }
    }
}