using Example23.Models;
using Microsoft.ML;
using System;

namespace Example23 {

    // REGRESSION:
    //
    // A supervised machine learning task that is used to predict the value
    // of the label from a set of related features. The label can be of any
    // real value and is not from a finite set of values as in classification tasks.
    //
    // Regression algorithms model the dependency of the label on its related features
    // to determine how the label will change as the values of the features are varied.
    //
    // The input of a regression algorithm is a set of examples with labels of known values.
    // The output of a regression algorithm is a function, which you can use to predict the
    // label value for any new set of input features.
    //
    // Examples of regression scenarios include:
    //
    // - Predicting house prices based on house attributes such as number of bedrooms,
    //   location, or size.
    // - Predicting future stock prices based on historical data and current market trends.
    // - Predicting sales of a product based on advertising budgets.
    //
    // Note: This example requires NuGet package Microsoft.ML.

    internal class Program {
        static void Main(string[] args) {

            // In this example, you will see how to use ML.NET to predict the price
            // of an apartment based on its square-footage.

            // Defining ML context.
            MLContext mlContext = new MLContext();

            // Creating training data.
            ApartmentData[] apartmentData = {
               new ApartmentData() { SquareFootage = 1.1F, Price = 1.2F },
               new ApartmentData() { SquareFootage = 1.9F, Price = 2.3F },
               new ApartmentData() { SquareFootage = 2.8F, Price = 3.0F },
               new ApartmentData() { SquareFootage = 3.4F, Price = 3.7F }
            };

            // Preparing training data.
            IDataView trainingData = mlContext.Data.LoadFromEnumerable(apartmentData);

            // Creating pipeline with the Stochastic Dual Coordinate Ascent method.
            // SDCA is a stochastic and streaming optimization algorithm.
            // https://www.csie.ntu.edu.tw/%7Ecjlin/papers/disk_decomposition/tkdd_disk_decomposition.pdf
            var pipeline = mlContext.Transforms.Concatenate("Features", new[] { "SquareFootage" })
                .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: "Price", maximumNumberOfIterations: 100));

            // Training model.
            var model = pipeline.Fit(trainingData);

            // Making a prediction.
            var engine = mlContext.Model.CreatePredictionEngine<ApartmentData, Prediction>(model);
            var predictionInput = new ApartmentData() { SquareFootage = 2.5F };

            var predictionOutput = engine.Predict(predictionInput);

            Console.WriteLine($"Predicted price for size: {predictionInput.SquareFootage * 1000} sqft = {predictionOutput.PredictedPrice:C}M");
        }
    }
}
