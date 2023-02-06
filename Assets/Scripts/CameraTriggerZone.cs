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

    public override void SectionChange(SectionState state){
        
        switch (state){
            case SectionState.Start:
            break;
            case SectionState.End:
                OnClick();
            break;
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
