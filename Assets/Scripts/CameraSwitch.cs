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

    void SetTriggers(){
        // Instance.cameraTriggers.SetActive(IsActiveCamera(mainCam));
        // (De)activates all triggers depending on active camera
    }

    public bool IsActiveCamera(CinemachineVirtualCamera camera) => Instance.ActiveCamera.Equals(camera);
    public void SwitchCamera(CinemachineVirtualCamera camera)
    {
        SetActiveCam(camera);

        foreach (CinemachineVirtualCamera c in Instance.cameras)
            if (c != ActiveCamera)
                c.Priority = 0;

        SetTriggers();

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
