using UnityEngine;

// Von InteractableObject erben lassen
public class ExampleDoor1 : InteractableObject
{
    GameManager gameManager;

    void Awake(){
        gameManager = FindObjectOfType<GameManager>();
        transform.position = Vector3.down *100;
    }

  //ONTuerSchließen danach OnAnschalten -> TurningRed danach -> OnTemperatur -> OnWarte (TurningRed) -> OnTürÖffnen ()

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
            GameObject.Find("DoorNew").GetComponent<Animator>().SetTrigger("Interact");
           
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
                gameManager.SetNextSection();
                transform.position= Vector3.down*100;
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
