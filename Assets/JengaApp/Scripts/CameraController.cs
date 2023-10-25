using UnityEngine;

namespace JengaApp
{
    public class CameraController : MonoBehaviour
    {
        #region Properties

        public bool HasTarget => targetObject != null;

        #endregion

        #region Fields

        [SerializeField] private Vector3 orbitOffset = Vector3.up * 5f;
        [SerializeField] private float orbitSpeed = 5f;
        [SerializeField] private float cameraDistance = 50f;

        private Transform targetObject;
        private Vector3 targetPosition;
        private Vector3 previousRotation;

        #endregion

        #region Unity Hooks

        private void Awake()
        {
            previousRotation = transform.eulerAngles;
        }

        #endregion

        #region Public Methods

        public void SetTarget(Transform target)
        {
            this.targetObject = target;
            this.targetPosition = target.transform.position + orbitOffset;
            UpdateCameraPosition();
        }

        public void RotateAroundAxis(float xAxis, float yAxis)
        {
            previousRotation.y += xAxis * orbitSpeed;
            previousRotation.x -= yAxis * orbitSpeed;
            UpdateCameraPosition();
        }

        #endregion

        #region Private Methods

        private void UpdateCameraPosition()
        {
            var rotation = Quaternion.Euler(previousRotation);
            var newPosition = targetPosition - (rotation * Vector3.forward * cameraDistance);
            transform.rotation = rotation;
            transform.position = newPosition;
        }

        #endregion
    }
}
