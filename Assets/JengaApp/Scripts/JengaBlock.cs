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
        [SerializeField] private Material selectedMaterial;

        #endregion

        #region Public Methods

        public void Initialise(IJengaBlockData config)
        {
            Config = config;
            SetModeBlockType(config.BlockType);

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

        public void SetModeBlockType(BlockType type)
        {
            switch (type)
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

        public void SetModeSelected(bool isSelected)
        {
            if (isSelected)
                meshRenderer.material = selectedMaterial;
            else
                SetModeBlockType(Config.BlockType);
        }

        #endregion
    }
}