namespace AutofacDemo.Ioc
{
    using System;
    using Autofac;
    using DummyComponents;

    public class LoggingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Console.WriteLine("Performing logging modules registrations");
            builder.RegisterType<Logging>().As<ILogging>();
        }
    }
}