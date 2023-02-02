using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeContainer : InteractableObject
{
    // Start is called before the first frame update
  
    GameManager gameManager;
    [SerializeField] GameObject messer;
    [SerializeField] GameObject selfie;

    void Awake(){
        gameManager = FindObjectOfType<GameManager>();
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
                messer.transform.parent = selfie.transform;
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
