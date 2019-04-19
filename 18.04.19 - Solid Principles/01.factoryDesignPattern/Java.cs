using System;
using System.Collections.Generic;
using System.Text;
using _01.factoryDesignPattern.Interface;

namespace _01.factoryDesignPattern
{
    public class Java : IProgrammingLanguage
    {
        public void GetYearOfCreation()
        {
            Console.WriteLine($"({GetType().Name}) My first appearance was in 1995");
        }
    }
}
