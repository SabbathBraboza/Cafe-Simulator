using UnityEngine;

public class CameraFollow : MonoBehaviour
{
      [SerializeField] private Transform playerTransform;  // The player's transform
      [SerializeField] private Vector3 initialOffset = new Vector3(-10, 35, 20);  // Initial offset from the player
      [SerializeField] private float smoothSpeed = 0.125f;  // Speed at which the camera follows
      [SerializeField] private float rotationSpeed = 50f;  // Speed at which the camera rotates around the Y-axis

      private float currentYaw = 0f;  // Track the current Y-axis rotation

      private void Start() => currentYaw = Mathf.Atan2(initialOffset.x, initialOffset.z) * Mathf.Rad2Deg;
      
      private void LateUpdate()
      {
                  if (Input.GetKey(KeyCode.A)) currentYaw -= rotationSpeed * Time.deltaTime;  // Rotate left
                  if (Input.GetKey(KeyCode.D)) currentYaw += rotationSpeed * Time.deltaTime;  // Rotate right

            // Calculate the new offset based on the current yaw
            float offsetDistance = initialOffset.magnitude;
            Vector3 offset = new Vector3(offsetDistance * Mathf.Sin(currentYaw * Mathf.Deg2Rad),initialOffset.y,offsetDistance * Mathf.Cos(currentYaw * Mathf.Deg2Rad));

            Vector3 desiredPosition = playerTransform.position + offset;
            // Smoothly interpolate the camera position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(playerTransform);
      }
}
