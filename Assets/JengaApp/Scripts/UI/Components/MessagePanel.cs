using UnityEngine;

namespace JengaApp.UI.Components
{
    public class MessagePanel : MonoBehaviour
    {
        #region Fields

        [SerializeField] private TMPro.TextMeshProUGUI textArea;

        #endregion

        #region Public Methods

        public void SetModeShow(string message)
        {
            textArea.text = message;
            this.gameObject.SetActive(true);
        }

        public void SetModeHide()
        {
            this.gameObject.SetActive(false);
        }

        #endregion
    }
}
