using Accord;
using Accord.Controls;
using Accord.IO;
using Accord.MachineLearning;
using Accord.MachineLearning.Bayes;
using Accord.Math;
using Accord.Statistics.Distributions.Univariate;
using Accord.Statistics.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    class NaiveBayesClassifer
    {
        StringBuilder sbGeneratedByProgram;
        StringBuilder sbNotGeneratedByProgram;
        public NaiveBayesClassifer()
        {
            sbGeneratedByProgram = new StringBuilder();
            sbNotGeneratedByProgram = new StringBuilder();
        }
        public void readFile()
        {
            String line;
            String[] classTextPair = new String[2];
            StreamReader streamReader = new StreamReader(Directory.GetCurrentDirectory() + "\\Training.txt");
            line = streamReader.ReadLine();
            while (line != null)
            {
                classTextPair = line.Split(',');

                if (classTextPair[0].CompareTo("NotProgramGenerated") == 0)
                    sbNotGeneratedByProgram.Append(classTextPair[1]);
                else
                    sbGeneratedByProgram.Append(classTextPair[1]);
                line = streamReader.ReadLine();
            }

        }
        public void ClassifyText()
        {
            readFile();
         
            string[] words = {  sbGeneratedByProgram.ToString() , sbNotGeneratedByProgram.ToString() };

            string[][] word = words.Tokenize();
            // Create a new Bag-of-Words for the texts
            var bow = new BagOfWords()
            {
                MaximumOccurance = 1 // the resulting vector will have only 0's and 1's
            };
            bow.Learn(word);
            //bow.Learn(Tokens);

            // Create input and outputs for training
            double[] inputP = bow.Transform(word[0]);
            double[] inputNP = bow.Transform(word[1]);
        
            int[][] inputs = {
                inputP.ToInt32(),
                inputNP.ToInt32()
            };

            int[] outputs =
            {
                0, // Program Generated
                1 // Not Program Generated
            };

            // Create the naïve bayes model
            var learner = new NaiveBayesLearning();
            learner.Options.InnerOption.UseLaplaceRule = true;

            var nb = learner.Learn(inputs, outputs);

            string[] text = "Yup! Two years without a car! Downtown living is morning too I got that this morning too too If the wi. Here's hoping!".Tokenize();
            int[] input = bow.Transform(text).ToInt32();
            int answer = nb.Decide(input);
            Console.WriteLine(answer);
            Console.WriteLine(nb.Probabilities(input)[0] + " " + nb.Probabilities(input)[1]);
            // Learn a Naive Bayes model from the examples
            //{
            //    // This classifies as Not Program Generated
            //    string text = @"How moms use their iPhones";
            //    int[] input = bow.GetFeatureVector(Tokenize(text));
            //    int answer = bayes.Compute(input);
            //   Console.WriteLine( bayes.Probabilities(input)[0]+" "+ bayes.Probabilities(input)[1]);

            //    string result = classes[answer];

            //    Console.WriteLine("1) Test: {0}", result);
            //}

            //{
            //    // This classifies as spam
            //    string text = @" WINNING GRACIOUSNESS";
            //    int[] input = bow.GetFeatureVector(Tokenize(text));
            //    int answer = bayes.Compute(input);
            //    string result = classes[answer];
            //    Console.WriteLine(bayes.Probabilities(input)[0] + " " + bayes.Probabilities(input)[1]);

            //    Console.WriteLine("2) Test: {0}", result);
            //}
        }


    }
}
