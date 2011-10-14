using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using SimIoC;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace Tests
{
    public class ContainerSpecs 
    {
        public abstract class concern : Observes<IContainer, Container>
        {
            
        }

        public class when_requesting_a_type_from_the_container : concern
        {
            public class and_there_is_a_factory_which_can_create_the_type : when_requesting_a_type_from_the_container


            {
                protected static FakeType result;
                protected static object the_created_instance;
                protected static ICreateAType factory;
                protected static IFindTypeFactories factory_registy;

                Establish context = () =>
                    {
                        the_created_instance = new FakeType();
                        factory = fake.an<ICreateAType>();
                        factory_registy = depends.@on<IFindTypeFactories>();

                        factory_registy.setup(x => x.get_factory_for(typeof (FakeType))).Return(factory);
                        factory.setup(x => x.create()).Return(the_created_instance);
                    };

                public class in_a_generic_context : and_there_is_a_factory_which_can_create_the_type
                {
                    Because b = () => result = sut.get_instance<FakeType>();

                    It should_return_the_instance_created_by_the_factory =
                        () => result.ShouldEqual(the_created_instance);
                }

                public class in_a_runtime_context : and_there_is_a_factory_which_can_create_the_type
                {
                    Because b = () => result = sut.get_instance(typeof(FakeType));

                    It should_return_the_instance_created_by_the_factory =
                        () => result.ShouldEqual(the_created_instance);

                    static object result;
                }
            }

            public class and_there_is_not_a_factory_which_can_create_the_type : when_requesting_a_type_from_the_container
            {

                Establish context = () =>
                    {
                        the_inner_exception = fake.an<Exception>();
                        factory = fake.an<ICreateAType>();
                        factory_registry = depends.@on<IFindTypeFactories>();

                        factory_registry.setup(x => x.get_factory_for(typeof(FakeType))).Return(factory);
                        factory.setup(x => x.create()).Throw(the_inner_exception);
                    };

                Because b = () => spec.catch_exception(() => sut.get_instance<FakeType>());

                It should_throw_an_exception_with_the_correct_type_information = () =>
                    {
                        var exception = spec.exception_thrown.ShouldBeAn<TypeCreationException>();
                        exception.InnerException.ShouldEqual(the_inner_exception);
                        exception.the_attempted_type.ShouldEqual(typeof(FakeType));
                    };

                static Exception the_inner_exception;
                static ICreateAType factory;
                static IFindTypeFactories factory_registry;
            }
        }

        public class FakeType
        {
            
        }
    }
}
