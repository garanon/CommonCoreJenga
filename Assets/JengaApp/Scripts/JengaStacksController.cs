using UnityEngine;

namespace JengaApp
{
    public class JengaStacksController : MonoBehaviour
    {
        #region Fields

        [SerializeField] private JengaStackPool stackObjectPool;
        [SerializeField] private JengaBlockPool blockObjectPool;

        #endregion

        #region Unity Hooks

        private void Start()
        {
            // Initialise an array of jenga stacks.
            var stackConfigs = new JengaStackConfig[]
            {
                new JengaStackConfig { NumBlocks = 5 },
                new JengaStackConfig { NumBlocks = 10 },
                new JengaStackConfig { NumBlocks = 20 },
            };

            Initialise(stackConfigs);
        }

        #endregion

        #region Public Methods

        public void Initialise(JengaStackConfig[] configs)
        {
            foreach (var config in configs)
            {
                var jengaStack = stackObjectPool.Get(this.transform, false);
                jengaStack.Initialise(config, blockObjectPool);
            }
        }

        #endregion
    }
}