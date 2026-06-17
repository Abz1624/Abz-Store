using UnityEngine;

namespace Abzstore
{
    public class AutoRotate : MonoBehaviour
    {
        [Header("Rotation Speed")]
        public float rotationSpeed = 30f;

        [Header("Rotation Axis")]
        public Vector3 rotationAxis = Vector3.up;

        private void Update()
        {
            transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime, Space.World);
        }
    }
}