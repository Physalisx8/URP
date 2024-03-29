using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Von InteractableObject erben lassen
public class Tongs : InteractableObject
{

    public Transform player, tongsContainer;

    public float pickUpRange;

    public bool equipped;

    // Anfangsposition der Zange
    private Vector3 initialPos;
    private Quaternion initalRot;

    GameManager gameManager;

        Vector3 startPos;
        Quaternion startRot;
     

    void Awake(){
        gameManager = FindObjectOfType<GameManager>();
        startPos = transform.position;
        startRot = transform.rotation;
    }

        public override void SectionChange(SectionState state)
    {
        base.SectionChange(state);

        switch (state){
            case SectionState.Start:
            if (debug)
                Debug.Log("START");
            Drop();
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

    private void Start()
    {
        initialPos = transform.localPosition;
        initalRot = transform.localRotation;
        // initiale Position speichern

    }
    public override void OnClick()
    {


        base.OnClick(); // Immer den BUms hier ausführen
        Vector3 distanceToPlayer = player.position - transform.position;
        if (gameManager != null)
        {
            if (!isInteractable)
            {
                gameManager.IncreaseErrorCounter();
            }
            else
            {
               
                //wenn das GameObject getroffen wird und die Zange nicht equipped ist und Player nah genug dran (kann also nicht vom start bedient werden)
                if (!equipped && distanceToPlayer.magnitude <= pickUpRange)
                {
                    PickUp();
                    gameManager.SetNextSection();
                }


            }
        }
        else
        {
            Debug.Log("gameManager = null");
        }


        // Your code what happens on a click







    }

    private void Update()
    {
        //Zange zurück legen, wenn space gedrückt wird
        //  if (equipped && Input.GetKeyDown(KeyCode.Space)) Drop();
    }
    private void PickUp()
    {
        equipped = true;

        //Tongs wird ein Kind von dem Container und wir setzen ihn an die richtige Stelle
        transform.SetParent(tongsContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

    }

    private void Drop()
    {
        equipped = false;

        //Wieder vom tongsContainer entfernen
        transform.SetParent(null);

        //An die Ausgangsposition setzen
        transform.localPosition = initialPos;
        transform.localRotation = initalRot;
    }

    public override void HoverStart()
    {
        // Your Code
        base.HoverStart();
        if (equipped == true)
        {
            HoverStop();
        }


    }

    public override void HoverStop()
    {
        // Your Code
        base.HoverStop();

    }
}
