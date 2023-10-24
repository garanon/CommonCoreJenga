using System.IO;
using UnityEngine;

namespace JengaApp
{
    /// <summary>
    /// A class to globally define constants and values for use across the app.
    /// </summary>
    public static class AppConstants
    {
        #region Properties

        // File paths
        public static string CachedDataFilePath => Path.Combine(Application.streamingAssetsPath, "cached_grade_data.json");

        // URLs
        public static string FetchGradeDataURL => "https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack";

        #endregion
    }
}
