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

            Console.WriteLine("||Knn Classification For Test Program||\n");
            Console.WriteLine("Before Program Analysis");
            KNNClassifier knnclassifier = new KNNClassifier(1);
            knnclassifier.runKNN();

            Console.WriteLine("-----------");

            Console.WriteLine("\nAfter Program Analysis: Enriched Training Set\n");
            KNNClassifier knnclassifierWithDscData = new KNNClassifier(2);
            knnclassifierWithDscData.runKNN();

            Console.WriteLine("----------------------------------------------");

            Console.WriteLine("\n\n||Naive Bayes ClassificationFor Motivating Program||\n");
            NaiveBayesProtoType nbP = new NaiveBayesProtoType(1);
            nbP.runNaiveBayes();

            Console.WriteLine("-----------");

            Console.WriteLine("\nAfter Program Analysis: Enriched Training Set\n");
            NaiveBayesProtoType nbAP = new NaiveBayesProtoType(0);
            nbAP.runNaiveBayes();

            //NaiveBayesClassifer nb = new NaiveBayesClassifer();
            // nb.ClassifyText();
            Console.ReadLine();
        }
    }
}
