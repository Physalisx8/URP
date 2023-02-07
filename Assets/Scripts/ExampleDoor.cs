using UnityEngine;

// Von InteractableObject erben lassen
public class ExampleDoor : InteractableObject
{
    GameManager gameManager;

    void Awake(){
        gameManager = FindObjectOfType<GameManager>();
    }

    
#region Additional Events
// Hier die Events hinzufügen und für alle subscriben/unsubscriben + Change Methode anlegen und befüllen
    [SerializeField] SectionEventSO OnTuerSchliessen;
    [SerializeField] SectionEventSO OnDings;

    public override void Enable()
    {
                // Alle event subscriben
        OnTuerSchliessen.OnInvoke += OnTuerSchliessenChange;
       OnDings.OnInvoke += OnDingsChange;
    }

        public override void Disable()
    {
                // Alle event unsubscriben
        OnTuerSchliessen.OnInvoke -= OnTuerSchliessenChange;
       OnDings.OnInvoke -= OnDingsChange;
    }

    void OnTuerSchliessenChange(SectionState state){
        switch (state){
            case SectionState.Start:
            // Section Resetten
            Reset();
            break;
            case SectionState.End:
            OnClick();
            // OnClick auslösen
            break;
        }
    }
      void OnDingsChange(SectionState state){
        switch (state){
            case SectionState.Start:
            // Section Resetten
            Reset();
            break;
            case SectionState.End:
            OnClick();
            // OnClick auslösen
            break;
        }
    }


    #endregion

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
