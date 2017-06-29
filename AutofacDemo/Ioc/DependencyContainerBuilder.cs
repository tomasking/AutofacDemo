namespace AutofacDemo.Ioc
{
    using System.Reflection;
    using Autofac;
    using Autofac.Configuration;
    using DummyComponents;
    using Microsoft.Extensions.Configuration;

    public class DependencyContainerBuilder
    {
        public IContainer Build()
        {
            var builder = new ContainerBuilder();
            
            // You can register types with no interfaces:
            builder.RegisterType<MainApplication>();

            // To ONLY expose type via it's interface use:
            builder.RegisterType<SomeProvider>().As<ISomeProvider>();

            // To expose via interface OR by it's type
            builder.RegisterType<SomeRepository>().AsSelf().As<ISomeRepository>();

            
            //Add modules to organise you depencies (http://docs.autofac.org/en/latest/configuration/modules.html)
            builder.RegisterModule(new LoggingModule());

            //Or load all modules from an assembly
            var assembly = typeof(MainApplication).GetTypeInfo().Assembly;
            builder.RegisterAssemblyModules(assembly);

            AddModuleFromConfigFile(builder);

            // Register all types of certain interface
            builder.RegisterAssemblyTypes(assembly).As(typeof(IConsumer));

            return builder.Build();
        }


        /// <summary>
        /// Requires Autofac.Configuration package. This allows you to import a module via config which also gives you the benefit off overriding it in your tests if you want.
        /// </summary>
        /// <param name="builder"></param>
        private static void AddModuleFromConfigFile(ContainerBuilder builder)
        {
            var config = new ConfigurationBuilder();
            config.AddJsonFile("Ioc/DependencyOverrides.json"); // Requires Microsoft.Extensions.Configuration.Json package
            var module = new ConfigurationModule(config.Build());
            builder.RegisterModule(module);
        }
    }
}