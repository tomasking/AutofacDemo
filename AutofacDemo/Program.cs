using System;
using Autofac;

namespace AutofacDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = new DependencyContainerBuilder().Build())
            {
                using (var scope = container.BeginLifetimeScope())
                {
                    var mainApplication = scope.Resolve<MainApplication>();
                    mainApplication.Start();

                    Console.WriteLine("Press any key to exit Autofacs containers scope");
                    Console.ReadLine();
                }    
            }

            Console.WriteLine();
            Console.WriteLine("Everything disposed, press any key to exit.");
            Console.ReadLine();
        }
    }

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

            return builder.Build();
        }
    }


    public interface ISomeProvider { }

    public class SomeProvider : ISomeProvider { }

    public interface ISomeRepository : IDisposable{ }

    public class SomeRepository : ISomeRepository
    {
        public void Dispose()
        {
            Console.WriteLine("Calling Dispose method of 'SomeRepository' as it implements IDisposable and will be called when containers scope is disposed" );
        }
    }
}