using UnityEngine;

namespace JengaApp.UI.Components
{
    public class GradeSelectionSidebar : MonoBehaviour
    {
        #region Fields

        [SerializeField] private Button buttonPrefab;

        #endregion

        #region Public Methods

        public void Initialise(JengaStacksController stacksController)
        {
            foreach (var stack in stacksController.JengaStacks)
            {
                var button = GameObject.Instantiate<Button>(buttonPrefab, this.transform);
                button.Initialise(stack.Config.Label, () => stacksController.SetStackActive(stack));
            }
        }

        #endregion
    }
}