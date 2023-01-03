using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Von InteractableObject erben lassen
public class ExampleDoor : InteractableObject
{
    public override void OnClick()
    {
        // Your code what happens on a click
        base.OnClick(); // Immer den BUms hier ausführen danach
        
    }

    public override void HoverStart()
    {
        // Your Code
        base.HoverStart();
    }

        public override void HoverStop()
    {
        // Your Code
        base.HoverStop();
    }
}
