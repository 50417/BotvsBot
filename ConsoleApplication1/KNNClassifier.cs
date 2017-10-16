using Accord;
using Accord.IO;
using Accord.MachineLearning;
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
    class KNNClassifier
    {
        DataTable trainingData;
        // Create a new codification codebook to
        //convert strings into discrete symbols
        Codification codebook;
        public KNNClassifier(int i)
        {
            trainingData = new DataTable("Sample Training Data");
            trainingData = prepareTrainingDataset(i);
        }

        public DataTable prepareTrainingDataset(int i)
        {
            var path = Directory.GetCurrentDirectory() + "\\example.xlsx";
    
            // Read the Excel worksheet into a DataTable
            if (i == 1)
                return new ExcelReader(path).GetWorksheet("T1");
            else
                return new ExcelReader(path).GetWorksheet("T2");
        }
        public DataTable convertStringDataToDiscreteSymbol()
        {
            codebook = new Codification(trainingData, "GeneratedByProgram");
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

        public void testForInstance(KNearestNeighbors<string> knn, String input, String Output)
        {

            // Obtain the numeric output that represents the answer
            int c = knn.Decide(input); // answer will be 0

            // Now let us convert the numeric output to an actual "Yes" or "No" answer
            string result = codebook.Revert("GeneratedByProgram", c); // answer will be "No"

            Console.WriteLine("Test Data Input :  " + input + "\nExpectation: " + Output + "\nResult: " + result);

        }

        private int Decide(string input)
        {
            throw new NotImplementedException();
        }

        public void runKNN()
        {
            // K=1 means Only its nearest neighbour will be used 
            var knn = new KNearestNeighbors<string>(k: 1, distance: new Levenshtein());
            // In order to compare strings, we will be using Levenshtein's string distance

            String[] trainingInput = trainingData.ToArray<String>("Output");
            DataTable trainingsymbols = convertStringDataToDiscreteSymbol();

            int[] trainingOutput = trainingsymbols.ToArray<int>("GeneratedByProgram");
            // We learn the algorithm:
            knn.Learn(trainingInput, trainingOutput);

            // After the algorithm has been created, we can use it:`
            int answer = knn.Decide("Chars"); // answer should be 1.

            DataTable testdata = new DataTable("Sample Data");
            testdata.Columns.Add("Output", "GeneratedByProgram");

            testdata.Rows.Add("a8", "Yes");
            testdata.Rows.Add("b5", "Yes");
            testdata.Rows.Add("This is real", "No");
            testdata.Rows.Add("a9", "Yes");
            testdata.Rows.Add("b15", "Yes");
            testdata.Rows.Add("b15", "Yes");
            testdata.Rows.Add("b18", "Yes");
            testdata.Rows.Add("b200", "Yes");
            testdata.Rows.Add("b17", "Yes");
            testdata.Rows.Add("b62", "Yes");
            testdata.Rows.Add("b90", "Yes");
            testdata.Rows.Add("b123", "Yes");
            testdata.Rows.Add("This is Ok", "Yes");
            testdata.Rows.Add("b1", "Yes");
            testdata.Rows.Add("b64", "Yes");
            testdata.Rows.Add("I am god", "No");
            testdata.Rows.Add("b14", "Yes");
            testdata.Rows.Add("b1", "Yes");
            testdata.Rows.Add("b64", "Yes");
            testdata.Rows.Add("b100000000000", "Yes");

            testForInstance(knn, "b15", "Yes");

            DataTable testsymbols = codebook.Apply(testdata);
            String[] testInput = testdata.ToArray<String>("Output");
            int[] testOutput = testsymbols.ToArray<int>("GeneratedByProgram");
            int[] answers = knn.Decide(testInput); // answer should be 1.


            Console.WriteLine("\n Accuracy (Tested on 20 data set): " + calculateAccuracy(answers, testOutput));
           

        }


    }
}
