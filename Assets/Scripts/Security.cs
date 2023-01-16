using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Von InteractableObject erben lassen
public class Security : InteractableObject
{
    GameManager gameManager;
    GameObject leathergloves;
    GameObject leatherap;
     

    void Awake(){
        gameManager = FindObjectOfType<GameManager>();
        leathergloves = GameObject.Find("leathergloves");
        leatherap = GameObject.Find("Apron");

    }
    public override void OnClick()
    {
        base.OnClick(); // Immer den BUms hier ausführen

        // Your code what happens on a click
        if (gameManager != null)
        {
            if (!isInteractable){
                gameManager.IncreaseErrorCounter();
            }
       
            else{
                
              //  leathergloves.SetActive(false);
              //  leatherap.SetActive(false);
                gameManager.SetNextSection();
            }
        } else {
            Debug.Log("gameManager = null");
        }
        
        
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
