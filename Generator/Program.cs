using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Generator
{
    class Program
    {

        static void Main()
        {
            List<object> listOfClasses = new List<object>();
            GenerateValues v = new GenerateValues(10, 100, 10, 100);
            v.Generator<ExampleClass>(new ExampleClass(), out listOfClasses);
            
                foreach (object l in listOfClasses)
                {
                    Console.WriteLine(l.ToString());
                }
            
                //Getting object values from the List

            Console.ReadKey();
        }
    }
}
