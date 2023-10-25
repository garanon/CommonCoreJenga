using System;
using System.Collections.Generic;
using System.Linq;
using JengaApp.UI;
using Newtonsoft.Json;
using UnityEngine;

namespace JengaApp
{
    public class AppController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private JengaStacksController stacksController;

        #endregion

        #region Unity Hooks

        private void Start()
        {
            Debug.Log("Fetching grade data...");
            DownloadGradeData(OnDataDownloadSuccess, OnDataDownloadFailed);
        }

        #endregion

        #region Private Methods

        private void DownloadGradeData(Action<string> onSuccess, Action<string> onFailed)
        {
            WebAPIManager.Instance.GetDataFromUrl(AppConstants.FetchGradeDataURL, onSuccess, onFailed);
        }

        private void OnDataDownloadSuccess(string jsonData)
        {
            Debug.Log("Grade data downloaded.");

            // Store a version locally.
            UserProfile.SaveGradeData(jsonData);

            // Initialise the stacks
            InitialiseJengaStacksFromJson(jsonData);
        }

        private void OnDataDownloadFailed(string errorMessage)
        {
            Debug.LogError($"Failed to download data {errorMessage}.");
            Debug.Log("Checking for a cached version...");

            // Attempt to load a cached version.
            if (UserProfile.TryLoadCachedGradeData(out var jsonData))
            {
                Debug.Log("Loaded data from file.");

                // Initialise the stacks
                InitialiseJengaStacksFromJson(jsonData);
            }
            else
            {
                Debug.LogError($"Failed to fetch grade data.");
            }
        }

        private void InitialiseJengaStacksFromJson(string json)
        {
            // Parse the data
            var gradeData = JsonConvert.DeserializeObject<StandardizedGradeJengaBlock[]>(json);

            // Split and organise the data.
            var groupedData = gradeData.GroupBy(item => item.Grade);
            var configs = new List<JengaStackConfig>();
            foreach (var group in groupedData)
            {
                var sortedData = group
                                    .OrderBy(x => x.Domain)
                                    .ThenBy(x => x.Cluster)
                                    .ThenBy(x => x.GetStandardIdSortKey())
                                    .ToArray();

                // Create the configs.
                var config = new JengaStackConfig
                {
                    Label = group.Key,
                    Blocks = sortedData
                };
                configs.Add(config);
            }

            // Initialise the jenga stacks.
            stacksController.Initialise(configs.ToArray());

            // Initialise game modes
            var gameModes = GetComponents<GameMode>();
            UIManager.Instance.InitialiseGameModes(gameModes.ToArray());
        }

        #endregion
    }
}
