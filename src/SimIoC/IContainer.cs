using System;

namespace SimIoC
{
    public interface IContainer
    {
        T get_instance<T>();

        object get_instance(Type type);
    }
}