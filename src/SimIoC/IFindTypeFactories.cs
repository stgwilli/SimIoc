using System;

namespace SimIoC
{
    public interface IFindTypeFactories
    {
        ICreateAType get_factory_for(Type type); 
    }
}