using Accord.Controls;
using Accord.Math;
using Accord.Statistics.Distributions.Univariate;
using Accord.MachineLearning.Bayes;
using System.Data;
using Accord.IO;
using System;
using Accord;
using Accord.Statistics.Filters;

namespace ConsoleApplication1
{
    public class Class1
    {
        public void foo()
        {
            // Read the Excel worksheet into a DataTable
            //DataTable table = new ExcelReader("C:\\Users\\Sohil77\\Downloads\\examples.xls").GetWorksheet("Classification - Yin Yang");

            // Convert the DataTable to input and output vectors
            //double[][] inputs = table.ToJagged<double>("X", "Y");
            // int[] outputs = table.Columns["G"].ToArray<int>();
            //int length = inputs.GetTotalLength(true, true);
            //Console.WriteLine(length + " " + outputs.GetTotalLength(true, true));
            // Plot the data
            //ScatterplotBox.Show("Yin-Yang", inputs, outputs).Hold();
            DataTable data = new DataTable("Mitchell's Tennis Example");

            data.Columns.Add("Day", "Outlook", "Temperature", "Humidity", "Wind", "PlayTennis");

            data.Rows.Add("D1", "Sunny", "Hot", "High", "Weak", "No");
            data.Rows.Add("D2", "Sunny", "Hot", "High", "Strong", "No");
            data.Rows.Add("D3", "Overcast", "Hot", "High", "Weak", "Yes");
            data.Rows.Add("D4", "Rain", "Mild", "High", "Weak", "Yes");
            data.Rows.Add("D5", "Rain", "Cool", "Normal", "Weak", "Yes");
            data.Rows.Add("D6", "Rain", "Cool", "Normal", "Strong", "No");
            data.Rows.Add("D7", "Overcast", "Cool", "Normal", "Strong", "Yes");
            data.Rows.Add("D8", "Sunny", "Mild", "High", "Weak", "No");
            data.Rows.Add("D9", "Sunny", "Cool", "Normal", "Weak", "Yes");
            data.Rows.Add("D10", "Rain", "Mild", "Normal", "Weak", "Yes");
            data.Rows.Add("D11", "Sunny", "Mild", "Normal", "Strong", "Yes");
            data.Rows.Add("D12", "Overcast", "Mild", "High", "Strong", "Yes");
            data.Rows.Add("D13", "Overcast", "Hot", "Normal", "Weak", "Yes");
            data.Rows.Add("D14", "Rain", "Mild", "High", "Strong", "No");


            // Create a new codification codebook to
            //convert strings into discrete symbols
           Codification codebook = new Codification(data,
                "Outlook", "Temperature", "Humidity", "Wind", "PlayTennis");

   

            // Extract input and output pairs to train
            DataTable symbols = codebook.Apply(data);
            int[][] trainingInputs = symbols.ToArray<int>("Outlook", "Temperature", "Humidity", "Wind");
            int[] trainingOutputs = symbols.ToArray<int>("PlayTennis");

            // In our problem, we have 2 classes (samples can be either
            // positive or negative), and 2 inputs (x and y coordinates).
            Console.WriteLine(trainingInputs.Length + " "+ trainingOutputs.Length);

            // Create a new Naive Bayes learning
            var learner = new NaiveBayesLearning();

            // Learn a Naive Bayes model from the examples
            NaiveBayes nb = learner.Learn(trainingInputs, trainingOutputs);

            // Consider we would like to know whether one should play tennis at a
            // sunny, cool, humid and windy day. Let us first encode this instance
            int[] instance = codebook.Translate("Sunny", "Cool", "High", "Strong");
            Console.WriteLine(instance[0]+" "+ instance[1]+ " "+ instance[2]+" "+instance[3]);
            // Let us obtain the numeric output that represents the answer
            int c = nb.Decide(instance); // answer will be 0

            // Now let us convert the numeric output to an actual "Yes" or "No" answer
            string result = codebook.Translate("PlayTennis", c); // answer will be "No"

            // We can also extract the probabilities for each possible answer
            double[] probs = nb.Probabilities(instance); // { 0.795, 0.205 }
                                                         // Create a Naive Bayes learning algorithm
                                                         //var teacher = new NaiveBayesLearning<NormalDistribution>();
                                                         //teacher.Learn(inputs,outputs);
                                                         // Use the learning algorithm to learn
                                                         // var nb = teacher.Learn(inputs, outputs);
            Console.WriteLine(c+" "+result +" "+ probs.GetValue(0) +" "+ probs.GetValue(1));
            Console.ReadLine();
          
        }
    }
}
