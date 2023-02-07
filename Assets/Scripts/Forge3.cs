using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Von InteractableObject erben lassen
public class Forge3 : InteractableObject
{
    GameManager gameManager;
    Animator animator;
    GameObject door;
    TempBar tempBar;

    [SerializeField] CanvasGroup UI;

    [SerializeField] GameObject skript;

    [SerializeField] GameObject empties;
  

    


    void Awake()
    {
        transform.position = Vector3.down*100;
        gameManager = FindObjectOfType<GameManager>();
        door = GameObject.Find("Door");
        animator = door.GetComponent<Animator>();
        //tempBar = skript.GetComponent<TempBar>();
    }

//OnHärteTemp
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
           //animator.Play("ForgeDoor_close");
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
               

                empties.transform.position = new Vector3(1.51f,2.34f,7.24f);
                transform.position = Vector3.down *100;
                gameManager.SetNextSection();

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
