using UnityEngine;

namespace JengaApp.UI.Components
{
    public class GameModeSidebar : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Toggle togglePrefab;

        #endregion

        #region Public Methods

        public void Initialise(GameMode[] gameModes)
        {
            foreach (var gameMode in gameModes)
            {
                var toggle = GameObject.Instantiate<Toggle>(togglePrefab, this.transform);
                toggle.Initialise(gameMode.GetType().Name, (isOn) => OnGameModeToggle(gameMode, isOn));
            }
        }

        #endregion

        #region Private Methods

        private void OnGameModeToggle(GameMode gameMode, bool isOn)
        {
            if (isOn)
            {
                gameMode.StartGameMode();
            }
            else
            {
                gameMode.FinishGameMode();
            }
        }

        #endregion
    }
}
