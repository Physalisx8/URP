using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Von InteractableObject erben lassen
public class Forge : InteractableObject
{
    GameManager gameManager;
    Animator animator;
    GameObject door;
    [SerializeField] GameObject UI;

    [SerializeField] GameObject skript;
    TempBar tempBar;
    int count;


    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        door = GameObject.Find("Door");
        animator = door.GetComponent<Animator>();
        tempBar = skript.GetComponent<TempBar>();
    }

#region Additional Events
// Hier die Events hinzufügen und für alle subscriben/unsubscriben + Change Methode anlegen und befüllen
    [SerializeField] SectionEventSO OnHaerteTemperatur;
    //[SerializeField] SectionEventSO OnDings;

    public override void Enable()
    {
                // Alle event subscriben
        OnHaerteTemperatur.OnInvoke += OnHaerteTemperaturChange;
    //    OnDings.OnInvoke += OnDingsChange;
    }

        public override void Disable()
    {
                // Alle event unsubscriben
        OnHaerteTemperatur.OnInvoke -= OnHaerteTemperaturChange;
    //    OnDings.OnInvoke -= OnDingsChange;
    }

    void OnHaerteTemperaturChange(SectionState state){
        switch (state){
            case SectionState.Start:
            // Section Resetten
            Reset();
            break;
            case SectionState.End:
            OnDemo();
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
            OnClick();
            break;
            case SectionState.End:
                OnClick();
            break;
        }
    }

    void Reset(){
        if (debug)
            Debug.Log("Reset");
            UI.SetActive(false);
            StopAllCoroutines();
            tempBar.Reset();
    }

        public void OnDemo()
    {
                count += 1;
                Debug.Log("print count " + count);
                
                animator.SetTrigger("OpenDoor");
                gameManager.SetNextSection();
            

                if ((count%2)==0 && count != 0)
                {
                    Debug.Log(" count = " + count + " this section should be UI ploppy");
                    UI.SetActive(true);
                    StartCoroutine(wait());
                    tempBar.OnDemo(true);
                   

                }

            
        }
       
        

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
                count += 1;
                Debug.Log("print count " + count);
                
                animator.SetTrigger("OpenDoor");
                gameManager.SetNextSection();
            

                if ((count%2)==0 && count != 0)
                {
                    Debug.Log(" count = " + count + " this section should be UI ploppy");
                    UI.SetActive(true);
                    StartCoroutine(wait());

                }

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
