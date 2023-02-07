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
    public Transform player, knifeContainer;

    public float pickUpRange;
    public bool equipped;
    GameManager gameManager;
    private Vector3 initialPos;
    private Quaternion initalRot;

    Vector3 startPos;
    Quaternion startRot;

    private bool moveToParent;
    private Vector3 position = Vector3.zero;
    private Vector3 angles = Vector3.zero;

    [SerializeField] private float speed;

    //public bool move => moveToParent;
    //public Vector3 rotateToEulerangles => angles;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        startPos = transform.position;
        startRot = transform.rotation;

    }

    public override void SectionChange(SectionState state)
    {
        base.SectionChange(state);

        switch (state)
        {
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

    void Reset()
    {
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

    private void Update()
    {
        if (moveToParent)
        {
            Move();
        }
    }

    public void MoveKnife(Vector3 target, Vector3 eulerAngles)
    {
        position = target;
        angles = eulerAngles;
        moveToParent = true;
    }

    private void Move()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, position, Time.deltaTime * speed);
        transform.localEulerAngles = angles;

        if (transform.localPosition.Equals(position)) { moveToParent = false; }
    }

    public override void OnClick()
    {
        base.OnClick(); // Immer den BUms hier ausführen
        //Debug.Log("Knife Click");
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

        transform.SetParent(knifeContainer);

        moveToParent = true;


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
