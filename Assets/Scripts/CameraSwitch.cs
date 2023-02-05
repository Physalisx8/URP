using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : Singleton<CameraSwitch>
{
    [SerializeField] bool debug;
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
        if (debug)
            Debug.Log("SWITCH CAMERA: " + camera.name);
        SetActiveCam(camera);

        foreach (CinemachineVirtualCamera c in Instance.cameras)
            if (c != ActiveCamera)
                c.Priority = 0;

        // Set Camera Triggers active when main cam is active, otherwise deactivate
        bool triggerState = camera.Equals(Instance.mainCam);
        cameraTriggers.SetActive(triggerState);	

        if (debug)
            Debug.Log("Active Camera: " + ActiveCamera.name);

    }

    void SetActiveCam(CinemachineVirtualCamera camera){
        Instance.ActiveCamera = camera;
        Instance.ActiveCamera.Priority = 1;
        

    }

    public void Register(CinemachineVirtualCamera camera)
    {
        if (Instance.cameras.Contains(camera))
            return;

        Instance.cameras.Add(camera);
        if (Instance.ActiveCamera == null)
            Instance.SwitchCamera(camera);
    }

    public void Unregister(CinemachineVirtualCamera camera)
    {
        if (!Instance.cameras.Contains(camera))
            return;

        Instance.cameras.Remove(camera);
    }
}
