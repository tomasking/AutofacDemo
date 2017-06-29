namespace AutofacDemo.DummyComponents
{
    using System;

    public interface ISomeRepository : IDisposable { }

    public class SomeRepository : ISomeRepository
    {
        public void Dispose()
        {
            Console.WriteLine("Calling Dispose method of 'SomeRepository' as it implements IDisposable and will be called when containers scope is disposed" );
        }
    }
}