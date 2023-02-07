using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Von InteractableObject erben lassen
public class Security : InteractableObject
{
    GameManager gameManager;
    GameObject leathergloves;
    GameObject leatherap;
    Animator animator;

    Vector3 startPos;
    Quaternion startRot;


    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        leatherap = GameObject.Find("Apron");
        animator = leatherap.GetComponent<Animator>();
        startPos = transform.position;
        startRot = transform.rotation;
    }

    public override void SectionChange(SectionState state)
    {
        base.SectionChange(state);

        switch (state)
        {
            case SectionState.Start:
                Debug.Log("Start SecurityApron");
                Reset();
                break;
            case SectionState.End:
                OnClick();
                break;
        }
    }

    void Reset()
    {
        animator.Play("flying_apron_back");
        transform.position = startPos;
        transform.rotation = startRot;
    }


    public override void OnClick()
    {
        base.OnClick(); // Immer den BUms hier ausführen
        if (gameManager != null)
        {
            if (!isInteractable)
            {
                Debug.Log("WHy are we here.");
                gameManager.IncreaseErrorCounter();
            }
            else
            {
                animator.Play("flying_apron");
                gameManager.SetNextSection();
            }
        }
        else
        {
            Debug.Log("gameManager = null");
        }

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
