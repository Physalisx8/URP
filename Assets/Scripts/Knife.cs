using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Colors
/*
#352201
#542803
#681100
#861600
#a00000
#c11b1b
#d44115
#e9582c
#e97e1c
#ffaa0f
#fbc034
#ffcf61
#ffe6ad
*/
#endregion

// Von InteractableObject erben lassen
public class Knife : InteractableObject
{
    public Transform player, tongsContainer;

    public float pickUpRange;
    public bool equipped;
    GameManager gameManager;
    private Vector3 initialPos;
    private Quaternion initalRot;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        initialPos = transform.localPosition;

        initalRot = transform.localRotation;
        // initiale Position speichern

    }

    public override void SectionChange(bool isActive)
    {
        base.SectionChange(isActive);
        if (isActive)
        {
            // Wenn Event(Section) auf aktiv gesetzt wird.
        }
        else
        {
            // Wenn Event inaktiv wird. Brauchen wir aber eigentlich nicht
            PickUp();
        }
    }


    public override void OnClick()
    {
        base.OnClick(); // Immer den BUms hier ausführen
        Debug.Log("Knife Click");
        Vector3 distanceToPlayer = player.position - transform.position;
        // Your code what happens on a click

        if (gameManager != null)
        {
            if (!isInteractable)
            {
                gameManager.IncreaseErrorCounter();
            }
            else
            {
                gameManager.SetNextSection();
                if (!equipped && distanceToPlayer.magnitude <= pickUpRange)
                {
                    PickUp();
                }

            }
        }
        else
        {
            Debug.Log("gameManager = null");
        }


    }

    private void PickUp()
    {
        equipped = true;

        transform.SetParent(tongsContainer);

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        //transform.scale = Vector3.one;


    }

    private void Drop()
    {
        equipped = false;

        //Wieder vom tongsContainer entfernen
        transform.SetParent(null);
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
