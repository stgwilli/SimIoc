using System;

namespace SimIoC
{
    public class TypeCreationException : Exception
    {
        public Type the_attempted_type { get; set; }

        public TypeCreationException(Exception exception, Type the_attempted_type) : base(exception.Message, exception)
        {
            this.the_attempted_type = the_attempted_type;
        }
    }
}