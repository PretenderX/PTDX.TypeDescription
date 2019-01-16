using System.Reflection;
using Autofac;

namespace PTDX.TypeDescription.Autofac
{
    public static class ContainerBuilderExtension
    {
        public static ContainerBuilder UseTypeDescription(this ContainerBuilder builder, params Assembly[] providerAssemblies)
        {
            builder.RegisterType<TypeDescriptionConfiguration>()
                .WithParameter(new TypedParameter(typeof(Assembly[]), providerAssemblies))
                .As<ITypeDescriptionConfiguration>()
                .InstancePerLifetimeScope();
            builder.RegisterType<TypeDescriptionManager>()
                .AsImplementedInterfaces()
                .SingleInstance();

            return builder;
        }

        public static ContainerBuilder UseTypeDescription<T>(this ContainerBuilder builder)
            where T : ITypeDescriptionConfiguration
        {
            builder.RegisterType<T>()
                .As<ITypeDescriptionConfiguration>()
                .InstancePerLifetimeScope();
            builder.RegisterType<TypeDescriptionManager>()
                .AsImplementedInterfaces()
                .SingleInstance();

            return builder;
        }
    }
}