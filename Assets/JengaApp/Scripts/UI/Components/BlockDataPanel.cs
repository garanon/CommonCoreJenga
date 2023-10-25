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
            Debug.Log($"Block selected: {block}");
            this.gameObject.SetActive(true);
        }

        public void SetModeHide()
        {
            selectedBlock = null;
            this.gameObject.SetActive(false);
        }

        #endregion
    }
}
