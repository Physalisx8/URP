using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeContainer : InteractableObject
{
    // Start is called before the first frame update

    GameManager gameManager;
    [SerializeField] GameObject knife;
    private GameObject knifeContainer;

    private string oldParent = null;
    private Vector3 oldPosition;
    private Vector3 oldRotation;
        

      Vector3 startPos;
    Quaternion startRot;

        void Awake(){
        gameManager = FindObjectOfType<GameManager>();
        knifeContainer = GameObject.Find("knifeContainer");
        startPos = transform.position;
        startRot = transform.rotation;

    }
    
#region Additional Events
// Hier die Events hinzufügen und für alle subscriben/unsubscriben + Change Methode anlegen und befüllen
    [SerializeField] SectionEventSO OnEsseII;
    //[SerializeField] SectionEventSO OnDings;

    public override void Enable()
    {
                // Alle event subscriben
        OnEsseII.OnInvoke += OnEsseIIChange;
    //    OnDings.OnInvoke += OnDingsChange;
    }

        public override void Disable()
    {
                // Alle event unsubscriben
        OnEsseII.OnInvoke -= OnEsseIIChange;
    //    OnDings.OnInvoke -= OnDingsChange;
    }

    void OnEsseIIChange(SectionState state){
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
        transform.SetParent(null);
        transform.position = startPos;
        transform.rotation = startRot;
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
                
                if (oldParent != null)
                {
                    knife.transform.parent = GameObject.Find(oldParent).transform;
                    knife.GetComponent<Knife>().MoveKnife(oldPosition, oldRotation);
                    //knife.transform.localPosition = oldPosition;
                    //knife.transform.eulerAngles = oldRotation;
                    GameObject.Find("Door").GetComponent<Animator>().Play("ForgeDoor_close");
                    gameManager.SetNextSection();
                }
                else
                {
                    saveOldValues();

                    knife.transform.parent = transform;
                    Vector3 rotation = knife.transform.localEulerAngles;
                    knife.GetComponent<Knife>().MoveKnife(new Vector3(0, -0.48f, 0), new Vector3(90, rotation.y, rotation.z));

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
