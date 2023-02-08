using UnityEngine;

// Von InteractableObject erben lassen
public class ExampleDoor : InteractableObject
{
    GameManager gameManager;

    void Awake(){
        gameManager = FindObjectOfType<GameManager>();
    }

 
    public override void SectionChange(SectionState state)
    {
        base.SectionChange(state);

        switch (state){
            case SectionState.Start:
            if (debug)
                Debug.Log("START");
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
          
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<Animator>().SetTrigger("Interact");
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
               GetComponent<Animator>().SetTrigger("Interact");
                GetComponent<BoxCollider>().enabled = false;
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
