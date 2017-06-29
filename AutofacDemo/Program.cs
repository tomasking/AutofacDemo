namespace AutofacDemo
{
    using System;
    using Autofac;
    using Ioc;

    class Program
    {

        //TODOS: scope, register multiple consumers at once, show lazily loaded type, named parameters
        
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
}