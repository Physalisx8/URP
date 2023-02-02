using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class InteractableObject : MonoBehaviour
{
    public bool debug;
    public UnityEvent OnHoverStart;
    public UnityEvent OnHoverStop;

    public UnityEvent OnClickStart;
    public UnityEvent OnInactiveClick;
    public bool isHovering; // is there currentkly a hover?

    public bool isInteractable; // dont change here please

        [Header("Listening to ...")]
    public BoolEventSO OnSectionChange;

    void OnEnable(){
        if (OnSectionChange != null){
            OnSectionChange.OnInvoke += SectionChange;
            if (debug)
            Debug.Log("Subsrcibed! " + name);
        }
    }
    
    void OnDisable(){
        if (OnSectionChange != null){
            OnSectionChange.OnInvoke -= SectionChange;
            if (debug)
                Debug.Log("Unsubscribed! " + name);
        }
    }

    public virtual void SectionChange(bool isActive){
        if (debug){
            Debug.Log("Section Change " + isActive);
        }
        // Do stuff
    }

    public void SetInteractable(bool interactable)
    {
        isInteractable = interactable;
    }

    // Triggered when Object is clicked
    public virtual void OnClick() { 
        if (isInteractable)
            OnClickStart.Invoke();
        else
            OnInactiveClick.Invoke();
        }

    #region Hover
    // Just filter for hovering actions
    public void OnHover(bool isHovering)
    {
        // State didnt Change
        if (this.isHovering == isHovering)
            return;

        this.isHovering = isHovering;
        if (isHovering)
            HoverStart();
        else
            HoverStop();
    }

// Override in Subclass, triggered when hover starts
    public virtual void HoverStart() { OnHoverStart.Invoke(); }

// Override in Subclass, triggered when hover stops
    public virtual void HoverStop() { OnHoverStop.Invoke(); }
    #endregion
}
