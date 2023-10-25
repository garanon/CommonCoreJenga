using UnityEngine;

namespace JengaApp.UI.Components
{
    public class BlockDataPanel : MonoBehaviour
    {
        #region Fields

        [SerializeField] private TMPro.TextMeshProUGUI textArea;

        private StandardizedGradeJengaBlock selectedBlock;

        #endregion

        #region Unity Hooks

        private void Awake()
        {
            SetModeHide();
        }

        #endregion

        #region Public Methods

        public void SetModeShow(StandardizedGradeJengaBlock block)
        {
            selectedBlock = block;
            textArea.text = GetBlockDataText(block);
            this.gameObject.SetActive(true);
        }

        public void SetModeHide()
        {
            selectedBlock = null;
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
