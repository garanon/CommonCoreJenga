using System;
using System.IO;
using UnityEngine;

namespace JengaApp
{
    public static class UserProfile
    {
        #region Public Methods

        public static bool TryLoadCachedGradeData(out string json)
        {
            if (File.Exists(AppConstants.CachedDataFilePath))
            {
                try
                {
                    json = File.ReadAllText(AppConstants.CachedDataFilePath);
                    return true;
                }
                catch (Exception e)
                {
                    Debug.LogError("Error reading data: " + e.Message);
                }
            }
            else
            {
                Debug.LogError($"File does not exist at location: {AppConstants.CachedDataFilePath}.");
            }

            json = string.Empty;
            return false;
        }

        public static void SaveGradeData(string jsonData)
        {
            try
            {
                // Create the StreamingAssets folder if it doesn't exist
                if (!Directory.Exists(Application.streamingAssetsPath))
                {
                    Directory.CreateDirectory(Application.streamingAssetsPath);
                }

                // Write the data to a file
                File.WriteAllText(AppConstants.CachedDataFilePath, jsonData);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error saving data to file: {e.Message}");
            }
        }

        #endregion
    }
}