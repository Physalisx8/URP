using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Von InteractableObject erben lassen
public class TempReg : InteractableObject
{
 GameManager gameManager;

[SerializeField] bool adjustable;
[SerializeField] TextMeshPro text;
[SerializeField] GameObject Obj;
 private int increasing = 0;
 private string stringy; 



      void Awake(){
        gameManager = FindObjectOfType<GameManager>();
        
    }
    public override void OnClick()

    {
        base.OnClick();
        adjustable = true;
       
             if (gameManager != null)
         {
             if (!isInteractable){
                 gameManager.IncreaseErrorCounter();
             }
             else{
                 gameManager.SetNextSection();
             }
         } else {
             Debug.Log("gameManager = null");
         }
     }

     public void Update(){
        if (adjustable == true){
            changeTemperature();
            if (Input.GetMouseButtonDown(1)){
                StopInc();
            }
        }
   
     }


public void changeTemperature(){
    
    
   // Debug.Log("DAKJSLÖDJSALKJDALKSJDLKAJDLKWAJDWJLKWAJDÖLWAJöd");
      
      if (Input.GetAxis("Mouse ScrollWheel") >0 && increasing >=0 && increasing <750) {
         Obj.transform.Rotate(Vector3.back * 10f, Space.Self);
  
        increasing +=10;
        text.SetText(increasing + "°");
        

  
}
if (Input.GetAxis("Mouse ScrollWheel") < 0 && increasing >0 && increasing<=750) {
      Obj.transform.Rotate(Vector3.forward * 10f, Space.Self);
    
        increasing -=10;
        text.SetText(increasing + "°");
    
  
  
}

}

public void StopInc(){
    adjustable= false;
    Debug.Log("nopedidy");
}
}
