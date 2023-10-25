using UnityEngine;

namespace JengaApp.UI.Components
{
    public class BlockDataPanel : MonoBehaviour
    {
        #region Fields

        [SerializeField] private TMPro.TextMeshProUGUI textArea;

        private JengaBlock selectedBlock;

        #endregion

        #region Unity Hooks

        private void Awake()
        {
            SetModeHide();
        }

        #endregion

        #region Public Methods

        public void SetModeShow(JengaBlock block)
        {
            // Disable current block.
            selectedBlock?.SetModeSelected(false);

            // Set up new block.
            block.SetModeSelected(true);
            textArea.text = GetBlockDataText(block.Config as StandardizedGradeJengaBlock);
            selectedBlock = block;

            // Display the panel.
            this.gameObject.SetActive(true);
        }

        public void SetModeHide()
        {
            // Disable current block.
            selectedBlock?.SetModeSelected(false);
            selectedBlock = null;

            // Hide the panel.
            this.gameObject.SetActive(false);
        }

        #endregion

        #region Private Methods

        private string GetBlockDataText(StandardizedGradeJengaBlock block)
        {
            return $"{block.Grade}: {block.Domain}" +
                    $"\n{block.Cluster}" +
                    $"\n{block.StandardId}: {block.StandardDescription}";

        }

        #endregion
    }
}
