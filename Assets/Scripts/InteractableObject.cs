using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class InteractableObject : MonoBehaviour
{
    public UnityEvent OnHoverStart;
    public UnityEvent OnHoverStop;

    public UnityEvent OnClickStart;
    public bool isHovering; // is there currentkly a hover?

    // Triggered when Object is clicked
    public virtual void OnClick() { OnClickStart.Invoke();}

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
