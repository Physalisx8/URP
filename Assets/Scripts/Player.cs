using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera firstPersonCam;
    [SerializeField] CinemachineVirtualCamera detailTempCam;
    [SerializeField] GameObject ZoomOut;
    
    void Awake(){
                CameraSwitch.Instance.SetMainCam(firstPersonCam);
                CameraSwitch.Instance.Register(firstPersonCam);
                CameraSwitch.Instance.SwitchCamera(firstPersonCam);
            }
private void Update(){
      if (!CameraSwitch.Instance.IsActiveCamera(firstPersonCam)){
            ZoomOut.SetActive(true);
        if(CameraSwitch.Instance.IsActiveCamera(detailTempCam)){
            ZoomOut.SetActive(false);
        }
        }
       
    if (Input.GetMouseButtonDown(1)){
        ZoomOut.SetActive(false);
        Debug.Log("Check!");
        if (!CameraSwitch.Instance.IsActiveCamera(firstPersonCam)){
            Debug.Log("Is Detail!");
            CameraSwitch.Instance.SwitchCamera(firstPersonCam);

        }
    }
}
}