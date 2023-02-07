using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField] bool debug;
    [SerializeField] CinemachineVirtualCamera firstPersonCam;
    [SerializeField] CinemachineVirtualCamera detailTempCam;
    [SerializeField] GameObject ZoomOut;
    [SerializeField] GameObject CameraTriggers;

    void Awake()
    {
        if(!CameraTriggers.activeInHierarchy) { CameraTriggers.SetActive(true); }

        CameraSwitch.Instance.SetMainCam(firstPersonCam);
        CameraSwitch.Instance.Register(firstPersonCam);
        CameraSwitch.Instance.SwitchCamera(firstPersonCam);
    }
    private void Update()
    {
        if (!CameraSwitch.Instance.IsActiveCamera(firstPersonCam))
        {
            ZoomOut.SetActive(true);
            if (CameraSwitch.Instance.IsActiveCamera(detailTempCam))
            {
                ZoomOut.SetActive(false);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            ZoomOut.SetActive(false);
            if (debug)
                 Debug.Log("Check!");
            if (!CameraSwitch.Instance.IsActiveCamera(firstPersonCam))
            {
                if (debug)
                    Debug.Log("Is Detail!");
                CameraSwitch.Instance.SwitchCamera(firstPersonCam);

            }
        }
    }
}