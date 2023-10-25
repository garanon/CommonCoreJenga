using System;
using System.Collections;
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
            UIManager.Instance.SetModeShowMessagePanel("Downloading grade data...");
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
            UIManager.Instance.SetModeHideMessagePanel();
            Debug.Log("Grade data downloaded.");

            // Store a version locally.
            UserProfile.SaveGradeData(jsonData);

            // Initialise the stacks
            InitialiseJengaStacksFromJson(jsonData);
        }

        private void OnDataDownloadFailed(string errorMessage)
        {
            UIManager.Instance.SetModeShowMessagePanel("Failed to download data. Checking for a local version...");
            Debug.LogError($"Failed to download data {errorMessage}. Checking for a cached version...");

            // Attempt to load a cached version.
            if (UserProfile.TryLoadCachedGradeData(out var jsonData))
            {
                // Artifical delay.
                IEnumerator waitRoutine(Action onComplete)
                {
                    yield return new WaitForSeconds(1f);
                    onComplete?.Invoke();
                }
                StartCoroutine(waitRoutine(() =>
                {
                    UIManager.Instance.SetModeHideMessagePanel();
                    Debug.Log("Network unreachable. Loaded data from file.");

                    // Initialise the stacks
                    InitialiseJengaStacksFromJson(jsonData);
                }));
            }
            else
            {
                UIManager.Instance.SetModeShowMessagePanel("Failed to fetch grade data. Try again later.");
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
