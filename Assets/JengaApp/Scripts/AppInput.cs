using JengaApp.UI;
using UnityEngine;

namespace JengaApp
{
    public class AppInput : MonoBehaviour
    {
        #region Fields

        [SerializeField] private CameraController cameraController;
        [SerializeField] private JengaStacksController stacksController;

        #endregion

        #region Unity Hooks

        private void Update()
        {
            // Left click
            if (Input.GetMouseButton(0) && cameraController.HasTarget)
            {
                ProcessCameraMovement();
            }

            // Right click down
            if (Input.GetMouseButtonDown(1))
            {
                DisplayBlockData(true);
            }
        }

        #endregion

        #region Private Methods

        private void ProcessCameraMovement()
        {
            var mouseX = Input.GetAxis("Mouse X");
            var mouseY = Input.GetAxis("Mouse Y");
            cameraController.RotateAroundAxis(mouseX, mouseY);
        }

        private void DisplayBlockData(bool display)
        {
            if (display == true)
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hit))
                {
                    var jengaBlock = hit.collider.gameObject.GetComponentInParent<JengaBlock>();
                    if (jengaBlock != null)
                    {
                        // Only show the information if the stack is active.
                        if (stacksController.ActiveStack.JengaBlocks.Contains(jengaBlock))
                        {
                            UIManager.Instance.SetModeShowBlockData(jengaBlock);
                        }
                    }
                }
            }
            else
            {
                UIManager.Instance.SetModeHideBlockData();
            }
        }

        #endregion
    }
}
