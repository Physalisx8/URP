using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeContainer : InteractableObject
{
    // Start is called before the first frame update

    GameManager gameManager;
    [SerializeField] GameObject knife;

    private string oldParent = null;
    private Vector3 oldPosition;
    private Vector3 oldRotation;
        

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
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
                    knife.transform.localPosition = oldPosition;
                    knife.transform.eulerAngles = oldRotation;
                    gameManager.SetNextSection();
                }
                else
                {
                    saveOldValues();

                    knife.transform.parent = transform;
                    knife.transform.localPosition = new Vector3(0, -0.48f, 0);
                    Vector3 rotation = knife.transform.eulerAngles;
                    knife.transform.eulerAngles = new Vector3(90, rotation.y, rotation.z);
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
        oldRotation = knife.transform.eulerAngles;
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
