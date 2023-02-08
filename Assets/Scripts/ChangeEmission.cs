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
            GetComponent<Animator>().Play("idle");
    
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
                GetComponent<Animator>().SetTrigger("Interaction_2");
                gameManager.SetNextSection();
                GetComponent<BoxCollider>().enabled = false;
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
