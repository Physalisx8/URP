using System.Collections;
using UnityEngine;

// Von InteractableObject erben lassen
public class Forge2 : InteractableObject
{
    GameManager gameManager;
    Animator animator;
    GameObject door;
   [SerializeField] GameObject empties;
       [SerializeField] CanvasGroup UI;

    [SerializeField] GameObject skript;
    TempBar tempBar;
  

    


    void Awake()
    {
        transform.position = Vector3.down*100;
        gameManager = FindObjectOfType<GameManager>();
        door = GameObject.Find("Door");
        animator = door.GetComponent<Animator>();
        tempBar = skript.GetComponent<TempBar>();
    }

    //OnSchließeForge
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
                tempBar.OnDemo(true);
                OnClick();
            break;
        }
    }

      void Reset(){
        if (debug)
            Debug.Log("Reset");
            //animator.Play("openidle");
            tempBar.Reset();
            //StartCoroutine(wait());
            UI.alpha = 1f;
            //animator.SetTrigger("CloseDoor");
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
               // gameManager.IncreaseErrorCounter();
            }
            else
            {
                animator.SetTrigger("CloseDoor");
                gameManager.SetNextSection();
                UI.alpha = 1f;
                StartCoroutine(wait());
                empties.transform.position = new Vector3(1.51f,2.34f,7.24f);
                transform.position = Vector3.down *100;
                
                
        

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

