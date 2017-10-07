using Accord;
using Accord.Controls;
using Accord.IO;
using Accord.MachineLearning.Bayes;
using Accord.Math;
using Accord.Statistics.Distributions.Univariate;
using Accord.Statistics.Filters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class MachineLearningNaive
    {
        DataTable trainingData;
        // Create a new codification codebook to
        //convert strings into discrete symbols
        Codification codebook;
        NaiveBayesLearning learner;
       
        public MachineLearningNaive()
        {
            trainingData = new DataTable("Sample Training Data");
            learner = new NaiveBayesLearning();
            prepareTrainingDataset();

        }
        public void prepareTrainingDataset()
        {
            trainingData.Columns.Add("Input", "Output", "GeneratedByProgram");

            trainingData.Rows.Add("8", "a8", "Yes");
            trainingData.Rows.Add("", "m77", "No");
            
            trainingData.Rows.Add("3", "a3", "Yes");
            trainingData.Rows.Add("8", "a8", "Yes");
            trainingData.Rows.Add("8", "a8", "Yes");
            trainingData.Rows.Add("8", "a8", "Yes");
            trainingData.Rows.Add("8", "a8", "Yes");
            trainingData.Rows.Add("8", "a8", "Yes");
            trainingData.Rows.Add("8", "a8", "Yes");
            trainingData.Rows.Add("1200", "a1200", "Yes");
            trainingData.Rows.Add("1200", "a8", "No");
            trainingData.Rows.Add("8", "a16", "No");
            trainingData.Rows.Add("", "This place is cool", "No");
            
            trainingData.Rows.Add("", "m77", "No");
            trainingData.Rows.Add("", "as", "No");
        }
            
        public DataTable convertStringDataToDiscreteSymbol()
        {
            codebook = new Codification(trainingData, "Input", "Output", "GeneratedByProgram");
            return codebook.Apply(trainingData);
        }
        public float calculateAccuracy(int[] results, int[] actual)
        {
            int count = 0;
            for (int i = 0; i < results.Length; i++)
            {
                if (results[i] - actual[i] == 0)
                {
                    count += 1;
                }
             
            }
            return (float)count / results.Length * 100;
        }
       public void testForInstance(NaiveBayes nb,String input, String Output)
        {
   
            DataTable testdata = new DataTable("Sample Data");
            testdata.Columns.Add("Input", "Output", "GeneratedByProgram");

            testdata.Rows.Add(input, Output, "Yes");
            DataTable testsymbols = codebook.Apply(testdata);
            int[][] testInput = testsymbols.ToArray<int>("Input", "Output");
            int[] instance = new int[2];

            instance[0] = testInput[0][0];
            instance[1] = testInput[0][1];

            // Obtain the numeric output that represents the answer
            int c = nb.Decide(instance); // answer will be 0

            // Now let us convert the numeric output to an actual "Yes" or "No" answer
            string result = codebook.Revert("GeneratedByProgram", c); // answer will be "No"

            // We can also extract the probabilities for each possible answer
            double[] probs = nb.Probabilities(instance);

            Console.WriteLine("Test Data Input : ("+input+","+Output+")"+ "\nProbability of No: " + probs.GetValue(0) + "\nProbability of Yes: " + probs.GetValue(1)+ "\nResult: " + result );

        }
        public NaiveBayes train()
        {
            
            // Extract input and output pairs to train
            DataTable symbols = convertStringDataToDiscreteSymbol();
            int[][] trainingInputs = symbols.ToArray<int>("Input", "Output");
            int[] trainingOutputs = symbols.ToArray<int>("GeneratedByProgram");
            return learner.Learn(trainingInputs, trainingOutputs);


        }

        

        public  void runNaive()
        {
          
            // Learn a Naive Bayes model from the examples
            NaiveBayes nb = train();
            
            DataTable testdata = new DataTable("Sample Data");
            testdata.Columns.Add( "Input", "Output", "GeneratedByProgram");

            testdata.Rows.Add( "8", "a8", "Yes");

            testdata.Rows.Add("7", "a8", "No");
            testdata.Rows.Add("-5", "b5", "Yes");
            testdata.Rows.Add("", "This is real", "No");
            testdata.Rows.Add("8", "a9", "No");
            testForInstance(nb,"7", "a8");
            testForInstance(nb, "8", "a8");

            DataTable testsymbols = codebook.Apply(testdata);
            int[][] testInput = testsymbols.ToArray<int>( "Input", "Output");
            int[] testOutput = testsymbols.ToArray<int>("GeneratedByProgram");
            // Extract input and output pairs to train
            //DataTable symbols = convertStringDataToDiscreteSymbol();
            //int[][] trainingInputs = symbols.ToArray<int>("Input", "Output");
            //int[] trainingOutputs = symbols.ToArray<int>("GeneratedByProgram");

            // Classify the samples using the model
            int[] answers = nb.Decide(testInput);
     
            Console.WriteLine( "Accuracy: " + calculateAccuracy(answers,testOutput));
            Console.ReadLine();

        }
    }
}
