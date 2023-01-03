using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera firstPersonCam;
    
    void Awake(){
                CameraSwitch.Instance.SetMainCam(firstPersonCam);
                CameraSwitch.Instance.Register(firstPersonCam);
                CameraSwitch.Instance.SwitchCamera(firstPersonCam);
            }
private void Update(){
    if (Input.GetMouseButtonDown(1)){
        Debug.Log("Check!");
        if (!CameraSwitch.Instance.IsActiveCamera(firstPersonCam)){
            Debug.Log("Is Detail!");
            CameraSwitch.Instance.SwitchCamera(firstPersonCam);
        }
    }
}
}