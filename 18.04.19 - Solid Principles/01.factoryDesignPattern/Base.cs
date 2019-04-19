using System;
using System.Collections.Generic;
using _01.factoryDesignPattern.Factory;
using _01.factoryDesignPattern.Interface;

namespace _01.factoryDesignPattern
{
    class Base
    {
        static void Main()
        {
            List<string> languages = new List<string>
            {
                "Python",
                "JavaScript",
                "Java"
            };
            foreach (var language in languages)
            {
                IProgrammingLanguage programmingLanguage = FactoryMethod.GetLanguageInstance(language);
                programmingLanguage.GetYearOfCreation();

            }

        }
    }
}
