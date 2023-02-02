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

    public override void SectionChange(bool isActive){
        if (isActive){
            // Wenn Section aktiviert wird
        }else{
            // Wenn section deaktiviert wird
            OnClick();
        }
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
