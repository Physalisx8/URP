using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeContainer : InteractableObject
{
    // Start is called before the first frame update

    GameManager gameManager;
    [SerializeField] GameObject knife;
    private GameObject knifeContainer;

    private GameObject oldKnifeTransform = null;

      Vector3 startPos;
    Quaternion startRot;

        void Awake(){
        gameManager = FindObjectOfType<GameManager>();
        knifeContainer = GameObject.Find("knifeContainer");
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
                
                if (oldKnifeTransform != null)
                {
                    Debug.Log(oldKnifeTransform.transform.parent);


                    knife.transform.parent = oldKnifeTransform.transform.parent;
                    knife.transform.localPosition = oldKnifeTransform.transform.localPosition;
                    knife.transform.eulerAngles = oldKnifeTransform.transform.eulerAngles;
                    gameManager.SetNextSection();
                }
                else
                {
                    oldKnifeTransform = knife;
                    Debug.Log(knife.transform.parent);

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
