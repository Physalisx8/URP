using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeContainer2 : InteractableObject
{
    // Start is called before the first frame update
    GameManager gameManager;

    [SerializeField]
    GameObject knife;

    GameObject knifeContainer;
    GameObject tongs;

    // [SerializeField] GameObject empties;
    private string oldParent = null;

    private Vector3 oldPosition;

    private Vector3 oldRotation;

    void Awake()
    {
        // transform.position = Vector3.down *100;
        gameManager = FindObjectOfType<GameManager>();
        knifeContainer = GameObject.Find("knifeContainer");
        tongs = GameObject.Find("tongs");
    }

    public override void SectionChange(SectionState state)
    {
        base.SectionChange(state);

        switch (state)
        {
            case SectionState.Start:
                if (debug) Debug.Log("START");
                Reset();
                break;
            case SectionState.End:
                OnClick();
                break;
        }
    }

    void Reset()
    {
        if (debug) Debug.Log("Reset");
        knife.transform.parent = knifeContainer.transform;
        knife.GetComponent<Knife>().MoveKnife(Vector3.zero, Vector3.zero);
        tongs.transform.position = Vector3.up*100;
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
                gameManager.IncreaseErrorCounter();
            }
            else
            {
                knife.transform.parent = transform;
                Vector3 rotation = knife.transform.localEulerAngles;
                knife
                    .GetComponent<Knife>()
                    .MoveKnife(new Vector3(0, -0.0175f, 0.1f),
                    new Vector3(80f, 0, 0));
                tongs.transform.position = Vector3.down*100;

                // empties.transform.position = new Vector3(1.6f,3.16f,7.45f);
                // transform.position = Vector3.down*100;
                //knife.transform.localPosition = new Vector3(0, -0.48f, 0);
                //Vector3 rotation = knife.transform.eulerAngles;
                //knife.transform.eulerAngles = new Vector3(90, rotation.y, rotation.z);
                gameManager.SetNextSection();
                //gameManager.SectionsFinished();
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
