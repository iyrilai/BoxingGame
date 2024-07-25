using UnityEngine;

public class FPPCamera : MonoBehaviour
{
    [SerializeField] Transform playerHeadTrans;

    void FixedUpdate()
    {
        transform.SetPositionAndRotation(playerHeadTrans.position, playerHeadTrans.rotation);
    }
}
