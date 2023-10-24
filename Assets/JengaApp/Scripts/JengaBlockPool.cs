using JengaApp.Utilities;
using UnityEngine;

namespace JengaApp
{
    public class JengaBlockPool : ObjectPool<JengaBlock>
    {
        #region ObjectPool Overrides

        protected override void OnCommission(JengaBlock pooledObject)
        {
            base.OnCommission(pooledObject);
            pooledObject.WakeUp();
        }

        protected override void OnDecommission(JengaBlock pooledObject)
        {
            pooledObject.Sleep();
            pooledObject.transform.rotation = Quaternion.identity;
            base.OnDecommission(pooledObject);
        }

        #endregion
    }
}
