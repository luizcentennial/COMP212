using Microsoft.ML.Data;

namespace Example24.Models {
    internal class Prediction {
        [ColumnName("PredictedLabel")]
        public uint SelectedClusterId;

        [ColumnName("Score")]
        public float[] Distance;
    }
}
