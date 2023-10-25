using System.Collections.Generic;
using JengaApp.Utilities;
using UnityEngine;

namespace JengaApp
{
    public class JengaStack : MonoBehaviour
    {
        #region Properties

        public JengaStackConfig Config => config;
        public List<JengaBlock> JengaBlocks { get; private set; } = new();

        #endregion

        #region Fields

        [SerializeField] private TMPro.TextMeshPro label;

        [SerializeField] private float blockSpacing = 1f;

        private JengaStackConfig config;
        private JengaBlockPool objectPool;

        #endregion

        #region Public Methods

        public void Initialise(JengaStackConfig config, JengaBlockPool objectPool)
        {
            this.config = config;
            this.objectPool = objectPool;

            // Initialise the labels.
            label.text = config.Label;

            // Build the tower.
            BuildTower();
        }

        public void ResetStack()
        {
            // Release all the current blocks.
            foreach (var block in JengaBlocks)
            {
                // TODO: Relying on activeSelf to tell if the block has
                //       already been released. Create a specific property.
                if (block.gameObject.activeSelf)
                    objectPool.Release(block);
            }

            // Build the tower from scratch.
            BuildTower();
        }

        #endregion

        #region Private Methods

        private void BuildTower()
        {
            JengaBlocks.Clear();

            for (var i = 0; i < config.TotalNumBlocks; ++i)
            {
                var blockConfig = config.Blocks[i];

                var jengaBlock = objectPool.Get(this.transform, false);
                CalculateAndSetPosition(jengaBlock, i);

                jengaBlock.Initialise(blockConfig);
                JengaBlocks.Add(jengaBlock);
            }
        }

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
