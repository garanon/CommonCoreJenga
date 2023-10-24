using UnityEngine;

namespace JengaApp
{
    public class JengaStack : MonoBehaviour
    {
        #region Fields

        #endregion

        #region Public Methods

        public void Initialise(JengaStackConfig config, JengaBlockPool objectPool)
        {
            for (var i = 0; i < config.NumBlocks; ++i)
            {
                var jengaBlock = objectPool.Get(this.transform, false);
                jengaBlock.Initialise();
            }
        }

        #endregion
    }
}
