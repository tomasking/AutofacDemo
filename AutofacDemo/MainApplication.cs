namespace AutofacDemo
{
    using System;
    using System.Collections.Generic;
    using DummyComponents;

    public class MainApplication
    {
        private readonly ISomeProvider _someProvider;
        private readonly SomeRepository _someRepository;
        private readonly SomeTypeRegisteredInConfig _someTypeRegisteredInConfig;
        private readonly IEnumerable<IConsumer> _consumers;

        public MainApplication(ISomeProvider someProvider, SomeRepository someRepository, SomeTypeRegisteredInConfig someTypeRegisteredInConfig, IEnumerable<IConsumer> consumers)
        {
            _someProvider = someProvider;
            _someRepository = someRepository;
            _someTypeRegisteredInConfig = someTypeRegisteredInConfig;
            _consumers = consumers;
        }

        public void Start()
        {
            Console.WriteLine("In start method of MainApplication class, must have resolved all dependencies!");
        }
    }
}
