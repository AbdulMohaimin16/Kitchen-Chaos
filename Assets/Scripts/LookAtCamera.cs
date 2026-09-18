using UnityEngine;

public class LookAtCamera : MonoBehaviour
{ 
    private enum LookAtMode
    {
        LookAt,
        LookAtInverted,
        CameraForward,
        CameraForwardInverted,
    }

    [SerializeField] private LookAtMode lookAtMode;

    void LateUpdate()
    {

        switch (lookAtMode)
        {
            case LookAtMode.LookAt:
                transform.LookAt(Camera.main.transform);
                break;
            case LookAtMode.LookAtInverted:
                Vector3 dirInverted = transform.position - Camera.main.transform.position;
                transform.LookAt(transform.position + dirInverted);
                break;
            case LookAtMode.CameraForward:
                transform.forward = Camera.main.transform.forward;
                break;
            case LookAtMode.CameraForwardInverted:
                transform.forward = -Camera.main.transform.forward;
                break;
            default:
                break;
        }

       /* if (lookAtMode == LookAtMode.LookAt)
            transform.LookAt(Camera.main.transform);
        else if (lookAtMode == LookAtMode.LookAtInverted)
        {
            Vector3 dirInverted = transform.position - Camera.main.transform.position;
            transform.LookAt(transform.position + dirInverted);
        }
        else if (lookAtMode == LookAtMode.CameraForward)
            transform.forward = Camera.main.transform.forward;
        else if (lookAtMode == LookAtMode.CameraForward)
            transform.forward = -Camera.main.transform.forward;*/
    }
}
