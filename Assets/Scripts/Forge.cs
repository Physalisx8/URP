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
                if (count < 2 || count > 2)
                {
                    gameManager.SetNextSection();
                }

                if (count == 2)
                {
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
