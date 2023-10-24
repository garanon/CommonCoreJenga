using JengaApp.Utilities;
using UnityEngine;

namespace JengaApp
{
    public class JengaStacksController : MonoBehaviour
    {
        #region Fields

        [Header("Object pools")]
        [SerializeField] private JengaStackPool stackObjectPool;
        [SerializeField] private JengaBlockPool blockObjectPool;

        [Header("Configuration")]
        [SerializeField] private float stackSpacing = 5f;

        #endregion

        #region Unity Hooks

        private void Start()
        {
            // Initialise an array of jenga stacks.
            var stackConfigs = new JengaStackConfig[]
            {
                new JengaStackConfig { NumBlocksPerRow = 3, TotalNumBlocks = 5 },
                new JengaStackConfig { NumBlocksPerRow = 3, TotalNumBlocks = 10 },
                new JengaStackConfig { NumBlocksPerRow = 3, TotalNumBlocks = 20 },
            };

            Initialise(stackConfigs);
        }

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

                ++stackIndex;
            }
        }

        #endregion
    }
}