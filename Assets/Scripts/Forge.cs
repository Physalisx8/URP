using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Von InteractableObject erben lassen
public class Forge : InteractableObject
{
    GameManager gameManager;
    Animator animator;
    GameObject door;


  
    TempBar tempBar;
    int count;

    


    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        door = GameObject.Find("Door");
        animator = door.GetComponent<Animator>();
       
    }
/*
#region Additional Events
// Hier die Events hinzufügen und für alle subscriben/unsubscriben + Change Methode anlegen und befüllen
    [SerializeField] SectionEventSO OnHaerteTemperatur;
    [SerializeField] SectionEventSO OnSchliesseForge;

    public override void Enable()
    {
                // Alle event subscriben
        OnHaerteTemperatur.OnInvoke += OnHaerteTemperaturChange;
       OnSchliesseForge.OnInvoke += OnSchliesseForgeChange;
    }

        public override void Disable()
    {
                // Alle event unsubscriben
        OnHaerteTemperatur.OnInvoke -= OnHaerteTemperaturChange;
       OnSchliesseForge.OnInvoke -= OnSchliesseForgeChange;
    }

//OnHaerteTemperatur - wenn das Messer glüht und die Tür sich öffnet 
    void OnHaerteTemperaturChange(SectionState state){
        switch (state){
            case SectionState.Start:
            // Section Resetten
            ResetUI();
            UI.alpha = 1f;
            break;
            case SectionState.End:
            OnClick();
            // OnClick auslösen
            break;
        }
    }
        void OnSchliesseForgeChange(SectionState state){
        switch (state){
            case SectionState.Start:
            // Section Resetten
           
            UI.alpha = 0f;
            break;
            case SectionState.End:
            //animator.Play("ForgeDoor_close");
            OnClick();
            // OnClick auslösen
            break;
        }
    }



    #endregion
*/
//OnEsse-
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
            GameObject.Find("Door").GetComponent<BoxCollider>().enabled = true;
           animator.Play("idle");
            
    }
/*
    void ResetUI(){
        if (debug)
            Debug.Log("Reset");
           
            //UI.SetActive(false);
            //StopAllCoroutines();
            Debug.Log("I try to cancel you!");
            tempBar.Reset();
            //tempBar.OnDemo(false);
            animator.Play("ForgeDoor_close");
      
           
    }

       
    public void UIPlay(){
        Debug.Log("I'm trying to do my Job ffs");
                    UI.alpha = 1f;
                    StartCoroutine(wait());
                   // StopCoroutine(wait());
                    tempBar.OnDemo(true);
  
                }*/
    

    public override void OnClick()
    {
        base.OnClick(); // Immer den BUms hier ausführen

        // Your code what happens on a click
        if (gameManager != null) 
        {
            if (!isInteractable)
            {
                gameManager.IncreaseErrorCounter();
            }
            else
            {
                GameObject.Find("Door").GetComponent<BoxCollider>().enabled = false;
                animator.SetTrigger("OpenDoor");
               // empties.transform.position = new Vector3(1.51f,2.34f,7.24f);
                gameManager.SetNextSection();
            
/*
                if ((count%2)==0 && count != 0)
                {
                   // Debug.Log(" count = " + count + " this section should be UI ploppy");
                    UI.alpha = 1f;
                    door.GetComponent<BoxCollider>().enabled = false;
                    
                    StartCoroutine(wait());

                }*/

            }
        }
        else
        {
            Debug.Log("gameManager = null");
        }
    }

    public IEnumerator wait()
    {

        yield return new WaitForSeconds(2);
       
        tempBar.TemperatureRise();
        
          //gameManager.SetNextSection();

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
