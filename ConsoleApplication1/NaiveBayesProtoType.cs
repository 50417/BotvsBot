using Accord;
using Accord.IO;
using Accord.MachineLearning;
using Accord.MachineLearning.Bayes;
using Accord.Math;
using Accord.Math.Distances;
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
    class NaiveBayesProtoType
    {

        DataTable trainingData;
        // Create a new codification codebook to
        //convert strings into discrete symbols
        Codification codebook;
        public NaiveBayesProtoType(int i)
        {
            trainingData = new DataTable("Sample Training Data");
            trainingData = prepareTrainingDataset(i);
        }

        public DataTable prepareTrainingDataset(int i)
        {
            var path = Directory.GetCurrentDirectory() + "\\DataSet.xlsx";

            // Read the Excel worksheet into a DataTable
            if (i == 1)
                return new ExcelReader(path).GetWorksheet("TrainingDataBefore");
            else
                return new ExcelReader(path).GetWorksheet("TrainingDataAfter");
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

        public void testForInstance(NaiveBayes nb, String[] testInstance, String Output)
        {
            try
            {
                // Obtain the numeric output that represents the answer
                int c = nb.Decide(codebook.Transform(testInstance)); // answer will be 0

                // Now let us convert the numeric output to an actual "Yes" or "No" answer
                string result = codebook.Revert("GeneratedByProgram", c); // answer will be "No"

                Console.WriteLine("Test Data Input :  " + testInstance[0] + "," + testInstance[1] + "\nExpectation: " + Output + "\nResult: " + result);
            }
            catch(Exception e)
            {
              
                Console.WriteLine("Test Data Input :  " + testInstance[0] + "," + testInstance[1] + "\nExpectation: " + Output + "\nResult: " + "No");

            }

        }

        private int Decide(string input)
        {
            throw new NotImplementedException();
        }

        public void runNaiveBayes()
        {

            codebook = new Codification(trainingData, "Feature1", "Feature2", "GeneratedByProgram");
             

            //  Training data to symbol
            DataTable trainingsymbols = codebook.Apply(trainingData); ;
            int[][] trainingInputs = trainingsymbols.ToJagged<int>("Feature1", "Feature2");
            int[] trainingOutputs = trainingsymbols.ToArray<int>("GeneratedByProgram");

            // Create a new Naive Bayes learning
            var learner = new NaiveBayesLearning();
            learner.Options.InnerOption.UseLaplaceRule = true;

            // We learn the algorithm:
            NaiveBayes nb = learner.Learn(trainingInputs, trainingOutputs);

            DataTable testdata = new DataTable("Sample Data");
            testdata.Columns.Add("Feature1","Feature2", "GeneratedByProgram");

            testdata.Rows.Add("This", " is real", "No");
            testdata.Rows.Add("a","8", "Yes");
            testdata.Rows.Add("b","2000", "Yes");
            testdata.Rows.Add("a", "9", "Yes");
            testdata.Rows.Add("a", "90", "Yes");
            testdata.Rows.Add("a", "12", "Yes");
            testdata.Rows.Add("b", "15", "Yes");
            testdata.Rows.Add("b", "18", "Yes");
            testdata.Rows.Add("b", "200", "Yes");
            testdata.Rows.Add("a", "5", "Yes");
            testdata.Rows.Add("a", "62", "Yes");
            testdata.Rows.Add("b", "5000", "Yes");
            testdata.Rows.Add("b", "17", "Yes");
            testdata.Rows.Add("b", "62", "Yes");
            testdata.Rows.Add("b", "90", "Yes");
            testdata.Rows.Add("b", "123", "Yes");
            testdata.Rows.Add("This", " is Ok", "Yes");
            testdata.Rows.Add("b", "1", "Yes");
            testdata.Rows.Add("b", "64", "Yes");
            testdata.Rows.Add("I ", "am god", "No");
            testdata.Rows.Add("b", "33", "Yes");

            String[] inst={ "b","15"};
            testForInstance(nb, inst, "Yes");

            DataTable testsymbols = codebook.Apply(testdata);
            int[][] testInput = testsymbols.ToJagged<int>("Feature1","Feature2");
            int[] testOutput = testsymbols.ToArray<int>("GeneratedByProgram");
           int[] answers = nb.Decide(testInput); 


            Console.WriteLine("\n Accuracy (Tested on 20 data set): " + calculateAccuracy(answers, testOutput));


        }
    }
}
