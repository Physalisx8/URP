using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Von InteractableObject erben lassen
public class ChangeEmission : InteractableObject
{
       GameManager gameManager;

    [SerializeField] Material lampMaterial;
    [SerializeField] GameObject Obj;

        void Awake(){
        gameManager = FindObjectOfType<GameManager>();
    }

#region Additional Events
// Hier die Events hinzufügen und für alle subscriben/unsubscriben + Change Methode anlegen und befüllen
    [SerializeField] SectionEventSO OnWarte;
    //[SerializeField] SectionEventSO OnDings;

    public override void Enable()
    {
                // Alle event subscriben
        OnWarte.OnInvoke += OnWarteChange;
    //    OnDings.OnInvoke += OnDingsChange;
    }

        public override void Disable()
    {
                // Alle event unsubscriben
        OnWarte.OnInvoke -= OnWarteChange;
    //    OnDings.OnInvoke -= OnDingsChange;
    }

    void OnWarteChange(SectionState state){
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
        base.OnClick();

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
    public void LampOn (){
        
       
        lampMaterial.EnableKeyword("_EMISSION");
         lampMaterial.SetColor("_EmissionColor", new Color32(255,251,220, 200));
         Obj.SetActive(true);
    }

    public void LampOff(){
       lampMaterial.DisableKeyword("_EMISSION");
       Obj.SetActive(false);
      
    }

}
