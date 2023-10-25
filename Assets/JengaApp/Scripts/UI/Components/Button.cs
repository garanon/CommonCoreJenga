using System;
using UnityEngine;

namespace JengaApp.UI.Components
{
    public class Button : MonoBehaviour
    {
        #region Fields

        [SerializeField] private TMPro.TextMeshProUGUI label;

        private Action onPressedCallback;

        #endregion

        #region Public Methods

        public void Initialise(string label, Action onPressedCallback)
        {
            this.label.text = label;
            this.onPressedCallback = onPressedCallback;
        }

        public void OnButtonPress()
        {
            onPressedCallback?.Invoke();
        }

        #endregion
    }
}
