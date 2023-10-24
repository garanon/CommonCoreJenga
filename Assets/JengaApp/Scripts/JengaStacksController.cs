using System.Collections.Generic;
using JengaApp.Utilities;
using UnityEngine;

namespace JengaApp
{
    public class JengaStacksController : MonoBehaviour
    {
        #region Properties

        public List<JengaStack> JengaStacks { get; private set; } = new();

        #endregion

        #region Fields

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
        }

        #endregion
    }
}