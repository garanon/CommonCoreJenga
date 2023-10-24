using UnityEngine;

namespace JengaApp
{
    public class JengaBlock : MonoBehaviour
    {
        #region Properties

        public IJengaBlockData Config { get; private set; }

        #endregion

        #region Fields

        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private Material defaultMaterial;
        [SerializeField] private Material glassMaterial;
        [SerializeField] private Material woodMaterial;
        [SerializeField] private Material stoneMaterial;

        #endregion

        #region Public Methods

        public void Initialise(IJengaBlockData config)
        {
            Config = config;
            SetMode(config.BlockType);

        }

        public void SetMode(BlockType blockType)
        {
            switch (blockType)
            {
                case BlockType.Invalid:
                    meshRenderer.material = defaultMaterial;
                    break;
                case BlockType.Glass:
                    meshRenderer.material = glassMaterial;
                    break;
                case BlockType.Wood:
                    meshRenderer.material = woodMaterial;
                    break;
                case BlockType.Stone:
                    meshRenderer.material = stoneMaterial;
                    break;
            }
        }

        #endregion
    }
}