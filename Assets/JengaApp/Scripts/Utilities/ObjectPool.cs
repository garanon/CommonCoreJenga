using UnityEngine;

namespace JengaApp.Utilities
{
    public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region Fields

        [SerializeField] private T prefab;

        private UnityEngine.Pool.ObjectPool<T> objectPool;

        #endregion

        #region Unity Hooks

        private void Awake()
        {
            objectPool = new UnityEngine.Pool.ObjectPool<T>(OnCreate, OnCommission, OnDecommission);
        }

        #endregion

        #region Public Methods

        public T Get(Transform parent = null, bool worldPositionStays = true)
        {
            var pooledObject = objectPool.Get();

            if (parent != null)
                pooledObject.transform.SetParent(parent, worldPositionStays);

            return pooledObject;
        }

        public void Release(T pooledObject)
        {
            objectPool.Release(pooledObject);

            if (pooledObject.transform.parent != this.transform)
                pooledObject.transform.SetParent(this.transform);
        }

        #endregion

        #region Protected Methods

        protected virtual T OnCreate()
        {
            return GameObject.Instantiate<T>(prefab, this.transform);
        }

        protected virtual void OnCommission(T pooledObject)
        {
            pooledObject.gameObject.SetActive(true);
        }

        protected virtual void OnDecommission(T pooledObject)
        {
            pooledObject.gameObject.SetActive(false);
        }

        #endregion
    }
}