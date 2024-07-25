using UnityEngine;

public class FPPCamera : MonoBehaviour
{
    [SerializeField] Transform playerHeadTrans;

    [Header("Settings")]
    [SerializeField] float clampAngle = 80.0f;     // Maximum vertical look angle

    private float rotationX = 0f;

    void FixedUpdate()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -clampAngle, clampAngle);

        transform.SetPositionAndRotation(playerHeadTrans.position, Quaternion.Euler(rotationX, playerHeadTrans.eulerAngles.y, playerHeadTrans.eulerAngles.z));
    }
}
