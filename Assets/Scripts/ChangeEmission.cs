using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Von InteractableObject erben lassen
public class ChangeEmission : InteractableObject
{

    [SerializeField] Material lampMaterial;
    public void LampOn (){
       
        lampMaterial.EnableKeyword("_EMISSION");
         lampMaterial.SetColor("_EmissionColor", new Color32(255,251,220, 200));
    }

    public void LampOff(){
       lampMaterial.DisableKeyword("_EMISSION");
    
      
    }

}
