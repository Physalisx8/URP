using Cinemachine;
using UnityEngine;

public class CameraTriggerZone : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera cam;
    
    public void OnTriggered()
    {
        CameraSwitch.Instance.SwitchCamera(cam);
    }
}
