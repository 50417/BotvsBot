using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 Test = new Class1();
            //Test.foo();
            MachineLearningNaive hello = new MachineLearningNaive();
            //hello.runNaive();
            TestProgram program = new TestProgram();
            //String yes = program.foo(122);
            //int yess = program.fooint(200);
            Console.WriteLine("Before Program Analysis");
            KNNClassifier knnclassifier = new KNNClassifier(1);
            knnclassifier.runKNN();

            Console.WriteLine("\nAfter Program Analysis");
            KNNClassifier knnclassifierWithDscData = new KNNClassifier(2);
            knnclassifierWithDscData.runKNN();
            Console.ReadLine();
        }
    }
}
