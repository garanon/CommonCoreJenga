using System.Collections.Generic;
using System.Linq;
using JengaApp.UI;
using JengaApp.Utilities;
using UnityEngine;

namespace JengaApp
{
    public class JengaStacksController : MonoBehaviour
    {
        #region Properties

        public List<JengaStack> JengaStacks { get; private set; } = new();

        public JengaStack ActiveStack { get; private set; }

        #endregion

        #region Fields

        [SerializeField] private CameraController cameraController;

        [Header("Object pools")]
        [SerializeField] private JengaStackPool stackObjectPool;
        [SerializeField] private JengaBlockPool blockObjectPool;

        [Header("Configuration")]
        [SerializeField] private float stackSpacing = 5f;

        #endregion

        #region Public Methods

        public void Initialise(JengaStackConfig[] configs)
        {
            var stackIndex = 0;
            foreach (var config in configs)
            {
                var jengaStack = stackObjectPool.Get(this.transform, false);
                var position = MathUtility.GetEqualSpacedPosition(Vector3.right * stackSpacing, stackIndex, configs.Length);
                jengaStack.transform.localPosition = position;

                jengaStack.Initialise(config, blockObjectPool);
                JengaStacks.Add(jengaStack);

                ++stackIndex;
            }

            var targetStack = JengaStacks.FirstOrDefault();
            if (targetStack != null)
            {
                SetStackActive(targetStack);
            }

            UIManager.Instance.InitialiseGradeSelection(this);
        }

        public void SetStackActive(JengaStack stack)
        {
            if (ActiveStack != stack)
            {
                ActiveStack = stack;
                cameraController.SetTarget(stack.transform);
                UIManager.Instance.SetModeHideBlockData();
            }
        }

        #endregion
    }
}