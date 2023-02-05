using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Von InteractableObject erben lassen
public class SecurityGloves : InteractableObject
{
    GameManager gameManager;
    GameObject leathergloves;
   /*
    GameObject leatherap;
    Animator animator;
*/
Vector3 startPos;
     

    void Awake(){
        gameManager = FindObjectOfType<GameManager>();
        leathergloves = GameObject.Find("leathergloves");

        startPos = transform.position;
    
       // leatherap = GameObject.Find("Apron");
       // animator = leatherap.GetComponent<Animator> ();

    }

            public override void SectionChange(SectionState state)
    {
        base.SectionChange(state);

        switch (state){
            case SectionState.Start:
            if (debug)
                Debug.Log("Start");
            Reset();
            break;
            case SectionState.End:
                OnClick();
            break;
        }
    }

        void Reset(){
        if (debug)
            Debug.Log("Reset");
        transform.SetParent(null);
        transform.position = startPos;
    }

    public override void OnClick()
    {
        base.OnClick(); // Immer den BUms hier ausführen
         if (gameManager != null)
        {
            if (!isInteractable){
                gameManager.IncreaseErrorCounter();
            }
       
            else{
            //leathergloves.SetActive(false);
            transform.position = Vector3.down * 100;

           /* if (animator.GetCurrentAnimatorStateInfo(0).IsName("flying_apron")){
            leatherap.SetActive(false);*/
                gameManager.SetNextSection();
            }
        } else {
            Debug.Log("gameManager = null");
        }}

        
 
   
    
    /*

public void NextSection(){
                gameManager.SetNextSection();
    
}
*/

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
