using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera firstPersonCam;
    [SerializeField] CinemachineVirtualCamera ForgeCam;
    [SerializeField] CinemachineVirtualCamera TongsCam;
    [SerializeField] CinemachineVirtualCamera TemperCam;
    
    private void OnEnable(){
        CameraSwitch.Register(firstPersonCam);
        CameraSwitch.Register(ForgeCam);
        //CameraSwitch.Register(TongsCam);
        //CameraSwitch.Register(TemperCam);
        
    }

    private void OnDisable(){
        CameraSwitch.Unregister(firstPersonCam);
        CameraSwitch.Unregister(ForgeCam);
        //CameraSwitch.Unregister(TongsCam);
        //CameraSwitch.Unregister(TemperCam);
        
    }

private void Update(){
    if (Input.GetMouseButtonDown(1)){
        //switch camera
        if(CameraSwitch.IsActiveCamera(firstPersonCam)){
            Debug.Log("TouchedHomeBase");
            CameraSwitch.SwitchCamera(ForgeCam);

        }
        else if(CameraSwitch.IsActiveCamera(ForgeCam)){
            CameraSwitch.SwitchCamera(firstPersonCam);
        }
}
}
}