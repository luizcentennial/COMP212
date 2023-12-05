using Example24.Models;
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.IO;

namespace Example24 {

    // CLUSTERING:
    //
    // An unsupervised machine learning task that is used to group instances of data into
    // clusters that contain similar characteristics.
    //
    // Clustering can also be used to identify relationships in a dataset that you might not
    // logically derive by browsing or simple observation.
    //
    // The inputs and outputs of a clustering algorithm depends on the methodology chosen.
    // You can take a distribution, centroid, connectivity, or density-based approach.
    //
    // Examples of clustering scenarios include:
    //
    // - Understanding segments of hotel guests based on habits and characteristics of hotel
    //   choices.
    // - Identifying customer segments and demographics to help build targeted advertising
    //   campaigns.
    // - Categorizing inventory based on manufacturing metrics.
    //
    // Note: This example requires NuGet package Microsoft.ML.


    internal class Program {
        static void Main(string[] args) {

            // In this example, you'll see how to use ML.NET to divide iris flowers
            // into different groups that correspond to different types of iris.

            //Creating ML context.
            MLContext mlContext = new MLContext(seed: 1); // Seed set to any number so you have a deterministic environment.

            // Configuring data loading.
            string dataset = Path.Combine(Environment.CurrentDirectory, "Data", "iris-data.txt");
            IDataView fullData = mlContext.Data.LoadFromTextFile(path: dataset,
                                                                 columns: new[] {
                                                                     new TextLoader.Column("Label", DataKind.Single, 0),
                                                                     new TextLoader.Column(nameof(IrisData.SepalLength), DataKind.Single, 1),
                                                                     new TextLoader.Column(nameof(IrisData.SepalWidth), DataKind.Single, 2),
                                                                     new TextLoader.Column(nameof(IrisData.PetalLength), DataKind.Single, 3),
                                                                     new TextLoader.Column(nameof(IrisData.PetalWidth), DataKind.Single, 4),
                                                                 },
                                                                 hasHeader: true,
                                                                 separatorChar: '\t');

            // Splitting dataset in two parts: training (80%) and testing (20%).
            DataOperationsCatalog.TrainTestData trainTestData = mlContext.Data.TrainTestSplit(fullData, testFraction: 0.2);
            var trainingDataView = trainTestData.TrainSet;
            var testingDataView = trainTestData.TestSet;

            // Processing data transformations in pipeline.
            var pipeline = mlContext.Transforms.Concatenate("Features", nameof(IrisData.SepalLength), nameof(IrisData.SepalWidth), nameof(IrisData.PetalLength), nameof(IrisData.PetalWidth));

            // Creating and training the model.   
            var trainer = mlContext.Clustering.Trainers.KMeans(featureColumnName: "Features", numberOfClusters: 3);
            var trainingPipeline = pipeline.Append(trainer);
            var trainedModel = trainingPipeline.Fit(trainingDataView);

            // Evaluating accuracy of the model.
            //IDataView predictions = trainedModel.Transform(testingDataView);
            //var metrics = mlContext.Clustering.Evaluate(predictions, scoreColumnName: "Score", featureColumnName: "Features");

            // Saving the model as a .ZIP file for later use.
            //mlContext.Model.Save(trainedModel, trainingDataView.Schema, "path/to/file.zip");

            // Testing with one sample 
            var setosaFlower = new IrisData() {
                SepalLength = 3.3f,
                SepalWidth = 1.6f,
                PetalLength = 0.2f,
                PetalWidth = 5.1f,
            };

            // Loading a previously created model.
            //ITransformer model = mlContext.Model.Load("path/to/model", out var modelInputSchema);
            
            // Creating a prediction engine related to the loaded trained model.
            var predEngine = mlContext.Model.CreatePredictionEngine<IrisData, Prediction>(trainedModel);

            // Making a prediction.
            var resultprediction = predEngine.Predict(setosaFlower);

            Console.WriteLine($"Cluster assigned for setosa flowers: {resultprediction.SelectedClusterId}");
        }
    }
}
