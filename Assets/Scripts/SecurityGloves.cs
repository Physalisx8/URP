using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Von InteractableObject erben lassen
public class SecurityGloves : InteractableObject
{
    GameManager gameManager;
    GameObject leathergloves;
    GameObject leatherap;
    Animator animator;

     

    void Awake(){
        gameManager = FindObjectOfType<GameManager>();
        leathergloves = GameObject.Find("leathergloves");
    
        leatherap = GameObject.Find("Apron");
        animator = leatherap.GetComponent<Animator> ();

    }
    public override void OnClick()
    {
        base.OnClick(); // Immer den BUms hier ausführen
         leathergloves.SetActive(false);

         if (animator.GetCurrentAnimatorStateInfo(0).IsName("flying_apron")){
            leatherap.SetActive(false);
            NextSection();
         }
            
        }
        // Your code what happens on a click
   
    
    

public void NextSection(){

     if (gameManager != null)
        {
            if (!isInteractable){
                gameManager.IncreaseErrorCounter();
            }
       
            else{
                
              // leathergloves.SetActive(false);
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
