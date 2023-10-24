using System;
using UnityEngine;

namespace JengaApp
{
    public class JengaBlock : MonoBehaviour
    {
        #region Properties

        public IJengaBlockData Config { get; private set; }

        #endregion

        #region Fields

        [SerializeField] private new Rigidbody rigidbody;
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

        public void WakeUp()
        {
            rigidbody.WakeUp();
            rigidbody.isKinematic = false;
        }

        public void Sleep()
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.isKinematic = true;
            rigidbody.Sleep();
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