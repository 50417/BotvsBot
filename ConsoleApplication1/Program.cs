using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            TestProgram program = new TestProgram();

            // Console.WriteLine("Before Program Analysis");
            //KNNClassifier knnclassifier = new KNNClassifier(1);
            // knnclassifier.runKNN();

            //Console.WriteLine("\nAfter Program Analysis");
            //KNNClassifier knnclassifierWithDscData = new KNNClassifier(2);
            //knnclassifierWithDscData.runKNN();

            NaiveBayesProtoType nbP = new NaiveBayesProtoType(1);
            nbP.runNaiveBayes();
            NaiveBayesProtoType nbAP = new NaiveBayesProtoType(0);
            nbAP.runNaiveBayes();


            //NaiveBayesClassifer nb = new NaiveBayesClassifer();
            // nb.ClassifyText();
            Console.ReadLine();
        }
    }
}
