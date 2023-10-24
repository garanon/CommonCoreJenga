using System.Linq;
using UnityEngine;

namespace JengaApp.Utilities
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region Singleton

        // Check to see if we're about to be destroyed.
        private static bool isShuttingDown = false;
        private static object lockObject = new();
        private static T instance;

        /// <summary>
        /// Access singleton instance through this property.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (isShuttingDown)
                {
                    Debug.LogWarning($"[Singleton] Instance {typeof(T)} already destroyed. Returning null.");
                    return null;
                }

                lock (lockObject)
                {
                    if (instance == null)
                    {
                        // Search for existing instance.
                        try
                        {
                            instance = FindObjectsOfType<T>().Single();
                        }
                        catch
                        {
                            Debug.LogError($"Multiple instances of type {typeof(T)} in scene.");
                        }

                        // Create new instance if one doesn't already exist.
                        if (instance == null)
                        {
                            // Need to create a new GameObject to attach the singleton to.
                            var singletonObject = new GameObject();
                            instance = singletonObject.AddComponent<T>();
                            singletonObject.name = $"[Singleton] {typeof(T)}";
                        }
                    }

                    return instance;
                }
            }
        }

        #endregion

        #region Unity Hooks

        protected virtual void Awake()
        {
            // Make instance persistent.
            GameObject.DontDestroyOnLoad(Instance);
        }

        protected virtual void OnApplicationQuit()
        {
            isShuttingDown = true;
        }

        protected virtual void OnDestroy()
        {
            isShuttingDown = true;
        }

        #endregion
    }
}