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
        base.OnClick(); 
         if (gameManager != null)
        {
            if (!isInteractable){
                gameManager.IncreaseErrorCounter();
            }
       
            else{
            //yeeted die Handschuhe ins nirvana
            transform.position = Vector3.down * 100;
            gameManager.SetNextSection();
            }
        } else {
            Debug.Log("gameManager = null");
        }}

        

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
