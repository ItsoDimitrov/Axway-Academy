using System;
using System.Collections.Generic;
using System.Text;
using _01.factoryDesignPattern.Interface;

namespace _01.factoryDesignPattern.Factory
{
    public static class FactoryMethod
    {
        public static IProgrammingLanguage GetLanguageInstance(string languageName)
        {
            switch (languageName)
            {
                case "Python":
                    return new Python();

                case "Java":
                    return new Java();

                case "JavaScript":
                    return new JavaScript();
                default:
                    return null;


            }
        }
    }
}
