using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacDemo
{
    public class MainApplication
    {
        private readonly ISomeProvider _someProvider;
        private readonly SomeRepository _someRepository;

        public MainApplication(ISomeProvider someProvider, SomeRepository someRepository)
        {
            _someProvider = someProvider;
            _someRepository = someRepository;
        }

        public void Start()
        {
            Console.WriteLine("In start method of MainApplication class, must have resolved all dependencies!");
        }
    }
}
