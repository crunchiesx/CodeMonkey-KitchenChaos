using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private enum LookMode
    {
        LookAt,
        LookAtInverted,
        CameraForward,
        CameraForwardInverted
    }
    [SerializeField] private LookMode lookMode;

    private void LateUpdate()
    {
        switch (lookMode)
        {
            case LookMode.LookAt:
                transform.LookAt(Camera.main.transform);
                break;
            case LookMode.LookAtInverted:
                transform.LookAt(transform.position + (transform.position - Camera.main.transform.position));
                break;
            case LookMode.CameraForward:
                transform.forward = Camera.main.transform.forward;
                break;
            case LookMode.CameraForwardInverted:
                transform.forward = -Camera.main.transform.forward;
                break;
        }
    }
}
