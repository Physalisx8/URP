using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Von InteractableObject erben lassen
public class ChangeEmission1 : InteractableObject
{
       GameManager gameManager;

    [SerializeField] Material lampMaterial;
    [SerializeField] GameObject Obj;
    [SerializeField] GameObject empties;

        void Awake(){
        gameManager = FindObjectOfType<GameManager>();
        transform.position = Vector3.down*100;
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
            GameObject.Find("TurningRed").GetComponent<Animator>().Play("idle");
    
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
                GameObject.Find("TurningRed").GetComponent<Animator>().SetTrigger("Interaction_2");
                empties.transform.position = new Vector3(-1.03f,1.97f,3.47f);
                gameManager.SetNextSection();
                transform.position = Vector3.down *100;

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
