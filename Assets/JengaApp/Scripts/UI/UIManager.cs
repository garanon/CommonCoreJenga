using JengaApp.UI.Components;
using JengaApp.Utilities;
using UnityEngine;

namespace JengaApp.UI
{
    public class UIManager : SingletonMonoBehaviour<UIManager>
    {
        #region Fields

        [SerializeField] private GradeSelectionSidebar gradeSelectionSidebar;
        [SerializeField] private GameModeSidebar gameModeSidebar;
        [SerializeField] private BlockDataPanel blockDataPanel;
        [SerializeField] private MessagePanel messagePanel;

        #endregion

        #region Public Methods

        public void InitialiseGradeSelection(JengaStacksController stacksController)
        {
            gradeSelectionSidebar.Initialise(stacksController);
        }

        public void InitialiseGameModes(GameMode[] gameModes)
        {
            gameModeSidebar.Initialise(gameModes);
        }

        public void SetModeShowBlockData(StandardizedGradeJengaBlock block)
        {
            blockDataPanel.SetModeShow(block);
        }

        public void SetModeHideBlockData()
        {
            blockDataPanel.SetModeHide();
        }

        public void SetModeShowMessagePanel(string message)
        {
            messagePanel.SetModeShow(message);
        }

        public void SetModeHideMessagePanel()
        {
            messagePanel.SetModeHide();
        }

        #endregion
    }
}
