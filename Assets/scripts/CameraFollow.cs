using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;  // The tank's transform

    public float smoothSpeed = 0.125f;  // Adjust this to control the smoothness of the camera follow
    public Vector3 offset;  // Adjust this to set the distance between the camera and the tank

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // float targetYRotation = target.eulerAngles.y;
        // transform.rotation = Quaternion.Euler(0f, targetYRotation, 0f);

        Quaternion desiredRotation = Quaternion.Euler(0f, target.eulerAngles.y, 0f);

        Vector3 offset2 = desiredRotation * new Vector3(0f, 15.8f, -35f);
        transform.RotateAround(target.position, Vector3.up, 5f * Time.deltaTime);
        transform.position = target.position + offset2;
        transform.LookAt(target.position);

        // transform.LookAt(target);  // Make the camera look at the tank
    }
}
