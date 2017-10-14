using Accord.Controls;
using Accord.Math;
using Accord.Statistics.Distributions.Univariate;
using Accord.MachineLearning.Bayes;
using System.Data;
using Accord.IO;
using System;
using Accord;
using Accord.Statistics.Filters;
using Accord.MachineLearning;
using Accord.Math.Distances;
using System.IO;

namespace ConsoleApplication1
{
    public class Class1
    {
        public void foo()
        {
            String path = Environment.CurrentDirectory +"\\example.xlsx";

            // Read the Excel worksheet into a DataTable
            DataTable table = new ExcelReader(path).GetWorksheet("T1");

            //Convert the DataTable to input and output vectors
            String[] trainingInputs = table.Columns["Output"].ToArray<String>();
        
            // Create a new codification codebook to
            //convert strings into discrete symbols
            Codification codebook = new Codification(table,
                "GeneratedByProgram");

            // Extract input and output pairs to train
            DataTable symbols = codebook.Apply(table);
             int[] trainingOutputs = symbols.ToArray<int>("GeneratedByProgram");
            var knn = new KNearestNeighbors<string>(k: 1, distance: new Levenshtein());
            // In order to compare strings, we will be using Levenshtein's string distance

            // We learn the algorithm:
            knn.Learn(trainingInputs, trainingOutputs);

            int answer = knn.Decide("Chars");
       



        }
    }
}
