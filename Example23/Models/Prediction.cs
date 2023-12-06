using Microsoft.ML.Data;

namespace Example23.Models {
    internal class Prediction {
        // ML.NET has default names for the predicted value columns produced by a model.
        // Depending on the task the name may differ.
        // For the linear regression algorithm used in this example, the default name of
        // the output column is "Score", which is defined by the ColumnName attribute on
        // the PredictedPrice property.
        
        [ColumnName("Score")]
        public float PredictedPrice { get; set; }
    }
}
