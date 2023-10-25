using System;
using UnityEngine;
using UnityEngine.UI;

namespace JengaApp.UI.Components
{
    public class Toggle : MonoBehaviour
    {
        #region Fields

        [SerializeField] private TMPro.TextMeshProUGUI label;
        [SerializeField] private Image backgroundImage;
        [SerializeField] private Sprite offImage;
        [SerializeField] private Sprite onImage;

        private string toggleName;
        private bool isOn;
        private Action<bool> onToggleCallback;

        #endregion

        #region Public Methods

        public void Initialise(string label, Action<bool> onToggleCallback)
        {
            toggleName = label;
            this.onToggleCallback = onToggleCallback;
            UpdateButtonAndLabel();
        }

        public void ToggleSwitch(bool isOn)
        {
            this.isOn = isOn;
            onToggleCallback?.Invoke(isOn);
            UpdateButtonAndLabel();
        }

        #endregion

        #region Private Methods

        private void UpdateButtonAndLabel()
        {
            var actionName = isOn ? "STOP" : "START";
            this.label.text = $"{toggleName}\n{actionName}";

            backgroundImage.sprite = isOn ? offImage : onImage;
        }

        #endregion
    }
}
