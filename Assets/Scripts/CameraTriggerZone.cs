using Cinemachine;
using UnityEngine;

public class CameraTriggerZone : InteractableObject
{
    [SerializeField] CinemachineVirtualCamera cam;
    
    public override void OnClick()
    {
        CameraSwitch.Instance.SwitchCamera(cam);
        base.OnClick();
    }

    public override void HoverStart()
    {
        base.HoverStart();
    }

        public override void HoverStop()
    {
        base.HoverStop();
    }
}
