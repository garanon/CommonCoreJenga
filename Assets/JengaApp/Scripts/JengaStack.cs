using JengaApp.Utilities;
using UnityEngine;

namespace JengaApp
{
    public class JengaStack : MonoBehaviour
    {
        #region Fields

        [SerializeField] private float blockSpacing = 1f;

        #endregion

        #region Public Methods

        public void Initialise(JengaStackConfig config, JengaBlockPool objectPool)
        {
            for (var i = 0; i < config.TotalNumBlocks; ++i)
            {
                var jengaBlock = objectPool.Get(this.transform, false);
                CalculateAndSetPosition(jengaBlock, i);

                jengaBlock.Initialise();
            }
        }

        #endregion

        #region Private Methods

        private void CalculateAndSetPosition(JengaBlock block, int blockIndex)
        {
            var rowIndex = blockIndex % JengaStackConfig.NumBlocksPerRow;
            var columnIndex = Mathf.FloorToInt(blockIndex / JengaStackConfig.NumBlocksPerRow);
            var isOddRow = columnIndex % 2 > 0;

            var position = default(Vector3);
            position.x = MathUtility.GetEqualSpacedPosition(Vector3.right * blockSpacing, rowIndex, JengaStackConfig.NumBlocksPerRow).x;
            position.y = columnIndex;

            block.transform.localPosition = position;

            if (isOddRow)
            {
                block.transform.RotateAround(this.transform.position, Vector3.up, 90f);
            }
        }

        #endregion
    }
}
