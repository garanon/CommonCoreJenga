using System;
using System.Collections;
using JengaApp.Utilities;
using UnityEngine;
using UnityEngine.Networking;

namespace JengaApp
{
    public class WebAPIManager : SingletonMonoBehaviour<WebAPIManager>
    {
        #region Fields

        private const float MinimumWaitTime = 1f;

        #endregion

        #region Public Methods

        public void GetDataFromUrl(string url, Action<string> onSuccess, Action<string> onFailed)
        {
            StartCoroutine(GetDataFromUrlRoutine(url, onSuccess, onFailed));
        }

        #endregion

        #region Private Methods

        private IEnumerator GetDataFromUrlRoutine(string url, Action<string> onSuccess, Action<string> onFailed)
        {
            // Wait for a minimum time.
            yield return new WaitForSeconds(MinimumWaitTime);

            // Check user has internet
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                var errorMessage = "User is not connected to the internet.";
                onFailed?.Invoke(errorMessage);
                yield break;
            }

            // Send the request.
            using (var www = UnityWebRequest.Get(url))
            {
                // Send the request and wait for a response
                yield return www.SendWebRequest();

                // Check for errors and post an error.
                if (www.result == UnityWebRequest.Result.ConnectionError ||
                    www.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.LogError($"{nameof(GetDataFromUrlRoutine)} failed with error: {www.error}");
                    onFailed?.Invoke(www.error);
                }
                // Otherwise, post a success.
                else
                {
                    string json = www.downloadHandler.text;
                    onSuccess?.Invoke(json);
                }
            }
        }

        #endregion
    }
}