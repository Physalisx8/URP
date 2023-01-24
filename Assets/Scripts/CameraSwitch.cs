using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : Singleton<CameraSwitch>
{
    public CinemachineVirtualCamera mainCam;
    [SerializeField] List<CinemachineVirtualCamera> cameras = new List<CinemachineVirtualCamera>();

    [SerializeField] GameObject cameraTriggers;

    public CinemachineVirtualCamera ActiveCamera = null;

    public void RegisterTriggers(GameObject obj){
        Instance.cameraTriggers = obj;
    }

    public void SetMainCam(CinemachineVirtualCamera camera){
        Instance.mainCam = camera;
    }

    public bool IsActiveCamera(CinemachineVirtualCamera camera) => Instance.ActiveCamera.Equals(camera);

    
    public void SwitchCamera(CinemachineVirtualCamera camera)
    {
        SetActiveCam(camera);

        foreach (CinemachineVirtualCamera c in Instance.cameras)
            if (c != ActiveCamera)
                c.Priority = 0;

        // Set Camera Triggers active when main cam is active, otherwise deactivate
        bool triggerState = camera.Equals(Instance.mainCam);
        Debug.Log(Instance.mainCam.name);
        cameraTriggers.SetActive(triggerState);	

    }

    void SetActiveCam(CinemachineVirtualCamera camera){
        Instance.ActiveCamera = camera;
        Instance.ActiveCamera.Priority = 1;
        Debug.Log(ActiveCamera.name);
    }

    public void Register(CinemachineVirtualCamera camera)
    {
        if (Instance.cameras.Contains(camera))
            return;

        Instance.cameras.Add(camera);
        Debug.Log("Camera registered: " + camera);
        if (Instance.ActiveCamera == null)
            Instance.SwitchCamera(camera);
    }

    public void Unregister(CinemachineVirtualCamera camera)
    {
        if (!Instance.cameras.Contains(camera))
            return;

        Instance.cameras.Remove(camera);
        Debug.Log("Camera unregistered: " + camera);
    }
}
