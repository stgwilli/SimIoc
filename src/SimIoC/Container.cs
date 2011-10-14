using System;

namespace SimIoC
{
    public class Container : IContainer
    {
        IFindTypeFactories factory_registry;

        public Container(IFindTypeFactories factory_registry)
        {
            this.factory_registry = factory_registry;
        }

        public T get_instance<T>()
        {
            return (T)get_instance(typeof(T));
        }

        public object get_instance(Type type)
        {
            try
            {
                return factory_registry.get_factory_for(type).create();
            }
            catch (Exception ex)
            {
                throw new TypeCreationException(ex, type);
            }
        }
    }
}