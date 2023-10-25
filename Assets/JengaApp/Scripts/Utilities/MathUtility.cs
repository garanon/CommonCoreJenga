using UnityEngine;

namespace JengaApp.Utilities
{
    public static class MathUtility
    {
        #region Methods

        public static Vector3 GetEqualSpacedPosition(Vector3 spaceBetweenObjects, int objectIndex, int totalObjectCount)
        {
            if (totalObjectCount <= 1)
                return Vector3.zero;

            var totalSpace = spaceBetweenObjects * (totalObjectCount - 1);
            var space = totalSpace / (totalObjectCount - 1);
            var position = -totalSpace / 2f + (objectIndex * space);
            return position;
        }

        #endregion
    }
}