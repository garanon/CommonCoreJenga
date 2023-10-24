using UnityEngine;

namespace JengaApp
{
    public abstract class GameMode : MonoBehaviour
    {
        #region Properties

        public bool IsActive { get; private set; }

        #endregion

        #region Abstract Methods

        public abstract void OnGameModeStart();
        public abstract void OnGameModeUpdate();
        public abstract void OnGameModeFinish();

        #endregion

        #region Public Methods

        [ContextMenu("Start Game Mode")]
        public void StartGameMode()
        {
            IsActive = true;
            OnGameModeStart();
        }

        [ContextMenu("Finish Game Mode")]
        public void FinishGameMode()
        {
            OnGameModeFinish();
            IsActive = false;
        }

        #endregion

        #region Unity Hooks

        private void Update()
        {
            if (IsActive)
            {
                OnGameModeUpdate();
            }
        }

        #endregion
    }
}