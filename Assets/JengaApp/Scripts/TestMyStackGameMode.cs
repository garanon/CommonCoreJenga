using UnityEngine;

namespace JengaApp
{
    public class TestMyStackGameMode : GameMode
    {
        #region Fields

        [SerializeField] private JengaStacksController stacksController;
        [SerializeField] private JengaBlockPool jengaBlockPool;

        #endregion

        #region GameMode Implementation

        public override void OnGameModeStart()
        {
            // For each stack...
            foreach (var stack in stacksController.JengaStacks)
            {
                // For each block...
                foreach (var block in stack.JengaBlocks)
                {
                    // If the block is a glass type, remove it.
                    if (block.Config.BlockType == BlockType.Glass)
                    {
                        // TODO: Relying on activeSelf to tell if the block has
                        //       already been released. Create a specific property.
                        if (block.gameObject.activeSelf)
                        {
                            jengaBlockPool.Release(block);
                        }
                    }
                }
            }
        }

        public override void OnGameModeUpdate()
        {
        }

        public override void OnGameModeFinish()
        {
            // Reset all the stacks.
            foreach (var stack in stacksController.JengaStacks)
            {
                stack.ResetStack();
            }
        }

        #endregion
    }
}