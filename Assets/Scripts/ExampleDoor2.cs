using UnityEngine;

// Von InteractableObject erben lassen
public class ExampleDoor2 : InteractableObject
{
    GameManager gameManager;

    void Awake(){
        gameManager = FindObjectOfType<GameManager>();
        transform.position = Vector3.down *100;
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
            GameObject.Find("DoorNew").GetComponent<Animator>().Play("idle");
           
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
               
            GameObject.Find("DoorNew").GetComponent<Animator>().SetTrigger("Interact");
               
            transform.position = Vector3.down *100;
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
