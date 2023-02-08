using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeContainer1 : InteractableObject
{
    // Start is called before the first frame update

    GameManager gameManager;
    [SerializeField] GameObject knife;
    GameObject knifeContainer;
    // [SerializeField] GameObject empties;

    private string oldParent = null;
    private Vector3 oldPosition;
    private Vector3 oldRotation;



#region Additional Events
// Hier die Events hinzufügen und für alle subscriben/unsubscriben + Change Methode anlegen und befüllen
    [SerializeField] SectionEventSO OnAbschrecken;
        public override void Enable()
    {
                // Alle event subscriben
        OnAbschrecken.OnInvoke += OnAbschreckenChange;
      
    }

        public override void Disable()
    {
                // Alle event unsubscriben
        OnAbschrecken.OnInvoke -= OnAbschreckenChange;
    }

//OnHaerteTemperatur - wenn das Messer glüht und die Tür sich öffnet 
    void OnAbschreckenChange(SectionState state){
        switch (state){
            case SectionState.Start:
            // Section Resetten
         Reset2();
            break;
            case SectionState.End:
            OnClick();
            // OnClick auslösen
            break;
        }
    }


    #endregion

    void Reset2(){
        Debug.Log(knifeContainer.transform.parent + "first ");
        knife.transform.parent=knifeContainer.transform;
        knife.GetComponent<Knife>().MoveKnife(Vector3.zero, oldRotation);
        Debug.Log(knifeContainer.transform.parent + "second first");
    }
    void Awake()
    {
       // transform.position = Vector3.down *100;
        gameManager = FindObjectOfType<GameManager>();
        knifeContainer = GameObject.Find("knifeContainer");
  
    }


    public override void SectionChange(SectionState state)
    {
        base.SectionChange(state);

        switch (state)
        {
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

    void Reset()
    {
        if (debug)
            Debug.Log("Reset");
        knife.transform.parent = knifeContainer.transform;
        Debug.Log("knifetransform "+ knife.transform.parent);
        knife.GetComponent<Knife>().MoveKnife(Vector3.zero,Vector3.zero);
        Debug.Log("oldParent" + oldParent);
        oldParent = null;

   
    }
    public override void OnClick()
    {
        base.OnClick(); // Immer den BUms hier ausführen

        // Your code what happens on a click
        if (gameManager != null)
        {
            if (!isInteractable)
            {
                //gameManager.IncreaseErrorCounter();
            }
            else
            {

                if (oldParent != null)
                {
                    knife.transform.parent = GameObject.Find(oldParent).transform;
                    knife.GetComponent<Knife>().MoveKnife(Vector3.zero, oldRotation);
                   // empties.transform.position = new Vector3(1.6f,3.16f,7.45f);
                    //knife.transform.localPosition = oldPosition;
                    //knife.transform.eulerAngles = oldRotation;
                    //GameObject.Find("Door").GetComponent<Animator>().Play("ForgeDoor_close");
                    
                    //transform.position = Vector3.down*100;
                    gameManager.SetNextSection();
            
                }
                else
                {
                    saveOldValues();

                    knife.transform.parent = transform;
                    Vector3 rotation = knife.transform.localEulerAngles;
                    knife.GetComponent<Knife>().MoveKnife(new Vector3(0, -0.75f, 0.5f), new Vector3(90, rotation.y, -246));
                   // empties.transform.position = new Vector3(1.6f,3.16f,7.45f);
                   // transform.position = Vector3.down*100;
                    //knife.transform.localPosition = new Vector3(0, -0.48f, 0);
                    //Vector3 rotation = knife.transform.eulerAngles;
                    //knife.transform.eulerAngles = new Vector3(90, rotation.y, rotation.z);
                    gameManager.SetNextSection();
                }
            }
        }
        else
        {
            Debug.Log("gameManager = null");
        }


    }

    private void saveOldValues()
    {
        oldParent = knife.transform.parent.name;
        oldPosition = knife.transform.localPosition;
        oldRotation = knife.transform.localEulerAngles;
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
